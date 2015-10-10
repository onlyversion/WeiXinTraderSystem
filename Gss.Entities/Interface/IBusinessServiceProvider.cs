using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Gss.Entities.BzjEntities;
using Gss.Entities.DataManager;
using Gss.Entities.Enums;
using Gss.Entities.JTWEntityes;
using Gss.Entities.SystemSetting;
using Gss.Entities.TradeManager;
using Gss.Entities.AccountManager;

namespace Gss.Entities.Interface
{
    public interface IBusinessServiceProvider : IDisposable
    {
        #region 登录

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="accountName">账户名</param>
        /// <param name="password">密码</param>
        /// <returns>登陆结果</returns>
        LoginResult Login(string accountName, string password);

        #endregion

        #region 获取账户列表相关

        /// <summary>
        /// 获取客户列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="accountName">账户名</param>
        /// <param name="filter">过滤信息</param>
        /// <param name="clientList">获取的客户列表</param>
        /// <returns>ErrType</returns>
        ErrType GetClientList(string loginID, ACCOUNT_TYPE accType, string accountName, ClientAccountFilter filter, out List<ClientAccount> clientList);

        /// <summary>
        /// 获取金商列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="accountName">账户名</param>
        /// <param name="dealerList">获取的金商账户列表</param>
        /// <returns>ErrType</returns>
        ErrType GetDealerList(string loginID, ACCOUNT_TYPE accType, string accountName, out List<DealerAccount> dealerList);

        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="mgrList">获取的管理员列表</param>
        /// <returns>ErrType</returns>
        ErrType GetAdminList(string loginID, out List<ManagerAccount> mgrList);

        /// <summary>
        /// 获取在线客户列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="accountName">账户名</param>
        /// <param name="filter">过滤信息</param>
        /// <param name="clientList">获取的在线客户列表</param>
        /// <returns>ErrType</returns>
        ErrType GetOnlineClientList(string LoginID, ACCOUNT_TYPE accType, string accountName, ClientAccountFilter filter, out List<ClientAccount> onlineClientList);

        #endregion

        #region 修改账户相关

        /// <summary>
        /// 修改客户资料
        /// </summary>
        /// <param name="clientAcc">客户资料</param>
        /// <param name="loginID">登陆标识</param>
        /// <returns>ErrType</returns>
        ErrType ModifyClientAccountInfo(ClientAccount clientAcc, string loginID);


        /// <summary>
        /// 修改客户资料
        /// </summary>
        /// <param name="clientAcc">客户资料</param>
        /// <param name="loginID">登陆标识</param>
        /// <returns>ErrType</returns>
        ErrType ModifyClientAccountInfo(ClientAccount clientAcc, FundsInformation Fdinfo, string loginID);

        ///// <summary>
        ///// 修改金商资料（包括权限）弃用
        ///// </summary>
        ///// <param name="dealerAcc">金商账户类</param>
        ///// <param name="loginID">登陆标识</param>
        ///// <param name="accType">账户类型，管理员或金商</param>
        ///// <returns>ErrType</returns>
        //ErrType ModifyDealerAccountInfo(DealerAccount dealerAcc, string loginID, ACCOUNT_TYPE accType);

        /// <summary>
        /// 修改管理员资料
        /// </summary>
        /// <param name="adminAcc">管理员资料</param>
        /// <param name="loginID">登陆标识</param>
        /// <returns>ErrType</returns>
        ErrType ModifyAdminAccountInfo(ManagerAccount adminAcc, string loginID);

        #endregion

        #region 新增账户相关

        /// <summary>
        /// 新增客户账号
        /// </summary>
        /// <param name="clientAcc">新增的客户资料信息</param>
        /// <param name="loginID">账户类型</param>
        /// <param name="accType">登录标识ID</param>
        /// <returns>ErrType</returns>
        ErrType AddClientAccount(ClientAccount clientAcc, UserTypeInfo type, string loginID);



        /// <summary>
        /// 新增客户账号
        /// </summary>
        /// <param name="clientAcc">新增的客户资料信息</param>
        /// <param name="Fdinfo">资金信息</param>
        /// <param name="loginID">账户类型</param>
        /// <param name="accType">登录标识ID</param>
        /// <returns>ErrType</returns>
        ErrType AddClientAccount(ClientAccount clientAcc,FundsInformation Fdinfo , UserTypeInfo type, string loginID);

