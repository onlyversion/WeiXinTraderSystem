using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Gss.Common.Utility;

namespace Gss.Entities.TradeManager
{
    /// <summary>
    /// 资金信息Model
    /// </summary>
    public class FundInformation : INotifyPropertyChanged
    {

        #region --- Interface-INotifyPropertyChanged 通知属性改变事件---

        /// <summary>
        /// PropertyChanged event of the INotifyPropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise the PropertyChanged event.
        /// </summary>
        /// <param name="name">name of the property has been changed</param>
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region --- Data 数据---
        public const double TOLERANCE = 0.00000001;
        #endregion

        #region --- Properties 属性定义---
        private double _accountBalance;
        private double _availableDeposit;
        private double _frozenDeposit;
        private double _lossOrProfit;
        private double _netAssets;
        private double _occupiedDeposit;
        private double _riskCoefficient;

        /// <summary>
        /// Gets or sets account balance.
        /// 获取或设置账户结余
        /// </summary>
        public double AccountBalance
        {
            get { return _accountBalance; }
            set
            {
                if (Math.Abs(_accountBalance - value) > TOLERANCE)
                {
                    _accountBalance = value;
                    NetAssets = AccountBalance + LossOrProfit;
                    AvailableDeposit = NetAssets - FrozenDeposit - OccupiedDeposit;
                    RiskCoefficient = CalcRiskCodfficient();
                    RaisePropertyChanged("AccountBalance");
                }
            }
        }

        /// <summary>
        /// Gets or sets available deposit.
        /// 获取或设置可用订金
        /// </summary>
        public double AvailableDeposit
        {
            get { return _availableDeposit; }
            set
            {
                if (Math.Abs(_availableDeposit - value) > TOLERANCE)
                {
                    _availableDeposit = value;
                    RaisePropertyChanged("AvailableDeposit");
                }
            }
        }

        /// <summary>
        /// Gets or sets frozen deposit.
        /// 获取或设置预付款
        /// </summary>
        public double FrozenDeposit
        {
            get { return _frozenDeposit; }
            set
            {
                if (Math.Abs(_frozenDeposit - value) > TOLERANCE)
                {
                    _frozenDeposit = value;
                    AvailableDeposit = NetAssets - FrozenDeposit - OccupiedDeposit-DongJieMoney;
                    RaisePropertyChanged("FrozenDeposit");
                    RiskCoefficient = CalcRiskCodfficient();
                }
            }
        }

        /// <summary>
        /// Gets or sets loss or profit value.
        /// 获取或设置浮动盈亏
        /// </summary>
        public double LossOrProfit
        {
            get { return _lossOrProfit; }
            set
            {
                _lossOrProfit = value;
                RiskCoefficient = CalcRiskCodfficient();
                RaisePropertyChanged("LossOrProfit");

                NetAssets = AccountBalance + LossOrProfit;
                AvailableDeposit = NetAssets - FrozenDeposit - OccupiedDeposit;
                //if( Math.Abs( _lossOrProfit - value ) > TOLERANCE ) {
                //    _lossOrProfit = value;
                //    RaisePropertyChanged( "LossOrProfit" );

                //    NetAssets = AccountBalance + LossOrProfit;
                //    AvailableDeposit = NetAssets - FrozenDeposit - OccupiedDeposit;
                //}
            }
        }

        /// <summary>
        /// Gets or sets net assets.
        /// 获取或设置净资金余额
        /// </summary>
        public double NetAssets
        {
            get { return _netAssets; }
            set
            {
                if (Math.Abs(_netAssets - value) > TOLERANCE)
                {
                    _netAssets = value;
                    RaisePropertyChanged("NetAssets");

                    RiskCoefficient = CalcRiskCodfficient();
                }
            }
        }

        /// <summary>
        /// Gets or sets occupied deposit.
        /// 获取或设置占用定金
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
                    AvailableDeposit = NetAssets - FrozenDeposit - OccupiedDeposit-DongJieMoney;
                    RiskCoefficient = CalcRiskCodfficient();
                }
            }
        }

        /// <summary>
        /// Gets or sets risk coefficient.
        /// 获取或设置风险系数
        /// </summary>
        public double RiskCoefficient
        {
            get { return _riskCoefficient; }
            set
            {
                if (Math.Abs(_riskCoefficient - value) > TOLERANCE)
                {
                    _riskCoefficient = value;
                    RaisePropertyChanged("RiskCoefficient");
                }
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
                RiskCoefficient = CalcRiskCodfficient();
                AvailableDeposit = NetAssets - FrozenDeposit - OccupiedDeposit - DongJieMoney;
                RaisePropertyChanged("DongJieMoney");
            }
        }

        #endregion

        #region --- Public Interface 公共接口---

        /// <summary>
        /// Synchronous fund information.
        /// </summary>
        /// <param name="syncInfo">the sync fund information.</param>
        public void Sync(FundInformation syncInfo)
        {
            if (syncInfo == null)
                return;
            AccountBalance = syncInfo.AccountBalance;
            //NetAssets = syncInfo.NetAssets;
            FrozenDeposit = syncInfo.FrozenDeposit;
            OccupiedDeposit = syncInfo.OccupiedDeposit;
            DongJieMoney = syncInfo.DongJieMoney;
        }

        #endregion

        #region --- Helper method 辅助方法---

        /// <summary>
        /// 计算风险率
        /// 风险率公式改为：（账户结余-冻结资金+浮动盈亏）/(保证金+预付款)
        /// </summary>
        /// <returns></returns>
        private double CalcRiskCodfficient()
        {
            //if(NetAssets==0)
            //{
            //    return 0;
            //}
            //else
            //{
            //    double d = DataDigitFilter.FilterDouble((OccupiedDeposit + FrozenDeposit) / NetAssets, 4);
            //    return d; 
            //}
            if ((OccupiedDeposit + FrozenDeposit) <= 0.000001)
            {
                return 0;
            }
            else
            {
                double d = DataDigitFilter.FilterDouble((AccountBalance - DongJieMoney + LossOrProfit) / (OccupiedDeposit + FrozenDeposit), 4);
                return d;
            }

        }

        #endregion

    }
}
