﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gss.Common.Infrastructure;

namespace Gss.Entities.TradeManager
{
    /// <summary>
    /// 用户查询条件类 马友春
    /// </summary>
    [Serializable]
    public class CJQueryConInfomation : ObservableObject
    { private string _LoginID;

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
          private DateTime _Starttime;

        /// <summary>
        /// 申请出金的开始时间
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
        /// 申请出金的结束时间
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
        /// 用户帐号(如果不填,表示查询所有用户的订单)
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

           private string _State;

        /// <summary>
        /// All-全部，"0"-已申请，"1"-已付款
        /// </summary>
        public string State
        {
            get { return _State; }
            set
            {
                _State = value;
                RaisePropertyChanged("State");
            }
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
        private DateTime _PayStartTime;
        /// <summary>
        /// 付款开始时间
        /// </summary>
        public DateTime PayStartTime
        {
            get { return _PayStartTime; }
            set
            {
                _PayStartTime = value;
                RaisePropertyChanged("PayStartTime");
            }
        }
        private DateTime _PayEndTime;
        /// <summary>
        /// 付款结束时间
        /// </summary>
        public DateTime PayEndTime
        {
            get { return _PayEndTime; }
            set
            {
                _PayEndTime = value;
                RaisePropertyChanged("PayEndTime");
            }
        }


    }
}
