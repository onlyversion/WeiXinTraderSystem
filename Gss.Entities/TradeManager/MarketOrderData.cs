using System;
using Gss.Common.Utility;
using Gss.Entities.Enums;

namespace Gss.Entities
{
    /// <summary>
    /// 有效定单详细信息
    /// </summary>
    [Serializable]
    public class MarketOrderData : OrderDataBase
    {
        private double _occupiedDeposit;

        /// <summary>
        /// 获取或设置保证金
        /// </summary>
        public double OccupiedDeposit
        {
            get { return _occupiedDeposit; }
            set
            {
                if (Math.Abs(_occupiedDeposit - value) > TOLERANCE)
                {
                    _occupiedDeposit = value;
                    RaisePropertyChanged("OccupiedDeposit");
                }
            }
        }

        private double _remainingQuantity;

        /// <summary>
        /// 获取或设置剩余定单数量
        /// </summary>
        public double RemainingQuantity
        {
            get { return _remainingQuantity; }
            set
            {
                if (Math.Abs(_remainingQuantity - value) > TOLERANCE)
                {
                    _remainingQuantity = value;
                    RaisePropertyChanged("RemainingQuantity");
                }
            }
        }

        private double _tradeFee;

        /// <summary>
        /// 获取或设置基础工费
        /// </summary>
        public double TradeFee
        {
            get { return _tradeFee; }
            set
            {
                if (Math.Abs(_tradeFee - value) > TOLERANCE)
                {
                    _tradeFee = value;
                    RaisePropertyChanged("TradeFee");
                }
            }
        }

        private double _storageFee;

        /// <summary>
        /// 获取或设置仓储费
        /// </summary>
        public double StorageFee
        {
            get { return _storageFee; }
            set
            {
                if (Math.Abs(_storageFee - value) > TOLERANCE)
                {
                    _storageFee = value;
                    RaisePropertyChanged("StorageFee");
                }
            }
        }

        private bool allowStore;
        /// <summary>
        /// 是否允许入库 马友春
        /// </summary>
        public bool AllowStore
        {
            get { return allowStore; }
            set
            {
                allowStore = value;
                RaisePropertyChanged("AllowStore");
            }
        }

        private double _TotalWeight;
        /// <summary>
        /// 总重量
        /// </summary>
        public double TotalWeight
        {
            get { return _TotalWeight; }
            set
            {
                _TotalWeight = value;
                RaisePropertyChanged("TotalWeight");
            }
        }

        
        /// <summary>
        /// Gets a value indication whether earnings
        /// 获取是否盈利
        /// </summary>
        public bool IsEarnings { get; private set; }


        /// <summary>
        /// Gets or sets loss or profit
        /// 获取或设置盈亏值 马友春
        /// </summary>
        public double LossOrProfit
        {
            
            get
            {
                //买涨单：([平仓价]-[建仓价])/[点差基值]*[点值]*[手数]-[工费]-[仓储费]
                //买跌单：-([平仓价]-[建仓价])/[点差基值]*[点值]*[手数]-[工费]-[仓储费]
                double priceDiff;
                if (OwnedProduct == null)
                    return 0.00;
                if (OrderType == TRANSACTION_TYPE.Order)
                {
                    priceDiff = RealTimePrice - OrderPrice;
                }
                else
                {
                    priceDiff = -(RealTimePrice - OrderPrice);
                }
                double lossOrProfit = priceDiff / OwnedProduct.SpreadBaseValue * OwnedProduct.PointValue * OrderQuantity;
                //lossOrProfit = DataDigitFilter.FilterDouble(lossOrProfit, OwnedProduct.SpreadDigit);
                lossOrProfit = DataDigitFilter.FilterDouble(lossOrProfit, 2);//盈亏精确到分
                //lossOrProfit = lossOrProfit - TradeFee - StorageFee;
                IsEarnings = lossOrProfit > 0;
                RaisePropertyChanged("IsEarnings");
                return lossOrProfit;
                
                
            }
        }

        private double _money;
        /// <summary>
        /// 账户余额
        /// </summary>
        public double Money
        {
            get { return _money; }
            set
            {
                _money = value;
                RaisePropertyChanged("Money");
            }
        }

