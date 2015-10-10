using System;
using System.Collections.Generic;
using System.Linq;
using Gss.Common.Utility;
using Gss.Entities;
using Gss.BusinessService.ManagementService;
using Gss.Entities.Enums;
using Gss.Entities.JTWEntityes;
using Gss.Entities.SystemSetting;
using Gss.Entities.TradeManager;

namespace Gss.BusinessService
{
    public static class MyConverter
    {

        internal static LoginResult ToLoginResult(ReAdminAuth mgrResult)
        {
            //Todo:金通网待处理，登陆方法弃用

            #region MyRegion
            //if (mgrResult.LoginID == "-1")
            //{
            return new LoginResult("登陆失败，账号或密码失败");
            //}
            //else
            //{
            //    ManagerAuthority mgrAuthority = ToManagerAuthority(mgrResult.AnAuth);
            //return new LoginResult(mgrResult.LoginID, mgrResult.QuotesAddressIP, mgrResult.QuotesPort, mgrAuthority);
            //} 
            #endregion
        }

        //Todo:金通网待处理，登陆方法弃用
        #region MyRegion
        //internal static LoginResult ToLoginResult(ReAgentAuth dealerResult)
        //{
        //    if (dealerResult.LoginID == "-1")
        //    {
        //        return new LoginResult("登陆失败，账号或密码失败");
        //    }
        //    else
        //    {
        //        DealerAuthority dealerAuthority = ToDealerAuthority(dealerResult.AtAuth);
        //        return new LoginResult(dealerResult.LoginID, dealerResult.QuotesAddressIP, dealerResult.QuotesPort, new ManagerAuthority(dealerAuthority));
        //    }
        //} 
        #endregion

        //Todo:金通网待处理，登陆方法弃用
        #region MyRegion
        //internal static LoginResult ToLoginResult(ReClerkAuth reClerkAuth)
        //{
        //    if (reClerkAuth.LoginID == "-1")
        //    {
        //        return new LoginResult("登陆失败，账号或密码失败");
        //    }
        //    else
        //    {
        //        //Todo:权限待处理，登陆方法弃用
        //        DealerAuthority clerkAuthority = ToDealerAuthority(reClerkAuth.AtAuth);
        //        LoginResult result = new LoginResult(reClerkAuth.LoginID, reClerkAuth.QuotesAddressIP, reClerkAuth.QuotesPort, new ManagerAuthority(clerkAuthority));
        //        result.ClerkAgentId = reClerkAuth.AgentId;
        //        return result;
        //    }
        //} 
        #endregion

        #region TradeUser与 ClientAccount之间的转换

        internal static ClientAccount ToClientAccount(TradeUser user)
        {
            return new ClientAccount
            {
                AccInfo =
                {
                    UserID = user.UserID,
                    OrgId = user.OrgId,
                    AccountName = user.Account,
                    AccountPassword = user.LoginPwd,
                    Address = user.LinkAdress,
                    CellPhoneNumber = user.PhoneNum,
                    CeritificateEnum = ToCertificateEnum(user.CardType),//
                    CertificateNumber = user.CardNum,
                    Contact = user.LinkMan,
                    Email = user.Email,
                    FundsPassword = user.CashPwd,
                    TelephoneNumber = user.TelNum,
                    LastLoginTime = user.LastLoginTime,
                    LastUpdateTime = user.LastUpdateTime,
                    LastUpdateManager = user.LastUpdateID,
                    Legal = user.CorporationName,
                    LoginIP = user.Ip,
                    LoginMAC = user.Mac,
                    IsAccountEnabled = ToBoolean(user.Status),
                    IsOnline = user.Online,
                    OpeningMan = user.OpenMan,
                    OpenAccountTime = user.OpenTime,
                    OrderPhoneNumber = user.OrderPhone,
                    Sex = ToSexEnum(user.Sex),
                    UserName = user.UserName,
                    OrgName = user.OrgName,
                    BindAccount = user.BindAccount,
                    IsEnable = user.IsEnable == 1 ? "激活" : "未激活",
                    Reperson = user.Reperson,
                    Telephone = user.Telephone,
                    IsBroker = user.IsBroker,
                    PAccount = user.PAccount,
                    PUserId = user.PUserId,
                    PUserName = user.PUserName
                },
                FundsInfo =
                {
                    BankAccountName = user.AccountName,
                    BankCardNumber = user.BankCard,
                    BankNumber = user.BankAccount,
                    banktype = user.ConBankType,
                    //ContractStatus = (CONTRACT_STATUS)Enum.Parse(typeof(CONTRACT_STATUS), user.BankState),
                    ContractStatus = string.IsNullOrEmpty(user.BankState) ? CONTRACT_STATUS.Unbound : (CONTRACT_STATUS)Enum.Parse(typeof(CONTRACT_STATUS), user.BankState),//当为管理员账户时无签约状态
                    CurrentBalance = user.Money,
                    FrozenDeposit = user.FrozenMoney,
                    FundsAccount = user.Account,
                    OccupiedDeposit = user.OccMoney,
                    OpenBank = user.OpenBank,
                    SubAccount = user.SubUser,
                    TanAccount = user.TanUser,
                    DongJieMoney = user.DongJieMoney,
                },
                TransactionSettings =
                {
                    MinTrade = user.MinTrade,
                    OrderUnit = user.OrderUnit,
                    MaxTrade = user.MaxTrade,
                    AllowRecharge = user.PermitRcash,
                    AllowEncashment = user.PermitCcash,
                    AllowChargeback = user.PermitDelOrder,
                    AllowOrder = user.PermitDhuo,
                    AllowRecovery = user.PermitHshou,
                    AllowWarehousing = user.PermitRstore,
                },
            };
        }

        internal static TradeUser ToTradeUser(ClientAccount client)
        {
            return new TradeUser
            {
                UserName = client.AccInfo.UserName,
                Status = client.AccInfo.IsAccountEnabled ? "1" : "0",//0禁用，1启用
                AccountType = ((int)client.AccInfo.ClientType).ToString(),
                Account = client.AccInfo.AccountName,
                LoginPwd = client.AccInfo.AccountPassword,
                CashPwd = client.AccInfo.FundsPassword,
                CardType = ((int)client.AccInfo.CeritificateEnum).ToString(),
                CardNum = client.AccInfo.CertificateNumber,
                Sex = ToSexString(client.AccInfo.Sex),
                PhoneNum = client.AccInfo.CellPhoneNumber,
                TelNum = client.AccInfo.TelephoneNumber,
                Email = client.AccInfo.Email,
                LinkMan = client.AccInfo.Contact,
                LinkAdress = client.AccInfo.Address,
                OpenMan = client.AccInfo.OpeningMan,
                OpenTime = client.AccInfo.OpenAccountTime,
                LastUpdateTime = client.AccInfo.LastUpdateTime,
                LastUpdateID = client.AccInfo.LastUpdateManager,
                LastLoginTime = client.AccInfo.LastLoginTime,
                Ip = client.AccInfo.LoginIP,
                Mac = client.AccInfo.LoginMAC,
                Online = client.AccInfo.IsOnline,
                OrderPhone = client.AccInfo.OrderPhoneNumber,

                MinTrade = client.TransactionSettings.MinTrade,
                OrderUnit = client.TransactionSettings.OrderUnit,
                MaxTrade = client.TransactionSettings.MaxTrade,
                PermitRcash = client.TransactionSettings.AllowRecharge,
                PermitCcash = client.TransactionSettings.AllowEncashment,
                PermitDelOrder = client.TransactionSettings.AllowChargeback,
                PermitDhuo = client.TransactionSettings.AllowOrder,
                PermitHshou = client.TransactionSettings.AllowRecovery,
                PermitRstore = client.TransactionSettings.AllowWarehousing,
                CorporationName = client.AccInfo.Legal,

                OrgId = client.AccInfo.OrgId,
                OrgName = client.AccInfo.OrgName,
                BindAccount = client.AccInfo.BindAccount,
                UserID = client.AccInfo.UserID,
                OpenBank = client.FundsInfo.OpenBank,
                BankCard = client.FundsInfo.BankCardNumber
            };
        }

        #endregion


        //Todo:金通网待处理,旧权限弃用
        #region MyRegion
        //internal static DealerAccount ToDealerAccount(AgentUser user, AgentAuth authority)
        //{
        //    DealerAccount dealerAcc = new DealerAccount();
        //    dealerAcc.SyncAccInfo(ToDealerAccInfo(user));
        //    dealerAcc.SyncAuthority(ToDealerAuthority(authority));
        //    return dealerAcc;
        //} 
        #endregion

        #region AgentUser与DealerAccountInformation之间的转换

        //Todo:金通网 弃用
        #region MyRegion
        //internal static DealerAccountInformation ToDealerAccInfo(AgentUser user)
        //{
        //    return new DealerAccountInformation
        //    {
        //        AccountName = user.AgentId,
        //        AccountPassword = user.PassWord,
        //        Company = user.ComName,
        //        Legal = user.Coperson,
        //        CeritificateEnum = ToCertificateEnum(user.CardType),
        //        CertificateNumber = user.CardNum,
        //        ParentDealer = user.Agent,
        //        Reperson = user.Reperson,
        //        CellPhoneNumber = user.PhoneNum,
        //        TelephoneNumber = user.Telephone,
        //        Email = user.Email,
        //        Address = user.Address,
        //        OpenAccountTime = user.AddTime,
        //        LastLoginTime = user.LastLoginTime,
        //        LoginIP = user.Ip,
        //        LoginMAC = user.Mac,
        //        IsAccountEnabled = user.启用,
        //        IsOnline = user.OnLine,
        //        TradeAccount = user.TradeAccount,
        //    };
        //}