        /// <summary>
        /// 新增金商账号
        /// </summary>
        /// <param name="dealerAcc">新增的金商账号信息</param>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <returns>ErrType</returns>
        ErrType AddDealerAccount(DealerAccount dealerAcc, string loginID, ACCOUNT_TYPE accType);

        /// <summary>
        /// 新增管理员账户
        /// </summary>
        /// <param name="mgrAcc">新增的管理员账户信息</param>
        /// <param name="loginID">登陆标识</param>
        /// <returns>ErrType</returns>
        ErrType AddManagerAccount(ManagerAccount mgrAcc, string loginID);

        #endregion

        #region 删除账户相关

        /// <summary>
        /// 删除指定的客户账户
        /// </summary>
        /// <param name="clientAccountName">要删除的客户账户名</param>
        /// <param name="loginID">登陆标识</param>
        /// <returns>ErrType</returns>
        ErrType DeleteClientAccount(string accountName, string loginID);

        /// <summary>
        /// 删除指定的金商账户
        /// </summary>
        /// <param name="accountName">要删除的金商账户名</param>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <returns>ErrType</returns>
        ErrType DeleteDealerAccount(string accountName, string loginID, ACCOUNT_TYPE accType);

        /// <summary>
        /// 删除指定管理员账户
        /// </summary>
        /// <param name="accountName">要删除的管理员账户名</param>
        /// <param name="loginID">登陆标识</param>
        /// <returns>ErrType</returns>
        ErrType DeleteManagerAccount(string accountName, string loginID);

        #endregion

        #region 客户资金相关

        /// <summary>
        /// 获取客户资金信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="accountName">要查询的客户账户名</param>
        /// <param name="fundsInfo">返回的客户资金信息</param>
        /// <returns>ErrType</returns>
        ErrType GetClientFundsInfo(string loginID, ACCOUNT_TYPE accType, string accountName, out FundsInformation fundsInfo);

        /// <summary>
        /// 修改客户资金信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="accountName">要查询的客户账户名</param>
        /// <param name="fundsInfo">新的客户资金信息</param>
        /// <returns>ErrType</returns>
        ErrType ModifyClientFundsInfo(string loginID, ACCOUNT_TYPE accType, string accountName, FundsInformation fundsInfo);

        /// <summary>
        /// 库存结算操作，如果资金大于0，则表示入金，反之则为出金
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="accountName">要查询的客户账户名</param>
        /// <param name="money">出入金金额，大于0为入金，小于0为出金</param>
        /// <returns>ErrType</returns>
        ErrType CashIO(string loginID, ACCOUNT_TYPE accType, string accountName, double money);

        /// <summary>
        /// 资金调整
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="accountName">要查询的客户账户名</param>
        /// <param name="money">资金调整金额</param>
        /// <returns>ErrType</returns>
        ErrType AdjustMoney(string loginID, ACCOUNT_TYPE accType, string accountName, double money);
        #endregion

        #region 获取有效定单列表

        /// <summary>
        /// 有效定单查询
        /// </summary>
        /// <param name="loginID">登录ID标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="requestInfo">查询的限定信息</param>
        /// <param name="orderList">返回的有效定单列表</param>
        /// <returns>ErrType</returns>
        ErrType GetMarketOrderList(string loginID, ACCOUNT_TYPE accType, RequestInformationBase requestInfo, out List<MarketOrderData> orderList);

        #endregion

        #region 获取限价挂单列表

        /// <summary>
        /// 限价挂单查询
        /// </summary>
        /// <param name="loginID">登录ID标识</param>
        /// <param name="accType">账户类型，管理员或金商</param>
        /// <param name="requestInfo">查询的限定信息</param>
        /// <param name="orderList">返回的限价挂单列表</param>
        /// <returns>ErrType</returns>
        ErrType GetPendingOrderList(string loginID, ACCOUNT_TYPE accType, RequestInformationBase requestInfo, out List<PendingOrderData> orderList);

        #endregion

        #region 获取对冲记录列表

