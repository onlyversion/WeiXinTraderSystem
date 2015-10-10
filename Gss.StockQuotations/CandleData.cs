using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gss.Common.Utility;

namespace Gss.StockQuotations {
    /// <summary>
    /// 存储一个完整的蜡状图数据类
    /// </summary>
    public class CandleData {
        #region 属性

        /// <summary>
        /// 获取或设置收盘价，有时亦为实时价
        /// </summary>
        public double Close { get; set; }

        /// <summary>
        /// 获取或设置最高价
        /// </summary>
        public double High { get; set; }

        /// <summary>
        /// 获取或设置最低价
        /// </summary>
        public double Low { get; set; }

        /// <summary>
        /// 获取或设置开盘价
        /// </summary>
        public double Open { get; set; }

        /// <summary>
        /// 获取或设置报价时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 获取或设置成交量
        /// </summary>
        public long Volume { get; set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 用一个完整的蜡状数据实例化一个蜡状数据类
        /// </summary>
        /// <param name="time">蜡状数据时间</param>
        /// <param name="open">开盘价</param>
        /// <param name="high">最高价</param>
        /// <param name="low">最低价</param>
        /// <param name="close">收盘价</param>
        /// <param name="volume">成交量</param>
        public CandleData( DateTime time, double open, double high, double low, double close, long volume ) {
            Time = time;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
        }  

        #endregion

        #region 公用接口

        /// <summary>
        /// 将一个数据字符串转换成蜡状图数据类
        /// </summary>
        /// <param name="dataStr">包含蜡状图数据的字符串</param>
        /// <returns>蜡状图数据类</returns>
        public static CandleData GetCandleDataFromString( string dataStr ) {
            string[] array = dataStr.Split( '\t', ' ' );

            if( array.Length != 7 )
                throw new FormatException( "行情数据格式化异常，请确认数据源以及行情数据结构是否改变" );

            DateTime time = DateTimeHelper.GetDateTimeFromTimeKey( array[0] );
            double open = Convert.ToDouble( array[1] );
            double high = Convert.ToDouble( array[2] );
            double low = Convert.ToDouble( array[3] );
            double close = Convert.ToDouble( array[4] );
            long volume = Convert.ToInt64( array[5] );

            return new CandleData( time, open, high, low, close, volume );
        }

        #endregion

    }
}