        //internal static AgentUser ToAgentUser(DealerAccountInformation dealerAccInfo)
        //{
        //    return new AgentUser
        //    {
        //        AgentId = dealerAccInfo.AccountName,
        //        PassWord = dealerAccInfo.AccountPassword,
        //        ComName = dealerAccInfo.Company,
        //        Coperson = dealerAccInfo.Legal,
        //        CardType = ((int)dealerAccInfo.CeritificateEnum).ToString(),
        //        CardNum = dealerAccInfo.CertificateNumber,
        //        Agent = dealerAccInfo.ParentDealer,
        //        Reperson = dealerAccInfo.Reperson,
        //        PhoneNum = dealerAccInfo.CellPhoneNumber,
        //        Telephone = dealerAccInfo.TelephoneNumber,
        //        Email = dealerAccInfo.Email,
        //        Address = dealerAccInfo.Address,
        //        AddTime = dealerAccInfo.OpenAccountTime,
        //        LastLoginTime = dealerAccInfo.LastLoginTime,
        //        Ip = dealerAccInfo.LoginIP,
        //        Mac = dealerAccInfo.LoginMAC,
        //        启用 = dealerAccInfo.IsAccountEnabled,
        //        OnLine = dealerAccInfo.IsOnline,
        //    };
        //} 
        #endregion

        #endregion

        //Todo:金通网待处理，旧权限弃用
        #region MyRegion
        //internal static ManagerAccount ToManagerAccount(AdminUser user, AdminAuth authority)
        //{
        //    ManagerAccount mgrAcc = new ManagerAccount();
        //    mgrAcc.SyncAccInfo(ToManagerAccInfo(user));
        //    mgrAcc.SyncAuthority(ToManagerAuthority(authority));
        //    return mgrAcc;
        //} 
        #endregion

        #region AdminUser与ManagerAccountInformation之间的转换

        //Todo:金通网待处理
        #region MyRegion
        //internal static ManagerAccountInformation ToManagerAccInfo(AdminUser user)
        //{
        //    return new ManagerAccountInformation
        //    {
        //        AccountName = user.AdminId,
        //        AccountPassword = user.PassWord,
        //        UserName = user.Name,
        //        Sex = ToSexEnum(user.Sex),
        //        IDNumber = user.CardNum,
        //        CellPhoneNumber = user.PhoneNum,
        //        TelephoneNumber = user.Telephone,
        //        Email = user.Email,
        //        Address = user.Address,
        //        OpenAccountTime = user.AddTime,
        //        LastLoginTime = user.LastLoginTime,
        //        LoginIP = user.Ip,
        //        LoginMAC = user.Mac,
        //        IsAccountEnabled = user.启用,
        //        IsOnline = user.OnLine,
        //    };
        //}

        //internal static AdminUser ToAdminUser(ManagerAccountInformation mgrAccInfo)
        //{
        //    return new AdminUser
        //    {
        //        AdminId = mgrAccInfo.AccountName,
        //        PassWord = mgrAccInfo.AccountPassword,
        //        Name = mgrAccInfo.UserName,
        //        Sex = ToSexString(mgrAccInfo.Sex),
        //        CardNum = mgrAccInfo.IDNumber,
        //        PhoneNum = mgrAccInfo.CellPhoneNumber,
        //        Telephone = mgrAccInfo.TelephoneNumber,
        //        Email = mgrAccInfo.Email,
        //        Address = mgrAccInfo.Address,
        //        AddTime = mgrAccInfo.OpenAccountTime,
        //        LastLoginTime = mgrAccInfo.LastLoginTime,
        //        Ip = mgrAccInfo.LoginIP,
        //        Mac = mgrAccInfo.LoginMAC,
        //        启用 = mgrAccInfo.IsAccountEnabled,
        //        OnLine = mgrAccInfo.IsOnline,
        //    };
        //} 
        #endregion

        #endregion

        #region Fundinfo与FundsInformation之间的转换

        internal static FundsInformation ToFundsInformation(Fundinfo info)
        {
            return new FundsInformation
            {
                BankAccountName = info.AccountName,
                BankCardNumber = info.BankCard,
                BankNumber = info.BankAccount,
                banktype = info.ConBankType,
                ContractStatus = (CONTRACT_STATUS)Enum.Parse(typeof(CONTRACT_STATUS), info.State),
                CurrentBalance = info.Money,
                FrozenDeposit = info.FrozenMoney,
                FundsAccount = info.CashUser,
                OccupiedDeposit = info.OccMoney,
                OpenBank = info.OpenBank,
                SubAccount = info.SubUser,
                TanAccount = info.TanUser,
                DongJieMoney = info.DongJieMoney,

            };
        }

        internal static Fundinfo ToFundInfo(FundsInformation fundsInfo)
        {
            return new Fundinfo
            {
                AccountName = fundsInfo.BankAccountName,
                BankCard = fundsInfo.BankCardNumber,
                BankAccount = fundsInfo.BankNumber,
                ConBankType = fundsInfo.banktype,
                State = ((int)fundsInfo.ContractStatus).ToString(),
                Money = fundsInfo.CurrentBalance,
                FrozenMoney = fundsInfo.FrozenDeposit,
                CashUser = fundsInfo.FundsAccount,
                OccMoney = fundsInfo.OccupiedDeposit,
                OpenBank = fundsInfo.OpenBank,
                SubUser = fundsInfo.SubAccount,
                TanUser = fundsInfo.TanAccount,
                DongJieMoney = fundsInfo.DongJieMoney
            };
        }

        #endregion

        #region AgentAuth与DealerAuthority之间的转换

        //Todo:金通网弃用
        #region MyRegion
        //internal static AgentAuth ToAgentAuth(DealerAuthority dealerAuthority)
        //{
        //    if (dealerAuthority != null)
        //        return null;

        //    return new AgentAuth
        //    {
        //        //账户权限管理
        //        IdManage = ToBoolean(dealerAuthority.AccountManager),
        //        UserManage = dealerAuthority.ClientAccountManager,
        //        AgentManage = dealerAuthority.DealerAccountManager,
        //        ReadOnly = dealerAuthority.AccMgrReadonly,

        //        //操作权限
        //        AddUserManage = dealerAuthority.AllowCreateNewAccount,
        //        DelUserManage = dealerAuthority.AllowDeleteClient,
        //        ChuRuManage = dealerAuthority.AllowCashIO,
        //        CashTzManage = dealerAuthority.AllowAdjustmentAmount,
        //        UserInfo = dealerAuthority.AllowViewClientInformation,
        //        TradeInfo = dealerAuthority.AllowViewTradeDetail,

        //        Orders = dealerAuthority.AllowMarketOrder,
        //        OrdersCancel = dealerAuthority.AllowChargebackOrder,
        //        OrdersStore = dealerAuthority.AllowWarehousingOrder,
        //        HoldOrder = dealerAuthority.AllowPendingOrder,
        //        HoldOrderCancel = dealerAuthority.AllowRevocationOrder,

        //        OrderReport = dealerAuthority.MarketOrderStatements,
        //        OrderCancelReport = dealerAuthority.ChargebackStatements,
        //        OrderStoreReport = dealerAuthority.WarehousingStatements,
        //        HoldReport = dealerAuthority.PendingOrderStatements,
        //        MoneyReport = dealerAuthority.AdjustDepositStatements,

        //        //交易管理
        //        TradeManage = ToBoolean(dealerAuthority.IsTradeManagerEnabled),
        //        OrderManage = dealerAuthority.AllowViewMarketOrder,
        //        HoldManage = dealerAuthority.AllowViewPendingOrder,
        //        StoreManage = dealerAuthority.AllowViewWarehousing,
        //        DelManage = dealerAuthority.AllowViewChargebackRecord,
        //        PtoManage = dealerAuthority.AllowViewHedgingTransactions,
        //        ReportManage = dealerAuthority.AllowExportStatement,

        //        //店员
        //        DeliverOrder = dealerAuthority.DeliverOrder,
        //        TihuoOrder = dealerAuthority.TihuoOrder,
        //        HuiGouOrder = dealerAuthority.HuiGouOrder,
        //        JgjOrder = dealerAuthority.JgjOrder,
        //        //TiHuoShouLi = dealerAuthority.TiHuoShouLi,
        //        BangDingUser = dealerAuthority.BangDingUser,
        //        TiHuo = dealerAuthority.TiHuo,
        //        ShouLiMingXi = dealerAuthority.ShouLiMingXi,
        //        CheckManage = dealerAuthority.CheckManage,
        //        CheckDel = dealerAuthority.CheckDel,
        //        AgentClerk = dealerAuthority.AgentClerk,

        //        OrderTakeReport = dealerAuthority.OrderTakeReport,
        //        OrderBackReport = dealerAuthority.OrderBackReport,
        //        OrderCheckReport = dealerAuthority.OrderCheckReport,
        //        JgjReport = dealerAuthority.JgjReport,
        //        AgentDoDetail = dealerAuthority.AgentDoDetail,

        //    };
        //}

        //internal static DealerAuthority ToDealerAuthority(AgentAuth authority)
        //{
        //    if (authority != null)
        //        return null;

        //    DealerAuthority auth = new DealerAuthority();

        //    //账户权限管理
        //    auth.ClientAccountManager = authority.UserManage;
        //    auth.DealerAccountManager = authority.AgentManage;
        //    auth.AccMgrReadonly = authority.ReadOnly;

        //    //操作权限
        //    auth.AllowCreateNewAccount = authority.AddUserManage;
        //    auth.AllowDeleteClient = authority.DelUserManage;
        //    auth.AllowCashIO = authority.ChuRuManage;
        //    auth.AllowAdjustmentAmount = authority.CashTzManage;
        //    auth.AllowViewClientInformation = authority.UserInfo;
        //    auth.AllowViewTradeDetail = authority.TradeInfo;

        //    auth.AllowMarketOrder = authority.Orders;
        //    auth.AllowChargebackOrder = authority.OrdersCancel;
        //    auth.AllowWarehousingOrder = authority.OrdersStore;
        //    auth.AllowPendingOrder = authority.HoldOrder;
        //    auth.AllowRevocationOrder = authority.HoldOrderCancel;

        //    auth.MarketOrderStatements = authority.OrderReport;
        //    auth.ChargebackStatements = authority.OrderCancelReport;
        //    auth.WarehousingStatements = authority.OrderStoreReport;
        //    auth.PendingOrderStatements = authority.HoldReport;
        //    auth.AdjustDepositStatements = authority.MoneyReport;

