using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Gss.BzjService.BZJServiceReference;
using Gss.BzjService.JgjServiceReference;
using Gss.Entities;
using Gss.Entities.BzjEntities;
using Gss.Entities.Interface;
using System.Net;
using Gss.Common.Utility;

namespace Gss.BzjService
{
    public class BzjServiceProvider : IBzjService
    {
        #region Data
        /// <summary>
        /// ITrade instantiation 
        /// WCF服务
        /// </summary>
        private readonly IManagerBzj _IManagerBzj;

        private JgjServiceSoapChannel _JgjServiceSoapClient;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public BzjServiceProvider()
        {
            WSHttpBinding binding = new WSHttpBinding(SecurityMode.None);
            binding.MaxReceivedMessageSize = 6553600;
            EndpointAddress address = new EndpointAddress(ConnectConfigData.BzjServiceAddress);
            ChannelFactory<IManagerBzj> ttgService = new ChannelFactory<IManagerBzj>(binding, address);
            _IManagerBzj = ttgService.CreateChannel();
           // _JgjServiceSoapClient = new JgjServiceSoapClient();

            //BasicHttpBinding jgjBinding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            //jgjBinding.MaxReceivedMessageSize = 6553600;
            //EndpointAddress jgjAddress = new EndpointAddress(ConnectConfigData.JgjWebService);
            //ChannelFactory<JgjServiceSoapChannel> jgjService = new ChannelFactory<JgjServiceSoapChannel>(jgjBinding, jgjAddress);
            //_JgjServiceSoapClient = jgjService.CreateChannel();
        }
        #endregion

