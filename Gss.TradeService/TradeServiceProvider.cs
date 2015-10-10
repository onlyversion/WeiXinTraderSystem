using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using Gss.Common.Utility;
using Gss.Entities;
using Gss.Entities.AccountManager.Account;
using Gss.Entities.Enums;
using Gss.Entities.Interface;
using Gss.Entities.JTWEntityes;
using Gss.Entities.TradeManager;
using Gss.TradeService.TradeService;

namespace Gss.TradeService
{
    public class TradeServiceProvider : ITradeServiceProvider
    {
        #region 成员

        /// <summary>
        /// 静态超时分钟数
        /// </summary>
        private const int TimeoutMinute = 4;

        private DateTime _createTime;
        private ITrade _tradeClient;

        #endregion

        #region 属性

        /// <summary>
        /// 获取交易服务实例对象
        /// </summary>
        private ITrade TradeService
        {
            get
            {
                if (_tradeClient == null)
                {
                    _tradeClient = CreateTradeClient();
                }
                else
                {
                    //WCF服务有个5分钟连接超时问题，这里的判断尝试在4分钟时候重新创建一个WCF服务
                    if (TimeoutCheck())
                    {
                        //_tradeClient.Close( );
                        _tradeClient = CreateTradeClient();
                    }
                }

                return _tradeClient;
            }
        }

        #endregion

        #region 公有接口

        /// <summary>
        /// 获取有效定单历史记录列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="searchInfo">查询信息</param>
        /// <param name="pageCnt">返回的记录页数</param>
        /// <param name="historyList">返回的有效定单历史记录列表</param>
        /// <returns>ErrType</returns>
        public ErrType GetChargebackRecorder(string loginID, HistorySearchInfo searchInfo, ref int pageCnt, out List<MarketHistoryData> historyList)
        {
            historyList = null;
            try
            {
                LQueryCon lqCon = TradeConverter.ToLQuery(searchInfo, loginID);
                List<LTradeOrder> list = TradeService.GetLTradeOrder(lqCon, "1", searchInfo.PageIndex, searchInfo.PageSize, ref pageCnt);
                historyList = list.Select(TradeConverter.ToMarketHistoryData).OrderByDescending(a => a.TradeTime).ToList();
                return GeneralErr.Success;

            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetChargebackRecorder);
            }
        }