        //    //交易管理
        //    auth.AllowViewMarketOrder = authority.OrderManage;
        //    auth.AllowViewPendingOrder = authority.HoldManage;
        //    auth.AllowViewWarehousing = authority.StoreManage;
        //    auth.AllowViewChargebackRecord = authority.DelManage;
        //    auth.AllowViewHedgingTransactions = authority.PtoManage;
        //    auth.AllowExportStatement = authority.ReportManage;

        //    //店员
        //    //TradeManage = authority.TradeManage;
        //    auth.DeliverOrder = authority.DeliverOrder;
        //    auth.TihuoOrder = authority.TihuoOrder;
        //    auth.HuiGouOrder = authority.HuiGouOrder;
        //    auth.JgjOrder = authority.JgjOrder;
        //    //TiHuoShouLi = authority.TiHuoShouLi;
        //    auth.BangDingUser = authority.BangDingUser;
        //    auth.TiHuo = authority.TiHuo;
        //    auth.ShouLiMingXi = authority.ShouLiMingXi;
        //    auth.CheckManage = authority.CheckManage;
        //    auth.CheckDel = authority.CheckDel;
        //    auth.AgentClerk = authority.AgentClerk;

        //    auth.OrderTakeReport = authority.OrderTakeReport;
        //    auth.OrderBackReport = authority.OrderBackReport;
        //    auth.OrderCheckReport = authority.OrderCheckReport;
        //    auth.JgjReport = authority.JgjOrder;
        //    auth.AgentDoDetail = authority.AgentDoDetail;
        //    return auth;
        //} 
        #endregion


        #endregion

        #region AdminAuth与ManagerAuthority之间的转换

        //Todo:金通网待处理
        #region MyRegion
        //internal static ManagerAuthority ToManagerAuthority(AdminAuth adminAuthority)
        //{
        //    if (adminAuthority != null)
        //        return null;

        //    return new ManagerAuthority
        //    {
        //        //账户权限管理
        //        ClientAccountManager = adminAuthority.UserManage,
        //        DealerAccountManager = adminAuthority.AgentManage,
        //        AdminAccountManager = adminAuthority.AdminManage,

        //        //操作权限
        //        AllowCreateNewAccount = adminAuthority.AddUserManage,
        //        AllowDeleteClient = adminAuthority.DelUserManage,
        //        AllowCashIO = adminAuthority.ChuRuManage,
        //        AllowAdjustmentAmount = adminAuthority.CashTzManage,
        //        AllowViewClientInformation = adminAuthority.UserInfo,
        //        AllowViewTradeDetail = adminAuthority.TradeInfo,

        //        AllowMarketOrder = adminAuthority.Orders,
        //        AllowChargebackOrder = adminAuthority.OrdersCancel,
        //        AllowPendingOrder = adminAuthority.HoldOrder,
        //        AllowRevocationOrder = adminAuthority.HoldOrderCancel,
        //        AllowWarehousingOrder = adminAuthority.OrdersStore,

        //        MarketOrderStatements = adminAuthority.OrderReport,
        //        ChargebackStatements = adminAuthority.OrderCancelReport,
        //        WarehousingStatements = adminAuthority.OrderStoreReport,
        //        PendingOrderStatements = adminAuthority.HoldReport,
        //        AdjustDepositStatements = adminAuthority.MoneyReport,

        //        //交易管理
        //        AllowViewMarketOrder = adminAuthority.OrderManage,
        //        AllowViewPendingOrder = adminAuthority.HoldManage,
        //        AllowViewWarehousing = adminAuthority.StoreManage,
        //        AllowViewChargebackRecord = adminAuthority.DelManage,
        //        AllowViewHedgingTransactions = adminAuthority.PtoManage,
        //        AllowExportStatement = adminAuthority.ReportManage,

        //        //系统设置
        //        AllowReleaseNews = adminAuthority.NewsManage,
        //        AllowReleaseAnnouncement = adminAuthority.TneManage,
        //        AllowHolidaysSettings = adminAuthority.HolidayManage,
        //        AllowTradingDaySettings = adminAuthority.TdateManage,
        //        AllowViewLog = adminAuthority.LogManage,
        //        AllowTransactionSettings = adminAuthority.TsetManage,
        //        EnableIPAddressFiltering = adminAuthority.IpManage,
        //        EnableMACAddressFiltering = adminAuthority.MacManage,

        //        //数据管理
        //        IsProductManagerEnabled = adminAuthority.ProManage,
        //        IsHistoryDataManagerEnabled = adminAuthority.HIsManage,
        //        ExchangeRateWater = adminAuthority.WaterRate,

        //        //TradeManage = adminAuthority.TradeManage,
        //        DeliverOrder = adminAuthority.DeliverOrder,
        //        TihuoOrder = adminAuthority.TihuoOrder,
        //        HuiGouOrder = adminAuthority.HuiGouOrder,
        //        JgjOrder = adminAuthority.JgjOrder,
        //        //TiHuoShouLi = adminAuthority.TiHuoShouLi,
        //        BangDingUser = adminAuthority.BangDingUser,
        //        TiHuo = adminAuthority.TiHuo,
        //        ShouLiMingXi = adminAuthority.ShouLiMingXi,
        //        CheckManage = adminAuthority.CheckManage,
        //        CheckDel = adminAuthority.CheckDel,
        //        AgentClerk = adminAuthority.AgentClerk,

        //        OrderTakeReport = adminAuthority.OrderTakeReport,
        //        OrderBackReport = adminAuthority.OrderBackReport,
        //        OrderCheckReport = adminAuthority.OrderCheckReport,
        //        JgjReport = adminAuthority.JgjOrder,
        //        AgentDoDetail = adminAuthority.AgentDoDetail

        //    };
        //}

        //internal static AdminAuth ToAdminAuth(ManagerAuthority mgrAuthority)
        //{
        //    if (mgrAuthority != null)
        //        return null;

        //    return new AdminAuth
        //    {
        //        //账户权限管理
        //        IdManage = ToBoolean(mgrAuthority.AccountManager),
        //        UserManage = mgrAuthority.ClientAccountManager,
        //        AgentManage = mgrAuthority.DealerAccountManager,
        //        AdminManage = mgrAuthority.AdminAccountManager,

        //        //操作权限
        //        AddUserManage = mgrAuthority.AllowCreateNewAccount,
        //        DelUserManage = mgrAuthority.AllowDeleteClient,
        //        ChuRuManage = mgrAuthority.AllowCashIO,
        //        CashTzManage = mgrAuthority.AllowAdjustmentAmount,
        //        UserInfo = mgrAuthority.AllowViewClientInformation,
        //        TradeInfo = mgrAuthority.AllowViewTradeDetail,

        //        Orders = mgrAuthority.AllowMarketOrder,
        //        OrdersCancel = mgrAuthority.AllowChargebackOrder,
        //        OrdersStore = mgrAuthority.AllowWarehousingOrder,
        //        HoldOrder = mgrAuthority.AllowPendingOrder,
        //        HoldOrderCancel = mgrAuthority.AllowRevocationOrder,

        //        OrderReport = mgrAuthority.MarketOrderStatements,
        //        OrderCancelReport = mgrAuthority.ChargebackStatements,
        //        OrderStoreReport = mgrAuthority.WarehousingStatements,
        //        HoldReport = mgrAuthority.PendingOrderStatements,
        //        MoneyReport = mgrAuthority.AdjustDepositStatements,

        //        //交易管理
        //        TradeManage = ToBoolean(mgrAuthority.IsTradeManagerEnabled),
        //        OrderManage = mgrAuthority.AllowViewMarketOrder,
        //        HoldManage = mgrAuthority.AllowViewPendingOrder,
        //        StoreManage = mgrAuthority.AllowViewWarehousing,
        //        DelManage = mgrAuthority.AllowViewChargebackRecord,
        //        PtoManage = mgrAuthority.AllowViewHedgingTransactions,
        //        ReportManage = mgrAuthority.AllowExportStatement,

        //        //系统设置
        //        SysManage = ToBoolean(mgrAuthority.IsSystemSettingsEnabled),
        //        NewsManage = mgrAuthority.AllowReleaseNews,
        //        TneManage = mgrAuthority.AllowReleaseAnnouncement,
        //        HolidayManage = mgrAuthority.AllowHolidaysSettings,
        //        TdateManage = mgrAuthority.AllowTradingDaySettings,
        //        LogManage = mgrAuthority.AllowViewLog,
        //        TsetManage = mgrAuthority.AllowTransactionSettings,
        //        IpManage = mgrAuthority.EnableIPAddressFiltering,
        //        MacManage = mgrAuthority.EnableMACAddressFiltering,

        //        //数据管理
        //        DataManage = ToBoolean(mgrAuthority.IsDataManagerEnabled),
        //        ProManage = mgrAuthority.IsProductManagerEnabled,
        //        HIsManage = mgrAuthority.IsHistoryDataManagerEnabled,
        //        WaterRate = mgrAuthority.ExchangeRateWater,

        //        //店员
        //        DeliverOrder = mgrAuthority.DeliverOrder,
        //        TihuoOrder = mgrAuthority.TihuoOrder,
        //        HuiGouOrder = mgrAuthority.HuiGouOrder,
        //        JgjOrder = mgrAuthority.JgjOrder,
        //        //TiHuoShouLi = mgrAuthority.TiHuoShouLi,
        //        BangDingUser = mgrAuthority.BangDingUser,
        //        TiHuo = mgrAuthority.TiHuo,
        //        ShouLiMingXi = mgrAuthority.ShouLiMingXi,
        //        CheckManage = mgrAuthority.CheckManage,
        //        CheckDel = mgrAuthority.CheckDel,
        //        AgentClerk = mgrAuthority.AgentClerk,

        //        OrderTakeReport = mgrAuthority.OrderTakeReport,
        //        OrderBackReport = mgrAuthority.OrderBackReport,
        //        OrderCheckReport = mgrAuthority.OrderCheckReport,
        //        JgjReport = mgrAuthority.JgjOrder,
        //        AgentDoDetail = mgrAuthority.AgentDoDetail

