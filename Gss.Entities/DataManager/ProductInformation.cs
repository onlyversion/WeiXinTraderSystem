using System;
using Gss.Common.Infrastructure;
using Gss.Common.Utility;
using Gss.Entities.Enums;

namespace Gss.Entities {
    /// <summary>
    /// 商品信息类
    /// </summary>
    [Serializable]
    public class ProductInformation : ObservableObject {
        private const double TOLERANCE = 0.00000001;

        #region 属性 —— 基础信息
        private double _allowMaxPrice;

        private int _allowMaxTimeDeviation;

        private double _allowMinPrice;

        private double _cutDownPrice;

        private string _depositFormula;

        private int _lossProfitSpread;

        private string _orderStorageFeeFormula;

        private int _pendingOrderSpread;

        private double _percentageOfDeposit;

        private double _pointValue;

        private string _productCode;

        private string _productName;

        private string _rawMaterialsCode;

        private string _recoveryFeeFormula;

        private string _recoveryStorageFeeFormula;

        private int _spread;

        private double _spreadBaseValue;

        private int _spreadDigit;

        private PRODUCT_STATE _state;

        private string _stockCode;

        private string _transactionFeeFormula;

        private double _weightUnit;

        /// <summary>
        /// 获取或设置允许成交的最大价格
        /// </summary>
        public double AllowMaxPrice {
            get { return _allowMaxPrice; }
            set {
                if( Math.Abs( _allowMaxPrice - value ) > TOLERANCE ) {
                    _allowMaxPrice = value;
                    RaisePropertyChanged( "AllowMaxPrice" );
                }
            }
        }

        /// <summary>
        /// 获取或设置允许交易的最大时间差，单位为秒
        /// </summary>
        public int AllowMaxTimeDeviation {
            get { return _allowMaxTimeDeviation; }
            set {
                if( _allowMaxTimeDeviation != value ) {
                    _allowMaxTimeDeviation = value;
                    RaisePropertyChanged( "AllowMaxPrice" );
                }
            }
        }

        /// <summary>
        /// 获取或设置允许成交最小价
        /// </summary>
        public double AllowMinPrice {
            get { return _allowMinPrice; }
            set {
                if( Math.Abs( _allowMinPrice - value ) > TOLERANCE ) {
                    _allowMinPrice = value;
                    RaisePropertyChanged( "AllowMinPrice" );
                }
            }
        }

        /// <summary>
        /// 获取或设置下浮价格
        /// </summary>
        public double CutDownPrice {
            get { return _cutDownPrice; }
            set {
                if( Math.Abs( _cutDownPrice - value ) > TOLERANCE ) {
                    _cutDownPrice = value;
                    RaisePropertyChanged( "CutDownPrice" );
                }
            }
        }

        /// <summary>
        /// 获取或设置定金计算公式
        /// </summary>
        public string DepositFormula {
            get { return _depositFormula; }
            set {
                _depositFormula = value;
                RaisePropertyChanged( "DepositFormula" );
            }
        }

        /// <summary>
        /// 获取或设置止损止盈点差
        /// </summary>
        public int LossProfitSpread {
            get { return _lossProfitSpread; }
            set {
                if( _lossProfitSpread != value ) {
                    _lossProfitSpread = value;
                    RaisePropertyChanged( "LossProfitSpread" );
                }
            }
        }

        /// <summary>
        /// 获取或设置买涨仓储费公式
        /// </summary>
        public string OrderStorageFeeFormula {
            get { return _orderStorageFeeFormula; }
            set {
                _orderStorageFeeFormula = value;
                RaisePropertyChanged( "OrderStorageFeeFormula" );
            }
        }

        /// <summary>
        /// 获取或设置挂单价点差
        /// </summary>
        public int PendingOrderSpread {
            get { return _pendingOrderSpread; }
            set {
                if( _pendingOrderSpread != value ) {
                    _pendingOrderSpread = value;
                    RaisePropertyChanged( "PendingOrderSpread" );
                }
            }
        }

        /// <summary>
        /// 获取或设置定金百分比
        /// </summary>
        public double PercentageOfDeposit {
            get { return _percentageOfDeposit; }
            set {
                if( Math.Abs( _percentageOfDeposit - value ) > TOLERANCE ) {
                    _percentageOfDeposit = value;
                    RaisePropertyChanged( "PendingOrderSpread" );
                }
            }
        }

        /// <summary>
        /// 获取或设置点值
        /// </summary>
        public double PointValue {
            get { return _pointValue; }
            set {
                if( Math.Abs( _pointValue - value ) > TOLERANCE ) {
                    _pointValue = value;
                    RaisePropertyChanged( "PointValue" );
                }
            }
        }

