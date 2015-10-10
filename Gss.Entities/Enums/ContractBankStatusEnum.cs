namespace Gss.Entities.Enums {
    /// <summary>
    /// 签约状态枚举
    /// </summary>
    public enum CONTRACT_STATUS {
        /// <summary>
        /// 未绑定银行状态
        /// </summary>
        Unbound = 0,

        /// <summary>
        /// 审核中
        /// </summary>
        Auditing = 1,

        /// <summary>
        /// 绑定成功
        /// </summary>
        Binding = 2,

        /// <summary>
        /// 审核失败
        /// </summary>
        AuditFailure = 3,

        /// <summary>
        /// 已解约
        /// </summary>
        Termination = 4,
    }

}
