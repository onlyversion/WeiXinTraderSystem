using System;
using Gss.Common.Infrastructure;
using Gss.Common.Utility;
using Gss.Entities.Enums;

namespace Gss.Entities.SystemSetting
{
    /// <summary>
    /// 用户查询条件类 马友春
    /// </summary>
    [Serializable]
    public class UserQueryConInfomation : ObservableObject
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

        private UserTypeInfo _userTypeInfo;
        /// <summary>
        /// 用户类型(0表示管理员 1表示金商)
        /// </summary>
        public UserTypeInfo UserTypeInfo
        {
            get { return _userTypeInfo;}
            set
            {
                _userTypeInfo = value;
                RaisePropertyChanged("UserTypeInfo");
            }
        }

        private string _AgentId;

        /// <summary>
        /// 当前登录的金商账号(UserTypeInfo=1时,须传递该值)
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

        private string _TradeAccount;

        /// <summary>
        /// 用户帐号(如果不填,表示查询所有用户的定单)
        /// </summary>
        public string TradeAccount
        {
            get { return _TradeAccount; }
            set
            {
                _TradeAccount = value;
                RaisePropertyChanged("TradeAccount");
            }
        }

        private string _UserName;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                RaisePropertyChanged("UserName");
            }
        }

        private string _CardNum;

        /// <summary>
        /// 证件号码
        /// </summary>
        public string CardNum
        {
            get { return _CardNum; }
            set
            {
                _CardNum = value;
                RaisePropertyChanged("CardNum");
            }
        }

        private bool _OnLine;
        /// <summary>
        /// 是否在线
        /// </summary>
        public bool OnLine
        {
            get;
            set;
        }
      
      
        /// <summary>
        /// 克隆一个完整的查询信息类
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return CloneHelper.CloneObject(this);
        }
        private string _OrgName;
        /// <summary>
        /// 会员名称
        /// </summary>
        public string OrgName
        {
            get { return _OrgName; }
            set
            {
                _OrgName = value;
                RaisePropertyChanged("OrgName");
            }
        }

        private string _GroupID;
        /// <summary>
        /// 用户组id
        /// </summary>
        public string GroupID
        {
            get { return _GroupID; }
            set
            {
                _GroupID = value;
                RaisePropertyChanged("GroupID");
            }
        }

        private string _telPhone;
        /// <summary>
        /// 手机
        /// </summary>
        public string TelPhone
        {
            get { return _telPhone; }
            set
            {
                _telPhone = value;
                RaisePropertyChanged("TelPhone");
            }
        }

        private DateTime _StartTime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return _StartTime; }
            set
            {
                _StartTime = value;
                RaisePropertyChanged("StartTime");
            }
        }

        private DateTime _EndTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return _EndTime; }
            set
            {
                _EndTime = value;
                RaisePropertyChanged("EndTime");
            }
        }
        private string _isBroker;
        /// <summary>
        /// 是否经济人，0全部，1是，2，否
        /// </summary>
        public string IsBroker
        {
            get { return _isBroker; }
            set
            {
                _isBroker = value;
                RaisePropertyChanged("IsBroker");
            }
        }

        private string _broker;
        /// <summary>
        /// 经济人
        /// </summary>
        public string Broker
        {
            get { return _broker; }
            set
            {
                _broker = value;
                RaisePropertyChanged("IsBroker");
            }
        }
    }
}