        //    };
        //} 
        #endregion

        #endregion

        #region DateSet与TradingDayInformation之间的转换

        internal static TradingDayInformation ToTradingDayInfo(DateSet dateInfo)
        {
            return new TradingDayInformation
            {
                Week = ToWeekEnum(dateInfo.Weekday),
                StartTime = dateInfo.Starttime,
                EndTime = dateInfo.Endtime,
                AllowTrade = dateInfo.Istrade,
                DescMsg = dateInfo.Desc,
                StockCode = dateInfo.PriceCode,
            };
        }

        internal static DateSet ToDateSet(TradingDayInformation tradingDayInfo)
        {
            return new DateSet
            {
                Weekday = ((int)tradingDayInfo.Week).ToString(),
                Starttime = tradingDayInfo.StartTime,
                Endtime = tradingDayInfo.EndTime,
                Istrade = tradingDayInfo.AllowTrade,
                Desc = tradingDayInfo.DescMsg,
                PriceCode = tradingDayInfo.StockCode,
            };
        }

        #endregion

        #region DateHoliday与HolidayInformation之间的转换

        internal static HolidayInformation ToHolidayInfo(DateHoliday holiday)
        {
            return new HolidayInformation
            {
                HolidayName = holiday.HoliName,
                StartTime = holiday.Starttime,
                EndTime = holiday.Endtime,
                DescMsg = holiday.Desc,
                HolidayID = holiday.ID,
                StockCode = holiday.PriceCode,
            };
        }

        internal static DateHoliday ToDateHoliday(HolidayInformation info)
        {
            return new DateHoliday
            {
                HoliName = info.HolidayName,
                Starttime = info.StartTime,
                Endtime = info.EndTime,
                Desc = info.DescMsg,
                ID = info.HolidayID,
                PriceCode = info.StockCode,
            };
        }

        #endregion

        //#region TradeSet与TradingSettingInformation之间的转换 弃用

        //internal static TradingSettingInformation ToTradingSettingInfo(TradeSet tradeSet)
        //{
        //    //Todo:金通网待处理
        //    return null;

        //    #region MyRegion

        //    //return new TradingSettingInformation
        //    //{
        //    //    PendingOrderValid = (PENDINGORDER_VALID)Enum.Parse(typeof(PENDINGORDER_VALID), tradeSet.HoldValid),
        //    //    StorageChargeBillableTime = tradeSet.CalcStoretime,
        //    //    WeekBilling = tradeSet.IsCalc,
        //    //    SettlementTime = tradeSet.Calctime,
        //    //    RiskRateFormula = tradeSet.FxExpress,
        //    //    LossOrProfitFormula = tradeSet.YkExpress,
        //    //    BrokeFormula = tradeSet.BcExpress,
        //    //}; 

        //    #endregion
        //}

        //internal static TradeSet ToTradeSet(TradingSettingInformation tradingSettingInfo)
        //{
        //    //Todo:金通网待处理
        //    return null;

        //    #region MyRegion

        //    //return new TradeSet
        //    //{
        //    //    HoldValid = ((int)tradingSettingInfo.PendingOrderValid).ToString(),
        //    //    IsCalc = tradingSettingInfo.WeekBilling,
        //    //    Calctime = tradingSettingInfo.SettlementTime,
        //    //    CalcStoretime = tradingSettingInfo.StorageChargeBillableTime,
        //    //    FxExpress = tradingSettingInfo.RiskRateFormula,
        //    //    YkExpress = tradingSettingInfo.LossOrProfitFormula,
        //    //    BcExpress = tradingSettingInfo.BrokeFormula,
        //    //}; 

        //    #endregion
        //}

        //#endregion

        #region TradeIp与IPAddressFilterInformation之间的转换

        internal static IPAddressFilterInformation ToIPAddressFilterInfo(TradeIp ipInfo)
        {
            return new IPAddressFilterInformation
            {
                StartIPAddr = ipInfo.StartIp,
                EndIPAddr = ipInfo.EndIp,
                FilterDesc = ipInfo.Desc,
                FilterID = ipInfo.ID,
            };
        }

        internal static TradeIp ToTradeIp(IPAddressFilterInformation ipAddrFilterInfo)
        {
            return new TradeIp
            {
                StartIp = ipAddrFilterInfo.StartIPAddr,
                EndIp = ipAddrFilterInfo.EndIPAddr,
                Desc = ipAddrFilterInfo.FilterDesc,
                ID = ipAddrFilterInfo.FilterID,
            };
        }

        #endregion

        #region TradeMac与MACFilterInformation之间的转换

        internal static MACFilterInformation ToMACFilterInfo(TradeMac macInfo)
        {
            return new MACFilterInformation
            {
                MACAddress = macInfo.MAC,
                FilterDesc = macInfo.Desc,
                FilterID = macInfo.ID,
            };
        }

        internal static TradeMac ToTradeMac(MACFilterInformation macInfo)
        {
            return new TradeMac
            {
                MAC = macInfo.MACAddress,
                Desc = macInfo.FilterDesc,
                ID = macInfo.FilterID,
            };
        }

        #endregion

        #region TradeProduct与ProductInformation之间的转换

        internal static ProductInformation ToProductInfo(TradeProduct product)
        {
            ProductInformation info = new ProductInformation();

            info.AllowMaxPrice = product.Maxprice;
            info.AllowMaxTimeDeviation = product.Maxtime;
            info.AllowMinPrice = product.Minprice;
            info.CutDownPrice = product.Lowerprice;
            info.DepositFormula = product.Ordemoneyfee;
            info.LossProfitSpread = product.SetBase;
            info.OrderStorageFeeFormula = product.Buystoragefee;
            info.PendingOrderSpread = product.Holdbase;
            info.PercentageOfDeposit = product.Ordemoney;
            info.PointValue = product.Valuedot;
            info.ProductCode = product.Productcode;
            info.ProductName = product.ProductName;
            info.RecovertyStorageFeeFormula = product.Sellstoragefee;
            info.RecoveryFeeFormula = product.Sellfee;
            info.Spread = product.Pricedot;
            info.SpreadBaseValue = product.Adjustbase;
            info.SpreadDigit = product.Adjustcount;
            info.State = (PRODUCT_STATE)Enum.Parse(typeof(PRODUCT_STATE), product.State);
            info.StockCode = product.Pricecode;
            info.RawMaterialsCode = product.Goodscode;
            info.TransactionFeeFormula = product.Expressionfee;
            info.WeightUnit = product.Unit;
            info.StartTradeTime = product.Starttime;
            info.EndTradeTime = product.Endtime;
            info.RealTimePrice = product.realprice;
            info.RealTimeTime = DateTimeHelper.GetDateTimeFromTimeKey(product.weektime);
            return info;

        }

        internal static TradeProduct ToTradeProduct(ProductInformation info)
        {
            return new TradeProduct
            {
                Maxprice = info.AllowMaxPrice,
                Maxtime = info.AllowMaxTimeDeviation,
                Minprice = info.AllowMinPrice,
                Lowerprice = info.CutDownPrice,
                Ordemoneyfee = info.DepositFormula,
                SetBase = info.LossProfitSpread,
                Buystoragefee = info.OrderStorageFeeFormula,
                Holdbase = info.PendingOrderSpread,
                Ordemoney = info.PercentageOfDeposit,
                Valuedot = info.PointValue,
                Productcode = info.ProductCode,
                ProductName = info.ProductName,
                Sellstoragefee = info.RecovertyStorageFeeFormula,
                Sellfee = info.RecoveryFeeFormula,
                Pricedot = info.Spread,
                Adjustbase = info.SpreadBaseValue,
                Adjustcount = info.SpreadDigit,
                State = ((int)info.State).ToString(),
                Pricecode = info.StockCode,
                Goodscode = info.RawMaterialsCode,
                Expressionfee = info.TransactionFeeFormula,
                Unit = info.WeightUnit,
                //Starttime = info.StartTradeTime,
                //Endtime = info.EndTradeTime,
                Starttime = "00:00:00",
                Endtime = "23:59:59",
            };
        }
        #endregion

        internal static LogInformation ToLogInfo(ALog log)
        {
            return new LogInformation
            {
                Desc = log.Desc,
                OperTime = log.OperTime,
                UType = (UserTypeInfo)log.UType,
                Account = log.Account,
            };
        }

        #region TradeRate与ExchangeRateWaterInformation之间的转换

        public static ExchangeRateWaterInformation ToRateWaterInfo(TradeRate tradeRate)
        {
            return new ExchangeRateWaterInformation
            {
                StockCode = tradeRate.PriceCode,
                Rate = tradeRate.Rate,
                Water = tradeRate.Water,
            };
        }

        public static TradeRate ToTradeRate(ExchangeRateWaterInformation rateWaterInfo)
        {
            return new TradeRate
            {
                PriceCode = rateWaterInfo.StockCode,
                Rate = rateWaterInfo.Rate,
                Water = rateWaterInfo.Water,
            };
        }
        #endregion

