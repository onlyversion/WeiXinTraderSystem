using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gss.Common.Infrastructure;
using Gss.Common.Utility;

namespace Gss.Entities {
    /// <summary>
    /// 节假日信息类
    /// </summary>
    [Serializable]
    public class HolidayInformation : ObservableObject {
        private string _holidayName;

        /// <summary>
        /// 获取或设置节假日名称
        /// </summary>
        public string HolidayName {
            get { return _holidayName; }
            set {
                _holidayName = value;
                RaisePropertyChanged( "HolidayName" );
            }
        }

        private DateTime _startTime;

        /// <summary>
        /// 获取或设置开始时间，格式HH:mm:ss
        /// </summary>
        public DateTime StartTime {
            get { return _startTime; }
            set {
                if( _startTime != value ) {
                    _startTime = value;
                    RaisePropertyChanged( "StartTime" );

                    if( _startTime > _endTime )
                        EndTime = StartTime; 
                }
            }
        }

        private DateTime _endTime;

        /// <summary>
        /// 获取或设置结束时间，格式HH:mm:ss
        /// </summary>
        public DateTime EndTime {
            get { return _endTime; }
            set {
                if( _endTime != value ) {
                    _endTime = value;
                    RaisePropertyChanged( "EndTime" );

                    if( _endTime < _startTime )
                        StartTime = EndTime; 
                }
            }
        }

        private string _descMsg;

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

        private string holidayID;

        /// <summary>
        /// 获取或设置节假日ID
        /// </summary>
        public string HolidayID {
            get { return holidayID; }
            set {
                holidayID = value;
                RaisePropertyChanged( "HolidayID" );
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
        /// 实例化一个包含默认值的节假日信息类
        /// </summary>
        public HolidayInformation( ) {
            StartTime = DateTime.Today;
            EndTime = DateTime.Today.AddDays( 1 ).AddSeconds( -1 );
        }

        /// <summary>
        /// 克隆一个完整的用户账户信息类
        /// </summary>
        /// <returns></returns>
        public object Clone( ) {
            return CloneHelper.CloneObject( this );
        }

        /// <summary>
        /// 同步节假日信息
        /// </summary>
        /// <param name="clone">同步数据源</param>
        public void Sync( HolidayInformation clone ) {
            HolidayName = clone.HolidayName;
            StartTime = clone.StartTime;
            EndTime = clone.EndTime;
            DescMsg = clone.DescMsg;
            StockCode = clone.StockCode;
        }
    }
}