        ///// <summary>
        ///// 获取对冲交易记录
        ///// </summary>
        ///// <param name="loginID">登录ID标识</param>
        ///// <param name="accType">账户类型，管理员或金商</param>
        ///// <param name="requestInfo">查询的限定信息</param>
        ///// <param name="orderList">返回的对冲交易记录</param>
        ///// <returns>ErrType</returns>
        //ErrType GetHedgingTradeList(string loginID, ACCOUNT_TYPE accType, RequestInformationBase requestInfo, out List<HedgingTradeData> orderList);
        ClientHedgingInfo GetHedgingTradeList(string loginID, ACCOUNT_TYPE accType, RequestInformationBase requestInfo);
        #endregion

        #region 获取导出报表地址

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
        ErrType GetExportStatementsWebAddr(string loginID, ACCOUNT_TYPE accType, DateTime startTime, DateTime endTime, STATEMENTS_TYPE type, out string webAddr);


         ErrType GetExportStatementsWebAddrUser(string TradeAccount, string UserName, string TelPhone, string Broker,
            string orgid, string IsBroker, string loginID, DateTime startTime, DateTime endTime, STATEMENTS_TYPE type, out string webAddr);
        #endregion

        #region 交易日相关

        /// <summary>
        /// 获取交易日信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="tradingInfoes">返回的交易日信息</param>
        /// <returns>ErrType</returns>
        ErrType GetTradingDayInfo(string loginID ,string StockCode, out List<TradingDayInformation> tradingInfoes);

        /// <summary>
        /// 修改指定的交易日信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="tradingDayInfo">新的交易日信息</param>
        /// <returns>ErrType</returns>
        ErrType ModifyTradingDayInfo(string loginID, TradingDayInformation tradingDayInfo);

        #endregion

        #region 节假日相关

        /// <summary>
        /// 获取节假日信息列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="holidayInfoes">翻译的节假日信息列表</param>
        /// <returns>ErrType</returns>
        ErrType GetHolidayInfo(string loginID, out List<HolidayInformation> holidayInfoes);

        /// <summary>
        /// 添加新的节假日信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="holidayInfo">新的节假日信息</param>
        /// <returns>ErrType</returns>
        ErrType AddHolidayInfo(string loginID, HolidayInformation holidayInfo);

        /// <summary>
        /// 删除指定的节假日
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="holidayName">要删除的节假日名称</param>
        /// <returns>ErrType</returns>
        ErrType DeleteHoliday(string loginID, string holidayName);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="holidayInfo"></param>
        /// <returns></returns>
        ErrType ModifyHolidayInfo(string loginID, HolidayInformation holidayInfo);

        #endregion

        #region 交易设置相关
        /// <summary>
        /// 添加交易设置信息
        /// </summary>
        /// <param name="tradingSettingInfo">交易设置信息</param>
        /// <param name="loginId">登陆标识</param>
        /// <returns></returns>
        ErrType AddTradeSet(TradeConfigInfo tradingSettingInfo, String loginId);

        /// <summary>
        /// 修改交易设置信息 
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="tradingSettingInfo">修改后的交易设置信息</param>
        /// <returns>ErrType</returns>
        ErrType ModifyTradeSet(string loginID, TradeConfigInfo tradingSettingInfo);

        /// <summary>
        /// 删除交易设置信息 
        /// </summary>
        /// <param name="ObjCode">交易设置信息--代码</param>
        /// <param name="loginID">登陆标识</param>
        /// <returns>ErrType</returns>
        ErrType DelTradeSet(string ObjCode, String LoginId);
        #endregion

        #region 日志记录

        /// <summary>
        /// 获取日志信息列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="logType">日志类型，管理员或金商</param>
        /// <param name="startTime">起始日志时间</param>
        /// <param name="endTime">结束日志时间</param>
        /// <param name="logInfoes">返回的日志信息列表</param>
        /// <returns>ErrType</returns>
        ErrType GetLogInfo(string loginID, LogRequestInformation logRequestInfo, out List<LogInformation> logInfoes);

        #endregion

        #region IP地址过滤相关

        /// <summary>
        /// 获取IP地址过滤信息列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="ipAddrFilterInfoes">返回的IP地址过滤列表</param>
        /// <returns>ErrType</returns>
        ErrType GetIPAddrFilteringInfoList(string loginID, out List<IPAddressFilterInformation> ipAddrFilterInfoes);