        internal static MarketOrderData ToMarketOrderData(TradeOrder order)
        {
            return new MarketOrderData
            {
                OccupiedDeposit = order.OccMoney,
                OrderID = order.OrderId,
                OrderPrice = order.OrderPrice,
                OrderQuantity = order.UseQuantity,
                OrderTime = order.OrderTime,
                OrderType = (TRANSACTION_TYPE)Enum.Parse(typeof(TRANSACTION_TYPE), order.OrderType),
                ProductCode = order.ProductCode,
                ProductName = order.ProductName,
                RemainingQuantity = order.UseQuantity,
                StopLoss = order.LossPrice,
                StopProfit = order.ProfitPrice,
                StorageFee = order.StorageFee,
                TradeAccount = order.TradeAccount,
                TradeFee = order.TradeFee,
                AllowStore = order.AllowStore,//马友春
                TotalWeight = order.TotalWeight,
                OrgName = order.OrgName,
                UserName = order.UserName,
                Telephone = order.Telephone,
                Money = order.Money,
                ProfitValue = order.ProfitValue,
                AlloccMoney = order.AllOccMoney,
                FrozenMoney = order.FrozenMoney,
                DongJieMoney = order.DongJieMoney,
                Orderunit = order.Orderunit


            };
        }
        internal static MarketHistoryData ToMarketHistoryData(LTradeOrder item)
        {
            return new MarketHistoryData
            {
                BasicLaborCharge = item.TradeFee,
                HistoryID = item.HistoryOrderId,
                LossOrProfit = item.ProfitValue,
                OrderID = item.OrderId,
                OrderPrice = item.OrderPrice,
                OrderTime = item.OrderTime,
                OrderType = (TRANSACTION_TYPE)Enum.Parse(typeof(TRANSACTION_TYPE), item.OrderType),
                ProductCode = item.ProductCode,
                ProductName = item.ProductName,
                StopLoss = item.LossPrice,
                StopProfit = item.ProfitPrice,
                StorageCharge = item.StorageFee,
                TradeAccount = item.TradeAccount,
                TradeCount = item.Quantity,
                TradePrice = item.OverPrice,
                TradeTime = item.OverTime,
                UserName = item.UserName,
                Telephone = item.Telephone,
                OrgName = item.OrgName,
                TradeType = (CHARGEBACK_MODE)Enum.Parse(typeof(CHARGEBACK_MODE), item.OverType),
            };
        }


        internal static PendingOrderData ToPendingOrderData(TradeHoldOrder order)
        {
            return new PendingOrderData
            {
                DueDate = order.ValidTime,
                FrozenDeposit = order.FrozenMoney,
                OrderID = order.HoldOrderID,
                OrderPrice = order.HoldPrice,
                OrderQuantity = order.Quantity,
                OrderTime = order.OrderTime,
                OrderType = (TRANSACTION_TYPE)Enum.Parse(typeof(TRANSACTION_TYPE), order.OrderType),
                ProductCode = order.ProductCode,
                ProductName = order.ProductName,
                StopLoss = order.LossPrice,
                StopProfit = order.ProfitPrice,
                OrgName = order.OrgName,
                UserName = order.UserName,
                Telephone = order.Telephone,
                TradeAccount = order.TradeAccount,
            };
        }


        internal static Gss.Entities.TradeManager.TradeJuJian ToClientTradeJuJianInfo(Gss.BusinessService.ManagementService.TradeJuJian item)
        {
            return new Gss.Entities.TradeManager.TradeJuJian
            {
                Chujin = item.chujin,
                Copper_20t_Num = item.Copper_20t_Num,
                Copper_50t_Num = item.Copper_50t_Num,
                Copper_DH_NUM = item.Copper_DH_NUM,
                Copper_DHAVG_PRICE = item.Copper_DHAVG_PRICE,
                Copper_HS_NUM = item.Copper_HS_NUM,
                Copper_HSAVG_PRICE = item.Copper_HSAVG_PRICE,
                EURGBP_DH_NUM = item.EURGBP_DH_NUM,
                EURGBP_DHAVG_PRICE = item.EURGBP_DHAVG_PRICE,
                EURGBP_HS_NUM = item.EURGBP_HS_NUM,
                EURGBP_HSAVG_PRICE = item.EURGBP_HSAVG_PRICE,
                EURUSD_DH_NUM = item.EURUSD_DH_NUM,
                EURUSD_DHAVG_PRICE = item.EURUSD_DHAVG_PRICE,
                EURUSD_HS_NUM = item.EURUSD_HS_NUM,
                EURUSD_HSAVG_PRICE = item.EURUSD_HSAVG_PRICE,
                GBPUSD_DH_NUM = item.GBPUSD_DH_NUM,
                GBPUSD_DHAVG_PRICE = item.GBPUSD_DHAVG_PRICE,
                GBPUSD_HS_NUM = item.GBPUSD_HS_NUM,
                GBPUSD_HSAVG_PRICE = item.GBPUSD_HSAVG_PRICE,
                Hisyingkui = item.Hisyingkui,
                KC_Copper_20t_Num = item.KC_Copper_20t_Num,
                KC_Copper_50t_Num = item.KC_Copper_50t_Num,
                KC_UKOil_100_Num = item.KC_UKOil_100_Num,
                KC_UKOil_20_Num = item.KC_UKOil_20_Num,
                KC_UKOil_50_Num = item.KC_UKOil_50_Num,
                KC_XAG_100kg_Num = item.KC_XAG_100kg_Num,
                KC_XAG_20kg_Num = item.KC_XAG_20kg_Num,
                KC_XAG_50kg_Num = item.KC_XAG_50kg_Num,
                KC_XAU_1000g_Num = item.KC_XAU_1000g_Num,
                KC_XPD_1000g_Num = item.KC_XPD_1000g_Num,
                KC_XPT_1000g_Num = item.KC_XPT_1000g_Num,
                Manual_chujin = item.Manual_chujin,
                Manual_rujin = item.Manual_rujin,
                Money = item.Money,
                OrgName = item.OrgName,
                Qichu = item.qichu,
                Qimo = item.qimo,
                Rujin = item.rujin,
                Storagefee = item.storagefee,
                Tradefee = item.tradefee,
                UKOil_100_Num = item.UKOil_100_Num,
                UKOil_20_Num = item.UKOil_20_Num,
                UKOil_50_Num = item.UKOil_50_Num,
                UKOil_DH_NUM = item.UKOil_DH_NUM,
                UKOil_DHAVG_PRICE = item.UKOil_DHAVG_PRICE,
                UKOil_HS_NUM = item.UKOil_HS_NUM,
                UKOil_HSAVG_PRICE = item.UKOil_HSAVG_PRICE,
                USDCHF_DH_NUM = item.USDCHF_DH_NUM,
                USDCHF_DHAVG_PRICE = item.USDCHF_DHAVG_PRICE,
                USDCHF_HS_NUM = item.USDCHF_HS_NUM,
                USDCHF_HSAVG_PRICE = item.USDCHF_HSAVG_PRICE,
                USDJPY_DH_NUM = item.USDJPY_DH_NUM,
                USDJPY_DHAVG_PRICE = item.USDJPY_DHAVG_PRICE,
                USDJPY_HS_NUM = item.USDJPY_HS_NUM,
                USDJPY_HSAVG_PRICE = item.USDJPY_HSAVG_PRICE,
                USDOLLAR_DH_NUM = item.USDOLLAR_DH_NUM,
                USDOLLAR_DHAVG_PRICE = item.USDOLLAR_DHAVG_PRICE,
                USDOLLAR_HS_NUM = item.USDOLLAR_HS_NUM,
                USDOLLAR_HSAVG_PRICE = item.USDOLLAR_HSAVG_PRICE,
                XAG_100kg_Num = item.XAG_100kg_Num,
                XAG_20kg_Num = item.XAG_20kg_Num,
                XAG_50kg_Num = item.XAG_50kg_Num,
                XAGUSD_DH_NUM = item.XAGUSD_DH_NUM,
                XAGUSD_DHAVG_PRICE = item.XAGUSD_DHAVG_PRICE,
                XAGUSD_HS_NUM = item.XAGUSD_HS_NUM,
                XAGUSD_HSAVG_PRICE = item.XAGUSD_HSAVG_PRICE,
                XAU_1000g_Num = item.XAU_1000g_Num,
                XAUUSD_DH_NUM = item.XAUUSD_DH_NUM,
                XAUUSD_DHAVG_PRICE = item.XAUUSD_DHAVG_PRICE,
                XAUUSD_HS_NUM = item.XAUUSD_HS_NUM,
                XAUUSD_HSAVG_PRICE = item.XAUUSD_HSAVG_PRICE,
                XPD_1000g_Num = item.XPD_1000g_Num,
                XPDUSD_DH_NUM = item.XPDUSD_DH_NUM,
                XPDUSD_DHAVG_PRICE = item.XPDUSD_DHAVG_PRICE,
                XPDUSD_HS_NUM = item.XPDUSD_HS_NUM,
                XPDUSD_HSAVG_PRICE = item.XPDUSD_HSAVG_PRICE,
                XPT_1000g_Num = item.XPT_1000g_Num,
                XPTUSD_DH_NUM = item.XPTUSD_DH_NUM,
                XPTUSD_DHAVG_PRICE = item.XPTUSD_DHAVG_PRICE,
                XPTUSD_HS_NUM = item.XPTUSD_HS_NUM,
                XPTUSD_HSAVG_PRICE = item.XPTUSD_HSAVG_PRICE,



            };
        }


        internal static HedgingTradeData ToHedgingTradeData(Hedging hedging)
        {
            return new HedgingTradeData
            {
                AveragePrice = hedging.AvgOrderPrice,
                HedgingLossOrProfit = hedging.HedgingProfitLoss,
                HedgingQuantity = hedging.HedgingQuantity,
                HedgingStorageFee = hedging.HedgingStorageFee,
                HedgingTradeFee = hedging.HedgingTradeFee,
                LossOrProfit = hedging.ProfitLoss,
                OrderQuantity = hedging.Quantity,
                OrderType = (TRANSACTION_TYPE)Enum.Parse(typeof(TRANSACTION_TYPE), hedging.OrderType),
                ProductName = hedging.ProductName,
                RealTimePrice = hedging.RealPrice,
                StorageFee = hedging.StorageFee,
                TradeFee = hedging.TradeFee,

            };
        }

        internal static void ToHedgingTradeData2(Hedging hedging, HedgingTradeData data)
        {

            data.AveragePrice2 = hedging.AvgOrderPrice;
            data.LossOrProfit2 = hedging.ProfitLoss;
            data.OrderQuantity2 = hedging.Quantity;
            data.OrderType2 = (TRANSACTION_TYPE)Enum.Parse(typeof(TRANSACTION_TYPE), hedging.OrderType);
            data.RealTimePrice2 = hedging.RealPrice;
            data.StorageFee2 = hedging.StorageFee;
            data.TradeFee2 = hedging.TradeFee;

        }

