using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.BzjEntities
{
    /// <summary>
    /// 买跌Model
    /// </summary>
    public  class BzjRecoverOrder:BaseInfo
    {
        //客户账号、姓名、单号、商品类型、买跌价、买跌重量、买跌款、买跌时间、付款时间、状态（待受理，已受理）

        private string _OrderId;
        /// <summary>
        /// Gets or sets  单号
        /// </summary>
        public string OrderId
        {
             get { return _OrderId; }
            set
            {
                _OrderId = value;
                RaisePropertyChanged("OrderId");
            }
        }

        private double _PayMoney;
        /// <summary>
        /// Gets or sets  买跌款
        /// </summary>
        public double PayMoney
        {
              get { return _PayMoney; }
            set
            {
                _PayMoney = value;
                RaisePropertyChanged("PayMoney");
            }
        }

        private string _TradeAccount;
        /// <summary>
        ///  Gets or sets  用户账户
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
        ///  Gets or sets  用户姓名
        /// </summary>
        public string UserName
        {
             get { return _UserName; }
            set
            {
                _UserName= value;
                RaisePropertyChanged("UserName");
            }
        }

        private string _ProductName;
        /// <summary>
        ///  Gets or sets  商品名称
        /// </summary>
        public string ProductName
        {
             get { return _ProductName; }
            set
            {
                _ProductName = value;
                if (ProductName.Contains("白银"))
                    _RealWeightString = RealWeight + "千克";
                else
                    _RealWeightString = RealWeight + "克";
                RaisePropertyChanged("ProductName");
                RaisePropertyChanged("RealWeightString");
            }
        }

        private double _OverPrice;
        /// <summary>
        ///  Gets or sets  买跌价
        /// </summary>
        public double OverPrice
        {
              get { return _OverPrice; }
            set
            {
                _OverPrice = value;
                RaisePropertyChanged("OverPrice");
            }
        }

        private double _RealWeight;
        /// <summary>
        ///  Gets or sets  买跌重量
        /// </summary>
        public double RealWeight
        {
              get { return _RealWeight; }
            set
            {
                _RealWeight = value;
                RaisePropertyChanged("RealWeightString");
                RaisePropertyChanged("RealWeight");
            }
        }

        private string _RealWeightString;
        /// <summary>
        ///  Gets or sets  买跌重量
        /// </summary>
        public string RealWeightString
        {
            get { return _RealWeightString; }
            set
            {
                _RealWeightString = value;
              
                RaisePropertyChanged("RealWeightString");
            }
        }

        private DateTime _Overtime;
        /// <summary>
        ///  Gets or sets  买跌时间
        /// </summary>
        public DateTime Overtime
        {
              get { return _Overtime; }
            set
            {
                _Overtime = value;
                RaisePropertyChanged("Overtime");
            }
        }

        private DateTime? _PayTime;
        /// <summary>
        ///  Gets or sets  付款时间
        /// </summary>
        public DateTime? PayTime
        {
            get { return _PayTime; }
            set
            {
                _PayTime = value;
                RaisePropertyChanged("PayTime");
            }
        }

        private string _State;
        /// <summary>
        /// Gets or sets  状态 0待受理 1已受理
        /// </summary>
        public string State
        {
            get { return _State; }
            set
            {
                _State = value;
                if (value == "0")
                    _StateString = "待受理";
                else if (value == "1")
                    _StateString = "已受理";
                RaisePropertyChanged("State");
                RaisePropertyChanged("StateString");
            }
        }

        
        private string _StateString;
        /// <summary>
        /// Gets or sets  状态 0待受理 1已受理
        /// </summary>
        public string StateString
        {
            get { return _StateString; }
            set
            {
                _StateString = value;
                RaisePropertyChanged("StateString");
            }
        }


        private string _DoPerson;
        /// <summary>
        /// 操作人
        /// </summary>
        public string DoPerson
        {
            get { return _DoPerson; }
            set
            {
                _DoPerson = value;
                RaisePropertyChanged("DoPerson");
            }
        }

        
    }
}
