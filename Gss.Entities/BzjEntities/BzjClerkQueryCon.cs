using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.BzjEntities
{
    public class BzjClerkQueryCon
    {
        /// <summary>
        ///  Gets or sets 管理员或金商登陆标识
        /// </summary>
        public string LoginId
        {
            get;
            set;
        }

        /// <summary>
        ///  Gets or sets 用户类型（0表示管理员 1表示金商）
        /// </summary>
        public int UserType
        {
            get;
            set;
        }

        /// <summary>
        ///  Gets or sets 金商账号(UserType=1时起作用)
        /// </summary>
        public string AgentId
        {
            get;
            set;
        }

        /// <summary>
        ///  Gets or sets 店员帐号
        /// </summary>
        public string ClerkId
        {
            get;
            set;
        }

        /// <summary>
        ///  Gets or sets 店员姓名
        /// </summary>
        public string ClerkName
        {
            get;
            set;
        }

        /// <summary>
        ///  Gets or sets 店员手机号码
        /// </summary>
        public string ClerkPhone
        {
            get;
            set;
        }
    }
}
