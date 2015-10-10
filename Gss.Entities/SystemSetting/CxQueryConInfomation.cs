using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gss.Common.Infrastructure;
using Gss.Common.Utility;

namespace Gss.Entities.SystemSetting
{
    /// <summary>
    /// 查询条件类 马友春
    /// </summary>
    [Serializable]
    public class CxQueryConInfomation : ObservableObject
    {
        private int _UserType;

        /// <summary>
        /// 用户类型(0表示管理员 1表示金商)
        /// </summary>
        public int UserType
        {
            get { return _UserType; }
            set
            {
                _UserType = value;
                RaisePropertyChanged("UserTypeInfo");
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

        private string _ProductName;

        /// <summary>
        /// 商品名称
        /// </summary>
             public string ProductName
        {
            get { return _ProductName; }
            set
            {
                _ProductName = value;
                RaisePropertyChanged("ProductName");
            }
        }

        

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
        private DateTime _StartTime;

        /// <summary>
        /// 
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
        private string _OrderType;
        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderType
        {
            get { return _OrderType; }
            set
            {
                _OrderType = value;
                RaisePropertyChanged("OrderType");
            }
        }
        private string _StockCode;
        /// <summary>
        /// 行情编码
        /// </summary>
        public string StockCode
        {
            get { return _StockCode; }
            set { _StockCode = value; }
        }



    }
}