        /// <summary>
        /// 添加新的IP地址过滤信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="ipAddrFilterInfo">要添加的新的IP地址过滤条件</param>
        /// <returns>ErrType</returns>
        ErrType AddIPAddrFilteringInfo(string loginID, IPAddressFilterInformation ipAddrFilterInfo);

        /// <summary>
        /// 删除指定的IP地址过滤信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="ipFilterName">指定的IP地址过滤信息名称</param>
        /// <returns>ErrType</returns>
        ErrType DeleteIPAddrFilteringInfo(string loginID, string ipFilterID);

        /// <summary>
        /// 修改选中的IP地址过滤信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="ipAddrFilterInfo">修改后的IP地址过滤信息</param>
        /// <returns>ErrType</returns>
        ErrType ModifyIPAddrFilteringInfo(string loginID, IPAddressFilterInformation ipAddrFilterInfo);

        #endregion

        #region MAC地址过滤相关

        /// <summary>
        /// 获取MAC地址过滤信息列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="macFilterInfoes">返回的MAC过滤地址列表</param>
        /// <returns>ErrType</returns>
        ErrType GetMACFilterInfoList(string loginID, out List<MACFilterInformation> macFilterInfoes);

        /// <summary>
        /// 添加新的MAC过滤信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="macFilterInfo">要添加的新的MAC过滤信息</param>
        /// <returns>ErrType</returns>
        ErrType AddMACFilterInfo(string loginID, MACFilterInformation macFilterInfo);

        /// <summary>
        /// 删除某个MAC过滤信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="macFilterID">选中的MAC过滤信息ID</param>
        /// <returns>ErrType</returns>
        ErrType DeleteMACFilterInfo(string loginID, string macFilterID);

        /// <summary>
        /// 修改选中的MAC地址过滤信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="macFilterInfo">修改后的MAC地址过滤信息</param>
        /// <returns>ErrType</returns>
        ErrType ModifyMACFilterInfo(string loginID, MACFilterInformation macFilterInfo);

        #endregion

        #region 商品管理相关

        /// <summary>
        /// 获取商品信息列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="infoList">返回的商品信息列表</param>
        /// <returns>ErrType</returns>
        ErrType GetProductInfoList(string loginID, out List<ProductInformation> infoList);

        /// <summary>
        /// 新增商品信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="productInfo">新增的商品信息</param>
        /// <returns>ErrType</returns>
        ErrType AddProductInfo(string loginID, ProductInformation productInfo);

        /// <summary>
        /// 删除指定的商品信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="productCode">要删除的商品编码</param>
        /// <returns>ErrType</returns>
        ErrType DeleteProductInfo(string loginID, string productCode);

        /// <summary>
        /// 修改指定的商品信息
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="productInfo">新的商品信息</param>
        /// <returns>ErrType</returns>
        ErrType ModifyProductInfo(string loginID, ProductInformation productInfo);
        #endregion

        #region 汇率和水相关

        /// <summary>
        /// 获取汇率和水信息列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="infoList">返回的汇率和水信息列表</param>
        /// <returns>ErrType</returns>
        ErrType GetRateWaterInfoList(string loginID, out List<ExchangeRateWaterInformation> infoList);

        /// <summary>
        /// 修改指定的汇率和水的信息
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="rateWaterInfo"></param>
        /// <returns></returns>
        ErrType ModifyRateWaterInfo(string loginID, ExchangeRateWaterInformation rateWaterInfo);

        #endregion

        #region 手工报价
        /// <summary>
        /// 手工报价
        /// </summary>
        /// <param name="loginId">登录标识ID</param>
        /// <param name="priceCode">商品代码</param>
        /// <param name="realPrice">实时价</param>
        /// <returns>ErrType</returns>
        ErrType ManualPrice(String loginId, String priceCode, double realPrice);
        #endregion

        #region 新闻公告
        /// <summary>
        /// 添加新闻公告记录
        /// </summary>
        /// <param name="newsInfo">新闻公告记录</param>
        /// <param name="loginId">登录用户标识ID</param>
        /// <returns></returns>
        ErrType AddTradeNews(NewsInfo newsInfo, String loginId);

