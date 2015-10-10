namespace Gss.Entities.Enums {
    /// <summary>
    /// 商品状态枚举
    /// </summary>
    public enum PRODUCT_STATE {
        /// <summary>
        /// 正常交易
        /// </summary>
        All = 0,
        /// <summary>
        /// 只报价
        /// </summary>
        AllowQuotation,
        /// <summary>
        /// 只买涨
        /// </summary>
        AllowOrder,
        /// <summary>
        /// 只买跌
        /// </summary>
        AllowRecovery,
        None,
    }
}
