using Gss.Entities.Enums;

namespace Gss.Entities {
    /// <summary>
    /// 对冲记录信息
    /// </summary>
    public class HedgingTradeData {
        /// <summary>
        /// 获取或设置平均价格
        /// </summary>
        public double AveragePrice { get; set; }

        /// <summary>
        /// 获取或设置平均价格
        /// </summary>
        public double? AveragePrice2 { get; set; }

        /// <summary>
        /// 获取或设置对冲盈亏
        /// </summary>
        public double HedgingLossOrProfit { get; set; }

        /// <summary>
        /// 获取或设置对冲数量
        /// </summary>
        public double HedgingQuantity { get; set; }

        /// <summary>
        /// 获取或设置对冲仓储费
        /// </summary>
        public double HedgingStorageFee { get; set; }

        /// <summary>
        /// 获取或设置对冲工费
        /// </summary>
        public double HedgingTradeFee { get; set; }

        /// <summary>
        /// 获取或设置盈亏
        /// </summary>
        public double LossOrProfit { get; set; }

        /// <summary>
        /// 获取或设置盈亏
        /// </summary>
        public double? LossOrProfit2 { get; set; }

        /// <summary>
        /// 获取或设置定单数量
        /// </summary>
        public double OrderQuantity { get; set; }

        /// <summary>
        /// 获取或设置定单数量
        /// </summary>
        public double? OrderQuantity2 { get; set; }

        /// <summary>
        /// 获取或设置定单类型
        /// </summary>
        public TRANSACTION_TYPE OrderType { get; set; }

        /// <summary>
        /// 获取或设置定单类型
        /// </summary>
        public TRANSACTION_TYPE? OrderType2 { get; set; }

        /// <summary>
        /// 获取或设置商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 获取或设置实时价
        /// </summary>
        public double RealTimePrice { get; set; }

        /// <summary>
        /// 获取或设置实时价
        /// </summary>
        public double? RealTimePrice2 { get; set; }

        /// <summary>
        /// 获取或设置仓储费
        /// </summary>
        public double StorageFee { get; set; }

        /// <summary>
        /// 获取或设置仓储费
        /// </summary>
        public double? StorageFee2 { get; set; }

        /// <summary>
        /// 获取或设置基础工费
        /// </summary>
        public double TradeFee { get; set; }

        /// <summary>
        /// 获取或设置基础工费
        /// </summary>
        public double? TradeFee2 { get; set; }
    }
}