        /// <summary>
        /// 删除新闻公告记录
        /// </summary>
        /// <param name="id">新闻记录ID</param>
        /// <param name="loginId">登录用户标识ID</param>
        /// <returns></returns>
        ErrType DelTradeNews(string id, String loginId);

        /// <summary>
        /// 编辑新闻公告
        /// </summary>
        /// <param name="newsInfo">新闻记录</param>
        /// <param name="loginId">登录用户标识</param>
        /// <returns></returns>
        ErrType ModifyTradeNews(NewsInfo newsInfo, String loginId);
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
        ErrType ModifyOrderAllowStore(int UserType, string LoginId, string TradeAccount, string OrderId, int AllowStore);
        #endregion

        #region 有效定单分页查询 马友春
        /// <summary>
        /// 有效定单分页查询
        /// </summary>
        /// <param name="Cxqc">查询条件</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="pagesize">返回列表</param>
        /// <param name="page">输出参数：总页数</param>
        /// <returns></returns>
        ClientTradeOrderInfo GetMultiTradeOrderWithPage(CxQueryConInfomation Cxqc, int pageindex, int pagesize, ref int pageCount);

        #endregion

        #region 限价定单分页查询 马友春
        /// <summary>
        /// 限价定单分页查询
        /// </summary>
        /// <param name="Cxqc">查询条件</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="pagesize">返回列表</param>
        /// <param name="page">输出参数：总页数</param>
        /// <returns></returns>
        ClientTradeHoldOrderInfo GetMultiTradeHoldOrderWithPage(CxQueryConInfomation Cxqc, int pageindex, int pagesize, ref int pageCount);

        #endregion

        #region 平仓历史分页查询
        ClientLTradeOrderInfo GetMultiLTradeOrderWithPage(CxQueryConInfomation Cxqc, string Ltype, int pageindex, int pagesize, ref int page);
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
        ErrType GetUserBaseInfoWithPage(UserQueryConInfomation Uqc, int pageindex, int pagesize, ref int pageCount, out List<ClientAccount> clientList);

        /// <summary>
        /// 客户资料分页查询
        /// </summary>
        /// <param name="Uqc">查询条件</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">输出参数：总页数</param>
        /// <param name="page">返回列表</param>
        /// <returns></returns>
        ClientUserBaseInfo GetUserBaseInfoWithPage(UserQueryConInfomation Uqc, int pageindex, int pagesize, ref int pageCount);
        #endregion

        #region 日志记录分页查询 马友春
        ErrType GetTradeALogInfoWithPage(LogQueryConInfomation Uqc, int pageindex, int pagesize, ref int pageCount, out List<LogInformation> logInfoes);
        #endregion

        /// <summary>
        /// 交割单[买跌]分页查询 马友春
        /// </summary>
        ErrType GetMultiTradeChcekWithPage(CxQueryConInfomation query, int pageindex,
                                                 int pagesize, ref int pageCount,
                                                 ref List<BzjRecoverOrder> bzjRecoverOrderList);

        /// <summary>
        /// 交割单[买跌]处理
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="PayTime">付款时间</param>
        /// <param name="LoginId"></param>
        /// <param name="UserType">操作用户类型</param>
        /// <returns></returns>
        ErrType ModifyTradeCheck(string orderid, DateTime PayTime, string LoginId, int UserType);

        /// <summary>
        /// 买跌检测（买跌单）
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="realWeight">实际克重</param>
        /// <param name="LoginId"></param>
        /// <param name="UserType">操作用户类型</param>
        /// <returns></returns>
        ErrType RecordRealWeight(string orderid, double realWeight, string LoginId, int UserType);


        #region 店员资料分页查询

        /// <summary>
        /// 店员资料分页查询
        /// </summary>
        ErrType GetClerkBaseInfoWithPage(BzjClerkQueryCon Cqc, int pageindex,
                                               int pagesize, ref int pageCount, ref ObservableCollection<BzjClerk> bzjClerkList);
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
        ErrType AddClerk(BzjClerk bzjClerk, DealerAuthority bzjAuth, string LoginId, int UserType);

        #endregion


