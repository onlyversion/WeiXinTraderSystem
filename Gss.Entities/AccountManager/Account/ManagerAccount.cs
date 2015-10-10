using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Gss.Common.Utility;

namespace Gss.Entities {
    /// <summary>
    /// 管理员账户类
    /// </summary>
    [Serializable]
    public class ManagerAccount : ICloneable {
        /// <summary>
        /// 获取管理员账户基本信息
        /// </summary>
        public ManagerAccountInformation AccInfo { get; private set; }

        /// <summary>
        /// 获取管理员账户权限
        /// </summary>
        public ManagerAuthority Authority { get; private set; }

        /// <summary>
        /// 用账户名实例化一个管理员账户类
        /// </summary>
        public ManagerAccount( ) {
            AccInfo = new ManagerAccountInformation( );
            Authority = new ManagerAuthority( );
        }

        /// <summary>
        /// 克隆一个包含完整管理员账户信息的类
        /// </summary>
        /// <returns></returns>
        public object Clone( ) {
            return CloneHelper.CloneObject( this );
        }

        /// <summary>
        /// 同步管理员账户数据（包含基本资料和权限）
        /// </summary>
        /// <param name="clone">同步数据源</param>
        public void Sync( ManagerAccount clone ) {
            AccInfo.Sync( clone.AccInfo );
            Authority.Sync( clone.Authority );
        }

        /// <summary>
        /// 同步管理员基本资料信息
        /// </summary>
        /// <param name="accInfo">同步的管理员基本资料数据源</param>
        public void SyncAccInfo( ManagerAccountInformation accInfo ) {
            if( accInfo != null )
                AccInfo.Sync( accInfo );
        }

        /// <summary>
        /// 同步管理员权限信息
        /// </summary>
        /// <param name="authority">同步的管理员权限数据源</param>
        public void SyncAuthority( ManagerAuthority authority ) {
            if( authority != null )
                Authority.Sync( authority );
        }

    }
}
