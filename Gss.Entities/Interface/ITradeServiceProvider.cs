using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Gss.Entities.AccountManager.Account;
using Gss.Entities.Enums;
using Gss.Entities.JTWEntityes;
using Gss.Entities.TradeManager;

namespace Gss.Entities.Interface {
    public interface ITradeServiceProvider {
        /// <summary>
        /// 获取有效定单历史记录列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="searchInfo">查询信息</param>
        /// <param name="pageCnt">返回的记录页数</param>
        /// <param name="historyList">返回的有效定单历史记录列表</param>
        /// <returns>ErrType</returns>
        ErrType GetChargebackRecorder( string loginID, HistorySearchInfo searchInfo, ref int pageCnt, out List<MarketHistoryData> historyList );

        /// <summary>
        /// 获取入库单历史记录列表
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="searchInfo">查询信息</param>
        /// <param name="pageCnt">返回的记录页数</param>
        /// <param name="historyList">返回的有效定单历史记录列表</param>
        /// <returns>ErrType</returns>
        ErrType GetWarehousingRecorder( string loginID, HistorySearchInfo searchInfo, ref int pageCnt, out List<WarehousingHistoryData> historyList );

        /// <summary>
        /// 市价单定单
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="clientAccountName">要下单的客户账户名</param>
        /// <param name="userType">用户类型，0：交易用户，1：管理员，2：金商</param>
        /// <param name="newOrderInfo">下单的定单信息</param>
        /// <returns>ErrType</returns>
        ErrType MarketOrder( string loginID, string clientAccountName, int userType, NewMarketOrderInfo newOrderInfo );

        /// <summary>
        /// 获取市价单
        /// </summary>
        /// <param name="UserType">用户类型(0交易用户 1表示管理员 2表示金商)</param>
        /// <param name="tradeAccount">用户交易账号</param>
        /// <param name="LoginID">登录标示</param>
        /// <returns></returns>
        List<MarketOrderData> GetMarketOrderList(string tradeAccount, string LoginID);

        /// <summary>
        /// 挂单查询
        /// </summary>
        /// <param name="UserType"></param>
        /// <param name="tradeAccount"></param>
        /// <param name="LoginID"></param>
        /// <returns></returns>
        List<PendingOrderData> GetTradeHoldOrder(string tradeAccount, string LoginID);

        /// <summary>
        /// 限价挂单定单
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="clientAccountName">要下单的客户账户名</param>
        /// <param name="userType">用户类型，0：交易用户，1：管理员，2：金商</param>
        /// <param name="newOrderInfo">下单的定单信息</param>
        /// <returns>ErrType</returns>
        ErrType PendingOrder( string loginID, string clientAccountName, int userType, NewPendingOrderInfo newOrderInfo );

        /// <summary>
        /// 市价单平仓
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="userType">用户类型，0：交易用户，1：管理员，2：金商</param>
        /// <param name="orderInfo">平仓信息</param>
        /// <returns>ErrType</returns>
        ErrType ChargebackOrder( string loginID, int userType, OrderChangedInformation orderInfo );

        /// <summary>
        /// 有效定单入库
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="userType">用户类型，0：交易用户，1：管理员，2：金商</param>
        /// <param name="orderInfo">平仓信息</param>
        /// <returns>ErrType</returns>
        ErrType WarehousingOrder( string loginID, int userType, OrderChangedInformation orderInfo );

        /// <summary>
        /// 撤销限价挂单
        /// </summary>
        /// <param name="loginID">登陆标识</param>
        /// <param name="userType">用户类型，0：交易用户，1：管理员，2：金商</param>
        /// <param name="orderData">要撤销的限价挂单</param>
        /// <returns>ErrType</returns>
        ErrType RevocationPendingOrder( string loginID, int userType, PendingOrderData orderData );

        /// <summary>
        /// 获取交易配置信息
        /// </summary>
        /// <param name="loginId">登录标识</param>
        /// <param name="list">配置信息</param>
        /// <returns></returns>
        ErrType GetTradeSetInfo(String loginId, ref ObservableCollection<TradeConfigInfo> list);

