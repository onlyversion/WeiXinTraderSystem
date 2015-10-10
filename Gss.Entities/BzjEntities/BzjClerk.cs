using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.BzjEntities
{
    /// <summary>
    /// 店员
    /// </summary>
    public class BzjClerk:BaseInfo
    {
        private string _ClerkName;
        /// <summary>
        /// Gets or sets 店员姓名
        /// </summary>
        public string ClerkName
        {
            get { return _ClerkName; }
            set
            {
                _ClerkName = value;
                RaisePropertyChanged("ClerkName");
            }
        }

        private string _ClerkId;
        /// <summary>
        /// Gets or sets 店员账号
        /// </summary>
        public string ClerkId
        {
            get { return _ClerkId; }
            set
            {
                _ClerkId = value;
                RaisePropertyChanged("ClerkId");
            }
        }

        private string _ClerkPwd;
        /// <summary>
        /// Gets or sets 店员密码
        /// </summary>
        public string ClerkPwd
        {
            get { return _ClerkPwd; }
            set
            {
                _ClerkPwd = value;
                RaisePropertyChanged("ClerkPwd");
            }
        }

        private string _ClerkPhone;
        /// <summary>
        /// Gets or sets 店员手机号码
        /// </summary>
        public string ClerkPhone
        {
            get { return _ClerkPhone; }
            set
            {
                _ClerkPhone = value;
                RaisePropertyChanged("ClerkPhone");
            }
        }

        private string _AgentId;
        /// <summary>
        /// Gets or sets 金商
        /// </summary>
        public string AgentId
        {
            get { return _AgentId; }
            set
            {
                _AgentId = value;
                RaisePropertyChanged("AgentId");
            }
        }
    }
}
