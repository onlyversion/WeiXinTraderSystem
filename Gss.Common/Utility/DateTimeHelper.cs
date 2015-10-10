using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Common.Utility {
    public class DateTimeHelper {
        private const string Default_Format = "yyyyMMddHHmmss";

        /// <summary>
        /// 从时间字符串获取DateTime
        /// </summary>
        /// <param name="timeKey">时间字符串</param>
        /// <param name="fmt">格式化方式</param>
        /// <returns>DateTime</returns>
        public static DateTime GetDateTimeFromTimeKey( string timeKey, string fmt = null ) {
            //int year = timeKey.Length >= 4 ? Convert.ToInt32( timeKey.Substring( 0, 4 ) ) : 1970;
            //int month = timeKey.Length >= 6 ? Convert.ToInt32( timeKey.Substring( 4, 2 ) ) : 1;
            //int day = timeKey.Length >= 8 ? Convert.ToInt32( timeKey.Substring( 6, 2 ) ) : 1;
            //int hr = timeKey.Length >= 10 ? Convert.ToInt32( timeKey.Substring( 8, 2 ) ) : 0;
            //int mn = timeKey.Length >= 12 ? Convert.ToInt32( timeKey.Substring( 10, 2 ) ) : 0;
            //int sc = timeKey.Length >= 14 ? Convert.ToInt32( timeKey.Substring( 12, 2 ) ) : 0;
            //return new DateTime( year, month, day, hr, mn, sc );
            string format = Default_Format.Substring( 0, timeKey.Length );//因为实时数据包含秒，但是历史数据不包含秒
            return DateTime.ParseExact( timeKey, format, null );
        }

        /// <summary>
        /// 将DateTime转化成时间字符串
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <param name="fmt">格式化方式</param>
        /// <returns>date time key string</returns>
        public static string GetTimeKeyFromDateTime( DateTime dt, string fmt = null ) {
            return string.IsNullOrEmpty( fmt ) ? dt.ToString( fmt ) : dt.ToString( Default_Format );
        }
    }
}
