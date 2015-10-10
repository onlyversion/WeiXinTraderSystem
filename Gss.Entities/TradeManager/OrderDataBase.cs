using System;
using Gss.Common.Infrastructure;
using Gss.Common.Utility;
using Gss.Entities.Enums;

namespace Gss.Entities
{
    /// <summary>
    /// 定单数据基类
    /// </summary>
    [Serializable]
    public abstract class OrderDataBase : ObservableObject
    {
        protected const double TOLERANCE = 0.00000001;

        private string _orderID;
        private double _orderPrice;
        private double _orderQuantity;
        private DateTime _orderTime;
        private TRANSACTION_TYPE _orderType;
        private ProductInformation _ownedProduct;
        private string _productCode;
        private string _productName;
        private double _stopLoss;
        private double _stopProfit;
        private string _tradeAccount;

        /// <summary>
        /// 获取或设置定单ID
        /// </summary>
        public string OrderID
        {
            get { return _orderID; }
            set
            {
                _orderID = value;
                RaisePropertyChanged("OrderID");
            }
        }

        /// <summary>
        /// 获取或设置定单价
        /// </summary>
        public double OrderPrice
        {
            get { return _orderPrice; }
            set
            {
                if (Math.Abs(_orderPrice - value) > TOLERANCE)
                {
                    _orderPrice = value;
                    RaisePropertyChanged("OrderPrice");
                }
            }
        }

        /// <summary>
        /// 获取或设置定单数量
        /// </summary>
        public double OrderQuantity
        {
            get { return _orderQuantity; }
            set
            {
                if (Math.Abs(_orderQuantity - value) > TOLERANCE)
                {
                    _orderQuantity = value;
                    RaisePropertyChanged("OrderQuantity");
                }
            }
        }

        /// <summary>
        /// 获取或设置定单时间
        /// </summary>
        public DateTime OrderTime
        {
            get { return _orderTime; }
            set
            {
                if (_orderTime != value)
                {
                    _orderTime = value;
                    RaisePropertyChanged("OrderTime");
                }
            }
        }

        /// <summary>
        /// 获取或设置定单类型
        /// </summary>
        public TRANSACTION_TYPE OrderType
        {
            get { return _orderType; }
            set
            {
                if (_orderType != value)
                {
                    _orderType = value;
                    RaisePropertyChanged("OrderType");
                }
            }
        }

        /// <summary>
        /// 获取或设置所属的某个商品信息
        /// </summary>
        public ProductInformation OwnedProduct
        {
            get { return _ownedProduct; }
            set
            {
                _ownedProduct = value;

                if (value != null)
                {
                    IsPriceRising = value.IsPriceRising;
                    //响应实时价格更新事件
                    value.PropertyChanged += (s, e) =>
                    {
                        if (e.PropertyName.Equals("RealTimePrice"))
                        {
                            RaisePropertyChanged("RealTimePrice");
                            RaisePropertyChanged("RealTimePriceString");
                            RaisePropertyChanged("LossOrProfit");
                            IsPriceRising = value.IsPriceRising;
                            RaisePropertyChanged("IsPriceRising");
                            RaisePropertyChanged("RiskCoefficient");
                        }
                    };
                }
                   
            }
        }


        /// <summary>
        /// 获取或设置商品编码
        /// </summary>
        public string ProductCode
        {
            get { return _productCode; }
            set
            {
                _productCode = value;
                RaisePropertyChanged("ProductCode");
            }
        }

        /// <summary>
        /// 获取或设置商品名称
        /// </summary>
        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                RaisePropertyChanged("ProductName");
            }
        }

        private string _OrgName;
          /// <summary>
        /// 微会员名称
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


        private string _UserName;
        /// <summary>
        /// 客户名称
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

        private string _Telephone;
        /// <summary>
        /// 会员编码
        /// </summary>
        public string Telephone
        {
            get { return _Telephone; }
            set
            {
                _Telephone = value;
                RaisePropertyChanged("Telephone");
            }
        }

        private bool? _isPriceRising;

        /// <summary>
        /// 获取或设置价格是否正上涨
        /// </summary>
        public bool? IsPriceRising
        {
            get { return _isPriceRising; }
            set
            {
                _isPriceRising = value;
                RaisePropertyChanged("IsPriceRising");
            }
        }
        

        /// <summary>
        /// 获取实时价
        /// </summary>
        public double RealTimePrice
        {
            get
            {
                if (OwnedProduct == null)
                    return 0d;
                else
                    return OrderType == TRANSACTION_TYPE.Order ? OwnedProduct.RecoveryPrice : OwnedProduct.OrderPrice;
            }
        }

        /// <summary>
        /// 获取实时价的字符串形式，会补0
        /// </summary>
        public string RealTimePriceString
        {
            get
            {
                if (OwnedProduct == null)
                    return "0";
                else
                    return DataDigitFilter.FilterString(RealTimePrice, OwnedProduct.SpreadDigit);
            }
        }

        /// <summary>
        /// 获取或设置止损价
        /// </summary>
        public double StopLoss
        {
            get { return _stopLoss; }
            set
            {
                if (Math.Abs(_stopLoss - value) > TOLERANCE)
                {
                    _stopLoss = value;
                    RaisePropertyChanged("StopLoss");
                }
            }
        }

        /// <summary>
        /// 获取或设置止盈价
        /// </summary>
        public double StopProfit
        {
            get { return _stopProfit; }
            set
            {
                if (Math.Abs(_stopProfit - value) > TOLERANCE)
                {
                    _stopProfit = value;
                    RaisePropertyChanged("StopProfit");
                }
            }
        }

        /// <summary>
        /// 获取或设置客户账户
        /// </summary>
        public string TradeAccount
        {
            get { return _tradeAccount; }
            set
            {
                _tradeAccount = value;
                RaisePropertyChanged("TradeAccount");
            }
        }

       
        

    }
}
