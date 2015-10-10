using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities {
    public class LoginResult {
        /// <summary>
        /// 获取登陆标识，失败值为“-1”
        /// </summary>
        public string LoginID { get; private set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; private set; }

        /// <summary>
        /// 金商账户名，仅店员登录时有效
        /// </summary>
        public string ClerkAgentId { get;  set; }

        /// <summary>
        /// 获取行情地址
        /// </summary>
        public string QuotationAddr { get; private set; }

        /// <summary>
        /// 获取或设置行情端口
        /// </summary>
        public int QuotationPort { get; private set; }

        /// <summary>
        /// 获取登陆是否成功
        /// </summary>
        public bool LoginSuccess {
            get { return !LoginID.Equals( "-1" ); }
        }

        /// <summary>
        /// 获取登陆失败信息
        /// </summary>
        public string ErrMsg { get; private set; }

        /// <summary>
        /// 获取该登陆账号的权限。（金商类权限会自动转换成管理员权限）
        /// </summary>
        public ManagerAuthority MgrAuthority { get; private set; }

        /// <summary>
        /// 用登陆标识符和用户权限实例化一个登陆结果类
        /// </summary>
        /// <param name="loginID">登陆标识符</param>
        /// <param name="authority">用户权限</param>
        public LoginResult( string loginID, string quotationAddr, int quotationPort, ManagerAuthority authority ) {
            LoginID = loginID;
            MgrAuthority = authority;
            QuotationAddr = quotationAddr;
            QuotationPort = quotationPort;
        }

        public LoginResult(string loginID, string quotationAddr, int quotationPort, string userID)
        {
            LoginID = loginID;
            UserID = userID;
            QuotationAddr = quotationAddr;
            QuotationPort = quotationPort;
        }

        /// <summary>
        /// 用错误信息实例化一个失败的登陆结果类
        /// </summary>
        /// <param name="errMsg">登陆失败的错误信息</param>
        public LoginResult( string errMsg ) {
            LoginID = "-1";
            ErrMsg = errMsg;
        }
    }
}
