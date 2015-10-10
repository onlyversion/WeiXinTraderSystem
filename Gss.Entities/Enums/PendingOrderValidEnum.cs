namespace Gss.Entities.Enums {
    /// <summary>
    /// 挂单有效期枚举
    /// </summary>
    public enum PENDINGORDER_VALID {
        /// <summary>
        /// 客户自定义
        /// </summary>
        CustomerDefine = 0,

        /// <summary>
        /// 定单当日有效
        /// </summary>
        OrderDay = 1,

        /// <summary>
        /// 一直有效
        /// </summary>
        Always = 2,
    }
}