        internal static UserQueryCon ToUserQueryCon(string loginID, ACCOUNT_TYPE accType, string accountName, ClientAccountFilter filter)
        {
            return new UserQueryCon
            {
                LoginId = loginID,
                //Todo:金通网待处理
                #region MyRegion
                //UserTypeInfo = (int)accType,
                //AgentId = accountName, 
                #endregion
                TradeAccount = filter.AccountName,
                UserName = filter.UserName,
                CardNum = filter.CertificateNumber,
            };
        }

        internal static CxQueryCon ToCxQueryCon(CxQueryConInfomation query)
        {
            return new CxQueryCon
            {
                ProductName = query.ProductName,
                TradeAccount = query.TradeAccount,
                LoginID = query.LoginID,
                StartTime = query.StartTime,
                EndTime = query.EndTime,
                OrgName = query.OrgName,
                OrderType = query.OrderType,
                PriceCode = query.StockCode,

            };
        }


        internal static LQueryCon ToLQueryCon(CxQueryConInfomation query)
        {
            return new LQueryCon
            {
                ProductName = query.ProductName,
                TradeAccount = query.TradeAccount,
                LoginID = query.LoginID,
                StartTime = query.StartTime,
                EndTime = query.EndTime,
                OrgName = query.OrgName,
                OrderType = query.OrderType,
                PriceCode = query.StockCode

            };
        }


        internal static UserQueryCon ToUserQueryCon(UserQueryConInfomation query)
        {
            return new UserQueryCon
            {
                LoginId = query.LoginID,
                UType = EnumConverter.ConverterUserType(query.UserTypeInfo),
                TradeAccount = query.TradeAccount,
                UserName = query.UserName,
                CardNum = query.CardNum,
                OnLine = query.OnLine,
                OrgName = query.OrgName,
                UserGroupId = query.GroupID,
                TelPhone = query.TelPhone,
                StartTime = query.StartTime,
                EndTime = query.EndTime,
                IsBroker = query.IsBroker,
                Broker = query.Broker
            };
        }

        internal static LogQueryCon ToLogQueryCon(LogQueryConInfomation query)
        {
            return new LogQueryCon
            {
                LoginID = query.LoginID,
                //Todo:金通网待处理
                //LogType = query.LogType,
                StartTime = query.Starttime,
                EndTime = query.Endtime,
                Account = query.Account,
            };
        }

        //Todo:金通网待处理
        #region MyRegion
        //internal static BzjRecoverOrder ToBzjRecoverOrder(RecoverOrder order)
        //{
        //    BzjRecoverOrder bzjOrder = new BzjRecoverOrder();
        //    bzjOrder.OrderId = order.OrderId;
        //    bzjOrder.PayMoney = order.PayMoney;
        //    bzjOrder.TradeAccount = order.TradeAccount;
        //    bzjOrder.UserName = order.UserName;
        //    bzjOrder.RealWeight = order.RealWeight;//买跌重量必须放在产品名称之前
        //    bzjOrder.ProductName = order.ProductName;
        //    bzjOrder.OverPrice = order.OverPrice;

        //    bzjOrder.Overtime = order.Overtime;
        //    bzjOrder.PayTime = order.PayTime;
        //    bzjOrder.State = order.State;
        //    bzjOrder.DoPerson = order.DoPerson;
        //    return bzjOrder;
        //}


        //internal static ClerkQueryCon ToClerkQueryCon(BzjClerkQueryCon bzjCon)
        //{
        //    ClerkQueryCon con = new ClerkQueryCon();
        //    con.LoginId = bzjCon.LoginId;
        //    con.UserTypeInfo = bzjCon.UserTypeInfo;
        //    con.AgentId = bzjCon.AgentId;
        //    con.ClerkId = bzjCon.ClerkId;
        //    con.ClerkName = bzjCon.ClerkName;
        //    con.ClerkPhone = bzjCon.ClerkPhone;
        //    return con;

        //}

        //internal static BzjClerk ToBzjClerk(Clerk clerk)
        //{
        //    return new BzjClerk()
        //               {
        //                   ClerkName = clerk.ClerkName,
        //                   ClerkId = clerk.ClerkId,
        //                   ClerkPwd = clerk.ClerkPwd,
        //                   ClerkPhone = clerk.ClerkPhone,
        //                   AgentId = clerk.AgentId

        //               };
        //}

        //internal static Clerk ToClerk(BzjClerk clerk)
        //{
        //    return new Clerk()
        //               {
        //                   ClerkName = clerk.ClerkName,
        //                   ClerkId = clerk.ClerkId,
        //                   ClerkPwd = clerk.ClerkPwd,
        //                   ClerkPhone = clerk.ClerkPhone,
        //                   AgentId = clerk.AgentId

        //               };
        //} 
        #endregion



        #region 辅助转换方法

        private static bool ToBoolean(string str)
        {
            try
            {
                bool ret = Convert.ToBoolean(str);
                return ret;
            }
            catch
            {
                return !str.Equals("0");
            }
        }

        private static bool ToBoolean(bool? val)
        {
            return !(val.HasValue && !val.Value);
        }

        private static CeritificateEnum ToCertificateEnum(string str)
        {
            try
            {
                return (CeritificateEnum)Enum.Parse(typeof(CeritificateEnum), str);
            }
            catch
            {
                return CeritificateEnum.ID;
            }
        }

        private static BANK ToBankEnum(string str)
        {
            if (string.IsNullOrEmpty(str))
                return BANK.NULL;
            else
            {
                try
                {
                    return (BANK)Enum.Parse(typeof(BANK), str);
                }
                catch
                {
                    return BANK.NULL;
                }
            }
        }

        private static string ToBankStr(BANK bank)
        {
            if (bank == BANK.NULL)
                return null;
            else
                return ((int)bank).ToString();
        }

        private static string ToSexString(SEX? sex)
        {
            if (sex == null)
                return "";
            else if (sex == SEX.Male)
                return "1";
            else
                return "0";
            //return ((int)sex).ToString();
        }

        private static SEX? ToSexEnum(string sexStr)
        {
            if (string.IsNullOrEmpty(sexStr))
                return null;
            else if (sexStr.Equals("0"))
                return SEX.Female;
            else
                return SEX.Male;
        }

        private static WEEK ToWeekEnum(string weekStr)
        {
            try
            {
                return (WEEK)Enum.Parse(typeof(WEEK), weekStr);
            }
            catch
            {
                return WEEK.Sunday;
            }
        }

        /// <summary>
        /// 0全部允许，1只报价，2只买涨，3只买跌，4全部禁止
        /// </summary>
        /// <param name="allowOrder"></param>
        /// <param name="allowRecovery"></param>
        /// <param name="allowQuotation"></param>
        /// <returns></returns>
        private static string ToState(bool allowOrder, bool allowRecovery, bool allowQuotation)
        {
            if (allowOrder && allowRecovery && allowQuotation)
                return "0";
            else if (!(allowQuotation || allowOrder || allowRecovery))
                return "4";
            else if (allowQuotation)
                return "1";
            else if (allowOrder)
                return "2";
            else //allowRecovery == true
                return "3";
        }
        #endregion


        internal static RoleEntity ToRoleEntity(RoleInfo roleInfo)
        {
            RoleEntity roleEntity = new RoleEntity();
            roleEntity.RoleID = roleInfo.RoleID;
            roleEntity.RoleName = roleInfo.RoleName;
            roleEntity.Remark = roleInfo.Remark;
            return roleEntity;
        }

        internal static RoleInfo ToRoleInfo(RoleEntity roleEntity)
        {
            RoleInfo roleInfo = new RoleInfo();
            roleInfo.RoleID = roleEntity.RoleID;
            roleInfo.RoleName = roleEntity.RoleName;
            roleInfo.Remark = roleEntity.Remark;
            return roleInfo;
        }

        internal static PrivilegeInfo ToPrivilegeInfo(PrivilegeEntity privilegeEntity)
        {
            PrivilegeInfo privilegeInfo = new PrivilegeInfo();
            privilegeInfo.Check = privilegeEntity.Check;
            privilegeInfo.ParentPrivilegeID = privilegeEntity.ParentPrivilegeId;
            privilegeInfo.ParentPrivilegeName = privilegeEntity.ParentPrivilegeName;
            privilegeInfo.PrivilegeId = privilegeEntity.PrivilegeId;
            privilegeInfo.PrivilegeName = privilegeEntity.PrivilegeName;
            privilegeInfo.Displayorder = privilegeEntity.Displayorder;
            return privilegeInfo;
        }

        internal static PrivilegeEntity ToPrivilegeEntity(PrivilegeInfo privilegeInfo)
        {
            PrivilegeEntity privilegeEntity = new PrivilegeEntity();
            privilegeEntity.Check = privilegeInfo.Check;
            privilegeEntity.ParentPrivilegeId = privilegeInfo.ParentPrivilegeID;
            privilegeEntity.ParentPrivilegeName = privilegeInfo.ParentPrivilegeName;
            privilegeEntity.PrivilegeId = privilegeInfo.PrivilegeId;
            privilegeEntity.PrivilegeName = privilegeInfo.PrivilegeName;
            privilegeEntity.Displayorder = privilegeInfo.Displayorder;
            return privilegeEntity;
        }