        #region 店员资料修改

        /// <summary>
        /// 店员资料修改
        /// </summary>
        /// <param name="bzjClerk">店员信息</param>
        /// <param name="LoginId">登录标识</param>
        /// <param name="UserType">登录用户类型</param>
        ErrType ModifyClerk(BzjClerk bzjClerk, string LoginId, int UserType);
        #endregion


        #region 店员资料修改

        /// <summary>
        /// 店员资料修改
        /// </summary>
        /// <param name="clerkId">店员账号</param>
        /// <param name="LoginId">登录标识</param>
        /// <param name="UserType">登录用户类型</param>
        ErrType DelClerk(string clerkId, string LoginId, int UserType);
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
        ErrType GetClerkAuth(string clerkId, string LoginId, int UserType, ref DealerAuthority bzjClerkAuth);
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
        ErrType ModifyClerkAuth(DealerAuthority bzjAuth, string clerkId, string LoginId, int UserType);
        #endregion

        #region 角色权限

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">角色信息</param>
        /// <returns></returns>
        ErrType AddRole(string loginID, RoleInfo roleInfo);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">角色ID</param>
        /// <returns></returns>
        ErrType DeleteRole(string loginID, string roleID);

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">角色信息</param>
        /// <returns></returns>
        ErrType UpdateRole(string loginID, RoleInfo roleInfo);


        /// <summary>
        /// 新增权限
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="list">权限列表信息</param>
        /// <param name="roldeID">角色ID</param>
        /// <returns></returns>
        ErrType AddRolePrivileges(string loginID, ObservableCollection<PrivilegeInfo> list, string roldeID);

        /// <summary>
        /// 5.1.6	获取系统所有角色数据
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">角色信息列表</param>
        /// <returns></returns>
        ErrType GetRoles(string loginID, ref ObservableCollection<RoleInfo> list);

        /// <summary>
        ///5.1.7	获取当前角色对应的权限数据
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">角色ID</param>
        /// <param name="list">权限列表</param>
        /// <returns></returns>
        ErrType GetPrivilegesRole(string loginID, string roleID, ref ObservableCollection<PrivilegeInfo> list);

        /// <summary>
        /// 5.2.10	根据用户ID获取所有用户权限集合
        /// </summary>
        /// <param name="loginID">登录标识ID</param>
        /// <param name="userID">用户ID</param>
        /// <param name="userPrivilegesInfo">权限</param>
        /// <returns></returns>
        ErrType UserRolePrivileges(string loginID, string userID, ref UserPrivilegesInfo userPrivilegesInfo);

        /// <summary>
        ///5.2.1权限新增
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="privilegeInfo">权限信息</param>
        /// <returns></returns>
        ErrType AddPrivileges(string loginID, PrivilegeInfo privilegeInfo);

        /// <summary>
        ///5.2.2	修改权限数据
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="privilegeInfo">权限信息</param>
        /// <returns></returns>
        ErrType UpdatePrivileges(string loginID, PrivilegeInfo privilegeInfo);

        /// <summary>
        ///5.2.3	权限删除
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="privilegeID">权限ID</param>
        /// <returns></returns>
        ErrType DeletePrivileges(string loginID, string privilegeID);

        /// <summary>
        ///5.2.11	获取所有用户权限集合
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="privilegeInfoList">权限信息列表</param>
        /// <returns></returns>
        ErrType GetPrivileges(string loginID, ref ObservableCollection<PrivilegeInfo> privilegeInfoList);

        /// <summary>
        /// 5.4.1	新增用户角色
        /// </summary>
        /// <param name="loginID">登录标识ID</param>
        /// <param name="roleID">角色ID</param>
        /// <param name="userID">用户ID</param>
        /// <returns>ErrType</returns>
        ErrType AddUserRole(string loginID, string roleID, string userID);

        /// <summary>
        /// 5.4.2	删除用户角色
        /// </summary>
        /// <param name="loginID">登录标识ID</param>
        /// <param name="userID">用户ID</param>
        /// <returns>ErrType</returns>
        ErrType DeleteUserRole(string loginID, string userID);

