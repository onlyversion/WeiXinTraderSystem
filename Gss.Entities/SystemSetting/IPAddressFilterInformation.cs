using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gss.Common.Infrastructure;
using Gss.Common.Utility;

namespace Gss.Entities {
    /// <summary>
    /// IP地址过滤信息类
    /// </summary>
    [Serializable]
    public class IPAddressFilterInformation : ObservableObject {
        private string _startIPAddr;

        /// <summary>
        /// 获取或设置起始的需要过滤IP地址
        /// </summary>
        public string StartIPAddr {
            get { return _startIPAddr; }
            set {
                _startIPAddr = value;
                RaisePropertyChanged( "StartIPAddr" );
            }
        }

        private string _endIPAddr;

        /// <summary>
        /// 获取或设置结束的需要过滤IP地址
        /// </summary>
        public string EndIPAddr {
            get { return _endIPAddr; }
            set {
                _endIPAddr = value;
                RaisePropertyChanged( "EndIPAddr" );
            }
        }

        private string _filterDesc;

        /// <summary>
        /// 获取或设置该过滤规则的描述
        /// </summary>
        public string FilterDesc {
            get { return _filterDesc; }
            set {
                _filterDesc = value;
                RaisePropertyChanged( "FilterDesc" );
            }
        }

        private string _filterID;

        /// <summary>
        /// 获取或设置过滤ID
        /// </summary>
        public string FilterID {
            get { return _filterID; }
            set {
                _filterID = value;
                RaisePropertyChanged( "FilterID" );
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
        /// 同步IP地址过滤信息数据
        /// </summary>
        /// <param name="clone">同步数据源</param>
        public void Sync( IPAddressFilterInformation clone ) {
            StartIPAddr = clone.StartIPAddr;
            EndIPAddr = clone.EndIPAddr;
            FilterDesc = clone.FilterDesc;
        }
    }
}
