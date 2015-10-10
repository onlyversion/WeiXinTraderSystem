using System;
using Gss.Entities.Enums;

namespace Gss.Entities {
    /// <summary>
    /// 有效定单历史数据
    /// </summary>
    public class MarketHistoryData {
        /// <summary>
        /// 获取或设置基础工费
        /// </summary>
        public double BasicLaborCharge { get; set; }

        /// <summary>
        /// 获取或设置历史编号
        /// </summary>
        public string HistoryID { get; set; }

        /// <summary>
        /// 获取或设置盈亏值
        /// </summary>
        public double LossOrProfit { get; set; }

        /// <summary>
        /// 获取或设置定单号
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 获取或设置定单价
        /// </summary>
        public double OrderPrice { get; set; }

        /// <summary>
        /// 获取或设置定单时间
        /// </summary>
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// 获取或设置定单类型
        /// </summary>
        public TRANSACTION_TYPE OrderType { get; set; }

        /// <summary>
        /// 获取商品编码
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 获取商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 获取或设置止损值
        /// </summary>
        public double StopLoss { get; set; }

        /// <summary>
        /// 获取或设置止盈值
        /// </summary>
        public double StopProfit { get; set; }

        /// <summary>
        /// 获取或设置仓储费
        /// </summary>
        public double StorageCharge { get; set; }

        /// <summary>
        /// 获取或设置客户账户
        /// </summary>
        public string TradeAccount { get; set; }

        /// <summary>
        /// 获取或设置所属会员名称
        /// </summary>
        public string OrgName { get; set; }

        /// <summary>
        /// 获取或设置客户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 获取或设置会员编码
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 获取或设置交易数量
        /// </summary>
        public double TradeCount { get; set; }

        /// <summary>
        /// 获取或设置交易价
        /// </summary>
        public double TradePrice { get; set; }

        /// <summary>
        /// 获取或设置交易时间
        /// </summary>
        public DateTime TradeTime { get; set; }

        /// <summary>
        /// 获取或设置平仓方式    0系统强制平仓,1手动平仓,2入库
        /// </summary>
        public CHARGEBACK_MODE TradeType { get; set; }
    }
}