        #region 用户库存信息查询
        /// <summary>
        /// 用户库存信息查询
        /// </summary>
        /// <param name="userId"></param>
        public ErrType GetAdminUserStockInfo(string loginID, string userId, ref BzjInfoInformation bzjInfo, int roleType)
        {
            try
            {
                StockEntity info = _IManagerBzj.GetAdminUserStockInfo(loginID, userId,roleType);
                bzjInfo = MyConverter.ToBzjInfo(info);
                return info.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, info.Desc);

            }
            catch (Exception ex)
            {
                Console.WriteLine("用户库存信息查询:" + ex.Message + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region 实物入库\增加库存
        /// <summary>
        /// 实物入库\增加库存
        /// </summary>
        /// <param name="userID">客户用户ID</param>
        /// <param name="loginAccountName">登录用户名</param>
        /// <param name="accountName">被操作用户名</param>
        /// <param name="orderType">定单类型 1入库 2 买跌</param>
        /// <param name="Product">入库商品类别XAU黄金 XAG白银 XPT铂金 XPD巴金</param>
        /// <param name="loginID">登录标识ID</param>
        /// <param name="deliverNo">定单编码</param>
        /// <param name="total">数量</param>
        /// <param name="price">价格</param>
        /// <param name="direction">交割单表方向: 9 实物入库 13 库存调整</param>
        /// <returns></returns>
        public ErrType CreateDeliverAdmin(string userID, string loginAccountName, string userName, string orderType,
            string Product, string loginID, string deliverNo, decimal total, double price, int direction, int roleType)
        {
            try
            {
                DeliverEntity entity = new DeliverEntity();
                entity.UserID = userID;
                entity.DeliverNo = deliverNo;
                entity.OperationUserID = loginAccountName;
                entity.Total = total;
                entity.LockPrice = (decimal)price;
                entity.Account = userName;
                entity.Direction = direction;
                ResultDesc result = _IManagerBzj.CreateDeliverAdmin(entity, orderType, Product, loginID, roleType);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);

            }
            catch (Exception ex)
            {
                Console.WriteLine(@"实物入库\增加库存:" + ex.Message + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region 减少库存数量
        /// <summary>
        /// 减少库存数量
        /// </summary>
        /// <param name="operationID">操作员的ID或用户名</param>
        /// <param name="loginID">登录ID</param>
        /// <param name="userID">用户id</param>
        /// <param name="accountName">用户名</param>
        /// <param name="au">黄金数量</param>
        /// <param name="ag">白银数量</param>
        /// <param name="pt">铂金数量</param>
        /// <param name="pd">钯金数量</param>
        /// <returns></returns>
        public ErrType CreateStockDeliverAdmin(string operationID, string loginID,
            string userID, string accountName, double au, double ag, double pt, double pd, int roleType)
        {
            try
            {
                OrderEntity orderEnity = new OrderEntity();
                orderEnity.UserId = userID;
                orderEnity.Account = accountName;
                orderEnity.Au = (decimal)au;
                orderEnity.Ag = (decimal)ag;
                orderEnity.Pt = (decimal)pt;
                orderEnity.Pd = (decimal)pd;
                ResultDesc result = _IManagerBzj.CreateStockDeliverAdmin(operationID, orderEnity, loginID, roleType);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"减少库存数量:" + ex.Message + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region 金生金用户绑定
        /// <summary>
        /// 金生金用户绑定
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ErrType CreateAdminGssUser(BzjUserBindEntity bzjentity, string loginID, string userID, int roleType)
        {
            try
            {
                UserBindEntity entity = MyConverter.ToUserBindEntity(bzjentity);
                ResultDesc result = _IManagerBzj.CreateAdminGssUser(entity, loginID, roleType);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region 金生金账户是否已存在
        /// <summary>
        ///金生金账户是否已存在
        /// </summary>
        /// <param name="certificate">用户证件类型：身份证1，机构代码2，营业执照3 </param>
        /// <param name="cardNum">用户证件号</param>
        /// <returns> 0表示不存在  1表示存在</returns>
        public int JgjIsUserExist(int certificate, string cardNum)
        {
            IsUserExistRequest request = new IsUserExistRequest();
            request.Body = new IsUserExistRequestBody();
            request.Body.accountLoginId = cardNum;
            request.Body.certificate = certificate;
            IsUserExistResponse res = _JgjServiceSoapClient.IsUserExist(request);
            return res.Body.IsUserExistResult;
            //return _JgjServiceSoapClient.IsUserExist(certificate, cardNum);
        }
        #endregion

        #region 注册金生金账户
        /// <summary>
        /// 注册金生金账户
        /// </summary>
        /// <param name="certificate">用户证件类型：身份证1，机构代码2，营业执照3 </param>
        /// <param name="accountLoginId">用户证件号</param>
        /// <param name="pwd">没加密的密码</param>
        ///  <param name="agency">代理商名称</param>
        /// <param name="category">用户类型</param>
        /// <param name="username">真实姓名</param>
        /// <param name="tel">手机</param>
        /// <returns>1000表示用户已经存在，2000表示系统错误，guid表示注册成功，返回用户主键</returns>
        public string JgjUserRegister(int certificate, string accountLoginId, string pwd, string agency, int category, string userName, string tel)
        {
            UserRegisterRequest request = new UserRegisterRequest();
            request.Body = new UserRegisterRequestBody();
            request.Body.accountLoginId = accountLoginId;
            request.Body.certificate = certificate;
            request.Body.pwd = pwd;
            request.Body.agency = agency;
            request.Body.category = category;
            request.Body.username = userName;
            request.Body.tel = tel;
            UserRegisterResponse res = _JgjServiceSoapClient.UserRegister(request);
            return res.Body.UserRegisterResult;
           // return _JgjServiceSoapClient.UserRegister(certificate, accountLoginId, pwd, agency, category, userName, tel);
        }
        #endregion

        #region 	定单明细

        /// <summary>
        /// 定单明细
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="orderCode"></param>
        /// <param name="bzjInfo"></param>
        /// <returns></returns>
        public ErrType GetOrderNOInfo(string loginID, string orderCode, ref BzjOrderEntity bzjInfo, int roleType)
        {
            try
            {
                OrderEntity info = _IManagerBzj.GetOrderNOInfo(loginID, orderCode, roleType);
                bzjInfo = MyConverter.ToBzjOrderEntity(info);
                return info.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, info.Desc);

            }
            catch (Exception ex)
            {
                Console.WriteLine("用户库存信息查询:" + ex.Message + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region 金商管理客户提货
        /// <summary>
        /// 金商管理客户提货
        /// </summary>
        /// <param name="loginAccount">登录用户账户名/param>
        /// <param name="loginID">登录标识ID</param>
        /// <param name="agentInfoID">金商账户名</param>
        /// <param name="orderNo">定单编码</param>
        /// <param name="orderCode">提货买跌验证号</param>
        /// <param name="accountName">用户名</param>
        /// <param name="agentName">金商帐户</param>
        /// <param name="userID"></param>
        /// <param name="au">黄金</param>
        /// <param name="ag">白银</param>
        /// <returns></returns>
        public ErrType UpdateOrder(string loginAccount,string loginID, string agentInfoID,
            string orderNo, string orderCode, string accountName, string agentName, string userID, decimal au, decimal ag,decimal pt,decimal pd, int roleType)
        {
            try
            {
                OrderEntity orderEntity = new OrderEntity();

                orderEntity.OrderNo = orderNo;	// 	定单编码
                orderEntity.OrderType = 1;	//	定单类别：提货单= 1,        
                orderEntity.CarryWay = 1;	//	提货单方向：提货单 = 1
                orderEntity.OrderCode = orderCode;	//string	提货买跌验证号
                orderEntity.Account = accountName;	//	用户
                orderEntity.AgentName = agentName;	//	金商帐户
                orderEntity.UserId = userID;
                orderEntity.Au = au;//黄金
                orderEntity.Ag = ag;//白银
                orderEntity.Pt = pt;
                orderEntity.Pd = pd;

                OrderOperationEntity opEntyit = new OrderOperationEntity();
                opEntyit.OperationId = loginAccount;
                opEntyit.Type = 1;
                ResultDesc result = _IManagerBzj.UpdateOrder(loginID, orderEntity, opEntyit, agentInfoID, CommonHelper.GetNetwork(), roleType);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }

        #endregion

        #region 金商提货受理明细
        /// <summary>
        /// 金商提货受理明细
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="agentInfoID"></param>
        /// <param name="orderNo">定单编码</param>
        /// <param name="orderCode">提货买跌验证号</param>
        /// <param name="accountName">用户名</param>
        /// <param name="createDate">提货开始时间</param>
        /// <param name="endDate">提货结束时间</param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ErrType GetAgentOrderList(string agentInfoID, string loginID, string account,
            string orderNo, string orderCode, string userName, string createDate, 
            string endDate, int pageindex, int pagesize, ref int page,
            ref ObservableCollection<BzjTakeGoodsDetailEntity> list, int roleType)
        {
            try
            {
                OrderEntity orderEntity = new OrderEntity();
                orderEntity.OrderNo = orderNo;	// 	定单编码
                orderEntity.OrderCode = orderCode;	//	提货买跌验证号
                orderEntity.Account = account;	//	用户
                orderEntity.CreateDate = createDate;//提货开始时间
                orderEntity.EndDate = endDate;//提货结束时间
                orderEntity.Name = userName;
                //Name	String	姓名	


                OrderOperationEntity opEntyit = new OrderOperationEntity();
                opEntyit.Type = 1;
                EntityBase result = _IManagerBzj.GetAgentOrderList(agentInfoID, orderEntity, loginID, pageindex, pagesize, ref  page, roleType);
                if (result.Result)
                    list = MyConverter.ToBzjTakeGoodsDetailEntity(result.DataSource);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region 金商绑定账户
        /// <summary>
        /// 金商绑定账户
        /// </summary>
        /// <param name="account">绑定账户名</param>
        /// <param name="agentid">金商ID，当前登录金商</param>
        /// <param name="cardNum">证件号</param>
        /// <param name="loginID">登录ID</param>
        /// <returns></returns>
        public ErrType AgentBind(string account, string agentid, string cardNum, string loginID, int roleType)
        {
            try
            {
                ResultDesc result = _IManagerBzj.AgentBind(account, agentid, cardNum, loginID, roleType);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }
        #endregion


        #region 金商交割单(买涨)查询
        /// <summary>
        /// 金商交割单查询
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="bzjEntity">查询实体</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="page">总页面</param>
        /// <param name="bzjDeliverList">返回数据集</param>
        /// <returns></returns>
        public ErrType GetDeliverOrderList(string loginID, BzjDeliverEntity bzjEntity, string userName,
            int pageindex, int pagesize, ref int page, ref ObservableCollection<BzjDeliverEntity> bzjDeliverList, int roleType)
        {
            try
            {
                bzjDeliverList.Clear();
                DeliverEntity entity = new DeliverEntity();
                entity.Account = bzjEntity.Account;//客户账号
                entity.DeliverNo = bzjEntity.DeliverNo;//单号
                entity.CreateDate = bzjEntity.CreateDate;//提货开始时间
                entity.EndDate = bzjEntity.EndDate;//提货结束时间

                List<DeliverEntity> list = new List<DeliverEntity>();
                EntityBase result = _IManagerBzj.GetDeliverOrderList(loginID, entity, userName, pageindex, pagesize, ref page, ref list, roleType);

                if (result.Result)
                {
                    list = list.OrderByDescending(p => p.CreateDate).ToList();
                    foreach (DeliverEntity item in list)
                    {
                        BzjDeliverEntity newBzjDeliverEntity = new BzjDeliverEntity();
                        newBzjDeliverEntity.UserName = item.UserName;//		姓名
                        newBzjDeliverEntity.Account = item.Account;	//	客户账号
                        newBzjDeliverEntity.DeliverNo = item.DeliverNo;// 	交割单号
                        newBzjDeliverEntity.DeliverDate = item.DeliverDate;	//	日期
                        //方向 提货单 = 1,买跌单 = 2,金生金 = 3,到期单 = 5,已生金单 = 6,提成单 = 7,金店库存同步 = 8,实物受理=9,金商转库=10,公司提成=11,大区提成=12,库存调整=13
                        newBzjDeliverEntity.Direction = item.Direction;
                       
                        newBzjDeliverEntity.Total = item.Total;	//交割单总数量
                        newBzjDeliverEntity.AvailableTotal = item.AvailableTotal;//	可用数量
                        newBzjDeliverEntity.Goods = item.Goods;//商品类型
                        newBzjDeliverEntity.LockPrice = item.LockPrice;//交割价
                        newBzjDeliverEntity.CreateDate = item.CreateDate;//	交割时间
                        newBzjDeliverEntity.State = item.State;//禁用 = 0,正常 = 1 
                        bzjDeliverList.Add(newBzjDeliverEntity);
                    }
                }
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }
        #endregion


        #region 提货单查询
        /// <summary>
        /// 提货单查询
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="bzjEntity">查询实体</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="page">总页面</param>
        /// <param name="bzjDeliverList">返回数据集</param>
        /// <returns></returns>
        public ErrType GetOrderTakeList(string loginID, BzjOrderEntity bzjEntity, int pageindex,
            int pagesize, ref int page, ref ObservableCollection<BzjOrderEntity> retrnList, int roleType)
        {
            try
            {
                retrnList.Clear();
                OrderEntity entity = new OrderEntity();
                entity.Account = bzjEntity.Account;//客户账号
                entity.OrderNo = bzjEntity.OrderNO;//单号
                entity.Name = bzjEntity.Name;//姓名
                entity.OrderCode = bzjEntity.OrderCode;//验证码
                entity.CreateDate = bzjEntity.CreateDate;//提货开始时间
                entity.EndDate = bzjEntity.EndDate;//提货结束时间

                List<OrderEntity> list = new List<OrderEntity>();
                EntityBase result = _IManagerBzj.GetOrderTakeList(loginID, entity, pageindex, pagesize, ref page, ref list, roleType);
                if (result.Result)
                {
                    list = list.OrderByDescending(p => p.CreateDate).ToList();
                    foreach (OrderEntity item in list)
                    {
                        BzjOrderEntity newBzjOrderEntity = new BzjOrderEntity();
                        newBzjOrderEntity.Name = item.Name;
                        newBzjOrderEntity.Account = item.Account;
                        newBzjOrderEntity.OrderNO = item.OrderNo;
                        newBzjOrderEntity.OrderCode = item.OrderCode;
                        newBzjOrderEntity.CarryWay = item.CarryWay;
                        newBzjOrderEntity.Au = item.Au;
                        newBzjOrderEntity.Ag = item.Ag;
                        newBzjOrderEntity.Pt = item.Pt;
                        newBzjOrderEntity.Pd = item.Pd;
                        newBzjOrderEntity.AgQuantity = item.AgQuantity;
                        newBzjOrderEntity.AuQuantity = item.AuQuantity;
                        newBzjOrderEntity.PtQuantity = item.PtQuantity;
                        newBzjOrderEntity.PdQuantity = item.PdQuantity;
                        newBzjOrderEntity.AuP = item.AuP;
                        newBzjOrderEntity.AgP = item.AgP;
                        newBzjOrderEntity.PtP = item.PtP;
                        newBzjOrderEntity.PdP = item.PdP;
                        newBzjOrderEntity.CreateDate = item.CreateDate;
                        newBzjOrderEntity.OperationDate = item.OperationDate;
                        newBzjOrderEntity.State = item.State;
                        newBzjOrderEntity.OrderType = item.OrderType;
                        newBzjOrderEntity.ClerkId = item.ClerkID;
                        newBzjOrderEntity.AgentId = item.AgentID;
                        newBzjOrderEntity.TradeAccount = item.tradeAccount;
                        retrnList.Add(newBzjOrderEntity);
                    }
                }
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region 买跌单查询
        /// <summary>
        /// 买跌单查询
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="bzjEntity">查询实体</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="page">总页面</param>
        /// <param name="bzjDeliverList">返回数据集</param>
        /// <returns></returns>
        public ErrType GetOrderBackList(string loginID, BzjOrderEntity bzjEntity,
            int pageindex, int pagesize, ref int page, ref ObservableCollection<BzjOrderEntity> retrnList, int roleType)
        {
            try
            {
                retrnList.Clear();
                OrderEntity entity = new OrderEntity();
                entity.Account = bzjEntity.Account;//客户账号
                entity.OrderNo = bzjEntity.OrderNO;//单号
                entity.Name = bzjEntity.Name;//姓名
                entity.OrderCode = bzjEntity.OrderCode;//验证码
                entity.CreateDate = bzjEntity.CreateDate;//提货开始时间
                entity.EndDate = bzjEntity.EndDate;//提货结束时间

                List<OrderEntity> list = new List<OrderEntity>();
                EntityBase result = _IManagerBzj.GetOrderBackList(loginID, entity, pageindex, pagesize, ref page, ref list, roleType);
                if (result.Result)
                {
                    list = list.OrderByDescending(p => p.CreateDate).ToList();
                    foreach (OrderEntity item in list)
                    {
                    //          <!--客户账号	姓名	单号	黄金买跌重量	黄金买跌单价	黄金成本单价	白银买跌重量	
                    //白银买跌单价	白银成本单价	铂金买跌重量	铂金买跌单价	铂金成本单价	钯金买跌重量
                    //钯金买跌单价	钯金成本单价	总买跌款	买跌时间	付款时间	操作员	状态-->
                        BzjOrderEntity newBzjOrderEntity = new BzjOrderEntity();
                        newBzjOrderEntity.Name = item.Name;
                        newBzjOrderEntity.Account = item.Account;
                        newBzjOrderEntity.OrderNO = item.OrderNo;
                        //newBzjOrderEntity.OrderCode = item.OrderCode;
                        //newBzjOrderEntity.CarryWay = item.CarryWay;
                        newBzjOrderEntity.Au = item.Au;//重量 
                        newBzjOrderEntity.Ag = item.Ag;
                        newBzjOrderEntity.Pt = item.Pt;
                        newBzjOrderEntity.Pd = item.Pd;
                        //newBzjOrderEntity.AgQuantity = item.AgQuantity;
                        //newBzjOrderEntity.AuQuantity = item.AuQuantity;
                        //newBzjOrderEntity.PtQuantity = item.PtQuantity;
                        //newBzjOrderEntity.PdQuantity = item.PdQuantity;
                        newBzjOrderEntity.AuP = item.AuP;//平均价/买跌价
                        newBzjOrderEntity.AgP = item.AgP;
                        newBzjOrderEntity.PtP = item.PtP;
                        newBzjOrderEntity.PdP = item.PdP;

                        newBzjOrderEntity.TotalBackPrice = item.Au*item.AuP + item.Ag*item.AgP + item.Pt*item.PtP +
                                                           item.Pd * item.PdP;

                        newBzjOrderEntity.AuCost = item.AuCost;//成本价
                        newBzjOrderEntity.AgCost = item.AgCost;
                        newBzjOrderEntity.PtCost = item.PtCost;
                        newBzjOrderEntity.PdCost = item.PtCost;

                        newBzjOrderEntity.CreateDate = item.CreateDate;//买跌时间
                        newBzjOrderEntity.OperationDate = item.OperationDate;//付款时间
                        newBzjOrderEntity.ClerkId = item.ClerkID;         //操作员
                        //newBzjOrderEntity.OrderType = item.OrderType;
                        newBzjOrderEntity.State = item.State;
                        retrnList.Add(newBzjOrderEntity);
                    }
                }
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region 金生金单查询
        /// <summary>
        /// 金生金单查询
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="bzjEntity">查询实体</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="page">总页面</param>
        /// <param name="bzjDeliverList">返回数据集</param>
        /// <returns></returns>
        public ErrType GetOrderJsjList(string loginID, BzjOrderEntity bzjEntity, int pageindex,
            int pagesize, ref int page, ref ObservableCollection<BzjOrderEntity> retrnList, int roleType)
        {
            try
            {
                retrnList.Clear();
                OrderEntity entity = new OrderEntity();
                entity.Account = bzjEntity.Account;//客户账号
                entity.OrderNo = bzjEntity.OrderNO;//单号
                entity.Name = bzjEntity.Name;//姓名
                entity.OrderCode = bzjEntity.OrderCode;//验证码
                entity.CreateDate = bzjEntity.CreateDate;//提货开始时间
                entity.EndDate = bzjEntity.EndDate;//提货结束时间

                List<OrderEntity> list = new List<OrderEntity>();
                EntityBase result = _IManagerBzj.GetOrderJsjList(loginID, entity, pageindex, pagesize, ref page, ref list, roleType);
                if (result.Result)
                {
                    list = list.OrderByDescending(p=>p.CreateDate).ToList();
                    foreach (OrderEntity item in list)
                    {
                        BzjOrderEntity newBzjOrderEntity = new BzjOrderEntity();
                        newBzjOrderEntity.Name = item.Name;
                        newBzjOrderEntity.Account = item.Account;
                        newBzjOrderEntity.OrderNO = item.OrderNo;
                        //newBzjOrderEntity.OrderCode = item.OrderCode;
                        ////newBzjOrderEntity.CarryWay = item.CarryWay;
                        newBzjOrderEntity.Au = item.Au;
                        newBzjOrderEntity.Ag = item.Ag;
                        newBzjOrderEntity.Pt = item.Pt;
                        newBzjOrderEntity.Pd = item.Pd;
                        ////newBzjOrderEntity.AgQuantity = item.AgQuantity;
                        ////newBzjOrderEntity.AuQuantity = item.AuQuantity;
                        ////newBzjOrderEntity.PtQuantity = item.PtQuantity;
                        ////newBzjOrderEntity.PdQuantity = item.PdQuantity;
                        newBzjOrderEntity.AuP = item.AuP;
                        newBzjOrderEntity.AgP = item.AgP;
                        newBzjOrderEntity.PtP = item.PtP;
                        newBzjOrderEntity.PdP = item.PdP;
                        newBzjOrderEntity.CreateDate = item.CreateDate;
                        //newBzjOrderEntity.OperationDate = item.OperationDate;
                        newBzjOrderEntity.State = item.State;
                        //newBzjOrderEntity.OrderType = item.OrderType;

                        retrnList.Add(newBzjOrderEntity);
                    }
                }
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }
        #endregion

        #region 金商买跌单更新
        /// <summary>
        ///	金商买跌单更新
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="OrderNO">定单编号</param>
        /// <param name="agentName">金商账号</param>
        /// <returns></returns>
        public ErrType UpdateBuyBackOrder(string loginID, string OrderNO, string agentName, int roleType)
        {
            try
            {
                EntityBase result = _IManagerBzj.UpdateBuyBackOrder(loginID, OrderNO, agentName,roleType);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }
        #endregion

       
    }
}
