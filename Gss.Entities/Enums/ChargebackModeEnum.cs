namespace Gss.Entities.Enums {
    /// <summary>
    /// 平仓方式枚举
    /// </summary>
    public enum CHARGEBACK_MODE {
        /// <summary>
        /// 系统强制平仓（爆仓/止盈止损）
        /// </summary>
        Auto = 0,
        /// <summary>
        /// 手动平仓
        /// </summary>
        User,
        /// <summary>
        /// 入库
        /// </summary>
        Warehousing,

        /// <summary>
        /// 结算平仓
        /// </summary>
        Balance,
        /// <summary>
        /// 自动平仓（止损平仓）
        /// </summary>
        AutoStopLose,
        /// <summary>
        /// 自动平仓（止盈平仓）
        /// </summary>
        AutoStopProfit



    }
}