        /// <summary>
        /// 5.4.3	用户角色修改
        /// </summary>
        /// <param name="loginID">登录标识ID</param>
        /// <param name="roleID">角色ID</param>
        /// <param name="userID">用户ID</param>
        /// <returns>ErrType</returns>
        ErrType UpdateUserRole(string loginID, string roleID, string userID);

        /// <summary>
        /// 5.4.4	读取用户角色
        /// </summary>
        /// <param name="loginID">登录标识ID</param>
        /// <param name="userID">用户ID</param>
        /// <param name="roleID">角色ID</param>
        /// <returns>ErrType</returns>
        ErrType ReadUserRole(string loginID, string userID, ref string roleID);

        #endregion

        #region 微会员

        /// <summary>
        /// 获取父级微会员名称及ID
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        ErrType GetBaseOrgListAll(string loginID, ref ObservableCollection<OrgInfo> list);
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
        ErrType GetOrgList(string loginID, OrgInfo orgInfo, int pageindex, int pagesize, ref int pageCount,
                                 ref ObservableCollection<OrgInfo> list);

        /// <summary>
        /// 添加微会员
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">会员账户信息</param>
        /// <returns></returns>
        ErrType AddOrg(string loginID, OrgInfo orgInfo);

        /// <summary>
        /// 创建微会员代码
        /// </summary>
        /// <param name="orgid">微会员ID</param>
        /// <param name="telephone"></param>
        /// <param name="orgCode">返回参数，机构代码</param>
        ErrType GetOrgcode(string orgid, string telephone, ref string orgCode);

        /// <summary>
        /// 删除微会员
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">会员账户ID</param>
        /// <param name="orgName">会员账户名称</param>
        /// <returns></returns>
        ErrType DeleteOrg(string loginID, string orgID, string orgName);

        /// <summary>
        /// 更新微会员
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="roleInfo">会员账户信息</param>
        /// <returns></returns>
        ErrType UpdateOrg(string loginID, OrgInfo orgInfo);

        #endregion

        /// <summary>
        /// 获取出金分页查询
        /// </summary>
        /// <param name="Cjqc">查询条件</param>
        /// <param name="pageindex">页索引</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="pageCount">页总数</param>
        /// <param name="list">返回列表</param>
        /// <returns>ErrType</returns>
        ClientTradeChuJinInfo GetMultiTradeChuJinWithPage(CJQueryConInfomation Cjqc, int pageindex, int pagesize, ref int pageCount);


        /// <summary>
        /// 出金处理
        /// </summary>
        /// <param name="ApplyId">出金申请ID</param>
        /// <param name="LoginId">登陆ID</param>
        /// <param name="state">处理状态，"1"-已付款,"2"已拒绝 "3"处理中 "4"处理失败</param>
        /// <returns>ErrType</returns>
         ErrType ProcessChuJin(int ApplyId, String LoginId, ref string state);

        /// <summary>
        /// 出金拒绝
        /// </summary>
        /// <param name="ApplyId">出金申请ID</param>
        /// <param name="LoginId">登陆ID</param>
        /// <returns>ErrType</returns>
        ErrType RefusedChuJin(int ApplyId, String LoginId);

        /// <summary>
        /// 获取资金报表
        /// </summary>
        /// <param name="Fcqc">查询条件</param>
        /// <param name="pageindex">第几页,从1开始</param>
        /// <param name="pagesize">每页多少条</param>
        /// <param name="pageCount">输出参数(总页数)</param>
        /// <param name="list">List<FundChangeInformation></param>
        /// <returns>ErrType</returns>
        ClientFundChangeInfo GetMultiFundChangeWithPage(FcQueryConInfomation Fcqc, int pageindex, int pagesize,
            ref int pageCount);

        #region 解约处理
        /// <summary>
        /// 获取解约
        /// </summary>
        /// <param name="Cjqc"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="pageCount"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        ErrType GetMultiTerminationWithPage(CJQueryConInfomation Cjqc, int pageindex, int pagesize, ref int pageCount,
            out List<TradeJieYue> list);

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="ApplyId">解约id</param>
        /// <param name="LoginId">登陆标示</param>
        /// <returns></returns>
        ErrType ProcessJieYue(int ApplyId, string userid, String LoginId);
        /// <summary>
        /// 拒绝
        /// </summary>
        /// <param name="ApplyId"></param>
        /// <param name="LoginId"></param>
        /// <returns></returns>
        ErrType RefusedJieYue(int ApplyId, String LoginId);
        #endregion
        #region 会员报表
        /// <summary>
        /// 获取居间列表
        /// </summary>
        /// <param name="cond"></param>
        /// <returns></returns>
        void GetTradeJuJianInfo(SelectCondition cond, string UserID, ref ClientTradeJuJianInfo cinfo);
        #endregion