        private double _ProfitValue;
        /// <summary>
        /// 盈亏（除去本单之外的所有单子盈亏）
        /// </summary>
        public double ProfitValue
        {
            get { return _ProfitValue; }
            set
            {
                _ProfitValue = value;
                RaisePropertyChanged("ProfitValue");
            }
        }
        private double _AlloccMoney;
        /// <summary>
        /// 用户所有的保证金
        /// </summary>
        public double AlloccMoney
        {
            get { return _AlloccMoney; }
            set
            {
                _AlloccMoney = value;
                RaisePropertyChanged("AlloccMoney");
            }
        }
        private double _FrozenMoney;
        /// <summary>
        /// 用户所有的预付款
        /// </summary>
        public double FrozenMoney
        {
            get { return _FrozenMoney; }
            set
            {
                _FrozenMoney = value;
                RaisePropertyChanged("FrozenMoney");
            }
        }

        private string _RiskCoefficient;
        /// <summary>
        /// 风险率
        /// </summary>
        public string RiskCoefficient
        {
            get {
                return CacuRiskCoefficient(LossOrProfit);
            }
            
        }
        private double _DongJieMoney;
        /// <summary>
        /// 冻结资金
        /// </summary>
        public double DongJieMoney
        {
            get { return _DongJieMoney; }
            set
            {
                _DongJieMoney = value;
                RaisePropertyChanged("DongJieMoney");
            }
        }

        /// <summary>
        /// /// 计算风险率
        /// 风险率公式改为：（账户结余+除本单外所有单子的盈亏+本单浮动盈亏-账户冻结资金）/(每个用户所有保证金+每个用户所有预付款)
        /// 等效于：（账户余额-账户冻结资金+用户所有单子盈亏）/(用户所有的保证金+用户所有的预付款)
        /// </summary>
        /// <param name="lp">浮动盈亏</param>
        private string CacuRiskCoefficient( double lp)
         {
            if ((OccupiedDeposit + FrozenMoney) <= 0.000001)
            {
                return "0";
            }
            else
            {
                return DataDigitFilter.FilterDouble((Money - DongJieMoney + ProfitValue + LossOrProfit) / (AlloccMoney + FrozenMoney) * 100, 2).ToString();

            }
        }

        private double _Orderunit;
        /// <summary>
        /// 用户手数单位
        /// </summary>
        public double Orderunit
        {
            get { return _Orderunit; }
            set
            {
                _Orderunit = value;
                RaisePropertyChanged("Orderunit");
            }
        }

        
        //}
        //private string operType;
        ///// <summary>
        ///// 操作类别
        ///// </summary>
        //public string OperType {
        //    get { return operType; }
        //    set { operType = value; RaisePropertyChanged( "OperType" ); }
        //}

        //private double avgOrderPrice;

        //public double AvgOrderPrice {
        //    get { return avgOrderPrice; }
        //    set { avgOrderPrice = value; RaisePropertyChanged( "AvgOrderPrice" ); }
        //}
        //private double realPrice;

        //public double RealPrice {
        //    get { return realPrice; }
        //    set { realPrice = value; RaisePropertyChanged( "RealPrice" ); }
        //}
        //private double profitLoss;

        //public double ProfitLoss {
        //    get { return profitLoss; }
        //    set { profitLoss = value; RaisePropertyChanged( "ProfitLoss" ); }
        //}
        //private double hedgingQuantity;

        //public double HedgingQuantity {
        //    get { return hedgingQuantity; }
        //    set { hedgingQuantity = value; RaisePropertyChanged( "HedgingQuantity" ); }
        //}
        //private double hedgingProfitLoss;

        //private double frozenMoney;

        //public double FrozenMoney {
        //    get { return frozenMoney; }
        //    set { frozenMoney = value; RaisePropertyChanged( "FrozenMoney" ); }
        //}
        //private double hedgingTradeFee;

        //public double HedgingTradeFee {
        //    get { return hedgingTradeFee; }
        //    set { hedgingTradeFee = value; RaisePropertyChanged( "HedgingTradeFee" ); }
        //}

        //private double hedgingStorageFee;

        //public double HedgingStorageFee {
        //    get { return hedgingStorageFee; }
        //    set { hedgingStorageFee = value; RaisePropertyChanged( "HedgingStorageFee" ); }
        //}

        //private double HedgingProfitLoss;

        //public double HedgingProfitLoss1 {
        //    get { return HedgingProfitLoss; }
        //    set { HedgingProfitLoss = value; RaisePropertyChanged( "HedgingProfitLoss1" ); }
        //}

    }
}
