using System;
using Gss.Common.Utility;
using Gss.Entities.Enums;

namespace Gss.Entities {
    /// <summary>
    /// 用户信息
    /// </summary>
    [Serializable]
    public class UserInformation {
        /// <summary>
        /// 实例化一个默认的用户信息类
        /// </summary>
        public UserInformation( ) {
            RememberUserName = true;
        }

        /// <summary>
        /// 获取或设置用户账户名
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 获取或设置用户密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 获取或设置是否记住密码
        /// </summary>
        public bool RememberPassword { get; set; }

        /// <summary>
        /// 获取或设置是否记住用户名
        /// </summary>
        public bool RememberUserName { get; set; }

        public ACCOUNT_TYPE AccType { get; set; }

        /// <summary>
        /// 解密用户信息
        /// </summary>
        public void Decrypt( ) {
            if( !string.IsNullOrEmpty( AccountName ) )
                AccountName = SecurityHelper.Decrypt( AccountName );
            if( !string.IsNullOrEmpty( Password ) )
                Password = SecurityHelper.Decrypt( Password );
        }

        /// <summary>
        /// 加密用户信息
        /// </summary>
        public void Encrypt( ) {
            if( !string.IsNullOrEmpty( AccountName ) )
                AccountName = SecurityHelper.Encrypt( AccountName );
            if( !string.IsNullOrEmpty( Password ) )
                Password = SecurityHelper.Encrypt( Password );
        }


    }
}
