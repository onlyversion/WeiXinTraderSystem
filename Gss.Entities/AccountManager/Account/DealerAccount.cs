using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gss.Common.Utility;

namespace Gss.Entities {
    /// <summary>
    /// 金商账户类
    /// </summary>
    [Serializable]
    public class DealerAccount : ICloneable {
        /// <summary>
        /// 获取金商账户基本信息
        /// </summary>
        public DealerAccountInformation AccInfo { get; private set; }

        /// <summary>
        /// 获取金商账户权限
        /// </summary>
        public DealerAuthority Authority { get; private set; }

        /// <summary>
        /// 用账户名实例化一个金商账户类
        /// </summary>
        public DealerAccount( ) {
            AccInfo = new DealerAccountInformation( );
            Authority = new DealerAuthority( );
        }

        /// <summary>
        /// 克隆一个完整的金商账户信息类
        /// </summary>
        /// <returns></returns>
        public object Clone( ) {
            return CloneHelper.CloneObject( this );
        }

        /// <summary>
        /// 同步金商资料数据（包含基本资料和权限）
        /// </summary>
        /// <param name="clone">同步数据源</param>
        public void Sync( DealerAccount clone ) {
            AccInfo.Sync( clone.AccInfo );
            Authority.Sync( clone.Authority );
        }

        /// <summary>
        /// 同步金商基本资料信息
        /// </summary>
        /// <param name="accInfo">同步的金商基本资料数据源</param>
        public void SyncAccInfo( DealerAccountInformation accInfo ) {
            if( accInfo != null )
                AccInfo.Sync( accInfo );
        }

        /// <summary>
        /// 同步金商权限信息
        /// </summary>
        /// <param name="authority">同步的金商权限数据源</param>
        public void SyncAuthority( DealerAuthority authority ) {
            if( authority != null )
                Authority.Sync( authority );
        }
    }
}
