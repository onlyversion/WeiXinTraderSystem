using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gss.Common.Infrastructure;
using Gss.Common.Utility;

namespace Gss.Entities {
    /// <summary>
    /// MAC地址过滤信息类
    /// </summary>
    [Serializable]
    public class MACFilterInformation : ObservableObject {
        private string _macAddress;

        /// <summary>
        /// 获取或设置过滤MAC地址
        /// </summary>
        public string MACAddress {
            get { return _macAddress; }
            set {
                _macAddress = value;
                RaisePropertyChanged( "MACAddress" );
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
        /// 同步MAC过滤信息
        /// </summary>
        /// <param name="clone">同步数据源</param>
        public void Sync( MACFilterInformation clone ) {
            MACAddress = clone.MACAddress;
            FilterDesc = clone.FilterDesc;
        }
    }
}
