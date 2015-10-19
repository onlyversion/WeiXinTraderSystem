using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using Gss.BusinessService.ManagementService;
using Gss.BusinessService.OrgTicketService;
using Gss.Common.Utility;
using Gss.Entities;
using Gss.Entities.BzjEntities;
using Gss.Entities.DataManager;
using Gss.Entities.Enums;
using Gss.Entities.Interface;
using Gss.Entities.JTWEntityes;
using Gss.Entities.SystemSetting;
using Gss.Entities.TradeManager;
using Gss.Entities.AccountManager;

namespace Gss.BusinessService
{
    public class BusinessServiceProvider : IBusinessServiceProvider
    {
        #region 成员
        /// <summary>
        /// 静态超时分钟数
        /// </summary>
        private const int TimeoutMinute = 4;

        /// <summary>
        /// WCF服务接口的创建时间
        /// </summary>
        private DateTime _createTime;
        /// <summary>
        /// 后台管理的WCF服务接口
        /// </summary>
        private IManager _managerService;

        /// <summary>
        /// 资金操作类型枚举
        /// </summary>
        private enum FUND_OPERATE_TYPE
        {
            /// <summary>
            /// 库存结算
            /// </summary>
            CashIO = 3,
            /// <summary>
            /// 调整资金
            /// </summary>
            AdjustMoney = 6,
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取后台服务实例对象
        /// </summary>
        public IManager ManagerService
        {
            get
            {
                if (_managerService == null)
                {
                    _managerService = CreateManagerClient();
                }
                else
                {
                    //WCF服务有个5分钟连接超时问题，这里的判断尝试在4分钟时候重新创建一个WCF服务
                    if (TimeoutCheck())
                    {
                        //_managerService.Close();
                        _managerService = CreateManagerClient();
                    }
                }

                return _managerService;
            }
        }


        private OrgTicketChannel _orgTicketService;
        /// <summary>
        /// 微会员创建二维码服务
        /// </summary>
        public OrgTicketChannel OrgTicketService
        {
            get
            {
                if (_orgTicketService == null)
                {
                    _orgTicketService = CreateOrgTicketService();
                }
                else
                {
                    //WCF服务有个5分钟连接超时问题，这里的判断尝试在4分钟时候重新创建一个WCF服务
                    if (OrgTimeoutCheck())
                    {
                        //_managerService.Close();
                        _orgTicketService = CreateOrgTicketService();
                    }
                }
                return _orgTicketService;
            }
        }

        private OrgTicketChannel _trade;
        /// <summary>
        /// 创建一个后台服务实例对象，并记录创建时间
        /// </summary>
        /// <returns>后台服务实例</returns>
        private OrgTicketChannel CreateOrgTicketService()
        {
            _createOrgTime = DateTime.Now;
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            binding.MaxReceivedMessageSize = 6553600;
            binding.MaxBufferSize = 6553600;
            //string path = "http://120.26.57.141:80/JiuXingWeiXin/services/createTicket?wsdl";
            string path = ConnectConfigData.OrgTicketService;
            EndpointAddress address = new EndpointAddress(path);
            ChannelFactory<OrgTicketChannel> service = new ChannelFactory<OrgTicketChannel>(binding, address);
            _trade = service.CreateChannel();
            return _trade;
        }

        private DateTime _createOrgTime = DateTime.Now;
        /// <summary>
        /// 进行服务引用实例是否可能超时的判断，返回true，则表示可能超时
        /// </summary>
        /// <returns>是否超时</returns>
        private bool OrgTimeoutCheck()
        {
            return _createOrgTime.AddMinutes(TimeoutMinute) < DateTime.Now;
        }
        #endregion

        #region 登陆
        public LoginResult Login(string accountName, string password)
        {
            string mac = MacAddress.LocalMAC;
            ReAdminAuth auth = ManagerService.AdminLogin(accountName, password, mac);
            if (auth.LoginID == "-1")
                return new LoginResult("登陆失败，账号或密码失败");
            else
            {
                return new LoginResult(auth.LoginID, auth.QuotesAddressIP, auth.QuotesPort, auth.UserID);
            }
        }

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="accountName">账户名</param>
        /// <param name="password">密码</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <returns>登陆结果</returns>
        public LoginResult Login(string accountName, string password, ACCOUNT_TYPE accType)
        {
            try
            {
                //Todo:金通网待处理
                return null;
                #region MyRegion
                //string mac = MacAddress.LocalMAC;
                //if (accType == ACCOUNT_TYPE.Manager)//管理员
                //{
                //    ReAdminAuth mgrResult = ManagerService.AdminLogin(accountName, password, mac);

                //    return MyConverter.ToLoginResult(mgrResult);
                //}
                //else if (accType == ACCOUNT_TYPE.Dealer)//金商
                //{
                //    ReAgentAuth dealerResult = ManagerService.AgentLogin(accountName, password, mac);
                //    return MyConverter.ToLoginResult(dealerResult);
                //}
                //else//金商店员
                //{
                //    ReClerkAuth dealerClerkResult = ManagerService.ClerkLogin(accountName, password, mac);

                //    return MyConverter.ToLoginResult(dealerClerkResult);
                //    return null;
                //} 
                #endregion
            }
            catch (Exception ex)
            {
                return new LoginResult("");
            }
        }

        #endregion

        #region 账户管理相关

        #region 客户相关操作

        #region 获取客户列表

        /// <summary>
        /// 获取客户列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="accountName">账户名</param>
        /// <param name="filter">过滤信息</param>
        /// <param name="clientList">获取的客户列表</param>
        /// <returns>ErrType</returns>
        public ErrType GetClientList(string loginID, ACCOUNT_TYPE accType, string accountName, ClientAccountFilter filter, out List<ClientAccount> clientList)
        {
            clientList = null;

            try
            {
                //Todo:金通网待处理
                #region MyRegion
                //UserQueryCon query = MyConverter.ToUserQueryCon(loginID, accType, accountName, filter);
                //UserBaseInfo info = ManagerService.GetUserBaseInfo(query);
                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc);

                //clientList = info.TdUserList.Select(MyConverter.ToClientAccount).ToList(); 
                #endregion
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetClientInfoError);
            }
        }

        #endregion

        #region 修改客户资料

