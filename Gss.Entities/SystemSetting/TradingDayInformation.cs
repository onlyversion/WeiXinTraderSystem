using System;
using Gss.Common.Infrastructure;
using Gss.Common.Utility;
using Gss.Entities.Enums;

namespace Gss.Entities {
    /// <summary>
    /// 交易日信息类
    /// </summary>
    [Serializable]
    public class TradingDayInformation : ObservableObject {
        private bool _allowTrade;
        private string _descMsg;
        private string _endTime;
        private string _startTime;
        private WEEK _week;

        /// <summary>
        /// 获取或设置是否允许交易
        /// </summary>
        public bool AllowTrade {
            get { return _allowTrade; }
            set {
                _allowTrade = value;
                RaisePropertyChanged( "AllowTrade" );
            }
        }

        /// <summary>
        /// 获取或设置描述信息
        /// </summary>
        public string DescMsg {
            get { return _descMsg; }
            set {
                _descMsg = value;
                RaisePropertyChanged( "DescMsg" );
            }
        }

        /// <summary>
        /// 获取或设置结束时间，格式HH:mm:ss
        /// </summary>
        public string EndTime {
            get { return _endTime; }
            set {
                _endTime = value;
                RaisePropertyChanged("EndTime");
            }
        }

        /// <summary>
        /// 获取或设置开始时间，格式HH:mm:ss
        /// </summary>
        public string StartTime {
            get { return _startTime; }
            set {
                _startTime = value;
                RaisePropertyChanged( "StartTime" );
            }
        }

        /// <summary>
        /// 获取或设置星期几
        /// </summary>
        public WEEK Week {
            get { return _week; }
            set {
                _week = value;
                RaisePropertyChanged( "Week" );
            }
        }

        private string _StockCode;
        /// <summary>
        /// 行情编码
        /// </summary>
        public string StockCode
        {
            get { return _StockCode; }
            set
            {
                _StockCode = value;
                RaisePropertyChanged("StockCode");
            }
        }

        /// <summary>
        /// 克隆一个完整的用户账户信息类
        /// </summary>
        /// <returns></returns>
        public object Clone( ) {
            return CloneHelper.CloneObject( this );
        }

        /// <summary>
        /// 同步交易日信息
        /// </summary>
        /// <param name="clone">同步数据源</param>
        public void Sync( TradingDayInformation clone ) {
            AllowTrade = clone.AllowTrade;
            DescMsg = clone.DescMsg;
            StartTime = clone.StartTime;
            EndTime = clone.EndTime;
            StockCode = clone.StockCode;
        }

        /// <summary>
        /// 比较时间字符串所代表的时间的大小
        /// </summary>
        /// <param name="timeStr1">源时间字符串</param>
        /// <param name="timeStr2">待比较的时间字符串</param>
        /// <param name="format">时间格式</param>
        /// <returns>比较结果，值小于0说明前者早于后者，等于0说明二者相等，大于0说明前者晚于后者</returns>
        private int DateLongTimeStringCompare( string timeStr1, string timeStr2, string format = "HH:mm:ss" ) {
            DateTime time1, time2;
            try {
                time1 = DateTime.ParseExact( timeStr1, format, null );
            } catch( FormatException e ) {
                throw new FormatException( "时间格式错误：" + timeStr1, e );
            }

            try {
                time2 = DateTime.ParseExact( timeStr2, format, null );
            } catch( FormatException e ) {
                throw new FormatException( "时间格式错误：" + timeStr2, e );
            }

            return time1.CompareTo( time2 );
        }
    }
}
