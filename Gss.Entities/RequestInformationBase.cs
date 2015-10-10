using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gss.Common.Infrastructure;

namespace Gss.Entities {
    public class RequestInformationBase : ObservableObject {
        private string _accountName;

        /// <summary>
        /// 获取或设置账户名称
        /// </summary>
        public string AccountName {
            get { return _accountName; }
            set {
                _accountName = value;
                RaisePropertyChanged( "AccountName" );
            }
        }

        private DateTime _startTime;

        /// <summary>
        /// 获取或设置起始时间
        /// </summary>
        public DateTime StartTime {
            get { return _startTime; }
            set {
                if( _startTime != value ) {
                    _startTime = value;
                    RaisePropertyChanged( "StartTime" );

                    if( _startTime > EndTime ) {
                        _endTime = value;
                        RaisePropertyChanged( "EndTime" );
                    }
                }
            }
        }

        private DateTime _endTime;

        /// <summary>
        /// 获取或设置结束时间
        /// </summary>
        public DateTime EndTime {
            get { return _endTime; }
            set {
                if( _endTime != value ) {
                    _endTime = value;
                    RaisePropertyChanged( "EndTime" );

                    if( _endTime < _startTime ) {
                        _startTime = value;
                        RaisePropertyChanged( "StartTime" );
                    }
                }
            }
        }

        /// <summary>
        /// 实例化一个包含默认起始时间为当天之前3天，结束时间为当天的查询请求基类
        /// </summary>
        public RequestInformationBase( ) {
            StartTime = DateTime.Today.AddDays( 0 );
            EndTime = DateTime.Today.AddDays( 1 ).AddSeconds( -1 );
        }
    }
}
