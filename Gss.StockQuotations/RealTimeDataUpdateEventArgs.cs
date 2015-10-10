using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.StockQuotations {
    public class RealTimeDataUpdateEventArgs : EventArgs {
        /// <summary>
        /// 行情编码
        /// </summary>
        public string StockCode { get; private set; }

        /// <summary>
        /// 实时价格
        /// </summary>
        public double Price { get; private set; }

        /// <summary>
        /// 实时时间
        /// </summary>
        public DateTime Time { get; private set; }

        /// <summary>
        /// 实例化一个实时数据更新事件参数类
        /// </summary>
        /// <param name="stockCode">更新的行情名称</param>
        /// <param name="price">最新的价格</param>
        /// <param name="time">当前时间</param>
        public RealTimeDataUpdateEventArgs( string stockCode, double price, DateTime time ) {
            StockCode = stockCode;
            Price = price;
            Time = time;
        }
    }
}
