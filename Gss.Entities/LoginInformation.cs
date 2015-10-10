using Gss.Common.Infrastructure;
using Gss.Entities.Enums;

namespace Gss.Entities {
    /// <summary>
    /// 登陆信息类，包含用户名和密码
    /// </summary>
    public class LoginInformation : ObservableObject {
        /// <summary>
        /// 账户名
        /// </summary>
        public string AccountName { get; private set; }

        /// <summary>
        /// 账户密码
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// 账户类型
        /// </summary>
        public ACCOUNT_TYPE AccountType { get; private set; }

        /// <summary>
        /// 用用户名和密码实例化一个登陆信息类
        /// </summary>
        /// <param name="accName">账户名</param>
        /// <param name="password">账户密码</param>
        /// <param name="type">账户类型</param>
        public LoginInformation( string accName, string password, ACCOUNT_TYPE type ) {
            AccountName = accName;
            Password = password;
            AccountType = type;
        }
    }
}