        /// <summary>
        /// 获取新闻公告信息
        /// </summary>
        /// <param name="loginId">登录用户标识ID</param>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <param name="nType">新闻类型</param>
        /// <param name="pageindex">页索引</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="page">页总数</param>
        ///  <param name="list">新闻数据集</param>
        /// <returns></returns>
        ErrType GetTradeNewsInfoWithPage(
            string loginId, DateTime starttime, DateTime endtime, NewsTypeEnum nType,
            int pageindex, int pagesize, ref int page, ref ObservableCollection<NewsInfo> list);
        //List<HisData> GetHisDataWithPage(Gss.TradeService.TradeService.HisQueryCon HisCon, int pageindex, int pagesize, ref int page);
        /// <summary>
        /// 获取历史数据
        /// </summary>
        /// <param name="loginId">登录用户标识ID</param>
        /// <param name="starttime">开始时间</param>
        /// <param name="endtime">结束时间</param>
        /// <param name="pageindex">页索引</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="page">页总数</param>
        /// <returns></returns>
        ErrType GetHistoryDataInfoWithPage(
            string loginId, string weekTime, DateTime starttime, DateTime endtime,string productNum,string cycle,
            int pageindex, int pagesize, ref int page, ref ObservableCollection<HisData> list);

       // Gss.TradeService.TradeService.ResultDesc ModifyHisData(Gss.TradeService.TradeService.HisData hisdata, string pricecode, string weekflg);
        /// <summary>
        /// 修改历史数据
        /// </summary>
        /// <param name="hisdata">HisData</param>
        /// <param name="pricecode">产品编码</param>
        /// <param name="weekflg">周期</param>
        /// <returns></returns>
        ErrType ModifyHisData(HisData hisdata, string pricecode, string weekflg);


        /// <summary>
        /// Modify login password.
        /// </summary>
        /// <param name="loginID">login ID</param>
        /// <param name="oldPwd">old password</param>
        /// <param name="newPwd">new password</param>
        /// <returns>ErrType</returns>
        ErrType ModifyLoginPassword(string loginID, string oldPwd, string newPwd);

        /// <summary>
        /// Modify funds password.
        /// </summary>
        /// <param name="loginID">login ID</param>
        /// <param name="oldPwd">old password</param>
        /// <param name="newPwd">new password</param>
        /// <returns>ErrType</returns>
        ErrType ModifyFundsPassword(string loginID, string oldPwd, string newPwd);

        /// <summary>
        /// 获取用户资金信息
        /// </summary>
        /// <param name="accountName">用户账号</param>
        /// <param name="loginId">登录ID</param>
        /// <param name="fund">ref  FundInformation</param>
        /// <returns>ErrType</returns>
        ErrType GetMoneyInventoryEx(string accountName, string loginId, ref FundInformation fund);

        /// <summary>
        /// 获取微会员微信二维码地址
        /// </summary>
        /// <param name="loginId">登录ID</param>
        /// <param name="orgID">微会员ID</param>
        /// <param name="url">输出Url</param>
        /// <returns>ErrType</returns>
        ErrType GetOrgTicketUrl(string loginId, string orgID, ref string url);

        /// <summary>
        /// 设置会员佣金比例
        /// </summary>
        /// <param name="loginId">登录标识</param>
        /// <param name="ratio1">一级佣金比例</param>
        /// <param name="ratio2">二级佣金比例</param>
        /// <param name="ratio3">三级佣金比例</param>
        /// <param name="orgIDList">待设置的会员列表</param>
        /// <returns>ResultDesc</returns>

        ErrType SetCommissionRatio(string loginId, double ratio1, double ratio2, double ratio3,
            List<string> orgIDList);

        /// <summary>
        /// 获取会员返佣比例
        /// </summary>
        /// <param name="loginId">登录ID</param>
        /// <param name="orgID">微会员ID</param>
        /// <param name="url">输出Url</param>
        /// <returns>ErrType</returns>
        ErrType GetCommissionRatio(string loginId, string orgID, ref CommissionRatioSet ratio,bool type);
    }
}