        /// <summary>
        /// 获取或设置商品编码
        /// </summary>
        public string ProductCode {
            get { return _productCode; }
            set {
                _productCode = value;
                RaisePropertyChanged( "ProductCode" );
            }
        }

        /// <summary>
        /// 获取或设置商品名称
        /// </summary>
        public string ProductName {
            get { return _productName; }
            set {
                _productName = value;
                RaisePropertyChanged( "ProductName" );
            }
        }

        /// <summary>
        /// 获取或设置原料编码
        /// </summary>
        public string RawMaterialsCode {
            get { return _rawMaterialsCode; }
            set {
                _rawMaterialsCode = value;
                RaisePropertyChanged( "RawMaterialsCode" );
            }
        }

        /// <summary>
        /// 获取或设置买跌仓储费公式
        /// </summary>
        public string RecovertyStorageFeeFormula {
            get { return _recoveryStorageFeeFormula; }
            set {
                _recoveryStorageFeeFormula = value;
                RaisePropertyChanged( "RecovertyStorageFeeFormula" );
            }
        }

        /// <summary>
        /// 获取或设置买跌手续费
        /// </summary>
        public string RecoveryFeeFormula {
            get { return _recoveryFeeFormula; }
            set {
                _recoveryFeeFormula = value;
                RaisePropertyChanged( "RecoveryFeeFormula" );
            }
        }

        /// <summary>
        /// 获取或设置点差
        /// </summary>
        public int Spread {
            get { return _spread; }
            set {
                if( _spread != value ) {
                    _spread = value;
                    RaisePropertyChanged( "Spread" );
                }
            }
        }

        /// <summary>
        /// 获取或设置点差基值
        /// </summary>
        public double SpreadBaseValue {
            get { return _spreadBaseValue; }
            set {
                if( Math.Abs( _spreadBaseValue - value ) > TOLERANCE ) {
                    _spreadBaseValue = value;
                    RaisePropertyChanged( "SpreadBaseValue" );
                }
            }
        }

        /// <summary>
        /// 获取点差基值,解决小数位较多时为科学计数法显示而不是原样显示的问题
        /// </summary>
        public decimal SpreadBaseValueString
        {
            get { return Convert.ToDecimal(SpreadBaseValue); }
        }

        /// <summary>
        /// 获取或设置点差位数
        /// </summary>
        public int SpreadDigit {
            get { return _spreadDigit; }
            set {
                if( _spreadDigit != value ) {
                    _spreadDigit = value;
                    RaisePropertyChanged( "SpreadDigit" );
                }
            }
        }

        /// <summary>
        /// 设置商品状态，0全部允许，1只报价，2只买涨，3只买跌，4全部禁止
        /// </summary>
        public PRODUCT_STATE State {
            get { return _state; }
            set {
                if( _state != value ) {
                    _state = value;
                    RaisePropertyChanged( "State" );
                }
            }
        }

        /// <summary>
        /// 获取或设置行情编码
        /// </summary>
        public string StockCode {
            get { return _stockCode; }
            set {
                _stockCode = value;
                RaisePropertyChanged( "StockCode" );
            }
        }

        /// <summary>
        /// 获取或设置交易工费
        /// </summary>
        public string TransactionFeeFormula {
            get { return _transactionFeeFormula; }
            set {
                _transactionFeeFormula = value;
                RaisePropertyChanged( "TransactionFeeFormula" );
            }
        }

        /// <summary>
        /// 获取或设置重量单位
        /// </summary>
        public double WeightUnit {
            get { return _weightUnit; }
            set {
                if( Math.Abs( _weightUnit - value ) > TOLERANCE ) {
                    _weightUnit = value;
                    RaisePropertyChanged( "WeightUnit" );
                }
            }
        }

        private string _startTradeTime;

        /// <summary>
        /// 获取或设置开始交易时间
        /// </summary>
        public string StartTradeTime {
            get { return _startTradeTime; }
            set {
                if( _startTradeTime != value ) {
                    _startTradeTime = value;
                    RaisePropertyChanged( "StartTradeTime" ); 
                }
            }
        }

        private string _endTradeTime;

        /// <summary>
        /// 获取或设置结束交易时间
        /// </summary>
        public string EndTradeTime {
            get { return _endTradeTime; }
            set {
                if( _endTradeTime != value ) {
                    _endTradeTime = value;
                    RaisePropertyChanged( "EndTradeTime" ); 
                }
            }
        }

        #endregion

