namespace Gss.Entities.Enums
{
    /// <summary>
    /// 报表类型枚举
    /// </summary>
    public enum STATEMENTS_TYPE
    {
        NULL = -1,
        /// <summary>
        /// 定单报表
        /// </summary>
        MarketOrder = 0,
        /// <summary>
        /// 挂单报表
        /// </summary>
        PendingOrder = 1,
        /// <summary>
        /// 入库报表
        /// </summary>
        Warehousing = 2,
        /// <summary>
        /// 平仓报表
        /// </summary>
        Chargeback = 3,
        /// <summary>
        /// 资金调整
        /// </summary>
        AdjustDeposit = 4,
        /// <summary>
        /// 账户结余
        /// </summary>
        AccountBalance=5,
        /// <summary>
        /// 提货受理报表
        /// </summary>
        AgentDoDetail = 6,
        /// <summary>
        /// 买跌单报表
        /// </summary>
        OrderBackReport = 7,
        /// <summary>
        /// 买涨交割单报表
        /// </summary>
        OrderTakeReport=8,
        /// <summary>
        /// 转金生金报表
        /// </summary>
        JgjReport = 9,
        /// <summary>
        /// 买跌交割单报表
        /// </summary>
        OrderCheckReport=10,

        /// <summary>
        /// 用户报表
        /// </summary>
        UserPeport=11
    }
}
