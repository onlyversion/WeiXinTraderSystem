using System;
using Gss.Entities.Enums;

namespace Gss.Entities {
    /// <summary>
    /// 日志请求信息类
    /// </summary>
    public class LogRequestInformation : RequestInformationBase {
        private LOG_TYPE _logType;

        /// <summary>
        /// 获取或设置日志类型
        /// </summary>
        public LOG_TYPE LogType {
            get { return _logType; }
            set {
                if( _logType != value ) {
                    _logType = value;
                    RaisePropertyChanged( "LogType" ); 
                }
            }
        }


        /// <summary>
        /// 实例化一个采用默认值的日志请求信息类
        /// </summary>
        public LogRequestInformation( ) {
            LogType = LOG_TYPE.Manager;
            StartTime = DateTime.Today.AddDays( 0 );
            EndTime = DateTime.Today;
        }

    }
}
