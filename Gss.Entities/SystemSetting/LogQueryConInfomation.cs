using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gss.Common.Infrastructure;
using Gss.Common.Utility;

namespace Gss.Entities.SystemSetting
{
    /// <summary>
    /// 用户查询条件类 马友春
    /// </summary>
    [Serializable]
    public class LogQueryConInfomation : ObservableObject
    {
        private string _LoginID;

        /// <summary>
        /// 用户或管理员或金商登陆标识
        /// </summary>
        public string LoginID
        {
            get { return _LoginID; }
            set
            {
                _LoginID = value;
                RaisePropertyChanged("LoginID");
            }
        }

        private int _LogType;
        /// <summary>
        /// 0查询管理员操作日志,1查询金商操作日志
        /// </summary>
        public int LogType
        {
            get { return _LogType; }
            set
            {
                _LogType = value;
                RaisePropertyChanged("LogType");
            }
        }

        private DateTime _Starttime;

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime Starttime
        {
            get { return _Starttime; }
            set
            {
                _Starttime = value;
                RaisePropertyChanged("Starttime");
            }
        }

        private DateTime _Endtime;

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime Endtime
        {
            get { return _Endtime; }
            set
            {
                _Endtime = value;
                RaisePropertyChanged("Endtime");
            }
        }

        private string _Account;
        /// <summary>
        /// 账号
        /// </summary>
        public string Account
        {
            get { return _Account; }
            set
            {
                _Account = value;
                RaisePropertyChanged("Account");
            }
        }


        /// <summary>
        /// 克隆一个完整的查询信息类
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return CloneHelper.CloneObject(this);
        }
    }
}
