using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gss.Common.Infrastructure;
using System.Windows.Controls;

namespace Gss.Entities {
    /// <summary>
    /// 交易设置类
    /// </summary>
    [Serializable]
    public class TransactionSettings : ObservableObject {
        #region 成员

        private const double DefaultOrderUnit = 0.5;
        private const double DefaultMinTrade = 0.5;
        private const double DefaultMaxTrade = 50;

        #endregion

        #region 属性

        private bool _allowChargeback;
        private bool _allowEncashment;
        private bool _allowOrder;
        private bool _allowRecharge;
        private bool _allowRecovery;
        private bool _allowWarehousing;
        private double _maxTrade;
        private double _minTrade;

        private double _orderUnit;

        /// <summary>
        /// 获取或设置是否允许平仓
        /// </summary>
        public bool AllowChargeback {
            get { return _allowChargeback; }
            set {
                _allowChargeback = value;
                RaisePropertyChanged( "AllowChargeback" );
            }
        }

        /// <summary>
        /// 获取或设置是否允许出金
        /// </summary>
        public bool AllowEncashment {
            get { return _allowEncashment; }
            set {
                _allowEncashment = value;
                RaisePropertyChanged( "AllowEncashment" );
            }
        }

        /// <summary>
        /// 获取或设置是否允许买涨
        /// </summary>
        public bool AllowOrder {
            get { return _allowOrder; }
            set {
                _allowOrder = value;
                RaisePropertyChanged( "AllowOrder" );
            }
        }

        /// <summary>
        /// 获取或设置是否允许入金
        /// </summary>
        public bool AllowRecharge {
            get { return _allowRecharge; }
            set {
                _allowRecharge = value;
                RaisePropertyChanged( "AllowRecharge" );
            }
        }

        /// <summary>
        /// 获取或设置是否允许买跌
        /// </summary>
        public bool AllowRecovery {
            get { return _allowRecovery; }
            set {
                _allowRecovery = value;
                RaisePropertyChanged( "AllowRecovery" );
            }
        }

        /// <summary>
        /// 获取或设置是否允许入库
        /// </summary>
        public bool AllowWarehousing {
            get { return _allowWarehousing; }
            set {
                _allowWarehousing = value;
                RaisePropertyChanged( "AllowWarehousing" );
            }
        }

        /// <summary>
        /// 获取或设置最大交易手数
        /// </summary>
        public double MaxTrade
        {
            get { return _maxTrade; }
            set {
                _maxTrade = value;
                RaisePropertyChanged( "MaxTrade" );
            }
        }

        /// <summary>
        /// 获取或设置最小交易手数
        /// </summary>
        public double MinTrade {
            get { return _minTrade; }
            set {
                _minTrade = value;
                
                RaisePropertyChanged( "MinTrade" );
            }
        }

        /// <summary>
        /// 获取或设置下单单位
        /// </summary>
        public double OrderUnit {
            get { return _orderUnit; }
            set {
                _orderUnit = value;
                RaisePropertyChanged( "OrderUnit" );
            }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public TransactionSettings( ) {
            AllowChargeback = true;
            AllowEncashment = true;
            AllowOrder = true;
            AllowRecharge = true;
            AllowRecovery = true;
            AllowWarehousing = true;

            OrderUnit = DefaultOrderUnit;
            MinTrade = DefaultMinTrade;
            MaxTrade = DefaultMaxTrade;
        }

        #endregion

        #region 同步方法

        /// <summary>
        /// 同步系统设置数据
        /// </summary>
        /// <param name="clone">同步数据源</param>
        internal void Sync( TransactionSettings clone ) {
            AllowChargeback = clone.AllowChargeback;
            AllowEncashment = clone.AllowEncashment;
            AllowOrder = clone.AllowOrder;
            AllowRecharge = clone.AllowRecharge;
            AllowRecovery = clone.AllowRecovery;
            AllowWarehousing = clone.AllowWarehousing;
            OrderUnit = clone.OrderUnit;
            MinTrade = clone.MinTrade;
            MaxTrade = clone.MaxTrade;
        }

        #endregion
    }
}