        #region 属性 —— 实时数据

        private double _realtimePrice;

        private DateTime _realtimeTime;

        private bool? _isPriceRising;

        /// <summary>
        /// 获取或设置价格是否正上涨
        /// </summary>
        public bool? IsPriceRising {
            get { return _isPriceRising; }
            set {
                _isPriceRising = value;
                RaisePropertyChanged( "IsPriceRising" );
            }
        }

        private double _orderPrice;

        /// <summary>
        /// 获取或设置买涨价
        /// </summary>
        public double OrderPrice {
            get { return _orderPrice; }
            set {
                _orderPrice = value;
                RaisePropertyChanged( "OrderPrice" );
                RaisePropertyChanged( "OrderPriceString" );
            }
        }

        /// <summary>
        /// 获取买涨价字符串（数据位补0）
        /// </summary>
        public string OrderPriceString {
            get { return DataDigitFilter.FilterString( OrderPrice, SpreadDigit ); }
        }

        private double _recoveryPrice;

        /// <summary>
        /// 获取或设置买跌价
        /// </summary>
        public double RecoveryPrice {
            get { return _recoveryPrice; }
            set {
                _recoveryPrice = value;
                RaisePropertyChanged( "RecoveryPrice" );
                RaisePropertyChanged( "RecoveryPriceString" );
            }
        }

        /// <summary>
        /// 获取买跌价字符串（数据位补0）
        /// </summary>
        public string RecoveryPriceString {
            get { return DataDigitFilter.FilterString( RecoveryPrice, SpreadDigit ); }
        }

        /// <summary>
        /// 获取或设置实时价格
        /// </summary>
        public double RealTimePrice {
            get { return _realtimePrice; }
            set {
                if( Math.Abs( _realtimePrice - value ) > TOLERANCE ) {
                    IsPriceRising = value > _realtimePrice;
                    _realtimePrice = value;
                    RaisePropertyChanged( "RealTimePrice" );

                    RecoveryPrice = value;
                    OrderPrice = CalcOrderPrice( value );
                }
            }
        }

        /// <summary>
        /// 获取或设置实时时间
        /// </summary>
        public DateTime RealTimeTime {
            get { return _realtimeTime; }
            set {
                _realtimeTime = value;
                RaisePropertyChanged( "RealTimeTime" );
            }
        }


        #endregion

        #region 公用接口

        /// <summary>
        /// 克隆一个完整的用户资金信息类
        /// </summary>
        /// <returns></returns>
        public object Clone( ) {
            return CloneHelper.CloneObject( this );
        }

        /// <summary>
        /// 同步商品信息
        /// </summary>
        /// <param name="clone">同步数据源</param>
        public void Sync( ProductInformation clone ) {
            AllowMaxPrice = clone.AllowMaxPrice;
            AllowMaxTimeDeviation = clone.AllowMaxTimeDeviation;
            AllowMinPrice = clone.AllowMinPrice;
            CutDownPrice = clone.CutDownPrice;
            DepositFormula = clone.DepositFormula;
            LossProfitSpread = clone.LossProfitSpread;
            OrderStorageFeeFormula = clone.OrderStorageFeeFormula;
            PendingOrderSpread = clone.PendingOrderSpread;
            PercentageOfDeposit = clone.PercentageOfDeposit;
            PointValue = clone.PointValue;
            ProductCode = clone.ProductCode;
            ProductName = clone.ProductName;
            RawMaterialsCode = clone.RawMaterialsCode;
            RecovertyStorageFeeFormula = clone.RecovertyStorageFeeFormula;
            RecoveryFeeFormula = clone.RecoveryFeeFormula;
            Spread = clone.Spread;
            SpreadBaseValue = clone.SpreadBaseValue;
            SpreadDigit = clone.SpreadDigit;
            State = clone.State;
            StockCode = clone.StockCode;
            TransactionFeeFormula = clone.TransactionFeeFormula;
            WeightUnit = clone.WeightUnit;
            StartTradeTime = clone.StartTradeTime;
            EndTradeTime = clone.EndTradeTime;
        }

        /// <summary>
        /// 实时数据更新
        /// </summary>
        /// <param name="price">更新的价格</param>
        /// <param name="time">更新的时间</param>
        public void Update( double price, DateTime time ) {
            RealTimePrice = price;
            RealTimeTime = time;
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 计算买涨价并返回
        /// </summary>
        /// <param name="price">实时价</param>
        /// <returns>买涨价</returns>
        private double CalcOrderPrice( double price ) {
            return price + Spread * SpreadBaseValue;
        }

        #endregion
    }
}
