using System;
using Gss.Common.Infrastructure;
using Gss.Common.Utility;
using Gss.Entities.Enums;

namespace Gss.Entities {
    /// <summary>
    /// 资金信息类
    /// </summary>
    [Serializable]
    public class FundsInformation : ObservableObject {
        #region 属性
        private string _bankAccountName;
        private string _bankCardNumber;
        private string _bankNumber;
        private CONTRACT_STATUS _contractStatus;
        private double _currentBalance;
        private double _frozenDeposit;
        private string _fundsAccount;
        private double _occupiedDeposit;
        private string _openBank;
        private string _subAccount;
        private string _tanAccount;

        private string _banktype;

        /// <summary>
        /// 银行类型代码
        /// </summary>
        public string banktype
        {
            get { return _banktype; }
            set
            {
                _banktype = value;
                RaisePropertyChanged("banktype");
            }
        }
        

        /// <summary>
        /// 获取或设置银行卡账户名
        /// </summary>
        public string BankAccountName {
            get { return _bankAccountName; }
            set {
                _bankAccountName = value;
                RaisePropertyChanged("BankAccountName");
            }
        }

        /// <summary>
        /// 获取或设置银行卡卡号
        /// </summary>
        public string BankCardNumber {
            get { return _bankCardNumber; }
            set {
                _bankCardNumber = value;
                RaisePropertyChanged("BankCardNumber");
            }
        }

        /// <summary>
        /// 获取或设置银行行号
        /// </summary>
        public string BankNumber {
            get { return _bankNumber; }
            set {
                _bankNumber = value;
                RaisePropertyChanged("BankNumber");
            }
        }

        /// <summary>
        /// 获取或设置签约状态
        /// </summary>
        public CONTRACT_STATUS ContractStatus {
            get { return _contractStatus; }
            set {
                if( _contractStatus != value ) {
                    _contractStatus = value;
                    RaisePropertyChanged( "TanAccount" );
                }
            }
        }

        /// <summary>
        /// 获取或设置当前账户余额
        /// </summary>
        public double CurrentBalance {
            get { return _currentBalance; }
            set {
                if( _currentBalance != value ) {
                    _currentBalance = value;
                    RaisePropertyChanged( "CurrentBalance" );
                }
            }
        }

        /// <summary>
        /// 获取或设置预付款
        /// </summary>
        public double FrozenDeposit {
            get { return _frozenDeposit; }
            set {
                if( _frozenDeposit != value ) {
                    _frozenDeposit = value;
                    RaisePropertyChanged( "OccupiedDeposit" );
                }
            }
        }

        /// <summary>
        /// 获取或设置资金账户
        /// </summary>
        public string FundsAccount {
            get { return _fundsAccount; }
            set {
                _fundsAccount = value;
                RaisePropertyChanged( "FundsAccount" );
            }
        }

        /// <summary>
        /// 获取或设置占用定金
        /// </summary>
        public double OccupiedDeposit {
            get { return _occupiedDeposit; }
            set {
                if( _occupiedDeposit != value ) {
                    _occupiedDeposit = value;
                    RaisePropertyChanged( "OccupiedDeposit" );
                }
            }
        }

        /// <summary>
        /// 获取或设置开户银行
        /// </summary>
        public string OpenBank {
            get { return _openBank; }
            set {
                _openBank = value;
                RaisePropertyChanged( "OpenBank" );
            }
        }

        /// <summary>
        /// 获取或设置子账号
        /// </summary>
        public string SubAccount {
            get { return _subAccount; }
            set {
                _subAccount = value;
                RaisePropertyChanged( "SubAccount" );
            }
        }

        /// <summary>
        /// 获取或设置摊位号
        /// </summary>
        public string TanAccount {
            get { return _tanAccount; }
            set {
                _tanAccount = value;
                RaisePropertyChanged( "TanAccount" );
            }
        }

        #endregion

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
        /// 克隆一个完整的用户资金信息类
        /// </summary>
        /// <returns></returns>
        public object Clone( ) {
            return CloneHelper.CloneObject( this );
        }

        /// <summary>
        /// 数据同步
        /// </summary>
        /// <param name="clone">同步数据源</param>
        public void Sync( FundsInformation clone ) {
            BankAccountName = clone.BankAccountName;
            BankCardNumber = clone.BankCardNumber;
            BankNumber = clone.BankNumber;
            OpenBank = clone.OpenBank;
            DongJieMoney = clone.DongJieMoney;
            banktype = clone.banktype;
        }

    }
}
