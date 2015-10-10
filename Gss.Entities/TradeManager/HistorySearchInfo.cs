using System;

namespace Gss.Entities {
    /// <summary>
    /// 历史数据查询信息
    /// </summary>
    public class HistorySearchInfo {
        /// <summary>
        /// Gets or sets the end date time to filter history result.
        /// 获取或设置作为过滤条件的结束时间
        /// </summary>
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Gets or sets the orders type.
        /// 获取或设置定单类型，all表示全部
        /// </summary>
        public string OrdersType { get; set; }

        /// <summary>
        /// Gets or sets the page index of history result.
        /// 获取或设置当前显示结果的页面序列数
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the page size of history result.
        /// 获取或设置当前显示结果的页面大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the product name to filter history result.
        /// 获取或设置作为结果过滤条件的商品名称，all表示全部
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the start date time to filter history result.
        /// 获取或设置作为过滤条件的起始时间
        /// </summary>
        public DateTime StartDateTime { get; set; }

        private string _tradeAccount;

        /// <summary>
        /// 获取或设置作为过滤条件的用户账户
        /// </summary>
        public string TradeAccount {
            get { return _tradeAccount; }
            set { _tradeAccount = value; }
        }

        /// <summary>
        /// 获取或设置用户类型，0：交易用户，1：管理员，2：金商
        /// </summary>
        public int UserType { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string OrgName { get; set; }
    }
}
