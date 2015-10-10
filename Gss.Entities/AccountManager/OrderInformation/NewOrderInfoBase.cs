using System;
using Gss.Entities.Enums;

namespace Gss.Entities {
    /// <summary>
    /// 新定单各项基本信息的类，作为有效定单和限价挂单的基类
    /// </summary>
    public abstract class NewOrderInfoBase {
        /// <summary>
        /// 获取或设置下单数量
        /// </summary>
        public double Count { get; set; }

        /// <summary>
        /// 获取或设置本机Mac地址
        /// </summary>
        public string MAC { get; set; }

        /// <summary>
        /// 获取或设置下单类型: 买跌或者买涨
        /// </summary>
        public TRANSACTION_TYPE OrderType { get; set; }

        /// <summary>
        /// 获取或设置保证金百分比
        /// </summary>
        public double PercentageOfDeposit { get; set; }

        /// <summary>
        /// 获取或设置商品编码
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 获取或设置定单实时价
        /// </summary>
        public double RealTimePrice { get; set; }

        /// <summary>
        /// 获取或设置定单时间
        /// </summary>
        public DateTime RealTimeTime { get; set; }

        /// <summary>
        /// 获取或设置止损价
        /// </summary>
        public double StopLossPrice { get; set; }

        /// <summary>
        /// 获取或设置止盈价
        /// </summary>
        public double StopProfitPrice { get; set; }
    }
}
