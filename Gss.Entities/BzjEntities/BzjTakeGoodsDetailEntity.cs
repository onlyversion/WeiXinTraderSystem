using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.BzjEntities
{
    /// <summary>
    /// 金商提货详细信息Model
    /// </summary>
    public class BzjTakeGoodsDetailEntity : BaseInfo
    {
        private string _OrderId;
        /// <summary>
        /// 定单ID
        /// </summary>
        public string OrderId
        {
            get{
                return _OrderId;
            }
            set
            {
                _OrderId = value;
                RaisePropertyChanged("OrderId");
            }
        }

        private string _OrderCode;
        /// <summary>
        /// 定单验证码
        /// </summary>
        public string OrderCode
        {
            get
            {
                return _OrderCode;
            }
            set
            {
                _OrderCode = value;
                RaisePropertyChanged("OrderCode");
            }
        }

        private string _UserId;
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId
        {
            get { return _UserId; }
            set
            {
                _UserId = value;
                RaisePropertyChanged("UserId");
            }
        }

        private string _OrderType;
        /// <summary>
        /// 定单类别 提货单 = 1, 买跌单 = 2, 买跌单 = 3,金生金 = 4,到期定单 = 5,已生金定单 = 6,提成定单 = 7
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
        private string _OrderNo;
        /// <summary>
        /// 定单编号
        /// </summary>
        public string OrderNo
        {
            get
            {
                return _OrderNo;
            }
            set
            {
                _OrderNo = value;
                RaisePropertyChanged("OrderNo");
            }
        }

        private string _UserName;
        /// <summary>
        /// 用户姓名
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

        private string _Account;
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string Account
        {
            get
            {
                return _Account;
            }
            set
            {
                _Account = value;
                RaisePropertyChanged("Account");
            }
        }

        private string _CarryWay;
        /// <summary>
        /// 非提货买跌 = 0,在线提货 = 1,金店提货 = 2,邮寄买跌 = 3,金店买跌 = 4
        /// </summary>
        public string CarryWay
        {
            get
            {
                return _CarryWay;
            }
            set
            {
                _CarryWay = value;
                RaisePropertyChanged("CarryWay");
            }
        }
        private double _Au;
        /// <summary>
        /// Au 数量
        /// </summary>
        public double Au
        {
            get
            {
                return _Au;
            }
            set
            {
                _Au = value;
                RaisePropertyChanged("Au");
            }
        }
        private double _Ag;
        /// <summary>
        /// Ag 数量
        /// </summary>
        public double Ag
        {
            get
            {
                return _Ag;
            }
            set
            {
                _Ag = value;
                RaisePropertyChanged("Ag");
            }
        }
        private double _Pt;
        /// <summary>
        /// Pt 数量
        /// </summary>
        public double Pt
        {
            get
            {
                return _Pt;
            }
            set
            {
                _Pt = value;
                RaisePropertyChanged("Pt");
            }
        }
        private double _Pd;
        /// <summary>
        /// Pd数量
        /// </summary>
        public double Pd
        {
            get
            {
                return _Pd;
            }
            set
            {
                _Pd = value;
                RaisePropertyChanged("Pd");
            }
        }

        private double _AuAvailable;
        /// <summary>
        /// Au 开票额
        /// </summary>
        public double AuAvailable
        {
            get
            {
                return _AuAvailable;
            }
            set
            {
                _AuAvailable = value;
                RaisePropertyChanged("AuAvailable");
            }
        }
        private double _AgAvailable;
        /// <summary>
        /// Ag 开票额
        /// </summary>
        public double AgAvailable
        {
            get
            {
                return _AgAvailable;
            }
            set
            {
                _AgAvailable = value;
                RaisePropertyChanged("AgAvailable");
            }
        }
        private double _PtAvailable;
        /// <summary>
        /// Pt 开票额
        /// </summary>
        public double PtAvailable
        {
            get
            {
                return _PtAvailable;
            }
            set
            {
                _PtAvailable = value;
                RaisePropertyChanged("PtAvailable");
            }
        }
        private double _PdAvailable;
        /// <summary>
        /// Pd开票额
        /// </summary>
        public double PdAvailable
        {
            get
            {
                return _PdAvailable;
            }
            set
            {
                _PdAvailable = value;
                RaisePropertyChanged("PdAvailable");
            }
        }

        private string _OperationDate;
        /// <summary>
        /// 提货时间
        /// </summary>
        public string OperationDate
        {
            get { return _OperationDate; }
            set
            {
                _OperationDate = value;
                RaisePropertyChanged("OperationDate");
            }
        }

        private string _CreateDate;
        /// <summary>
        /// 日期
        /// </summary>
          public string CreateDate
        {
            get { return _CreateDate; }
            set
            {
                _CreateDate = value;
                RaisePropertyChanged("CreateDate");
            }
        }
        


        private string _AgentId;
        /// <summary>
        /// 受理经商
        /// </summary>
        public string AgentId
        {
            get
            {
                return _AgentId;
            }
            set
            {
                _AgentId = value;
                RaisePropertyChanged("AgentId");
            }
        }

        private string _ClerkId;
        /// <summary>
        /// 金商店员
        /// </summary>
        public string ClerkId
        {
            get
            {
                return _ClerkId;
            }
            set
            {
                _ClerkId = value;
                RaisePropertyChanged("ClerkId");
            }
        }

        private string _TradeAccount;
        /// <summary>
        /// 转入金商库存账号
        /// </summary>
        public string TradeAccount
        {
            get
            {
                return _TradeAccount;
            }
            set
            {
                _TradeAccount = value;
                RaisePropertyChanged("TradeAccount");
            }
        }
    }
}
