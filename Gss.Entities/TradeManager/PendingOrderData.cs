using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities {
    public class PendingOrderData : OrderDataBase {
        private DateTime _dueDate;
        private double _frozenDeposit;

        /// <summary>
        /// 获取或设置有效期
        /// </summary>
        public DateTime DueDate {
            get { return _dueDate; }
            set {
                _dueDate = value;
                RaisePropertyChanged( "DueDate" );
            }
        }

        /// <summary>
        /// 获取或设置预付款
        /// </summary>
        public double FrozenDeposit {
            get { return _frozenDeposit; }
            set {
                _frozenDeposit = value;
                RaisePropertyChanged( "FrozenDeposit" );
            }
        }
        /// <summary>
        /// 盈亏
        /// </summary>
        public double LossOrProfit
        {
            get;
            set;
        }
        /// <summary>
        /// 风险率
        /// </summary>
        public string RiskCoefficient
        {
            get;
            set;
        }
    }
}