        /// <summary>
        /// 获取出入金和解约信息
        /// </summary>
        /// <param name="moneyList">ref List<TradeMoneyData></param>
        /// <returns>ErrType</returns>
        ErrType GetTradeMoneyInfo(ref List<TradeMoneyData> moneyList);
        /// <summary>
        /// 获取银行列表
        /// </summary>
        /// <returns></returns>
        ErrType GetTradeBank(ObservableCollection<Bank> banks);

        #region 客户分组
        /// <summary>
        /// 获取客户分组
        /// </summary>
        /// <param name="userGroups">返回的客户组列表</param>
        /// <returns></returns>
        ErrType GetUserGroupsInfo(ObservableCollection<UserGroup> userGroups);
        /// <summary>
        /// 添加客户组
        /// </summary>
        /// <param name="ugs"></param>
        /// <param name="LoginId"></param>
        /// <returns></returns>
        ErrType AddUserGroups(UserGroup ugs, String LoginId);
        /// <summary>
        /// 删除客户组
        /// </summary>
        /// <param name="UserGroupId"></param>
        /// <param name="LoginId"></param>
        /// <returns></returns>
        ErrType DelUserGroups(string UserGroupId, String LoginId);
        /// <summary>
        /// 修改客户组
        /// </summary>
        /// <param name="ugs"></param>
        /// <param name="LoginId"></param>
        /// <returns></returns>
        ErrType ModifyUserGroups(UserGroup ugs, String LoginId);

        /// <summary>
        /// 添加客户到客户组
        /// </summary>
        /// <param name="account">客户id</param>
        /// <param name="LoginId">登陆标示</param>
        /// <returns></returns>
        ErrType AddUserToUserGroups(string account, string Groupid, String LoginId, ref ClientAccount CAccount);
        /// <summary>
        /// 删除客户组的客户
        /// </summary>
        /// <param name="account">客户id</param>
        /// <param name="UserGroupId">用户组id</param>
        /// <param name="LoginId"></param>
        /// <returns></returns>
        ErrType DelUserFromUserGroups(string account, string UserGroupId, String LoginId);

        

        #endregion

        /// <summary>
        /// 创建微会员二维码
        /// </summary>
        /// <param name="orgId">微会员ID</param>
        /// <returns>ErrType</returns>
        ErrType CreateOrgTicket(string orgId);


        #region 体验券
        /// <summary>
        /// 获取体验券信息
        /// </summary>
        /// <param name="loginId">登录标识</param>
        /// <param name="type">类型</param>
        /// <param name="isEffciive">是否启用</param>
        /// <param name="endTime">到期时间</param>
        /// <param name="list">ObservableCollection<ExperienceInformation></param>
        /// <returns>ErrType</returns>
        ErrType GetExperienceInfo(string loginId, int type, int isEffciive, DateTime? endTime, ref ObservableCollection<ExperienceInformation> list);

        /// <summary>
        /// 添加体验券
        /// </summary>
        /// <param name="loginId">登录标识</param>
        /// <param name="ex">体验券</param>
        /// <returns>ResultDesc</returns>
        ErrType AddExperience(string loginId, ExperienceInformation ex);


        /// <summary>
        /// 编辑体验券
        /// </summary>
        /// <param name="loginId">登录标识</param>
        /// <param name="ex">体验券</param>
        /// <returns>ResultDesc</returns>
        ErrType EditExperience(string loginId, ExperienceInformation ex);

        /// <summary>
        /// 删除体验券
        /// </summary>
        /// <param name="loginId">登录标识</param>
        /// <param name="id">体验券标识</param>
        /// <returns>ResultDesc</returns>
        ErrType DelExperience(string loginId, int id);

        #endregion
    }
}