        internal static UserPrivilegesInfo ToUserPrivilegesInfo(List<PrivilegeEntity> list)
        {
            UserPrivilegesInfo info = new UserPrivilegesInfo();

            if (list != null)
            {

                #region 管理权限

                info.AccountManager = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account).FirstOrDefault() == null ? false : true;// 账号管理权限（父级）
                //管理员
                info.AdminAccountManager = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Manager).FirstOrDefault() == null ? false : true;//管理员权限
                info.RolePrivilegeEnabled = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Manager_Role).FirstOrDefault() == null ? false : true;//管理员--角色权限
                info.AdminAccountManagerAccountInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Manager_AccountInfo).FirstOrDefault() == null ? false : true;//管理员--管理员资料
                info.AdminAccountManagerAddAccount = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Manager_AddAccount).FirstOrDefault() == null ? false : true;//管理员--新增管理员
                info.AdminAccountManagerDelAccount = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Manager_DelAccount).FirstOrDefault() == null ? false : true;//管理员--删除管理员


                //客户管理 
                info.ClientAccountManager = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Client).FirstOrDefault() == null ? false : true;//客户账号管理权限
                info.ClientAccountManagerAccountInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Client_AccountInfo).FirstOrDefault() == null ? false : true;//客户账号--客户账户资料
                info.ClientAccountManagerAddAccount = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Client_AddAccount).FirstOrDefault() == null ? false : true;//客户账号--新增客户账户
                info.ClientAccountManagerAdjustMoney = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Client_AdjustMoney).FirstOrDefault() == null ? false : true;//客户账号--调节
                info.ClientAccountManagerDelAccount = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Client_DelAccount).FirstOrDefault() == null ? false : true;//客户账号--删除客户账户
                info.ClientAccountManagerFundsInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Client_FundsInfo).FirstOrDefault() == null ? false : true;//客户账号--客户资金信息
                info.ClientAccountManagerMarketOrder = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Client_MarketOrder).FirstOrDefault() == null ? false : true;//客户账号--即时成交
                info.ClientAccountManagerPendingOrder = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Client_PendingOrder).FirstOrDefault() == null ? false : true;//客户账号--挂单交易
                info.ClientAccountManagerOrderInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Client_OrderInfo
                    && p.ParentPrivilegeName == AppPrivilegeConfig.Account_Client).FirstOrDefault() == null ? false : true;//客户管理--订单信息


                //会员账户
                info.DealerAccountManager = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_OrgAccount).FirstOrDefault() == null ? false : true;//金商账号/会员账户管理权限
                info.DealerAccountManagerAccountInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_OrgAccount_AccountInfo).FirstOrDefault() == null ? false : true;//会员账户--会员账户资料
                info.DealerAccountManagerAddAccount = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_OrgAccount_AddAccount).FirstOrDefault() == null ? false : true;//会员账户--新增会员账户
                info.DealerAccountManagerDelAccount = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_OrgAccount_DelAccount).FirstOrDefault() == null ? false : true;//会员账户--删除会员账户
                info.DealerAccountManagerRole = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_OrgAccount_Role).FirstOrDefault() == null ? false : true;//会员账户--会员账户角色

                //在线客户
                info.ClientOnlineAccountManager = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Online).FirstOrDefault() == null ? false : true;//在线客户
                info.ClientOnlineAccountManagerAccountInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Online_AccountInfo).FirstOrDefault() == null ? false : true;//在线客户--账户资料
                info.ClientOnlineAccountManagerDelAccount = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Online_DelAccount).FirstOrDefault() == null ? false : true;//在线客户--删除账户
                info.ClientOnlineAccountManagerFundsInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Online_FundsInfo).FirstOrDefault() == null ? false : true;//在线客户--资金信息
                info.ClientOnlineAccountManagerOrderInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Online_OrderInfo
                  && p.ParentPrivilegeName == AppPrivilegeConfig.Account_Online).FirstOrDefault() == null ? false : true;//在线客户--订单信息

                //微会员
                info.OrgManager = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Org).FirstOrDefault() == null ? false : true;//微会员
                info.OrgManagerAccountInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Org_AccountInfo).FirstOrDefault() == null ? false : true;//微会员--微会员资料

                info.OrgManagerAddAccount = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Org_AddAccount).FirstOrDefault() == null ? false : true;//微会员--新增微会员
                info.OrgManagerDelAccount = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Org_DelAccount).FirstOrDefault() == null ? false : true;//微会员--删除微会员

                info.orgManagerRole = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Org_Role).FirstOrDefault() == null ? false : true;//微会员--微会员角色
                info.OrgManagerSetCommissionRatio = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Org_SetCommissionRatio).FirstOrDefault() == null ? false : true;//微会员--返佣比例

                info.OrgManagerSetDefaultCommissionRatio = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Org_SetDefaultCommissionRatio).FirstOrDefault() == null ? false : true;//微会员--返佣比例
                info.OrgManagerSetAllCommissionRatio = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Org_SetAllCommissionRatio).FirstOrDefault() == null ? false : true;//微会员--返佣比例



                #endregion

                #region 系统设置
                info.IsSystemSettingsEnabled = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.System).FirstOrDefault() == null ? false : true;//系统设置（父类）
                info.AllowReleaseNews = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.System_1).FirstOrDefault() == null ? false : true;//发布新闻
                info.AllowArticlesInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.System_ArticlesInfo).FirstOrDefault() == null ? false : true;//理财师说


                info.AllowReleaseAnnouncement = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.System_2).FirstOrDefault() == null ? false : true;//发布公告
                info.AllowViewLog = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.System_LogInfo).FirstOrDefault() == null ? false : true;//查看日志
                info.AllowHolidaysSettings = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.System_Holiday).FirstOrDefault() == null ? false : true;//假日设置
                info.AllowTradingDaySettings = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.System_TradingDay).FirstOrDefault() == null ? false : true;//交易日设置
                info.AllowTransactionSettings = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.System_TradingSetting).FirstOrDefault() == null ? false : true;//交易设置
                info.EnableIPAddressFiltering = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.System_IPAddrFilter).FirstOrDefault() == null ? false : true;//IP地址过滤
                info.EnableMACAddressFiltering = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.System_MACFilter).FirstOrDefault() == null ? false : true;//MAC地址过滤
                info.EnableRoleManager = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.System_RoleManager).FirstOrDefault() == null ? false : true;//角色管理
                info.EnablePrivilegeManager = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.System_PrivilegeManager).FirstOrDefault() == null ? false : true;//权限管理
                info.EnableTradeMoneyInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.System_TradeMoneyInfo).FirstOrDefault() == null ? false : true;//出入金解约
                info.GroupManager = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.System_Group).FirstOrDefault() == null ? false : true;//客户分组管理
                #endregion

                #region 数据管理
                info.IsDataManagerEnabled = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Data).FirstOrDefault() == null ? false : true;//数据管理权限（父类）
                info.IsProductManagerEnabled = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Data_ProductInfo).FirstOrDefault() == null ? false : true;//商品管理权限
                info.IsHistoryDataManagerEnabled = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Data_HistoryData).FirstOrDefault() == null ? false : true;//历史数据管理
                info.ExchangeRateWater = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Data_RateWaterInfo).FirstOrDefault() == null ? false : true;//汇率/水
                info.ManualPriceEnabled = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Data_ProductInfo_ManualPrice).FirstOrDefault() == null ? false : true;//手工报价
                info.EffectiveEnabled = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Data_Effective).FirstOrDefault() == null ? false : true;//体验券
                #endregion

                #region 提货受理权限
                info.TiHuoShouLi = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.TakeGoods).FirstOrDefault() == null ? false : true;//提货受理 （父级）
                info.ShouLiMingXi = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.TakeGoods_AcceptDetail).FirstOrDefault() == null ? false : true;//受理明细
                info.TiHuo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.TakeGoods_TakeGoods).FirstOrDefault() == null ? false : true;//提货
                info.BangDingUser = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.TakeGoods_BindingAccount).FirstOrDefault() == null ? false : true;//绑定账号
                #endregion

                #region 交易管理
                //交易管理（父级）
                info.IsTradeManagerEnabled = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade).FirstOrDefault() == null ? false : true;//交易管理（父级）
                //金生金单
                info.JgjOrder = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_JgjGoods).FirstOrDefault() == null ? false : true;//金生金单
                //买跌单
                info.HuiGouOrder = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_BackGoods).FirstOrDefault() == null ? false : true;//买跌单
                //提货单
                info.TihuoOrder = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_TakeGoods).FirstOrDefault() == null ? false : true;//提货单
                //交割单
                info.DeliverOrder = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_DeliveryGoods).FirstOrDefault() == null ? false : true;//交割单
                //市价定单
                info.AllowViewMarketOrder = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_MarketOrder).FirstOrDefault() == null ? false : true;//市价定单（有效单）
                info.AllowViewMarketOrderChargeback = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_MarketOrder_Chargeback).FirstOrDefault() == null ? false : true;//市价定单--平仓
                info.AllowViewMarketOrderOrderInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_MarketOrder_OrderInfo
                    && p.ParentPrivilegeName == AppPrivilegeConfig.Trade_MarketOrder).FirstOrDefault() == null ? false : true;//市价定单--订单信息

                //限价定单/委托订单
                info.AllowViewPendingOrder = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_PendingOrder).FirstOrDefault() == null ? false : true;//限价定单
                info.AllowViewPendingOrderCancel = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_PendingOrder_Cancel).FirstOrDefault() == null ? false : true;//限价定单--撤销
                info.AllowViewPendingOrderOrderInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_PendingOrder_OrderInfo
                      && p.ParentPrivilegeName == AppPrivilegeConfig.Trade_PendingOrder).FirstOrDefault() == null ? false : true;//限价定单--订单信息
                //平仓历史
                info.AllowViewChargebackRecord = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_ChargebackRecode).FirstOrDefault() == null ? false : true;//平仓历史
                info.AllowViewChargebackRecordOrderInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_ChargebackRecode_OrderInfo
                     && p.ParentPrivilegeName == AppPrivilegeConfig.Trade_ChargebackRecode).FirstOrDefault() == null ? false : true;//平仓历史--订单信息
                //入库单
                info.AllowViewWarehousing = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_WarehousingOrder).FirstOrDefault() == null ? false : true;//入库单
                //对冲交易
                info.AllowViewHedgingTransactions = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_HedgeTrade).FirstOrDefault() == null ? false : true;//对冲交易
                //导出报表
                info.AllowExportStatement = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_ExportStatements).FirstOrDefault() == null ? false : true;//导出报表
                info.AllowExportMarketOrderReport = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_ExportStatements_MarketOrderReport).FirstOrDefault() == null ? false : true;//市价单报表
                info.AllowExportPendingOrderReport = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_ExportStatements_PendingOrderReport).FirstOrDefault() == null ? false : true;//限价单报表
                info.AllowExportFundReport = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_ExportStatements_FundReport).FirstOrDefault() == null ? false : true;//资金报表
                info.AllowExportAdjustReport = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_ExportStatements_AdjustReport).FirstOrDefault() == null ? false : true;//导出平仓报表
                //出金处理
                info.TradeChuJin = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_ChuJin).FirstOrDefault() == null ? false : true;//出金处理

                info.TradeChuJinDetails = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_ChuJin_Details).FirstOrDefault() == null ? false : true;//出入金详情 
                info.TradeChuJinOrderInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_ChuJin_OrderInfo
                && p.ParentPrivilegeName == AppPrivilegeConfig.Trade_ChuJin).FirstOrDefault() == null ? false : true;//出金处理--订单信息
                //解约处理
                info.TradeTermination = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_Termination).FirstOrDefault() == null ? false : true;//解约处理
                info.TradeTerminationApproved = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_Termination_Approved).FirstOrDefault() == null ? false : true;//解约处理--审核解约
                info.TradeTerminationReject = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_Termination_Reject).FirstOrDefault() == null ? false : true;//解约处理--拒绝解约
                info.TradeTerminationOrderInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_Termination_OrderInfo
               && p.ParentPrivilegeName == AppPrivilegeConfig.Trade_Termination).FirstOrDefault() == null ? false : true;//解约处理--订单信息
                //资金报表
                info.AllowFundReport = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_FundReport).FirstOrDefault() == null ? false : true;//资金报表
                info.AllowFundReportOrderInfo = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_FundReport_OrderInfo
               && p.ParentPrivilegeName == AppPrivilegeConfig.Trade_FundReport).FirstOrDefault() == null ? false : true;//资金报表--订单信息
                //会员报表
                info.AllowJujian = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Trade_JujianManager).FirstOrDefault() == null ? false : true;//会员报表

                info.IsCanAlterDJ = list.Where(p => p.PrivilegeName == AppPrivilegeConfig.Account_Client_FundsInfo_Ok).FirstOrDefault() == null ? false : true;//修改冻结资金



                #endregion
            }

            return info;
        }

        internal static OrgEntity ToOrgEntity(OrgInfo info)
        {
            OrgEntity entity = new OrgEntity();
            entity.OrgName = info.OrgName;
            entity.OrgID = info.OrgID;
            entity.Coperson = info.Coperson;
            entity.CardType = EnumConverter.ConverterIDType(info.CardType);
            entity.CardNum = info.CardNum;
            entity.ParentOrgId = info.ParentOrgId == null ? "" : info.ParentOrgId;
            entity.ParentOrgName = info.ParentOrgName == null ? "" : info.ParentOrgName;
            entity.Reperson = info.Reperson;
            entity.PhoneNum = info.PhoneNum;
            entity.TelePhone = info.TelePhone;
            entity.Email = info.Email;
            entity.Address = info.Address;
            entity.AddTime = info.AddTime;
            entity.Status = info.Status == true ? Status.Enabled : Status.Disable;//Enabled=1,启用 禁用=0//禁用
            return entity;
        }

        internal static OrgInfo ToOrgInfo(OrgEntity entity)
        {
            OrgInfo info = new OrgInfo();
            info.OrgID = entity.OrgID;
            info.OrgName = entity.OrgName;
            info.Coperson = entity.Coperson;
            info.CardType = EnumConverter.ConverterCeritificateEnum(entity.CardType);
            info.CardNum = entity.CardNum;
            info.ParentOrgId = entity.ParentOrgId;
            info.ParentOrgName = entity.ParentOrgName;
            info.Reperson = entity.Reperson;
            info.PhoneNum = entity.PhoneNum;
            info.TelePhone = entity.TelePhone;
            info.Email = entity.Email;
            info.Address = entity.Address;
            info.AddTime = entity.AddTime;
            info.Status = entity.Status == Status.Enabled ? true : false;//Enabled=1,启用 禁用=0//禁用

            return info;
        }

        internal static NewsInfo ToNewsInfo(TradeNews news)
        {
            NewsInfo tInfo = new NewsInfo();
            tInfo.ID = news.ID;
            tInfo.NewsContent = news.NewsContent;
            tInfo.NewsTitle = news.NewsTitle;
            //Todo:查看枚举是否可以如此转换
            tInfo.NType = (NewsTypeEnum)news.NType;
            tInfo.PubPerson = news.PubPerson;
            tInfo.PubTime = news.PubTime;
            tInfo.Status = (NewsStatusEnum)news.Status;
            return tInfo;
        }

        internal static TradeNews ToTradeNews(NewsInfo tInfo)
        {
            TradeNews news = new TradeNews();
            news.ID = tInfo.ID;
            news.NewsContent = tInfo.NewsContent;
            news.NewsTitle = tInfo.NewsTitle;
            news.NType = (NewsType)tInfo.NType;
            news.PubPerson = tInfo.PubPerson;
            news.PubTime = tInfo.PubTime;
            news.Status = (NewsStatus)tInfo.Status;
            return news;
        }

        internal static CJQueryCon ToCJQueryCon(CJQueryConInfomation info)
        {
            CJQueryCon con = new CJQueryCon();
            con.Account = info.Account;
            con.EndTime = info.Endtime;
            con.LoginID = info.LoginID;
            con.StartTime = info.Starttime;
            con.State = info.State;
            con.OrgName = info.OrgName;
            con.PayStartTime = info.PayStartTime;
            con.PayEndTime = info.PayEndTime;
            return con;
        }
        internal static JYQueryCon ToJYQueryCon(CJQueryConInfomation info)
        {
            JYQueryCon con = new JYQueryCon();
            con.Account = info.Account;
            con.EndTime = info.Endtime;
            con.LoginID = info.LoginID;
            con.StartTime = info.Starttime;
            con.State = info.State;
            con.OrgName = info.OrgName;
            return con;
        }


        internal static FcQueryCon ToFcQueryCon(FcQueryConInfomation info)
        {
            FcQueryCon con = new FcQueryCon();
            con.Account = info.Account;
            con.EndTime = info.Endtime;
            con.LoginID = info.LoginID;
            con.StartTime = info.Starttime;
            con.Reason = info.Reason;
            con.OrgName = info.OrgName;
            return con;
        }

        internal static UserGroup ToUserGroup(UserGroups info)
        {
            UserGroup con = new UserGroup();
            con.AfterSecond = info.AfterSecond;
            con.DelayFlatOrder = info.DelayFlatOrder;
            con.DelayPlaceOrder = info.DelayPlaceOrder;
            con.FlatOrderSlipPoint = info.FlatOrderSlipPoint;
            con.IsDefaultGroup = info.IsDefaultGroup;
            con.PlaceOrderSlipPoint = info.PlaceOrderSlipPoint;
            con.UserGroupId = info.UserGroupId;
            con.UserGroupName = info.UserGroupName;

            return con;
        }
        internal static UserGroups ToUserGroups(UserGroup info)
        {
            UserGroups con = new UserGroups();
            con.AfterSecond = info.AfterSecond;
            con.DelayFlatOrder = info.DelayFlatOrder;
            con.DelayPlaceOrder = info.DelayPlaceOrder;
            con.FlatOrderSlipPoint = info.FlatOrderSlipPoint;
            con.IsDefaultGroup = info.IsDefaultGroup;
            con.PlaceOrderSlipPoint = info.PlaceOrderSlipPoint;
            con.UserGroupId = info.UserGroupId;
            con.UserGroupName = info.UserGroupName;

            return con;
        }

        internal static TradeChuJinInformation ToChuJinInfo(TradeChuJin cj)
        {
            TradeChuJinInformation info = new TradeChuJinInformation();
            info.Account = cj.Account;
            info.Amt = cj.Amt;
            info.ApplyId = cj.ApplyId;
            info.ApplyTime = cj.ApplyTime;
            info.BankCard = cj.BankCard;
            info.CardName = cj.CardName;
            info.FkTime = cj.FkTime;
            info.OpenBank = cj.OpenBank;
            info.State = cj.State;
            info.UserID = cj.UserId;
            info.State = cj.State;
            info.OrgName = cj.OrgName;
            info.TelePhone = cj.Telephone;
            info.ErrMsg = cj.ErrMsg;
            info.UserName = cj.UserName;
            return info;
        }
        internal static Gss.Entities.TradeManager.TradeJieYue ToTradeJieYue(Gss.BusinessService.ManagementService.TradeJieYue cj)
        {
            Gss.Entities.TradeManager.TradeJieYue info = new Gss.Entities.TradeManager.TradeJieYue();
            info.Account = cj.Account;
            info.ApplyId = cj.ApplyId;
            info.ApplyTime = cj.ApplyTime;
            info.BankCard = cj.BankCard;
            info.CardName = cj.CardName;
            info.OpenBank = cj.OpenBank;
            info.State = cj.State;
            info.UserID = cj.UserId;
            info.State = cj.State;
            info.OrgName = cj.OrgName;
            info.TelePhone = cj.Telephone;
            return info;
        }




        internal static FundChangeInformation ToFundChangeInfo(FundChange cj)
        {
            FundChangeInformation info = new FundChangeInformation();
            info.Account = cj.Account;
            info.Amt = cj.Amt;
            info.OpTime = cj.OpTime;
            info.OrgName = cj.OrgName;
            info.Reason = cj.Reason;
            info.UserName = cj.UserName;
            info.Telephone = cj.Telephone;
            return info;
        }

        internal static List<TradeMoneyData> TradeMoneyData(List<TradeMoney> list)
        {
            List<TradeMoneyData> tList = new List<TradeMoneyData>();
            foreach (var tm in list)
            {
                TradeMoneyData data = new TradeMoneyData();
                data.Account = tm.account;
                data.ChangeValue = tm.changevalue;
                data.NewValue = tm.newvalue;
                data.OldValue = tm.oldvalue;
                data.Opertime = tm.opertime;
                data.Reason = tm.reason;
                data.State = tm.state;
                tList.Add(data);
            }
            return tList;
        }
    }
}