        /// <summary>
        /// 获取入库单历史记录列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="searchInfo">查询信息</param>
        /// <param name="pageCnt">返回的记录页数</param>
        /// <param name="historyList">返回的有效定单历史记录列表</param>
        /// <returns>ErrType</returns>
        public ErrType GetWarehousingRecorder(string loginID, HistorySearchInfo searchInfo, ref int pageCnt, out List<WarehousingHistoryData> historyList)
        {
            historyList = null;
            try
            {
                LQueryCon lqCon = TradeConverter.ToLQuery(searchInfo, loginID);
                List<LTradeOrder> list = TradeService.GetLTradeOrder(lqCon, "2", searchInfo.PageIndex, searchInfo.PageSize, ref pageCnt);
                historyList = list.Select(TradeConverter.ToWarehousingHistory).OrderByDescending(a => a.TradeTime).ToList();
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetWarehousingRecorder);
            }
        }

        /// <summary>
        /// 市价单定单
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="clientAccountName">要下单的客户账户名</param>
        /// <param name="userType">用户类型，0：交易用户，1：管理员，2：金商</param>
        /// <param name="newOrderInfo">下单的定单信息</param>
        /// <returns>ErrType</returns>
        public ErrType MarketOrder(string loginID, string clientAccountName, int userType, NewMarketOrderInfo newOrderInfo)
        {
            try
            {
                MarOrdersLn marOln = TradeConverter.ToMarOrdersLn(loginID, clientAccountName, userType, newOrderInfo);
                Marketorders result = TradeService.GetWXMarketorders(marOln);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                //这里还应进行账户资金方面的处理
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 获取市价单
        /// </summary>
        /// <param name="UserType">用户类型(0交易用户 1表示管理员 2表示金商)</param>
        /// <param name="tradeAccount">用户交易账号</param>
        /// <param name="LoginID">登录标示</param>
        /// <returns></returns>
        public List<MarketOrderData> GetMarketOrderList(string tradeAccount, string LoginID)
        {
            List<MarketOrderData> Result;
            var list = TradeService.GetTradeOrderEx(tradeAccount, LoginID);
            Result = list.Select(TradeConverter.ToMarketOrderData).ToList();
            return Result;
        }

        /// <summary>
        /// 挂单查询
        /// </summary>
        /// <param name="UserType"></param>
        /// <param name="tradeAccount"></param>
        /// <param name="LoginID"></param>
        /// <returns></returns>
        public List<PendingOrderData> GetTradeHoldOrder(string tradeAccount, string LoginID)
        {
            List<PendingOrderData> Result;
            var list = TradeService.GetTradeHoldOrderEx(tradeAccount, LoginID);
            Result = list.Select(TradeConverter.ToPendingOrderData).ToList();
            return Result;
        }

        /// <summary>
        /// 限价挂单定单
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="clientAccountName">要下单的客户账户名</param>
        /// <param name="userType">用户类型，0：交易用户，1：管理员，2：金商</param>
        /// <param name="newOrderInfo">下单的定单信息</param>
        /// <returns>ErrType</returns>
        public ErrType PendingOrder(string loginID, string clientAccountName, int userType, NewPendingOrderInfo newOrderInfo)
        {
            try
            {
                OrdersLncoming orderLn = TradeConverter.ToOrdersLncoming(loginID, clientAccountName, userType, newOrderInfo);
                Orders result = TradeService.GetOrders(orderLn);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                //这里还应进行账户资金方面的处理
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 有效定单平仓
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="userType">用户类型，0：交易用户，1：管理员，2：金商</param>
        /// <param name="orderInfo">平仓信息</param>
        /// <returns>ErrType</returns>
        public ErrType ChargebackOrder(string loginID, int userType, OrderChangedInformation orderInfo)
        {
            try
            {
                DeliveryEnter delEnter = TradeConverter.ToDeliveryEnter(loginID, userType, orderInfo);
                Marketorders result = TradeService.DelOrder(delEnter);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 有效定单入库
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="userType">用户类型，0：交易用户，1：管理员，2：金商</param>
        /// <param name="orderInfo">平仓信息</param>
        /// <returns>ErrType</returns>
        public ErrType WarehousingOrder(string loginID, int userType, OrderChangedInformation orderInfo)
        {
            try
            {
                DeliveryEnter delEnter = TradeConverter.ToDeliveryEnter(loginID, userType, orderInfo);
                //Todo:金能网待处理
                #region 金能网待处理
                //Marketorders result = TradeService.GetMarDelivery(delEnter);
                //if (!result.Result)
                //    return new ErrType(ERR.SERVICE, result.Desc); 
                #endregion

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); 
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 撤销限价挂单
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="userType">用户类型，0：交易用户，1：管理员，2：金商</param>
        /// <param name="orderData">要撤销的限价挂单</param>
        /// <returns>ErrType</returns>
        public ErrType RevocationPendingOrder(string loginID, int userType, PendingOrderData orderData)
        {
            try
            {
                DelHoldInfo delHoldInfo = TradeConverter.ToDelHoldInfo(loginID, userType, orderData);
                MarDelivery marDel = TradeService.DelHoldOrder(delHoldInfo);
                if (!marDel.Result)
                    return new ErrType(ERR.SERVICE, marDel.Desc);

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); 
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 获取交易配置信息
        /// </summary>
        /// <param name="loginId">登录标识</param>
        /// <param name="list">配置信息</param>
        /// <returns></returns>
        public ErrType GetTradeSetInfo(String loginId, ref ObservableCollection<TradeConfigInfo> list)
        {
            try
            {
                TradeSetInfo result = TradeService.GetTradeSetInfo(loginId);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);
                foreach (TradeSet set in result.TdSetList)
                {
                    list.Add(new TradeConfigInfo()
                                 {
                                     ObjName = set.ObjName,
                                     ObjCode = set.ObjCode,
                                     ObjValue = set.ObjValue,
                                     Remark = set.Remark
                                 });
                }
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetTradeSetInfo);
            }

        }

        /// <summary>
        /// 获取新闻公告信息
        /// </summary>
        /// <param name="LoginId">登录用户标识ID</param>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <param name="NType">新闻类型</param>
        /// <param name="pageindex">页索引</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="page">页总数</param>
        ///  <param name="list">新闻数据集</param>
        /// <returns></returns>
        public ErrType GetTradeNewsInfoWithPage(
            string loginId, DateTime starttime, DateTime endtime, NewsTypeEnum nType,
            int pageindex, int pagesize, ref int page, ref ObservableCollection<NewsInfo> list)
        {
            try
            {
                NewsLqc lqc = new NewsLqc();
                lqc.EndTime = endtime;
                lqc.LoginID = loginId;
                lqc.NType = (NewsType)nType;
                lqc.StartTime = starttime;
                TradeNewsInfo result = TradeService.GetTradeNewsInfoWithPage(lqc, pageindex, pagesize, ref page);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                foreach (TradeNews news in result.TradeNewsInfoList)
                {
                    list.Add(TradeConverter.ToNewsInfo(news));
                }
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetTradeNewsInfo);
            }
        }

        public ErrType GetHistoryDataInfoWithPage(
            string loginId,string weekTime, DateTime starttime, DateTime endtime, string productNum, string cycle,
            int pageindex, int pagesize, ref int page, ref ObservableCollection<Gss.Entities.JTWEntityes.HisData> list)
        {
            HisQueryCon hqc = new HisQueryCon();
            hqc.EndTime = endtime;
            hqc.StartTime = starttime;
            hqc.weekflg = cycle;
            hqc.pricecode = productNum;

            hqc.weektime = weekTime;
            List<Gss.TradeService.TradeService.HisData> result;
            try
            {
                result = TradeService.GetHisDataWithPage(hqc, pageindex, pagesize, ref page);
                foreach (var item in result)
                {
                    list.Add(TradeConverter.ToHisDataInfo(item));
                }
                return GeneralErr.Success;
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetHistoryData);
            }
        }
        #endregion
        public ErrType ModifyHisData(Gss.Entities.JTWEntityes.HisData hisdata, string pricecode, string weekflg)
        {
            try
            {
                var result = TradeService.ModifyHisData(TradeConverter.ToServiceHisDataInfo(hisdata), pricecode, weekflg);
                if (!result.Result)
                {
                    return new ErrType(ERR.ERROR, "修改历史数据失败");
                }
                return GeneralErr.Success;
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }

        }
        #region 辅助方法

        /// <summary>
        /// 创建一个交易服务实例，并记录当前创建时间
        /// </summary>
        /// <returns>交易服务实例</returns>
        private ITrade CreateTradeClient()
        {
            _createTime = DateTime.Now;

            WSHttpBinding binding = new WSHttpBinding(SecurityMode.None);
            binding.MaxReceivedMessageSize = 6553600;
            EndpointAddress address = new EndpointAddress(ConnectConfigData.TradeServiceAddress);
            ChannelFactory<ITrade> ttgService = new ChannelFactory<ITrade>(binding, address);
            return ttgService.CreateChannel();
            // return new TradeClient( );
        }

        /// <summary>
        /// 进行服务引用实例是否可能超时的判断，返回true，则表示可能超时
        /// </summary>
        /// <returns>是否超时</returns>
        private bool TimeoutCheck()
        {
            return _createTime.AddMinutes(TimeoutMinute) < DateTime.Now;
        }
        #endregion

        /// <summary>
        /// Modify login password.
        /// </summary>
        /// <param name="loginID">login ID</param>
        /// <param name="oldPwd">old password</param>
        /// <param name="newPwd">new password</param>
        /// <returns>ErrType</returns>
        public ErrType ModifyLoginPassword(string loginID, string oldPwd, string newPwd)
        {
            try
            {
                int pwdType = 0;//密码类型，0表示登陆密码，1表示资金密码
                ResultDesc result = TradeService.ModifyUserPassword(loginID, pwdType, oldPwd, newPwd);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.ERROR, result.Desc);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// Modify funds password.
        /// </summary>
        /// <param name="loginID">login ID</param>
        /// <param name="oldPwd">old password</param>
        /// <param name="newPwd">new password</param>
        /// <returns>ErrType</returns>
        public ErrType ModifyFundsPassword(string loginID, string oldPwd, string newPwd)
        {
            try
            {
                int pwdType = 1;//密码类型，0表示登陆密码，1表示资金密码
                ResultDesc result = TradeService.ModifyUserPassword(loginID, pwdType, oldPwd, newPwd);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.ERROR, result.Desc);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetHistoryData);
            }
        }

        /// <summary>
        /// 获取用户资金信息
        /// </summary>
        /// <param name="accountName">用户账号</param>
        /// <param name="loginId">登录ID</param>
        /// <param name="fund">ref  FundInformation</param>
        /// <returns>ErrType</returns>
        public ErrType GetMoneyInventoryEx(string accountName, string loginId, ref  FundInformation fund)
        {
            try
            {
                MoneyInventory moneyInfo = TradeService.GetMoneyInventoryEx(accountName, loginId);
                fund = TradeConverter.ToFundInformation(moneyInfo);
                return moneyInfo.Result ? GeneralErr.Success : new ErrType(ERR.ERROR, moneyInfo.Desc);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetClientFundsInfo);
            }
        }
        /// <summary>
        /// 获取微会员微信二维码地址
        /// </summary>
        /// <param name="loginId">登录ID</param>
        /// <param name="orgID">微会员ID</param>
        /// <param name="url">输出Url</param>
        /// <returns>ErrType</returns>
        public ErrType GetOrgTicketUrl(string loginId, string orgID,ref string url)
        {
            try
            {
                OrgTicketUrlInfo info = TradeService.GetOrgTicketUrl(loginId, orgID);
                url = info.Url;
                return info.Result ? GeneralErr.Success : new ErrType(ERR.ERROR, info.Desc);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.ERROR, "加载异常!");
            }
        }

        /// <summary>
        /// 设置会员佣金比例
        /// </summary>
        /// <param name="loginId">登录标识</param>
        /// <param name="ratio1">一级佣金比例</param>
        /// <param name="ratio2">二级佣金比例</param>
        /// <param name="ratio3">三级佣金比例</param>
        /// <param name="orgIDList">待设置的会员列表</param>
        /// <returns>ResultDesc</returns>

       public  ErrType SetCommissionRatio(string loginId, double ratio1, double ratio2, double ratio3,
            List<string> orgIDList)
        {
            try
            {
                ResultDesc result = TradeService.SetCommissionRatio( loginId,  ratio1,  ratio2,  ratio3,orgIDList);
                return result.Result == true ? GeneralErr.Success : new ErrType(ERR.ERROR, result.Desc);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetHistoryData);
            }
        }

       /// <summary>
       /// 获取会员返佣比例
       /// </summary>
       /// <param name="loginId">登录ID</param>
       /// <param name="orgID">微会员ID</param>
       /// <param name="url">输出Url</param>
       /// <returns>ErrType</returns>
       public ErrType GetCommissionRatio(string loginId, string orgID,ref CommissionRatioSet ratio,bool type)
       {
           try
           {
               CommissionRatioSetInfo info = TradeService.GetCommissionRatio(loginId, orgID,type);
               ratio.ID = info.ID;
               ratio.OrgID = info.OrgID;
               ratio.Ratio1 = info.Ratio1;
               ratio.Ratio2 = info.Ratio2;
               ratio.Ratio3 = info.Ratio3;
               return info.Result ? GeneralErr.Success : new ErrType(ERR.ERROR, info.Desc);
           }
           catch (Exception ex)
           {
               FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
               return new ErrType(ERR.ERROR, "加载异常!");
           }
       }
    }
}