        /// <summary>
        /// 修改客户资料
        /// </summary>
        /// <param name="clientAcc">客户资料</param>
        /// <param name="loginID">登陆标识</param>
        /// <returns>ErrType</returns>
        public ErrType ModifyClientAccountInfo(ClientAccount clientAcc, string loginID)
        {
            try
            {
                TradeUser userInfo = MyConverter.ToTradeUser(clientAcc);
                ResultDesc result = ManagerService.ModifyTradeUser(userInfo, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }


        /// <summary>
        /// 修改客户资料
        /// </summary>
        /// <param name="clientAcc">客户资料</param>
        /// <param name="Fdinfo">资金资料</param>
        /// <param name="loginID">登陆标识</param>
        /// <returns></returns>
        public ErrType ModifyClientAccountInfo(ClientAccount clientAcc, FundsInformation Fdinfo, string loginID)
        {
            try
            {
                TradeUser userInfo = MyConverter.ToTradeUser(clientAcc);
                Fundinfo finfo = new Fundinfo();
                finfo.OpenBank = Fdinfo.OpenBank;
                finfo.BankCard = Fdinfo.BankCardNumber;
                finfo.ConBankType = Fdinfo.banktype;
                ResultDesc result = ManagerService.ModifyTradeUserEx(userInfo, finfo, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        #endregion

        #region 获取客户资金信息

        /// <summary>
        /// 获取客户资金信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="accountName">要查询的客户账户名</param>
        /// <param name="fundsInfo">返回的客户资金信息</param>
        /// <returns>ErrType</returns>
        public ErrType GetClientFundsInfo(string loginID, ACCOUNT_TYPE accType, string accountName, out FundsInformation fundsInfo)
        {
            fundsInfo = null;
            try
            {
                UserFundinfo info = ManagerService.GetUserFundinfo(loginID, accountName);
                if (!info.Result)
                    return new ErrType(ERR.SERVICE, info.Desc);

                fundsInfo = MyConverter.ToFundsInformation(info.Fdinfo);
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetClientFundsInfo);
            }
        }

        #endregion

        #region 修改客户资金信息

        /// <summary>
        /// 修改客户资金信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="accountName">要查询的客户账户名</param>
        /// <param name="fundsInfo">新的客户资金信息</param>
        /// <returns>ErrType</returns>
        public ErrType ModifyClientFundsInfo(string loginID, ACCOUNT_TYPE accType, string accountName, FundsInformation fundsInfo)
        {
            try
            {
                //Todo:金通网待处理
                //return GeneralErr.Success;
                #region MyRegion

                Fundinfo info = MyConverter.ToFundInfo(fundsInfo);
                //ResultDesc result = ManagerService.ModifyUserFundinfo(info, accountName, loginID, (int)accType);
                ResultDesc result = ManagerService.ModifyUserFundinfo(info, accountName, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);

                #endregion
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        #endregion

        #region 新增客户

        /// <summary>
        /// 新增客户账号
        /// </summary>
        /// <param name="clientAcc">新增的客户资料信息</param>
        /// <param name="loginID">账户类型</param>
        /// <param name="accType">登录标识ID</param>
        /// <returns>ErrType</returns>
        public ErrType AddClientAccount(ClientAccount clientAcc, UserTypeInfo type, string loginID)
        {
            try
            {
                UserType uType = EnumConverter.ConverterUserType(type);
                TradeUser userInfo = MyConverter.ToTradeUser(clientAcc);
                ResultDesc result = ManagerService.AddTradeUser(userInfo, uType, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
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
        /// 新增客户账号
        /// </summary>
        /// <param name="clientAcc">新增的客户资料信息</param>
        /// <param name="Fdinfo">资金信息</param>
        /// <param name="type">账户类型</param>
        /// <param name="loginID">登录标识</param>
        /// <returns></returns>
        public ErrType AddClientAccount(ClientAccount clientAcc, FundsInformation Fdinfo, UserTypeInfo type, string loginID)
        {
            try
            {
                UserType uType = EnumConverter.ConverterUserType(type);
                TradeUser userInfo = MyConverter.ToTradeUser(clientAcc);
                Fundinfo finfo = new Fundinfo();
                finfo.OpenBank = Fdinfo.OpenBank;
                finfo.BankCard = Fdinfo.BankCardNumber;
                finfo.ConBankType = Fdinfo.banktype;
                ResultDesc result = ManagerService.AddTradeUserEx(userInfo, finfo, uType, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 删除客户

        /// <summary>
        /// 删除指定的客户账户
        /// </summary>
        /// <param name="clientAccountName">要删除的客户账户名</param>
        /// <param name="loginID">登陆标识</param>
        /// <returns>ErrType</returns>
        public ErrType DeleteClientAccount(string clientAccountName, string loginID)
        {
            try
            {
                ResultDesc result = ManagerService.DelTradeUser(clientAccountName, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
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

        #endregion

        #endregion

        #region 金商相关操作

        #region 获取金商列表

        /// <summary>
        /// 获取金商列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="accountName">账户名</param>
        /// <param name="dealerList">获取的金商账户列表</param>
        /// <returns>ErrType</returns>
        public ErrType GetDealerList(string loginID, ACCOUNT_TYPE accType, string accountName, out List<DealerAccount> dealerList)
        {
            dealerList = null;

            try
            {
                //Todo:金通网待处理
                return GeneralErr.Success;

                #region MyRegion

                ////获取金商基本信息
                //AgentBaseInfo info = ManagerService.GetAgentBaseInfo(loginID, (int)accType, accountName);
                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc);

                //dealerList = new List<DealerAccount>();
                //StringBuilder errMsg = new StringBuilder();
                //foreach (var userInfo in info.AtUserList)
                //{
                //    //获取金商权限
                //    AgentAuthInfo authInfo = ManagerService.GetAgentAuth(userInfo.AgentId, loginID, (int)accType);
                //    if (!authInfo.Result)
                //    {
                //        errMsg.Append(authInfo.Desc);
                //        continue;
                //    }

                //    DealerAccount dealerAcc = MyConverter.ToDealerAccount(userInfo, authInfo.AtAuth);
                //    dealerList.Add(dealerAcc);
                //}

                //if (errMsg.Length != 0)
                //    return new ErrType(ERR.ERROR, errMsg.ToString());

                //return errMsg.Length == 0 ? GeneralErr.Success : new ErrType(ERR.SERVICE, errMsg.ToString()); 

                #endregion
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetDealerList);
            }
        }

        #endregion

        #region 修改金商资料
        //Todo:金通网弃用
        ///// <summary>
        ///// 修改金商资料（包括权限）
        ///// </summary>
        ///// <param name="dealerAcc">金商账户类</param>
        ///// <param name="loginID">登陆标识</param>
        ///// <param name="accType">账户类型，管理员或金商</param>
        ///// <returns>ErrType</returns>
        //public ErrType ModifyDealerAccountInfo(DealerAccount dealerAcc, string loginID, ACCOUNT_TYPE accType)
        //{
        //    try
        //    {

        //        #region MyRegion

        //        //修改基本信息
        //        AgentUser userInfo = MyConverter.ToAgentUser(dealerAcc.AccInfo);
        //        ResultDesc result = ManagerService.ModifyAgentUser(userInfo, loginID, (int)accType);
        //        if (!result.Result)
        //            return new ErrType(ERR.SERVICE, result.Desc);

        //        //修改权限
        //        AgentAuth authority = MyConverter.ToAgentAuth(dealerAcc.Authority);
        //        result = ManagerService.ModifyAgentAuth(authority, dealerAcc.AccInfo.AccountName, loginID, (int)accType);
        //        return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc); 

        //        #endregion
        //    }
        //    catch (TimeoutException te)
        //    {
        //          FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ErrType(ERR.EXEPTION, ex.Message);
        //    }
        //}

        #endregion

        #region 新增金商账户

        /// <summary>
        /// 新增金商账号
        /// </summary>
        /// <param name="dealerAcc">新增的金商账号信息</param>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <returns>ErrType</returns>
        public ErrType AddDealerAccount(DealerAccount dealerAcc, string loginID, ACCOUNT_TYPE accType)
        {
            try
            {
                //Todo:金通网待处理
                return GeneralErr.Success;

                #region MyRegion

                //AgentUser userInfo = MyConverter.ToAgentUser(dealerAcc.AccInfo);
                //AgentAuth authority = MyConverter.ToAgentAuth(dealerAcc.Authority);
                //ResultDesc result = ManagerService.AddAgent(userInfo, authority, loginID, (int)accType);
                //return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc); 

                #endregion
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

        #endregion

        #region 删除金商账户

        /// <summary>
        /// 删除指定的金商账户
        /// </summary>
        /// <param name="accountName">要删除的金商账户名</param>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <returns>ErrType</returns>
        public ErrType DeleteDealerAccount(string accountName, string loginID, ACCOUNT_TYPE accType)
        {
            try
            {
                //Todo:金通网待处理
                return GeneralErr.Success;

                #region MyRegion

                //ResultDesc result = ManagerService.DelAgent(accountName, loginID, (int)accType);
                //return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc); 

                #endregion
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

        #endregion

        #endregion

        #region 管理员相关操作

        #region 获取管理员列表

        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="mgrList">获取的管理员列表</param>
        /// <returns>ErrType</returns>
        public ErrType GetAdminList(string loginID, out List<ManagerAccount> mgrList)
        {
            mgrList = null;
            try
            {
                //Todo:金通网待处理
                return GeneralErr.Success;

                #region MyRegion

                ////获取管理员基本资料
                //AdminBaseInfo info = ManagerService.GetAdminBaseInfo(loginID);
                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc);

                //mgrList = new List<ManagerAccount>();
                //StringBuilder errMsg = new StringBuilder();
                //foreach (var userInfo in info.AnUserList)
                //{
                //    //获取管理员权限
                //    AdminAuthInfo authInfo = ManagerService.GetAdminAuth(userInfo.AdminId, loginID);
                //    if (!authInfo.Result)
                //    {
                //        errMsg.Append(authInfo.Desc);
                //        continue;
                //    }

                //    ManagerAccount mgrAcc = MyConverter.ToManagerAccount(userInfo, authInfo.AnAuth);
                //    mgrList.Add(mgrAcc);
                //}

                //return errMsg.Length == 0 ? GeneralErr.Success : new ErrType(ERR.SERVICE, errMsg.ToString()); 

                #endregion
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetAdminList);
            }
        }

        #endregion

        #region 新增管理员账户

        /// <summary>
        /// 新增管理员账户
        /// </summary>
        /// <param name="mgrAcc">新增的管理员账户信息</param>
        /// <param name="loginID">登陆标识</param>
        /// <returns>ErrType</returns>
        public ErrType AddManagerAccount(ManagerAccount mgrAcc, string loginID)
        {
            try
            {
                //Todo:金通网待处理
                return GeneralErr.Success;

                #region MyRegion

                //    AdminUser userInfo = MyConverter.ToAdminUser(mgrAcc.AccInfo);
                //    AdminAuth authority = MyConverter.ToAdminAuth(mgrAcc.Authority);

                //    ResultDesc result = ManagerService.AddAdmin(userInfo, authority, loginID);
                //    return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc); 

                #endregion
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        #endregion

        #region 修改管理员资料

        /// <summary>
        /// 修改管理员资料
        /// </summary>
        /// <param name="adminAcc">管理员资料</param>
        /// <param name="loginID">登陆标识</param>
        /// <returns>ErrType</returns>
        public ErrType ModifyAdminAccountInfo(ManagerAccount adminAcc, string loginID)
        {
            try
            {
                //Todo:金通网待处理
                return GeneralErr.Success;

                #region MyRegion

                ////修改基本信息
                //AdminUser userInfo = MyConverter.ToAdminUser(adminAcc.AccInfo);
                //ResultDesc result = ManagerService.ModifyAdminUser(userInfo, loginID);
                //if (!result.Result)
                //    return new ErrType(ERR.SERVICE, result.Desc);

                ////修改权限
                //AdminAuth authority = MyConverter.ToAdminAuth(adminAcc.Authority);
                //result = ManagerService.ModifyAdminAuth(authority, adminAcc.AccInfo.AccountName, loginID);
                //return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc); 

                #endregion
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        #endregion

        #region 删除管理员账户

        /// <summary>
        /// 删除指定管理员账户
        /// </summary>
        /// <param name="accountName">要删除的管理员账户名</param>
        /// <param name="loginID">登陆标识</param>
        /// <returns>ErrType</returns>
        public ErrType DeleteManagerAccount(string accountName, string loginID)
        {
            try
            {
                //Todo:金通网待处理
                return GeneralErr.Success;
                #region MyRegion
                //ResultDesc result = ManagerService.DelAdmin(accountName, loginID);
                //return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc); 
                #endregion
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        #endregion

        #endregion

        #region 获取在线客户

        /// <summary>
        /// 获取在线客户列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="accountName">账户名</param>
        /// <param name="filter">过滤信息</param>
        /// <param name="clientList">获取的在线客户列表</param>
        /// <returns>ErrType</returns>
        public ErrType GetOnlineClientList(string loginID, ACCOUNT_TYPE accType, string accountName, ClientAccountFilter filter, out List<ClientAccount> onlineClientList)
        {
            onlineClientList = null;
            try
            {
                //Todo:金通网待处理
                #region MyRegion
                //UserQueryCon query = MyConverter.ToUserQueryCon(loginID, accType, accountName, filter);
                //UserBaseInfo info = ManagerService.GetOnLineUserBaseInfo(query);
                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc);

                //onlineClientList = info.TdUserList.Select(MyConverter.ToClientAccount).ToList(); 
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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetOnlineClientList);
            }
        }

        #endregion

        #region 资金相关操作

        /// <summary>
        /// 库存结算操作，如果资金大于0，则表示入金，反之则为出金
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="accountName">要查询的客户账户名</param>
        /// <param name="money">出入金金额，大于0为入金，小于0为出金</param>
        /// <returns>ErrType</returns>
        public ErrType CashIO(string loginID, ACCOUNT_TYPE accType, string accountName, double money)
        {
            return FundsOperate(loginID, accType, accountName, money, FUND_OPERATE_TYPE.CashIO);
        }

        /// <summary>
        /// 资金调整
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="accountName">要查询的客户账户名</param>
        /// <param name="money">资金调整金额</param>
        /// <returns>ErrType</returns>
        public ErrType AdjustMoney(string loginID, ACCOUNT_TYPE accType, string accountName, double money)
        {
            return FundsOperate(loginID, accType, accountName, money, FUND_OPERATE_TYPE.AdjustMoney);
        }

        /// <summary>
        /// 资金操作
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="accountName">要查询的客户账户名</param>
        /// <param name="money">资金操作金额</param>
        /// <param name="operateType">操作类别，出金/入金/资金调整</param>
        /// <returns>ErrType</returns>
        private ErrType FundsOperate(string loginID, ACCOUNT_TYPE accType, string accName, double money, FUND_OPERATE_TYPE operateType)
        {
            try
            {
                ResultDesc result = ManagerService.ModifyUserMoney(loginID, accName, money, (int)operateType);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
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

        #endregion

        #endregion

        #region 交易管理相关

        /// <summary>
        /// 有效定单查询
        /// </summary>
        /// <param name="loginID">登录ID标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="requestInfo">查询的限定信息</param>
        /// <param name="orderList">返回的有效定单列表</param>
        /// <returns>ErrType</returns>
        public ErrType GetMarketOrderList(string loginID, ACCOUNT_TYPE accType, RequestInformationBase requestInfo, out List<MarketOrderData> orderList)
        {
            orderList = null;
            try
            {
                //Todo:金通网待处理
                #region MyRegion

                //TradeOrderInfo info = ManagerService.GetMultiTradeOrder((int)accType, loginID, requestInfo.AccountName, requestInfo.StartTime, requestInfo.EndTime);
                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc);

                //orderList = info.TdOrderList.Select(MyConverter.ToMarketOrderData).ToList(); 
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
                return new ErrType(ERR.EXEPTION, ErrorText.GetMarketOrderList);
            }
        }

        /// <summary>
        /// 限价挂单查询
        /// </summary>
        /// <param name="loginID">登录ID标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="requestInfo">查询的限定信息</param>
        /// <param name="orderList">返回的限价挂单列表</param>
        /// <returns>ErrType</returns>
        public ErrType GetPendingOrderList(string loginID, ACCOUNT_TYPE accType, RequestInformationBase requestInfo, out List<PendingOrderData> orderList)
        {
            orderList = null;
            try
            {
                //Todo:金通网待处理
                #region MyRegion
                //TradeHoldOrderInfo info = ManagerService.GetMultiTradeHoldOrder((int)accType, loginID, requestInfo.AccountName, requestInfo.StartTime, requestInfo.EndTime);
                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc);

                //orderList = info.TdHoldOrderList.Select(MyConverter.ToPendingOrderData).ToList(); 
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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetPendingOrderList);
            }
        }

        /// <summary>
        /// 获取对冲交易记录
        /// </summary>
        /// <param name="loginID">登录ID标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="requestInfo">查询的限定信息</param>
        /// <param name="orderList">返回的对冲交易记录</param>
        /// <returns>ErrType</returns>
        public ErrType GetHedgingTradeList(string loginID, ACCOUNT_TYPE accType, RequestInformationBase requestInfo, out List<HedgingTradeData> orderList)
        {
            orderList = null;
            try
            {
                HedgingInfo info = _managerService.GetHedgingInfo(loginID, requestInfo.StartTime, requestInfo.EndTime);
                if (!info.Result)
                    return new ErrType(ERR.SERVICE, info.Desc);

                orderList = info.HedgingList.Select(MyConverter.ToHedgingTradeData).ToList();
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetHedgingTradeList);
            }
        }

        /// <summary>
        /// 获取导出报表的网页地址
        /// </summary>
        /// <param name="loginID">登录ID标识</param>
        /// <param name="accType">账户类型，金商或管理员</param>
        /// <param name="startTime">查询起始时间</param>
        /// <param name="endTime">查询结束时间</param>
        /// <param name="type">报表类型</param>
        /// <param name="webAddr">返回的报表地址</param>
        /// <returns>ErrType</returns>
        public ErrType GetExportStatementsWebAddr(string loginID, ACCOUNT_TYPE accType, DateTime startTime, DateTime endTime, STATEMENTS_TYPE type, out string webAddr)
        {
            webAddr = string.Empty;
            try
            {
                int int_type = (int)type;
                ReportForms report = _managerService.GetReportForms(startTime, endTime, int_type, loginID);
                if (!report.Result)
                    return new ErrType(ERR.SERVICE, report.Desc);

                webAddr = report.ReportAddr;
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetExportStatementsWebAddr);
            }
        }

        public ErrType GetExportStatementsWebAddrUser(string TradeAccount, string UserName, string TelPhone, string Broker,
            string orgid, string IsBroker, string loginID, DateTime startTime, DateTime endTime, STATEMENTS_TYPE type, out string webAddr)
        {
            webAddr = string.Empty;
            try
            {
                int int_type = (int)type;
                ReportForms report = _managerService.GetReportFormsUser(TradeAccount, UserName, TelPhone, Broker,
             orgid, IsBroker, startTime, endTime, int_type, loginID);
                if (!report.Result)
                    return new ErrType(ERR.SERVICE, report.Desc);

                webAddr = report.ReportAddr;
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetExportStatementsWebAddr);
            }
        }


        #region 会员报表
        /// <summary>
        /// 获取会员报表
        /// </summary>
        /// <param name="cond"></param>
        /// <returns></returns>
        public void GetTradeJuJianInfo(SelectCondition cond, string UserID, ref ClientTradeJuJianInfo cinfo)
        {
            if (null == cinfo)
            {
                return;
            }
            try
            {
                JJQueryCon con = new JJQueryCon() { StartTime = cond.StartTime, EndTime = cond.EndTime, OrgName = cond.OrgName, LoginID = UserID };
                TradeJuJianInfo info = _managerService.GetTradeJuJianInfo(con);
                if (info.Result)
                {
                    cinfo.Result = info.Result;
                    cinfo.Desc = info.Desc;
                    //info.TdJuJianList.ForEach(p => cinfo.TradeJuJianLst.Add(MyConverter.ToClientTradeJuJianInfo(p)));
                    foreach (var item in info.TdJuJianList)
                    {
                        cinfo.TradeJuJianLst.Add(MyConverter.ToClientTradeJuJianInfo(item));
                    }
                    CountJuJian(cinfo);
                }
                else
                {

                    cinfo.Result = false;
                    cinfo.Desc = info.Desc;
                }
            }
            catch (TimeoutException te)
            {
                cinfo.Result = false;
                cinfo.Desc = "服务器响应超时";
            }
            catch (Exception ex)
            {
                cinfo.Result = false;
                cinfo.Desc = "获取数据失败，请稍后再试";
            }
        }

        private void CountJuJian(ClientTradeJuJianInfo info)
        {
            foreach (var item in info.TradeJuJianLst)
            {
                info.Qichu += item.Qichu;
                info.Rujin += item.Rujin;
                info.Chujin += item.Chujin;
                info.Manual_rujin += item.Manual_rujin;
                info.Manual_chujin += item.Manual_chujin;
                info.Hisyingkui += item.Hisyingkui;
                info.Tradefee += item.Tradefee;
                info.Storagefee += item.Storagefee;
                info.Qimo += item.Qimo;
                info.Money += item.Money;
                info.KC_XAG_100kg_Num += item.KC_XAG_100kg_Num;
                info.XAG_100kg_Num += item.XAG_100kg_Num;
                info.KC_XAG_50kg_Num += item.XAG_50kg_Num;
                info.XAG_50kg_Num += item.XAG_50kg_Num;
                info.KC_XAG_20kg_Num += item.KC_XAG_20kg_Num;
                info.XAG_20kg_Num += item.XAG_20kg_Num;

                info.KC_XAU_1000g_Num += item.KC_XAU_1000g_Num;
                info.XAU_1000g_Num += item.XAU_1000g_Num;

                info.KC_XPT_1000g_Num += item.KC_XPT_1000g_Num;
                info.XPT_1000g_Num += item.XPT_1000g_Num;

                info.KC_XPD_1000g_Num += item.KC_XPD_1000g_Num;
                info.XPD_1000g_Num += item.XPD_1000g_Num;


                info.KC_Copper_50t_Num += item.KC_Copper_50t_Num;
                info.Copper_50t_Num += item.Copper_50t_Num;
                info.KC_Copper_20t_Num += item.KC_Copper_20t_Num;
                info.Copper_20t_Num += item.Copper_20t_Num;

                info.KC_UKOil_100_Num += item.KC_UKOil_100_Num;
                info.UKOil_100_Num += item.UKOil_100_Num;
                info.KC_UKOil_50_Num += item.KC_UKOil_50_Num;
                info.UKOil_50_Num += item.UKOil_50_Num;
                info.KC_UKOil_20_Num += item.KC_UKOil_20_Num;
                info.UKOil_20_Num += item.UKOil_20_Num;
            }
        }
        #endregion

        #endregion

        #region 系统设置相关

        #region 交易日

        /// <summary>
        /// 获取交易日信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="StockCode">行情编码</param>
        /// <param name="tradingInfoes">返回的交易日信息</param>
        /// <returns>ErrType</returns>
        public ErrType GetTradingDayInfo(string loginID, string StockCode, out List<TradingDayInformation> tradingInfoes)
        {
            tradingInfoes = null;
            try
            {
                DateSetInfo info = ManagerService.GetDateSetInfoEx(StockCode, loginID);
                if (!info.Result)
                    return new ErrType(ERR.SERVICE, info.Desc);

                tradingInfoes = info.DtSetInfoList.Select(MyConverter.ToTradingDayInfo).ToList();
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetTradingDayInfo);
            }
        }

        /// <summary>
        /// 修改指定的交易日信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="tradingDayInfo">新的交易日信息</param>
        /// <returns>ErrType</returns>
        public ErrType ModifyTradingDayInfo(string loginID, TradingDayInformation tradingDayInfo)
        {
            try
            {
                DateSet dateSet = MyConverter.ToDateSet(tradingDayInfo);
                ResultDesc result = ManagerService.ModifyDateSetEx(dateSet, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 节假日

        /// <summary>
        /// 获取节假日信息列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="holidayInfoes">翻译的节假日信息列表</param>
        /// <returns>ErrType</returns>
        public ErrType GetHolidayInfo(string loginID, out List<HolidayInformation> holidayInfoes)
        {
            holidayInfoes = null;
            try
            {
                DateHolidayInfo info = ManagerService.GetHolidayInfo(loginID);
                if (!info.Result)
                    return new ErrType(ERR.SERVICE, info.Desc);

                holidayInfoes = info.DtHolidayInfoList.Select(MyConverter.ToHolidayInfo).ToList();
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetHolidayInfo);
            }
        }

        /// <summary>
        /// 添加新的节假日信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="holidayInfo">新的节假日信息</param>
        /// <returns>ErrType</returns>
        public ErrType AddHolidayInfo(string loginID, HolidayInformation holidayInfo)
        {
            try
            {
                DateHoliday holiday = MyConverter.ToDateHoliday(holidayInfo);
                string holidayID = "";
                ResultDesc result = ManagerService.AddHoliday(holiday, loginID, ref holidayID);
                if (result.Result)
                {
                    holidayInfo.HolidayID = holidayID;
                    return GeneralErr.Success;
                }
                else
                    return new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 删除指定的节假日
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="holidayName">要删除的节假日名称</param>
        /// <returns>ErrType</returns>
        public ErrType DeleteHoliday(string loginID, string holidayName)
        {
            try
            {
                ResultDesc result = ManagerService.DelHoliday(holidayName, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="holidayInfo"></param>
        /// <returns></returns>
        public ErrType ModifyHolidayInfo(string loginID, HolidayInformation holidayInfo)
        {
            try
            {
                DateHoliday holiday = MyConverter.ToDateHoliday(holidayInfo);
                ResultDesc result = ManagerService.ModifyHoliday(holiday, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        #endregion

        #region 交易设置管理
        /// <summary>
        /// 添加交易设置信息
        /// </summary>
        /// <param name="tradingSettingInfo">交易设置信息</param>
        /// <param name="loginId">登陆标识</param>
        /// <returns></returns>
        public ErrType AddTradeSet(TradeConfigInfo tradingSettingInfo, String loginId)
        {
            try
            {
                TradeSet tradeSet = new TradeSet();
                tradeSet.ObjName = tradingSettingInfo.ObjName;
                tradeSet.ObjCode = tradingSettingInfo.ObjCode;
                tradeSet.ObjValue = tradingSettingInfo.ObjValue;
                tradeSet.Remark = tradingSettingInfo.Remark;
                ResultDesc result = ManagerService.AddTradeSet(tradeSet, loginId);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 修改交易设置信息 
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="tradingSettingInfo">修改后的交易设置信息</param>
        /// <returns>ErrType</returns>
        public ErrType ModifyTradeSet(string loginID, TradeConfigInfo tradingSettingInfo)
        {
            try
            {
                TradeSet tradeSet = new TradeSet();
                tradeSet.ObjName = tradingSettingInfo.ObjName;
                tradeSet.ObjCode = tradingSettingInfo.ObjCode;
                tradeSet.ObjValue = tradingSettingInfo.ObjValue;
                tradeSet.Remark = tradingSettingInfo.Remark;
                ResultDesc result = ManagerService.ModifyTradeSet(tradeSet, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }


        /// <summary>
        /// 删除交易设置信息 
        /// </summary>
        /// <param name="ObjCode">交易设置信息--代码</param>
        /// <param name="loginID">登陆标识</param>
        /// <returns>ErrType</returns>
        public ErrType DelTradeSet(string ObjCode, String LoginId)
        {
            try
            {
                ResultDesc result = ManagerService.DelTradeSet(ObjCode, LoginId);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 日志记录 弃用

        /// <summary>
        /// 获取日志信息列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="logType">日志类型，管理员或金商</param>
        /// <param name="startTime">起始日志时间</param>
        /// <param name="endTime">结束日志时间</param>
        /// <param name="logInfoes">返回的日志信息列表</param>
        /// <returns>ErrType</returns>
        public ErrType GetLogInfo(string loginID, LogRequestInformation logRequestInfo, out List<LogInformation> logInfoes)
        {
            logInfoes = null;
            try
            {
                //Todo:金通网待处理
                #region MyRegion
                //DateTime endDate = new DateTime(logRequestInfo.EndTime.AddDays(1).Year, logRequestInfo.EndTime.AddDays(1).Month, logRequestInfo.EndTime.AddDays(1).Day);
                //TradeALogInfo info = ManagerService.GetTradeALogInfo(loginID, (int)logRequestInfo.LogType, logRequestInfo.StartTime, endDate);
                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc);

                //logInfoes = info.ALogList.Select(MyConverter.ToLogInfo).ToList(); 
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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
            new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.GetLogInfo);
            }
        }

        #endregion

        #region IP地址过滤

        /// <summary>
        /// 获取IP地址过滤信息列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="ipAddrFilterInfoes">返回的IP地址过滤列表</param>
        /// <returns>ErrType</returns>
        public ErrType GetIPAddrFilteringInfoList(string loginID, out List<IPAddressFilterInformation> ipAddrFilterInfoes)
        {
            ipAddrFilterInfoes = null;
            try
            {
                TradeIpInfo info = ManagerService.GetTradeIpInfo(loginID);
                if (!info.Result)
                    return new ErrType(ERR.SERVICE, info.Desc);

                ipAddrFilterInfoes = info.TradeIpInfoList.Select(MyConverter.ToIPAddressFilterInfo).ToList();
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
                return new ErrType(ERR.EXEPTION, ErrorText.GetIPAddrFilteringInfoList);
            }
        }

        /// <summary>
        /// 添加新的IP地址过滤信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="ipAddrFilterInfo">要添加的新的IP地址过滤条件</param>
        /// <returns>ErrType</returns>
        public ErrType AddIPAddrFilteringInfo(string loginID, IPAddressFilterInformation ipAddrFilterInfo)
        {
            try
            {
                TradeIp ipInfo = MyConverter.ToTradeIp(ipAddrFilterInfo);
                string filterID = "";
                ResultDesc result = ManagerService.AddTradeIp(ipInfo, loginID, ref filterID);
                if (result.Result)
                {
                    ipAddrFilterInfo.FilterID = filterID;
                    return GeneralErr.Success;
                }
                else
                    return new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 删除指定的IP地址过滤信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="ipFilterID">指定的IP地址过滤信息名称</param>
        /// <returns>ErrType</returns>
        public ErrType DeleteIPAddrFilteringInfo(string loginID, string ipFilterID)
        {
            try
            {
                ResultDesc result = ManagerService.DelTradeIp(ipFilterID, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 修改选中的IP地址过滤信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="ipAddrFilterInfo">修改后的IP地址过滤信息</param>
        /// <returns>ErrType</returns>
        public ErrType ModifyIPAddrFilteringInfo(string loginID, IPAddressFilterInformation ipAddrFilterInfo)
        {
            try
            {
                TradeIp tradeIP = MyConverter.ToTradeIp(ipAddrFilterInfo);
                ResultDesc result = ManagerService.ModifyTradeIp(tradeIP, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region MAC地址过滤

        /// <summary>
        /// 获取MAC地址过滤信息列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="macFilterInfoes">返回的MAC过滤地址列表</param>
        /// <returns>ErrType</returns>
        public ErrType GetMACFilterInfoList(string loginID, out List<MACFilterInformation> macFilterInfoes)
        {
            macFilterInfoes = null;
            try
            {
                TradeMacInfo macInfo = ManagerService.GetTradeMacInfo(loginID);

                if (!macInfo.Result)
                    return new ErrType(ERR.SERVICE, macInfo.Desc);

                macFilterInfoes = macInfo.TradeMacInfoList.Select(MyConverter.ToMACFilterInfo).ToList();
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
                return new ErrType(ERR.EXEPTION, ErrorText.GetMACFilterInfoList);
            }
        }

        /// <summary>
        /// 添加新的MAC过滤信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="macFilterInfo">要添加的新的MAC过滤信息</param>
        /// <returns>ErrType</returns>
        public ErrType AddMACFilterInfo(string loginID, MACFilterInformation macFilterInfo)
        {
            try
            {
                TradeMac macInfo = MyConverter.ToTradeMac(macFilterInfo);
                string filterID = "";
                ResultDesc result = ManagerService.AddTradeMac(macInfo, loginID, ref filterID);
                if (result.Result)
                {
                    macFilterInfo.FilterID = filterID;
                    return GeneralErr.Success;
                }
                else
                    return new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 删除某个MAC过滤信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="macFilterID">选中的MAC过滤信息ID</param>
        /// <returns>ErrType</returns>
        public ErrType DeleteMACFilterInfo(string loginID, string macFilterID)
        {
            try
            {
                ResultDesc result = ManagerService.DelTradeMac(macFilterID, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 修改选中的MAC地址过滤信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="macFilterInfo">修改后的MAC地址过滤信息</param>
        /// <returns>ErrType</returns>
        public ErrType ModifyMACFilterInfo(string loginID, MACFilterInformation macFilterInfo)
        {
            try
            {
                TradeMac macInfo = MyConverter.ToTradeMac(macFilterInfo);
                ResultDesc result = ManagerService.ModifyTradeMac(macInfo, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        #endregion

        #region 新闻公告
        /// <summary>
        /// 添加新闻公告记录
        /// </summary>
        /// <param name="newsInfo">新闻公告记录</param>
        /// <param name="loginId">登录用户标识ID</param>
        /// <returns></returns>
        public ErrType AddTradeNews(NewsInfo newsInfo, String loginId)
        {
            try
            {
                TradeNews news = MyConverter.ToTradeNews(newsInfo);
                ResultDesc result = ManagerService.AddTradeNews(news, loginId);
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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        /// <summary>
        /// 删除新闻公告记录
        /// </summary>
        /// <param name="id">新闻记录ID</param>
        /// <param name="loginId">登录用户标识ID</param>
        /// <returns></returns>
        public ErrType DelTradeNews(string id, String loginId)
        {
            try
            {
                ResultDesc result = ManagerService.DelTradeNews(id, loginId);
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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 编辑新闻公告
        /// </summary>
        /// <param name="newsInfo">新闻记录</param>
        /// <param name="loginId">登录用户标识</param>
        /// <returns></returns>
        public ErrType ModifyTradeNews(NewsInfo newsInfo, String loginId)
        {
            try
            {
                TradeNews news = MyConverter.ToTradeNews(newsInfo);
                ResultDesc result = ManagerService.ModifyTradeNews(news, loginId);
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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 客户分组
        /// <summary>
        /// 获取客户分组
        /// </summary>
        /// <param name="userGroups">返回的客户组列表</param>
        /// <returns></returns>
        public ErrType GetUserGroupsInfo(ObservableCollection<UserGroup> userGroups)
        {
            try
            {
                UserGroupsInfo result = ManagerService.GetUserGroupsInfo();
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);
                result.UserGroupsInfoList.ForEach(p => userGroups.Add(MyConverter.ToUserGroup(p)));
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        /// <summary>
        /// 添加客户组
        /// </summary>
        /// <param name="ugs"></param>
        /// <param name="LoginId"></param>
        /// <returns></returns>
        public ErrType AddUserGroups(UserGroup ugs, String LoginId)
        {
            try
            {
                UserGroups ug = new UserGroups();

                ResultDesc result = ManagerService.AddUserGroups(MyConverter.ToUserGroups(ugs), LoginId);
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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        /// <summary>
        /// 删除客户组
        /// </summary>
        /// <param name="UserGroupId"></param>
        /// <param name="LoginId"></param>
        /// <returns></returns>
        public ErrType DelUserGroups(string UserGroupId, String LoginId)
        {
            try
            {

                ResultDesc result = ManagerService.DelUserGroups(UserGroupId, LoginId);
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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        /// <summary>
        /// 修改客户组
        /// </summary>
        /// <param name="ugs"></param>
        /// <param name="LoginId"></param>
        /// <returns></returns>
        public ErrType ModifyUserGroups(UserGroup ugs, String LoginId)
        {
            try
            {
                ResultDesc result = ManagerService.ModifyUserGroups(MyConverter.ToUserGroups(ugs), LoginId);
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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }


        /// <summary>
        /// 添加客户到客户组
        /// </summary>
        /// <param name="account">客户id</param>
        /// <param name="LoginId">登陆标示</param>
        /// <returns></returns>
        public ErrType AddUserToUserGroups(string account, string Groupid, String LoginId, ref ClientAccount CAccount)
        {
            try
            {
                TradeUser user = new TradeUser();
                ResultDesc result = ManagerService.AddUserToUserGroups(account, Groupid, LoginId, ref user);
                CAccount = MyConverter.ToClientAccount(user);

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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        /// <summary>
        /// 删除客户组的客户
        /// </summary>
        /// <param name="account">客户id</param>
        /// <param name="UserGroupId">用户组id</param>
        /// <param name="LoginId"></param>
        /// <returns></returns>
        public ErrType DelUserFromUserGroups(string account, string UserGroupId, String LoginId)
        {
            try
            {
                ResultDesc result = ManagerService.DelUserFromUserGroups(account, UserGroupId, LoginId);
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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        #endregion
        #endregion

        #region 数据管理

        #region 商品管理

        /// <summary>
        /// 获取商品信息列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">用户标识，0：管理员，1：金商</param>
        /// <param name="infoList">返回的商品信息列表</param>
        /// <returns>ErrType</returns>
        public ErrType GetProductInfoList(string loginID, out List<ProductInformation> infoList)
        {
            infoList = null;
            try
            {
                #region MyRegion
                TradeProductInfo info = ManagerService.GetTradeProductInfo(loginID);
                if (!info.Result)
                    return new ErrType(ERR.SERVICE, info.Desc);

                infoList = info.TradeProductInfoList.Select(MyConverter.ToProductInfo).ToList();
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
                return new ErrType(ERR.EXEPTION, ErrorText.GetProductInfoList);
            }
        }

        /// <summary>
        /// 新增商品信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="productInfo">新增的商品信息</param>
        /// <returns>ErrType</returns>
        public ErrType AddProductInfo(string loginID, ProductInformation productInfo)
        {
            try
            {
                TradeProduct product = MyConverter.ToTradeProduct(productInfo);
                ResultDesc result = ManagerService.AddTradeProduct(product, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 删除指定的商品信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="productCode">要删除的商品编码</param>
        /// <returns>ErrType</returns>
        public ErrType DeleteProductInfo(string loginID, string productCode)
        {
            try
            {
                ResultDesc result = ManagerService.DelTradeProduct(productCode, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 修改指定的商品信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="productInfo">新的商品信息</param>
        /// <returns>ErrType</returns>
        public ErrType ModifyProductInfo(string loginID, ProductInformation productInfo)
        {
            try
            {
                TradeProduct product = MyConverter.ToTradeProduct(productInfo);
                ResultDesc result = ManagerService.ModifyTradeProduct(product, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 汇率和水

        /// <summary>
        /// 获取汇率和水信息列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="infoList">返回的汇率和水信息列表</param>
        /// <returns>ErrType</returns>
        public ErrType GetRateWaterInfoList(string loginID, out List<ExchangeRateWaterInformation> infoList)
        {
            infoList = null;
            try
            {
                TradeRateInfo info = ManagerService.GetTradeRateInfo(loginID);
                if (!info.Result)
                    return new ErrType(ERR.SERVICE, info.Desc);

                infoList = info.TradeRateInfoList.Select(MyConverter.ToRateWaterInfo).ToList();
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
                return new ErrType(ERR.EXEPTION, ErrorText.GetRateWaterInfoList);
            }
        }

        /// <summary>
        /// 修改指定的汇率和水的信息
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="rateWaterInfo"></param>
        /// <returns></returns>
        public ErrType ModifyRateWaterInfo(string loginID, ExchangeRateWaterInformation rateWaterInfo)
        {
            try
            {
                TradeRate rate = MyConverter.ToTradeRate(rateWaterInfo);
                ResultDesc result = ManagerService.ModifyTradeRate(rate, loginID);
                return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc);
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        #endregion

        #region 手工报价
        /// <summary>
        /// 手工报价
        /// </summary>
        /// <param name="loginId">登录标识ID</param>
        /// <param name="priceCode">商品代码</param>
        /// <param name="realPrice">实时价</param>
        /// <returns>ErrType</returns>
        public ErrType ManualPrice(String loginId, String priceCode, double realPrice)
        {
            try
            {
                ResultDesc result = ManagerService.ManualPrice(loginId, priceCode, realPrice);
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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion
        #endregion

        #region 释放资源

        /// <summary>
        /// 断开WCF连接
        /// </summary>
        public void Dispose()
        {
            // ManagerService.Close();
        }
        #endregion

        #region 辅助方法

        /// <summary>
        /// 进行服务引用实例是否可能超时的判断，返回true，则表示可能超时
        /// </summary>
        /// <returns>是否超时</returns>
        private bool TimeoutCheck()
        {
            return _createTime.AddMinutes(TimeoutMinute) < DateTime.Now;
        }

        /// <summary>
        /// 创建一个后台服务实例对象，并记录创建时间
        /// </summary>
        /// <returns>后台服务实例</returns>
        private IManager CreateManagerClient()
        {
            _createTime = DateTime.Now;

            WSHttpBinding binding = new WSHttpBinding(SecurityMode.None);
            binding.MaxReceivedMessageSize = 6553600;
            EndpointAddress address = new EndpointAddress(ConnectConfigData.GssManagerAddress);
            ChannelFactory<IManager> ttgService = new ChannelFactory<IManager>(binding, address);
            return ttgService.CreateChannel();
            // return new ManagerClient();
        }

        #endregion

        #region 有效定单入库限制 马友春
        /// <summary>
        /// 有效定单入库限制
        /// </summary>
        /// <param name="UserType">用户类型(0表示管理员 1表示金商)</param>
        /// <param name="LoginId">管理员或金商登陆标识</param>
        /// <param name="TradeAccount">用户账号</param>
        /// <param name="OrderId">定单号</param>
        /// <param name="AllowStore">1允许入库 0不允许入库</param>
        /// <returns>ErrType</returns>
        public ErrType ModifyOrderAllowStore(int UserType, string LoginId, string TradeAccount, string OrderId, int AllowStore)
        {
            try
            {
                //Todo:金通网待处理
                return GeneralErr.Success;

                #region MyRegion

                //ResultDesc result = ManagerService.ModifyOrderAllowStore(UserTypeInfo, LoginId, TradeAccount, OrderId, AllowStore);
                //return result.Result ? GeneralErr.Success : new ErrType(ERR.SERVICE, result.Desc); 

                #endregion
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion
        
        #region 有效定单分页查询 马友春
        /// <summary>
        /// 有效定单分页查询GetMultiTradeOrderWithPage
        /// </summary>
        /// <param name="Cxqc">查询条件</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="pagesize">返回列表</param>
        /// <param name="page">输出参数：总页数</param>
        /// <returns></returns>
        public ClientTradeOrderInfo GetMultiTradeOrderWithPage(CxQueryConInfomation Cxqc, int pageindex, int pagesize, ref int pageCount)
        {
            ClientTradeOrderInfo cinfo = new ClientTradeOrderInfo();
            try
            {

                CxQueryCon con = MyConverter.ToCxQueryCon(Cxqc);

                TradeOrderInfo info = ManagerService.GetMultiTradeOrderWithPage(con, pageindex, pagesize, ref pageCount);
                cinfo.Desc = info.Desc;
                cinfo.OccMoney = info.OccMoney;
                cinfo.Quantity = info.Quantity;
                cinfo.Result = info.Result;
                cinfo.Storagefee = info.Storagefee;
                cinfo.Tradefee = info.Tradefee;
                info.TdOrderList.ForEach(p => cinfo.TdOrderList.Add(MyConverter.ToMarketOrderData(p)));
                return cinfo;
            }
            catch (TimeoutException te)
            {
                cinfo.Result = false;
                cinfo.Desc = ErrorText.TimeoutException;
                return cinfo;
            }
            catch (Exception ex)
            {
                cinfo.Result = false;
                cinfo.Desc = ErrorText.GetMarketOrderList;
                return cinfo;
            }
        }
        #endregion

        #region 平仓历史分页查询
        /// <summary>
        /// 平仓历史分页查询
        /// </summary>
        /// <param name="Cxqc"></param>
        /// <param name="Ltype"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ClientLTradeOrderInfo GetMultiLTradeOrderWithPage(CxQueryConInfomation Cxqc, string Ltype, int pageindex, int pagesize, ref int page)
        {
            ClientLTradeOrderInfo cinfo = new ClientLTradeOrderInfo();
            try
            {

                LQueryCon con = MyConverter.ToLQueryCon(Cxqc);

                LTradeOrderInfo info = ManagerService.GetMultiLTradeOrderWithPage(con, Ltype, pageindex, pagesize, ref page);
                cinfo.Result = info.Result;
                cinfo.Desc = info.Desc;
                cinfo.Quantity = info.Quantity;
                cinfo.ProfitValue = info.ProfitValue;
                cinfo.Storagefee = info.Storagefee;
                cinfo.Tradefee = info.Tradefee;
                info.LTdOrderList.ForEach(p => cinfo.TOrderLst.Add(MyConverter.ToMarketHistoryData(p)));
                return cinfo;
            }
            catch (TimeoutException te)
            {
                cinfo.Result = false;
                cinfo.Desc = ErrorText.TimeoutException;
                return cinfo;
            }
            catch (Exception ex)
            {
                cinfo.Result = false;
                cinfo.Desc = ErrorText.GetPendingOrderList;
                return cinfo;
            }
        }
        #endregion

        #region 限价定单分页查询 马友春
        public ClientTradeHoldOrderInfo GetMultiTradeHoldOrderWithPage(CxQueryConInfomation Cxqc, int pageindex, int pagesize, ref int pageCount)
        {
            ClientTradeHoldOrderInfo cinfo = new ClientTradeHoldOrderInfo();
            try
            {
                CxQueryCon con = MyConverter.ToCxQueryCon(Cxqc);
                TradeHoldOrderInfo info = ManagerService.GetMultiTradeHoldOrderWithPage(con, pageindex, pagesize, ref pageCount);
                if (!info.Result)
                {
                    cinfo.Result = false;
                }
                else
                {
                    cinfo.Desc = info.Desc;
                    cinfo.FrozenMoney = info.FrozenMoney;
                    cinfo.Quantity = info.Quantity;
                    cinfo.Result = info.Result;
                    info.TdHoldOrderList.ForEach(p => cinfo.TdHoldOrderList.Add(MyConverter.ToPendingOrderData(p)));

                }
            }
            catch (TimeoutException te)
            {
                cinfo.Result = false;
                cinfo.Desc = ErrorText.TimeoutException;
            }
            catch (Exception ex)
            {
                cinfo.Result = false;
                cinfo.Desc = ErrorText.GetPendingOrderList;
            }
            return cinfo;
        }
        #endregion

        #region 客户资料分页查询 马友春

        /// <summary>
        /// 客户资料分页查询
        /// </summary>
        /// <param name="Cxqc">查询条件</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="pagesize">输出参数：总页数</param>
        /// <param name="page">返回列表</param>
        /// <returns></returns>
        public ErrType GetUserBaseInfoWithPage(UserQueryConInfomation Uqc, int pageindex, int pagesize, ref int pageCount, out List<ClientAccount> clientList)
        {
            clientList = null;
            try
            {
                UserQueryCon query = MyConverter.ToUserQueryCon(Uqc);
                UserBaseInfo info = ManagerService.GetUserBaseInfoWithPage(query, pageindex, pagesize, ref pageCount);
                if (!info.Result)
                    return new ErrType(ERR.SERVICE, info.Desc);

                clientList = info.TdUserList.Select(MyConverter.ToClientAccount).ToList();
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
                return new ErrType(ERR.EXEPTION, ErrorText.GetClientInfoError);
            }
        }


        /// <summary>
        /// 客户资料分页查询
        /// </summary>
        /// <param name="Cxqc">查询条件</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="pagesize">输出参数：总页数</param>
        /// <returns></returns>
        public ClientUserBaseInfo GetUserBaseInfoWithPage(UserQueryConInfomation Uqc, int pageindex, int pagesize, ref int pageCount)
        {
            ClientUserBaseInfo cinfo = new ClientUserBaseInfo();
            try
            {

                UserQueryCon query = MyConverter.ToUserQueryCon(Uqc);
                UserBaseInfo info = ManagerService.GetUserBaseInfoWithPage(query, pageindex, pagesize, ref pageCount);
                cinfo.Result = info.Result;
                cinfo.Desc = info.Desc;
                cinfo.FrozenMoney = info.FrozenMoney;
                cinfo.DongJieMoney = info.DongJieMoney;
                cinfo.Money = info.Money;
                cinfo.OccMoney = info.OccMoney;
                info.TdUserList.ForEach(p => cinfo.TdUserList.Add(MyConverter.ToClientAccount(p)));

            }
            catch (TimeoutException te)
            {
                cinfo.Result = false;
                cinfo.Desc = te.Message;
            }
            catch (Exception ex)
            {
                cinfo.Result = false;
                cinfo.Desc = ErrorText.GetClientInfoError;
            }
            return cinfo;

        }
        #endregion

        #region 日志记录分页查询 马友春

        /// <summary>
        /// 日志记录分页查询
        /// </summary>
        /// <param name="Cxqc">查询条件</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="pagesize">输出参数：总页数</param>
        /// <param name="page">返回列表</param>
        /// <returns></returns>
        public ErrType GetTradeALogInfoWithPage(LogQueryConInfomation Uqc, int pageindex, int pagesize, ref int pageCount, out List<LogInformation> logInfoes)
        {
            logInfoes = null;
            try
            {
                LogQueryCon query = MyConverter.ToLogQueryCon(Uqc);
                TradeALogInfo info = ManagerService.GetTradeALogInfoWithPage(query, pageindex, pagesize, ref pageCount);
                if (!info.Result)
                    return new ErrType(ERR.SERVICE, info.Desc);

                logInfoes = info.ALogList.Select(MyConverter.ToLogInfo).ToList();
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                return new ErrType(ERR.EXEPTION, ErrorText.GetLogInfo);
            }
        }
        #endregion

        #region 对冲

        public ClientHedgingInfo GetHedgingTradeList(string loginID, ACCOUNT_TYPE accType, RequestInformationBase requestInfo)
        {
            ClientHedgingInfo cinfo = new ClientHedgingInfo();
            try
            {
                HedgingInfo info = _managerService.GetHedgingInfo(loginID, requestInfo.StartTime, requestInfo.EndTime);
                cinfo.Desc = info.Desc;
                cinfo.ProfitValue = info.ProfitValue;
                cinfo.Quantity = info.Quantity;
                cinfo.Result = info.Result;
                cinfo.Storagefee = info.StorageFee;
                cinfo.Tradefee = info.TradeFee;
                //info.HedgingList.ForEach(p => cinfo.LTdOrderList.Add(MyConverter.ToHedgingTradeData(p)));
                string PreviousName = "";
                for (int i = 0; i < info.HedgingList.Count; i++)
                {
                    if (info.HedgingList[i].ProductName == PreviousName)
                    {
                        MyConverter.ToHedgingTradeData2(info.HedgingList[i], cinfo.LTdOrderList[cinfo.LTdOrderList.Count - 1]);
                    }
                    else
                    {
                        cinfo.LTdOrderList.Add(MyConverter.ToHedgingTradeData(info.HedgingList[i]));
                        cinfo.LTdOrderList[cinfo.LTdOrderList.Count - 1].OrderType2 = null;
                    }
                    PreviousName = info.HedgingList[i].ProductName;
                }


            }
            catch (TimeoutException te)
            {
                cinfo.Result = false;
                cinfo.Desc = ErrorText.TimeoutException;
            }
            catch (Exception ex)
            {
                cinfo.Result = false;
                cinfo.Desc = ErrorText.GetHedgingTradeList;
            }
            return cinfo;
        }
        #endregion

        #region 资金相关
        /// <summary>
        /// 获取出金信息
        /// </summary>
        /// <param name="Cjqc">查询条件</param>
        /// <param name="pageindex">页索引</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="pageCount">页总数</param>
        /// <param name="list">返回列表</param>
        /// <returns>ErrType</returns>
        public ClientTradeChuJinInfo GetMultiTradeChuJinWithPage(CJQueryConInfomation Cjqc, int pageindex, int pagesize, ref int pageCount)
        {
            ClientTradeChuJinInfo cinfo = new ClientTradeChuJinInfo();
            try
            {
                CJQueryCon query = MyConverter.ToCJQueryCon(Cjqc);
                TradeChuJinInfo info = ManagerService.GetMultiTradeChuJinWithPage(query, pageindex, pagesize, ref pageCount);
                if (info.Result)
                {
                    cinfo.Result = info.Result;
                    cinfo.Desc = info.Desc;
                    cinfo.AMT = info.Amt;
                    cinfo.AMT2 = info.Amt2;
                    cinfo.AMT3 = info.Amt3;
                    info.TdChuJinList.ForEach(p => cinfo.TOrderLst.Add(MyConverter.ToChuJinInfo(p)));
                }
                else
                {
                    cinfo.Result = cinfo.Result;
                    cinfo.Desc = info.Desc;
                }
            }
            catch (TimeoutException te)
            {
                cinfo.Result = cinfo.Result;
                cinfo.Desc = ErrorText.TimeoutException;
            }
            catch (Exception ex)
            {
                cinfo.Result = cinfo.Result;
                cinfo.Desc = ErrorText.QueryError;
            }
            return cinfo;
        }

        /// <summary>
        /// 出金处理
        /// </summary>
        /// <param name="ApplyId">出金申请ID</param>
        /// <param name="LoginId">登陆ID</param>
        /// <param name="state">处理状态，"1"-已付款,"2"已拒绝 "3"处理中 "4"处理失败</param>
        /// <returns>ErrType</returns>
        public ErrType ProcessChuJin(int ApplyId, String LoginId, ref string state)
        {
            try
            {

                ResultDesc desc = ManagerService.ProcessChuJin(ApplyId, LoginId, ref state);

                if (!desc.Result)
                    return new ErrType(ERR.SERVICE, desc.Desc);

                ErrType rst = new ErrType(ERR.SUCCESS);
                rst.Dec = desc.Desc;//描述为3的时候，代表状态为正在处理
                return rst;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }

        }
        /// <summary>
        /// 出金拒绝
        /// </summary>
        /// <param name="ApplyId">出金申请ID</param>
        /// <param name="LoginId">登陆ID</param>
        /// <returns>ErrType</returns>
        public ErrType RefusedChuJin(int ApplyId, String LoginId)
        {
            try
            {
                ResultDesc desc = ManagerService.RefusedChuJin(ApplyId, LoginId);

                if (!desc.Result)
                    return new ErrType(ERR.SERVICE, desc.Desc);

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }

        }

        /// <summary>
        /// 获取资金报表
        /// </summary>
        /// <param name="Fcqc">查询条件</param>
        /// <param name="pageindex">第几页,从1开始</param>
        /// <param name="pagesize">每页多少条</param>
        /// <param name="pageCount">输出参数(总页数)</param>
        /// <param name="list">List<FundChangeInformation></param>
        /// <returns>ErrType</returns>
        public ClientFundChangeInfo GetMultiFundChangeWithPage(FcQueryConInfomation Fcqc, int pageindex, int pagesize, ref int pageCount)
        {
            ClientFundChangeInfo cinfo = new ClientFundChangeInfo();
            try
            {
                FcQueryCon query = MyConverter.ToFcQueryCon(Fcqc);
                FundChangeInfo info = ManagerService.GetMultiFundChangeWithPage(query, pageindex, pagesize, ref pageCount);

                if (info.Result)
                {
                    cinfo.Result = info.Result;
                    cinfo.Desc = info.Desc;
                    cinfo.AMT = info.Amt;
                    cinfo.AMT2 = info.Amt2;
                    cinfo.AMT3 = info.Amt3;
                    cinfo.AMT4 = info.Amt4;
                    cinfo.AMT5 = info.Amt5;
                    cinfo.AMT6 = info.Amt6;
                    info.FundChangeList.ForEach(p => cinfo.TOderLst.Add(MyConverter.ToFundChangeInfo(p)));

                }
                else
                {
                    cinfo.Result = false;
                    cinfo.Desc = info.Desc;
                }
            }
            catch (TimeoutException te)
            {
                cinfo.Result = false;
                cinfo.Desc = ErrorText.TimeoutException;
            }
            catch (Exception ex)
            {
                cinfo.Result = false;
                cinfo.Desc = ErrorText.QueryError;
            }
            return cinfo;
        }
        #endregion

        #region 	交割单[买跌]分页查询 马友春
        /// <summary>
        /// 交割单[买跌]分页查询 马友春
        /// </summary>
        public ErrType GetMultiTradeChcekWithPage(CxQueryConInfomation query, int pageindex,
            int pagesize, ref int pageCount, ref List<BzjRecoverOrder> bzjRecoverOrderList)
        {
            try
            {
                //Todo:金通网待处理
                #region MyRegion
                //bzjRecoverOrderList.Clear();
                //CxQueryCon Cxqc = MyConverter.ToCxQueryCon(query);
                //RecoverOrderInfo info = ManagerService.GetMultiTradeChcekWithPage(Cxqc, pageindex, pagesize, ref pageCount);
                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc);
                //if (info.RecoverOrderList != null)
                //{
                //    bzjRecoverOrderList = info.RecoverOrderList.Select(MyConverter.ToBzjRecoverOrder).ToList();
                //    bzjRecoverOrderList.OrderByDescending(p => p.OverPrice);
                //} 
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
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        }
        #endregion

        #region 	交割单[买跌]处理
        /// <summary>
        /// 交割单[买跌]处理
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="PayTime">付款时间</param>
        /// <param name="LoginId"></param>
        /// <param name="UserType">操作用户类型</param>
        /// <returns></returns>
        public ErrType ModifyTradeCheck(string orderid, DateTime PayTime, string LoginId, int UserType)
        {
            try
            {
                //Todo:金通网待处理
                #region MyRegion
                //ResultDesc info = ManagerService.ModifyTradeCheck(orderid, PayTime, LoginId, UserTypeInfo);
                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc); 
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
        #endregion

        #region 	买跌检测（买跌单）
        /// <summary>
        ///  买跌检测（买跌单）
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="realWeight">实际克重</param>
        /// <param name="LoginId"></param>
        /// <param name="UserType">操作用户类型</param>
        /// <returns></returns>
        public ErrType RecordRealWeight(string orderid, double realWeight, string LoginId, int UserType)
        {
            try
            {
                //Todo:金通网待处理
                #region MyRegion
                //ResultDesc info = ManagerService.RecordRealWeight(orderid, realWeight, LoginId, UserTypeInfo);
                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc); 
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
        #endregion

        #region 店员资料分页查询
        /// <summary>
        /// 店员资料分页查询
        /// </summary>
        public ErrType GetClerkBaseInfoWithPage(BzjClerkQueryCon Cqc, int pageindex,
            int pagesize, ref int pageCount, ref ObservableCollection<BzjClerk> bzjClerkList)
        {

            try
            {
                //Todo:金通网待处理
                #region MyRegion
                //bzjClerkList.Clear();
                //ClerkQueryCon con = MyConverter.ToClerkQueryCon(Cqc);
                //ClerkBaseInfo info = ManagerService.GetClerkBaseInfoWithPage(con, pageindex, pagesize, ref pageCount);
                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc);
                //bzjClerkList = new ObservableCollection<BzjClerk>(info.ClerkList.Select(MyConverter.ToBzjClerk)); 
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
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        }
        #endregion

        #region 新增店员

        /// <summary>
        /// 新增店员
        /// </summary>
        /// <param name="bzjClerk">店员信息</param>
        /// <param name="bzjAuth">店员权限信息</param>
        /// <param name="LoginId">登录标识</param>
        /// <param name="UserType">登录用户类型</param>
        /// <returns></returns>
        public ErrType AddClerk(BzjClerk bzjClerk, DealerAuthority bzjAuth, string LoginId, int UserType)
        {
            try
            {
                //Todo:金通网待处理
                #region MyRegion
                //Clerk con = MyConverter.ToClerk(bzjClerk);
                //AgentAuth auth = MyConverter.ToAgentAuth(bzjAuth);
                //ResultDesc info = ManagerService.AddClerk(con,auth, LoginId, UserTypeInfo);
                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc); 
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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        #endregion

        #region 店员资料修改
        /// <summary>
        /// 店员资料修改
        /// </summary>
        /// <param name="bzjClerk">店员信息</param>
        /// <param name="LoginId">登录标识</param>
        /// <param name="UserType">登录用户类型</param>
        public ErrType ModifyClerk(BzjClerk bzjClerk, string LoginId, int UserType)
        {
            try
            {
                //Todo:金通网待处理
                #region MyRegion
                //Clerk con = MyConverter.ToClerk(bzjClerk);
                //ResultDesc info = ManagerService.ModifyClerk(con, LoginId, UserTypeInfo);
                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc); 
                #endregion

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        #endregion

        #region 店员资料修改
        /// <summary>
        /// 店员资料修改
        /// </summary>
        /// <param name="clerkId">店员账号</param>
        /// <param name="LoginId">登录标识</param>
        /// <param name="UserType">登录用户类型</param>
        public ErrType DelClerk(string clerkId, string LoginId, int UserType)
        {
            try
            {
                //Todo:金通网待处理
                #region MyRegion
                //ResultDesc info = ManagerService.DelClerk(clerkId, LoginId, UserTypeInfo);
                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc); 
                #endregion

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        #endregion

        #region 获取店员权限
        /// <summary>
        /// 获取店员权限
        /// </summary>
        /// <param name="clerkId">店员账号</param>
        /// <param name="LoginId">登录标识</param>
        /// <param name="UserType">登录用户类型</param>
        /// <param name="bzjClerkAuth">权限</param>
        /// <returns></returns>
        public ErrType GetClerkAuth(string clerkId, string LoginId, int UserType, ref DealerAuthority bzjClerkAuth)
        {
            try
            {
                //Todo:金通网待处理
                #region MyRegion
                //ClerkAuthInfo info = ManagerService.GetClerkAuth(clerkId, LoginId, UserTypeInfo);

                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc);
                //AgentAuth auth = info.AtAuth;
                //bool sfsf = auth.ChuRuManage;
                //bzjClerkAuth = MyConverter.ToDealerAuthority(auth);
                //bool ss = bzjClerkAuth.AllowCashIO; 
                #endregion
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        }

        #endregion

        #region 店员权限修改
        /// <summary>
        /// 店员权限修改
        /// </summary>
        /// <param name="bzjAuth">权限信息</param>
        /// <param name="clerkId">店员账号</param>
        /// <param name="LoginId">登录标识</param>
        /// <param name="UserType">登录用户类型</param>
        /// <returns></returns>
        public ErrType ModifyClerkAuth(DealerAuthority bzjAuth, string clerkId, string LoginId, int UserType)
        {
            try
            {
                //Todo:金通网待处理
                #region MyRegion
                //AgentAuth auth = MyConverter.ToAgentAuth(bzjAuth);
                //bool sfsf = auth.ChuRuManage;
                //ResultDesc info = ManagerService.ModifyClerkAuth(auth, clerkId, LoginId, UserTypeInfo);
                //if (!info.Result)
                //    return new ErrType(ERR.SERVICE, info.Desc); 
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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        #endregion

        #region 角色权限
        #region 添加角色
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">角色信息</param>
        /// <returns></returns>
        public ErrType AddRole(string loginID, RoleInfo roleInfo)
        {
            try
            {
                RoleEntity info = MyConverter.ToRoleEntity(roleInfo);
                EntityBase result = ManagerService.AddRole(loginID, info);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 删除角色
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">角色ID</param>
        /// <returns></returns>
        public ErrType DeleteRole(string loginID, string roleID)
        {
            try
            {
                EntityBase result = ManagerService.DeleteRole(loginID, roleID);
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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 修改角色
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">角色信息</param>
        /// <returns></returns>
        public ErrType UpdateRole(string loginID, RoleInfo roleInfo)
        {
            try
            {
                RoleEntity info = MyConverter.ToRoleEntity(roleInfo);
                EntityBase result = ManagerService.UpdateRole(loginID, info);
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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 新增角色权限
        /// <summary>
        /// 5.1.5	新增角色权限
        /// 该方法为指定的角色分配指定的权限
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="list">当前角色信息</param>
        /// <param name="roldeID">角色ID</param>
        /// <returns></returns>
        public ErrType AddRolePrivileges(string loginID, ObservableCollection<PrivilegeInfo> list, string roldeID)
        {
            try
            {
                List<RolePrivilegeEntity> entityList = new List<RolePrivilegeEntity>();
                foreach (PrivilegeInfo privilege in list)
                {
                    entityList.Add(new RolePrivilegeEntity()
                                                     {
                                                         RoleID = roldeID,
                                                         PrivilegeId = privilege.PrivilegeId
                                                     });
                }
                EntityBase result = ManagerService.AddRolePrivileges(loginID, entityList, roldeID);

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
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 获取系统所有角色数据
        /// <summary>
        /// 5.1.6	获取系统所有角色数据
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="list">角色信息列表</param>
        /// <returns></returns>
        public ErrType GetRoles(string loginID, ref ObservableCollection<RoleInfo> list)
        {
            try
            {
                list.Clear();
                List<RoleEntity> roleEntityList = new List<RoleEntity>();
                EntityBase result = ManagerService.GetRoles(loginID, ref  roleEntityList);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);
                foreach (RoleEntity entity in roleEntityList)
                {
                    list.Add(MyConverter.ToRoleInfo(entity));
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
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        }
        #endregion

        #region 5.1.7 获取当前角色对应的权限数据
        /// <summary>
        ///5.1.7	获取当前角色对应的权限数据
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">角色ID</param>
        /// <param name="list">权限列表</param>
        /// <returns></returns>
        public ErrType GetPrivilegesRole(string loginID, string roleID, ref ObservableCollection<PrivilegeInfo> list)
        {
            try
            {
                list.Clear();
                List<PrivilegeEntity> roleEntityList = new List<PrivilegeEntity>();
                EntityBase result = ManagerService.GetPrivilegesRole(loginID, roleID, ref  roleEntityList);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);
                foreach (PrivilegeEntity entity in roleEntityList)
                {
                    list.Add(MyConverter.ToPrivilegeInfo(entity));
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
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        }
        #endregion

        #region 5.2.10	根据用户ID获取所有用户权限集合
        /// <summary>
        /// 5.2.10	根据用户ID获取所有用户权限集合
        /// </summary>
        /// <param name="loginID">登录标识ID</param>
        /// <param name="userID">用户ID</param>
        /// <param name="userPrivilegesInfo">权限</param>
        /// <returns></returns>
        public ErrType UserRolePrivileges(string loginID, string userID, ref UserPrivilegesInfo userPrivilegesInfo)
        {
            try
            {
                List<PrivilegeEntity> list = new List<PrivilegeEntity>();
                EntityBase result = ManagerService.UserRolePrivileges(loginID, userID, ref  list);

                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);
                userPrivilegesInfo = MyConverter.ToUserPrivilegesInfo(list);
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        }
        #endregion

        #region 权限新增
        /// <summary>
        ///5.2.1权限新增
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">权限信息</param>
        /// <returns></returns>
        public ErrType AddPrivileges(string loginID, PrivilegeInfo privilegeInfo)
        {
            try
            {
                PrivilegeEntity privilegeEntity = MyConverter.ToPrivilegeEntity(privilegeInfo);

                EntityBase result = ManagerService.AddPrivileges(loginID, privilegeEntity);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 	修改权限数据
        /// <summary>
        ///5.2.2	修改权限数据
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">权限信息</param>
        /// <returns></returns>
        public ErrType UpdatePrivileges(string loginID, PrivilegeInfo privilegeInfo)
        {
            try
            {
                PrivilegeEntity privilegeEntity = MyConverter.ToPrivilegeEntity(privilegeInfo);

                EntityBase result = ManagerService.UpdatePrivileges(loginID, privilegeEntity);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 	权限删除
        /// <summary>
        ///5.2.3	权限删除
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">权限ID</param>
        /// <returns></returns>
        public ErrType DeletePrivileges(string loginID, string privilegeID)
        {
            try
            {

                EntityBase result = ManagerService.DeletePrivileges(loginID, privilegeID);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 	获取所有用户权限集合
        /// <summary>
        ///5.2.11	获取所有用户权限集合
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">权限信息列表</param>
        /// <returns></returns>
        public ErrType GetPrivileges(string loginID, ref ObservableCollection<PrivilegeInfo> privilegeInfoList)
        {
            try
            {
                List<PrivilegeEntity> privilegeEntityList = new List<PrivilegeEntity>();
                EntityBase result = ManagerService.GetPrivileges(loginID, ref privilegeEntityList);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);
                foreach (PrivilegeEntity entity in privilegeEntityList)
                {
                    privilegeInfoList.Add(MyConverter.ToPrivilegeInfo(entity));
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
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        }
        #endregion

        #region 新增用户角色
        /// <summary>
        /// 5.4.1	新增用户角色
        /// </summary>
        /// <param name="loginID">登录标识ID</param>
        /// <param name="roleID">角色ID</param>
        /// <param name="userID">用户ID</param>
        /// <returns>ErrType</returns>
        public ErrType AddUserRole(string loginID, string roleID, string userID)
        {
            try
            {
                UserRoleEntity userRoleEntity = new UserRoleEntity();
                userRoleEntity.RoleID = roleID;
                userRoleEntity.UserId = userID;

                EntityBase result = ManagerService.AddUserRole(loginID, userRoleEntity);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 删除用户角色
        /// <summary>
        /// 5.4.2	删除用户角色
        /// </summary>
        /// <param name="loginID">登录标识ID</param>
        /// <param name="userID">用户ID</param>
        /// <returns>ErrType</returns>
        public ErrType DeleteUserRole(string loginID, string userID)
        {
            try
            {
                EntityBase result = ManagerService.DeleteUserRole(loginID, userID);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 用户角色修改
        /// <summary>
        /// 5.4.3	用户角色修改
        /// </summary>
        /// <param name="loginID">登录标识ID</param>
        /// <param name="roleID">角色ID</param>
        /// <param name="userID">用户ID</param>
        /// <returns>ErrType</returns>
        public ErrType UpdateUserRole(string loginID, string roleID, string userID)
        {
            try
            {
                UserRoleEntity userRoleEntity = new UserRoleEntity();
                userRoleEntity.RoleID = roleID;
                userRoleEntity.UserId = userID;
                EntityBase result = ManagerService.UpdateUserRole(loginID, userRoleEntity);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 读取用户角色
        /// <summary>
        /// 5.4.4	读取用户角色
        /// </summary>
        /// <param name="loginID">登录标识ID</param>
        /// <param name="userID">用户ID</param>
        /// <param name="roleID">角色ID</param>
        /// <returns>ErrType</returns>
        public ErrType ReadUserRole(string loginID, string userID, ref string roleID)
        {
            try
            {
                UserRoleEntity userRoleEntity = ManagerService.ReadUserRole(loginID, userID);
                if (!userRoleEntity.Result)
                    return new ErrType(ERR.SERVICE, userRoleEntity.Desc);
                roleID = userRoleEntity.RoleID;
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        }
        #endregion
        #endregion

        #region 微会员相关 马友春
        /// <summary>
        /// 获取父级微会员名称及ID
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public ErrType GetBaseOrgListAll(string loginID, ref ObservableCollection<OrgInfo> list)
        {
            try
            {
                List<OrgEntity> eList = new List<OrgEntity>();
                EntityBase result = ManagerService.GetBaseOrgListAll(loginID, ref eList);
                foreach (OrgEntity entity in eList)
                {
                    list.Add(MyConverter.ToOrgInfo(entity));
                }
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        }

        #region 获取微会员列表
        /// <summary>
        /// 获取微会员列表
        /// </summary>
        /// <param name="loginID">登录标识ID</param>
        /// <param name="orgInfo">会员账户信息</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="pageCount">页总数</param>
        /// <param name="list">会员账户信息列表</param>
        /// <returns></returns>
        public ErrType GetOrgList(string loginID, OrgInfo orgInfo, int pageindex, int pagesize, ref int pageCount, ref ObservableCollection<OrgInfo> list)
        {
            try
            {
                List<OrgEntity> eList = new List<OrgEntity>();
                OrgEntity orgEntity = MyConverter.ToOrgEntity(orgInfo);
                EntityBase result = ManagerService.GetOrgList(loginID, orgEntity, pageindex, pagesize, ref pageCount, ref eList);
                foreach (OrgEntity entity in eList)
                {
                    list.Add(MyConverter.ToOrgInfo(entity));
                }
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        }
        #endregion

        #region 添加微会员
        /// <summary>
        /// 添加微会员
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">会员账户信息</param>
        /// <returns></returns>
        public ErrType AddOrg(string loginID, OrgInfo orgInfo)
        {
            try
            {
                OrgEntity orgEntity = MyConverter.ToOrgEntity(orgInfo);

                EntityBase result = ManagerService.AddOrg(loginID, orgEntity);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }

        /// <summary>
        /// 创建微会员代码
        /// </summary>
        /// <param name="orgid">微会员ID</param>
        /// <param name="telephone"></param>
        /// <param name="orgCode">返回参数，机构代码</param>
        public ErrType GetOrgcode(string orgid, string telephone, ref string orgCode)
        {
            try
            {
                orgCode = ManagerService.GetOrgcode(orgid, telephone);
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 删除微会员
        /// <summary>
        /// 删除微会员
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">会员账户ID</param>
        /// <param name="orgName">会员账户名称</param>
        /// <returns></returns>
        public ErrType DeleteOrg(string loginID, string orgID, string orgName)
        {
            try
            {
                EntityBase result = ManagerService.DeleteOrg(loginID, orgID, orgName);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 更新微会员
        /// <summary>
        /// 更新微会员
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">会员账户信息</param>
        /// <returns></returns>
        public ErrType UpdateOrg(string loginID, OrgInfo orgInfo)
        {
            try
            {
                OrgEntity orgEntity = MyConverter.ToOrgEntity(orgInfo);
                EntityBase result = ManagerService.UpdateOrg(loginID, orgEntity);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion





        #region 为会员账户绑定微会员 弃用
        /// <summary>
        /// 5.3.6	新增绑定帐号
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">会员账户信息</param>
        /// <returns></returns>
        public ErrType AddOrgUser(string loginID, string orgID, string account, bool state)
        {
            try
            {
                OrgUserEntity orgUserEntity = new OrgUserEntity();
                orgUserEntity.OrgID = orgID;
                orgUserEntity.Account = account;
                orgUserEntity.Status = state ? Status.Enabled : Status.Disable;//Enabled=1,//启用
                EntityBase result = ManagerService.AddOrgUser(loginID, orgUserEntity);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 解除微会员绑定 弃用
        /// <summary>
        /// 5.3.7	删除绑定帐号
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">会员账户信息</param>
        /// <returns></returns>
        public ErrType DeleteOrgUser(string loginID, string userID)
        {
            try
            {
                EntityBase result = ManagerService.DeleteOrgUser(loginID, userID);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
               new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 重新绑定微会员 弃用
        /// <summary>
        /// 5.3.8	修改绑定帐号
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="orgID">会员账户信息</param>
        /// <param name="account">微会员名</param>
        /// <param name="state">启用状态</param>
        /// <returns></returns>
        public ErrType UpdateOrgUser(string loginID, string orgID, string account, bool state)
        {
            try
            {
                OrgUserEntity orgUserEntity = new OrgUserEntity();
                orgUserEntity.OrgID = orgID;
                orgUserEntity.Account = account;
                orgUserEntity.Status = state ? Status.Enabled : Status.Disable;//Enabled=1,//启用
                EntityBase result = ManagerService.UpdateOrgUser(loginID, orgUserEntity);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);

                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 获取会员账户绑定的微会员 弃用
        /// <summary>
        /// 5.3.9	读取绑定帐号
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="account">账户名</param>
        ///  <param name="orgID">绑定的微会员ID</param>
        /// <returns></returns>
        public ErrType ReadOrgUsers(string loginID, string account, ref string orgID)
        {
            try
            {
                OrgUserEntity result = ManagerService.ReadOrgUser(loginID, account);
                if (!result.Result)
                    return new ErrType(ERR.SERVICE, result.Desc);
                orgID = result.OrgID;
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        }
        #endregion

        #endregion

        #region 解约
        /// <summary>
        /// 获取解约
        /// </summary>
        /// <param name="Cjqc"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="pageCount"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        ErrType IBusinessServiceProvider.GetMultiTerminationWithPage(CJQueryConInfomation Cjqc, int pageindex, int pagesize, ref int pageCount, out List<Gss.Entities.TradeManager.TradeJieYue> list)
        {
            list = null;
            try
            {
                JYQueryCon query = MyConverter.ToJYQueryCon(Cjqc);
                TradeJieYueInfo info = ManagerService.GetMultiTradeJieYueWithPage(query, pageindex, pagesize, ref pageCount);

                if (!info.Result)
                    return new ErrType(ERR.SERVICE, info.Desc);
                if (info.TdJieYueList != null)
                    list = info.TdJieYueList.Select(MyConverter.ToTradeJieYue).ToList();
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        }
        /// <summary>
        /// 审核解约
        /// </summary>
        /// <param name="ApplyId"></param>
        /// <param name="LoginId"></param>
        /// <returns></returns>
        public ErrType ProcessJieYue(int ApplyId, string userid, string LoginId)
        {
            try
            {
                var info = ManagerService.ProcessJieYue(ApplyId, userid, LoginId);

                if (!info.Result)
                    return new ErrType(ERR.SERVICE, info.Desc);
                else
                {
                    return GeneralErr.Success;
                }

            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
              new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        /// <summary>
        /// 拒绝解约
        /// </summary>
        /// <param name="ApplyId"></param>
        /// <param name="LoginId"></param>
        /// <returns></returns>
        public ErrType RefusedJieYue(int ApplyId, string LoginId)
        {
            try
            {
                var info = ManagerService.RefusedJieYue(ApplyId, LoginId);

                if (!info.Result)
                    return new ErrType(ERR.SERVICE, info.Desc);
                else
                {

                    return GeneralErr.Success;
                }

            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name,
             new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.OperationError);
            }
        }
        #endregion

        #region 获取出入金和解约信息
        /// <summary>
        /// 获取出入金和解约信息
        /// </summary>
        /// <param name="moneyList">ref List<TradeMoneyData></param>
        /// <returns>ErrType</returns>
        public ErrType GetTradeMoneyInfo(ref List<TradeMoneyData> moneyList)
        {
            try
            {
                #region MyRegion
                TradeMoneyInfo info = ManagerService.GetTradeMoneyInfo();

                if (!info.Result)
                    return new ErrType(ERR.SERVICE, info.Desc);
                List<TradeMoney> rList = info.TradeMoneyList;
                moneyList = MyConverter.TradeMoneyData(info.TradeMoneyList);
                #endregion
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        }
        #endregion
        
        #region
        public ClientFundChangeInfo GetMultiFundChangeWithPage(CxQueryConInfomation Fcqc, int pageindex, int pagesize, ref int page)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 获取银行列表
        /// <summary>
        /// 获取银行列表
        /// </summary>
        /// <returns></returns>
        public ErrType GetTradeBank(ObservableCollection<Bank> banks)
        {
            try
            {
                if (banks == null)
                {
                    banks = new ObservableCollection<Bank>();
                }
                banks.Clear();

                List<TradeBank> rst = ManagerService.GetTradeBank();
                rst.ForEach(p => banks.Add(new Bank() { BankCode = p.ConBankType, BankName = p.BankName }));
                return GeneralErr.Success;
            }
            catch (TimeoutException te)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, te.Message); return new ErrType(ERR.EXEPTION, ErrorText.TimeoutException);
            }
            catch (Exception ex)
            {
                FileLog.WriteLog("", Assembly.GetExecutingAssembly().GetName().Name, this.GetType().Name, new StackTrace().GetFrame(0).GetMethod().Name, ex.Message);
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        } 
        #endregion

        #region 创建微会员二维码
        /// <summary>
        /// 创建微会员二维码
        /// </summary>
        /// <param name="orgId">微会员ID</param>
        /// <returns>ErrType</returns>
        public ErrType CreateOrgTicket(string orgId)
        {
            try
            {
                createRequest request = new createRequest(orgId);
                createResponse response = OrgTicketService.create(request);
                var ret = response.createReturn;
                if (ret.ToString() == "true")
                    return GeneralErr.Success;
                else
                    return GeneralErr.Error;
            }
            catch (Exception e)
            {
                return GeneralErr.Error;
            }
        } 
        #endregion
        
        #region 体验券相关
        /// <summary>
        /// 获取体验券信息
        /// </summary>
        /// <param name="loginId">登录标识</param>
        /// <param name="type">类型</param>
        /// <param name="isEffciive">是否启用</param>
        /// <param name="endTime">到期时间</param>
        /// <param name="list">ObservableCollection<ExperienceInformation></param>
        /// <returns>ErrType</returns>
        public ErrType GetExperienceInfo(string loginId, int type, int isEffciive, DateTime? endTime, ref ObservableCollection<ExperienceInformation> list)
        {
            try
            {
                if (list == null)
                {
                    list = new ObservableCollection<ExperienceInformation>();
                }
                list.Clear();

                ExperienceInfo rst = ManagerService.GetExperienceInfo(loginId, type, isEffciive, endTime);
                if (rst.Result == false)
                    return GeneralErr.Error;
                foreach (Experience ex in rst.ExperienceList)
                {
                    ExperienceInformation exp = new ExperienceInformation();
                    exp.Id = ex.Id;
                    exp.Name = ex.Name;
                    exp.Type = ex.Type;
                    exp.Annount = ex.Annount;
                    exp.Rceharge = ex.Rceharge;
                    exp.Num = ex.Num;
                    exp.StartDate = ex.StartDate;
                    exp.EndDate = ex.EndDate;
                    exp.CreatID = ex.CreatID;
                    exp.Effective = ex.Effective == 0 ? 1 : 0;
                    exp.EffectiveTime = ex.EffectiveTime;
                    list.Add(exp);
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
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        }

        /// <summary>
        /// 添加体验券
        /// </summary>
        /// <param name="loginId">登录标识</param>
        /// <param name="ex">体验券</param>
        /// <returns>ResultDesc</returns>
        public ErrType AddExperience(string loginId, ExperienceInformation ex)
        {
            try
            {
                Experience exp = new Experience();
                exp.Name = ex.Name;
                exp.Type = ex.Type;
                exp.Annount = ex.Annount;
                exp.Rceharge = ex.Rceharge;
                exp.Num = ex.Num;
                exp.StartDate = ex.StartDate;
                exp.EndDate = ex.EndDate;
                exp.CreatID = ex.CreatID;
                exp.Effective = ex.Effective == 0 ? 1 : 0;
                exp.EffectiveTime = ex.EffectiveTime;
                ResultDesc desc = ManagerService.AddExperience(loginId, exp);
                if (desc.Result)
                    return GeneralErr.Success;
                else
                    return GeneralErr.Error;
            }
            catch (Exception e)
            {
                return GeneralErr.Error;
            }
        }

        /// <summary>
        /// 编辑体验券
        /// </summary>
        /// <param name="loginId">登录标识</param>
        /// <param name="ex">体验券</param>
        /// <returns>ResultDesc</returns>
        public ErrType EditExperience(string loginId, ExperienceInformation ex)
        {
            try
            {
                Experience exp = new Experience();
                exp.Id = ex.Id;
                exp.Name = ex.Name;
                exp.Type = ex.Type;
                exp.Annount = ex.Annount;
                exp.Rceharge = ex.Rceharge;
                exp.Num = ex.Num;
                exp.StartDate = ex.StartDate;
                exp.EndDate = ex.EndDate;
                exp.CreatID = ex.CreatID;
                exp.Effective = ex.Effective == 0 ? 1 : 0;
                exp.EffectiveTime = ex.EffectiveTime;
                ResultDesc desc = ManagerService.EditExperience(loginId, exp);
                if (desc.Result)
                    return GeneralErr.Success;
                else
                    return GeneralErr.Error;
            }
            catch (Exception e)
            {
                return GeneralErr.Error;
            }
        }

        /// <summary>
        /// 删除体验券
        /// </summary>
        /// <param name="loginId">登录标识</param>
        /// <param name="id">体验券标识</param>
        /// <returns>ResultDesc</returns>
        public ErrType DelExperience(string loginId, int id)
        {
            try
            {
                ResultDesc desc = ManagerService.DelExperience(loginId, id);
                if (desc.Result)
                    return GeneralErr.Success;
                else
                    return GeneralErr.Error;
            }
            catch (Exception e)
            {
                return GeneralErr.Error;
            }
        } 
        #endregion
        
        #region 广告相关
        /// <summary>
        /// 广告查询
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="sTime"></param>
        /// <param name="eTime"></param>
        /// <param name="Name"></param>
        /// <param name="Creater"></param>
        /// <param name="State"></param>
        /// <param name="list"></param>
        /// <param name="pageindex">第几页,从1开始</param>
        /// <param name="pagesize">每页多少条</param>
        /// <param name="page">输出参数(总页数)</param>
        /// <returns></returns>
        public ErrType GetAdvertInfoWithPage(string loginId, DateTime sTime, DateTime eTime, string Name, string Creater, int State,
            ref ObservableCollection<AdvertInfo> list, int pageindex, int pagesize, ref int page)
        {
            try
            {
                if (list == null)
                {
                    list = new ObservableCollection<AdvertInfo>();
                }
                list.Clear();
                AdvertLqc lqc = new AdvertLqc();
                lqc.Creator = Creater;
                lqc.EndTime = eTime;
                lqc.LoginID = loginId;
                lqc.Name = Name;
                lqc.StartTime = sTime;
                lqc.Status = State;

                AdvertListInfo rst = ManagerService.GetAdvertInfoWithPage(lqc, pageindex, pagesize, ref page);
                if (rst.Result == false)
                    return GeneralErr.Error;
                foreach (Advert ex in rst.AdvertList)
                {
                    AdvertInfo advert = new AdvertInfo();
                    advert.ID = ex.ID;
                    advert.Creator = ex.Creator;
                    advert.Name = ex.Name;
                    advert.Remark = ex.Remark;
                    advert.CreateDate = ex.CreateDate;
                    advert.Status = ex.Status;
                    advert.Url = ex.Url;
                    list.Add(advert);
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
                return new ErrType(ERR.EXEPTION, ErrorText.QueryError);
            }
        }

        /// <summary>
        /// 添加广告
        /// </summary>
        /// <param name="loginId">登录标识</param>
        /// <param name="info">广告内容</param>
        /// <returns>ErrType</returns>
        public ErrType AddAdvert(string loginId, AdvertInfo info)
        {
            try
            {
                Advert advert = new Advert();
                advert.ID = info.ID;
                advert.Creator = info.Creator;
                advert.Name = info.Name;
                advert.Remark = info.Remark;
                advert.CreateDate = info.CreateDate;
                advert.Status = info.Status;
                advert.Url = info.Url;
                ResultDesc desc = ManagerService.AddAdvert(loginId, advert);
                if (desc.Result)
                    return GeneralErr.Success;
                else
                    return GeneralErr.Error;
            }
            catch (Exception e)
            {
                return GeneralErr.Error;
            }
        }

        /// <summary>
        /// 删除广告
        /// </summary>
        /// <param name="loginId">登录标识</param>
        /// <param name="id">广告标识</param>
        /// <returns>ResultDesc</returns>
        public ErrType DelAdvert(string loginId, string id)
        {
            try
            {
                ResultDesc desc = ManagerService.DelAdvert(loginId, id);
                if (desc.Result)
                    return GeneralErr.Success;
                else
                    return GeneralErr.Error;
            }
            catch (Exception e)
            {
                return GeneralErr.Error;
            }
        }

        /// <summary>
        /// 编辑广告
        /// </summary>
        /// <param name="loginId">登录标识</param>
        /// <param name="info">广告</param>
        /// <returns>ResultDesc</returns>
        public ErrType EditAdvert(string loginId, AdvertInfo info)
        {
            try
            {
                Advert advert = new Advert();
                advert.ID = info.ID;
                advert.Creator = info.Creator;
                advert.Name = info.Name;
                advert.Remark = info.Remark;
                advert.Status = info.Status;
                advert.Url = info.Url;
                ResultDesc desc = ManagerService.EditAdvert(loginId, advert);
                if (desc.Result)
                    return GeneralErr.Success;
                else
                    return GeneralErr.Error;
            }
            catch (Exception e)
            {
                return GeneralErr.Error;
            }
        } 
        #endregion
    }
}
