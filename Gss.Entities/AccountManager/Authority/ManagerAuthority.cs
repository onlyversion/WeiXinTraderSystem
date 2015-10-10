using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gss.Entities.AccountManager.Authority;

namespace Gss.Entities
{
    /// <summary>
    /// 管理员权限类
    /// </summary>
    [Serializable]
    public class ManagerAuthority : DealerAuthority
    {
        #region 属性

        #region 管理权限

        private bool _adminAccountManager;

        /// <summary>
        /// 获取或设置是否启用超级管理员权限
        /// </summary>
        public bool AdminAccountManager
        {
            get { return _adminAccountManager; }
            set
            {
                if (_adminAccountManager != value)
                {
                    _adminAccountManager = value;
                    RaisePropertyChanged("AdminAccountManager");

                    ConstraintAccountManager();
                }
            }
        }

        /// <summary>
        /// 约束父级客户账户管理的权限
        /// </summary>
        protected override void ConstraintAccountManager()
        {
            //当3个子级管理权限都禁用时，将账号管理权限禁用
            bool status1 = ClientAccountManager || DealerAccountManager || AdminAccountManager || AgentClerk;
            bool status2 = ClientAccountManager && DealerAccountManager && AdminAccountManager && AgentClerk;

            if (status1 == status2)
                AccountManager = status1;
            else
                AccountManager = null;
        }

        /// <summary>
        /// 约束所有子级管理权限与父级账户管理的权限同步
        /// </summary>
        /// <param name="status">父级账户管理权限状态</param>
        protected override void ConstraintAccountManagerSub(bool status)
        {
            base.ConstraintAccountManagerSub(status);
            if (_adminAccountManager != status)
            {
                _adminAccountManager = status;
                RaisePropertyChanged("AdminAccountManager");
            }
        }

        #endregion

        #region 系统设置

        private bool? _isSystemSettingsEnabled;

        /// <summary>
        /// 获取或设置是否启用系统设置（父类）
        /// </summary>
        public bool? IsSystemSettingsEnabled
        {
            get { return _isSystemSettingsEnabled; }
            set
            {
                if (_isSystemSettingsEnabled != value)
                {
                    _isSystemSettingsEnabled = value;
                    RaisePropertyChanged("IsSystemSettingsEnabled");

                    if (value.HasValue)
                        ConstraintSystemSettingsSub(value.Value);
                }
            }
        }

        private bool _allowReleaseNews;

        /// <summary>
        /// 获取或设置是否允许发布新闻
        /// </summary>
        public bool AllowReleaseNews
        {
            get { return _allowReleaseNews; }
            set
            {
                if (_allowReleaseNews != value)
                {
                    _allowReleaseNews = value;
                    RaisePropertyChanged("AllowReleaseNews");

                    ConstraintEnableSystemSettings();
                }
            }
        }

        private bool _allowReleaseAnnouncement;

        /// <summary>
        /// 获取或设置是否允许发布公告
        /// </summary>
        public bool AllowReleaseAnnouncement
        {
            get { return _allowReleaseAnnouncement; }
            set
            {
                if (_allowReleaseAnnouncement != value)
                {
                    _allowReleaseAnnouncement = value;
                    RaisePropertyChanged("AllowReleaseAnnouncement");

                    ConstraintEnableSystemSettings();
                }
            }
        }

        private bool _allowViewLog;

        /// <summary>
        /// 获取或设置是否允许查看日志
        /// </summary>
        public bool AllowViewLog
        {
            get { return _allowViewLog; }
            set
            {
                if (_allowViewLog != value)
                {
                    _allowViewLog = value;
                    RaisePropertyChanged("AllowViewLog");

                    ConstraintEnableSystemSettings();
                }
            }
        }

        private bool _allowHolidaysSettings;

        /// <summary>
        /// 获取或设置是否允许进行节假日设置
        /// </summary>
        public bool AllowHolidaysSettings
        {
            get { return _allowHolidaysSettings; }
            set
            {
                if (_allowHolidaysSettings != value)
                {
                    _allowHolidaysSettings = value;
                    RaisePropertyChanged("AllowHolidaysSettings");

                    ConstraintEnableSystemSettings();
                }
            }
        }

        private bool _allowTradingDaySettings;

        /// <summary>
        /// 获取或设置是否允许进行交易日设置
        /// </summary>
        public bool AllowTradingDaySettings
        {
            get { return _allowTradingDaySettings; }
            set
            {
                if (_allowTradingDaySettings != value)
                {
                    _allowTradingDaySettings = value;
                    RaisePropertyChanged("AllowTradingDaySettings");

                    ConstraintEnableSystemSettings();
                }
            }
        }

        private bool _allowTransactionSettings;

        /// <summary>
        /// 获取或设置是否允许进行交易设置
        /// </summary>
        public bool AllowTransactionSettings
        {
            get { return _allowTransactionSettings; }
            set
            {
                if (_allowTransactionSettings != value)
                {
                    _allowTransactionSettings = value;
                    RaisePropertyChanged("AllowTransactionSettings");

                    ConstraintEnableSystemSettings();
                }
            }
        }

        private bool _enableIPAddressFiltering;

        /// <summary>
        /// 获取或设置是否启用IP地址过滤
        /// </summary>
        public bool EnableIPAddressFiltering
        {
            get { return _enableIPAddressFiltering; }
            set
            {
                if (_enableIPAddressFiltering != value)
                {
                    _enableIPAddressFiltering = value;
                    RaisePropertyChanged("EnableIPAddressFiltering");

                    ConstraintEnableSystemSettings();
                }
            }
        }

        private bool _enableMACAddressFiltering;

        /// <summary>
        /// 获取或设置是否启用MAC地址过滤
        /// </summary>
        public bool EnableMACAddressFiltering
        {
            get { return _enableMACAddressFiltering; }
            set
            {
                if (_enableMACAddressFiltering != value)
                {
                    _enableMACAddressFiltering = value;
                    RaisePropertyChanged("EnableMACAddressFiltering");

                    ConstraintEnableSystemSettings();
                }
            }
        }


        /// <summary>
        /// 约束父级系统设置的权限
        /// </summary>
        private void ConstraintEnableSystemSettings()
        {
            bool status1 = AllowReleaseNews || AllowReleaseAnnouncement || AllowViewLog || AllowHolidaysSettings ||
                AllowTradingDaySettings || AllowTransactionSettings || EnableIPAddressFiltering || EnableMACAddressFiltering;
            bool status2 = AllowReleaseNews && AllowReleaseAnnouncement && AllowViewLog && AllowHolidaysSettings &&
                AllowTradingDaySettings && AllowTransactionSettings && EnableIPAddressFiltering && EnableMACAddressFiltering;

            if (status1 == status2)
                IsSystemSettingsEnabled = status1;
            else
                IsSystemSettingsEnabled = null;
        }

        /// <summary>
        /// 约束所有子级管理权限与父级系统设置权限同步
        /// </summary>
        /// <param name="status">父级系统设置权限状态</param>
        private void ConstraintSystemSettingsSub(bool status)
        {

            _allowReleaseNews = _allowReleaseAnnouncement = _allowViewLog = _allowHolidaysSettings = status;
            _allowTradingDaySettings = _allowTransactionSettings = _enableIPAddressFiltering = _enableMACAddressFiltering = status;
            RaisePropertyChanged("AllowReleaseNews");
            RaisePropertyChanged("AllowReleaseAnnouncement");
            RaisePropertyChanged("AllowViewLog");
            RaisePropertyChanged("AllowHolidaysSettings");
            RaisePropertyChanged("AllowTradingDaySettings");
            RaisePropertyChanged("AllowTransactionSettings");
            RaisePropertyChanged("EnableIPAddressFiltering");
            RaisePropertyChanged("EnableMACAddressFiltering");
        }

        #endregion

        #region 数据管理

        private bool? _isDataManagerEnabled;

        /// <summary>
        /// 获取或设置是否启用数据管理权限（父类）
        /// </summary>
        public bool? IsDataManagerEnabled
        {
            get { return _isDataManagerEnabled; }
            set
            {
                if (_isDataManagerEnabled != value)
                {
                    _isDataManagerEnabled = value;
                    RaisePropertyChanged("IsDataManagerEnabled");

                    if (value.HasValue)
                        ConstraintDataManagerSub(value.Value);
                }
            }
        }

        private bool _isProductManagerEnabled;

        /// <summary>
        /// 获取或设置是否启用商品管理权限
        /// </summary>
        public bool IsProductManagerEnabled
        {
            get { return _isProductManagerEnabled; }
            set
            {
                if (_isProductManagerEnabled != value)
                {
                    _isProductManagerEnabled = value;
                    RaisePropertyChanged("IsProductManagerEnabled");

                    ConstraintIsDataManagerEnabled();
                }
            }
        }

        private bool _isHistoryDataManagerEnabled;

        /// <summary>
        /// 获取或设置是否启用历史数据管理
        /// </summary>
        public bool IsHistoryDataManagerEnabled
        {
            get { return _isHistoryDataManagerEnabled; }
            set
            {
                if (_isHistoryDataManagerEnabled != value)
                {
                    _isHistoryDataManagerEnabled = value;
                    RaisePropertyChanged("IsHistoryDataManagerEnabled");

                    ConstraintIsDataManagerEnabled();
                }
            }
        }

        private bool _exchangeRateWater;

        /// <summary>
        /// 获取或设置汇率/水
        /// </summary>
        public bool ExchangeRateWater
        {
            get { return _exchangeRateWater; }
            set
            {
                if (_exchangeRateWater != value)
                {
                    _exchangeRateWater = value;
                    RaisePropertyChanged("ExchangeRateWater");

                    ConstraintIsDataManagerEnabled();
                }
            }
        }

        /// <summary>
        /// 约束父级数据设置的权限
        /// </summary>
        private void ConstraintIsDataManagerEnabled()
        {
            bool status1 = IsProductManagerEnabled || IsHistoryDataManagerEnabled || ExchangeRateWater;

            bool status2 = IsProductManagerEnabled && IsHistoryDataManagerEnabled && ExchangeRateWater;

            if (status1 == status2)
                IsDataManagerEnabled = status1;
            else
                IsDataManagerEnabled = null;
        }

        /// <summary>
        ///  约束所有子级权限与父级数据管理权限同步
        /// </summary>
        /// <param name="status">父级数据管理权限状态</param>
        private void ConstraintDataManagerSub(bool status)
        {
            _isProductManagerEnabled = _isHistoryDataManagerEnabled = _exchangeRateWater = status;
            RaisePropertyChanged("IsProductManagerEnabled");
            RaisePropertyChanged("IsHistoryDataManagerEnabled");
            RaisePropertyChanged("ExchangeRateWater");
        }

        #endregion

        #endregion

        #region 构造函数

        /// <summary>
        /// 实例化一个包含默认值的管理员权限类
        /// </summary>
        public ManagerAuthority()
        {
            AccountManager = true;
            OperatingAuthority = true;
            IsTradeManagerEnabled = true;
            IsSystemSettingsEnabled = true;
            IsDataManagerEnabled = true;
            AccMgrReadonly = false;
        }

        /// <summary>
        /// 实例化一个根据基类（金商权限）的管理员权限类
        /// </summary>
        /// <param name="dealerAuthority"></param>
        public ManagerAuthority(DealerAuthority dealerAuthority)
        {
            base.Sync(dealerAuthority);

            AdminAccountManager = false;
            IsSystemSettingsEnabled = false;
            IsDataManagerEnabled = false;
        }

        public ManagerAuthority(ClerkAuthority dealerAuthority)
        {
           
            AllowViewMarketOrder = false;
            AllowViewPendingOrder = false;
            AllowViewWarehousing = false;
            AllowViewChargebackRecord = false;
            AllowViewHedgingTransactions = false;
            AllowExportStatement = false;

            AccountManager = false;
            //IsTradeManagerEnabled = dealerAuthority.TradeManage;
            AdminAccountManager = false;
            IsSystemSettingsEnabled = false;
            IsDataManagerEnabled = false;
        }


        #endregion

        #region 数据同步

        /// <summary>
        /// 同步管理员权限数据
        /// </summary>
        /// <param name="mgrAuthority">同步权限数据源</param>
        internal void Sync(ManagerAuthority mgrAuthority)
        {
            base.Sync(mgrAuthority);

            AdminAccountManager = mgrAuthority.AdminAccountManager;

            //同步系统设置权限
            if (mgrAuthority.IsSystemSettingsEnabled.HasValue)
                IsSystemSettingsEnabled = mgrAuthority.IsSystemSettingsEnabled;
            else
            {
                AllowReleaseAnnouncement = mgrAuthority.AllowReleaseAnnouncement;
                AllowReleaseNews = mgrAuthority.AllowReleaseNews;
                AllowViewLog = mgrAuthority.AllowViewLog;
                AllowHolidaysSettings = mgrAuthority.AllowHolidaysSettings;
                AllowTradingDaySettings = mgrAuthority.AllowTradingDaySettings;
                AllowTransactionSettings = mgrAuthority.AllowTransactionSettings;
                EnableIPAddressFiltering = mgrAuthority.EnableIPAddressFiltering;
                EnableMACAddressFiltering = mgrAuthority.EnableMACAddressFiltering;
            }

            //同步数据管理权限
            if (mgrAuthority.IsDataManagerEnabled.HasValue)
                IsDataManagerEnabled = mgrAuthority.IsDataManagerEnabled;
            else
            {
                IsProductManagerEnabled = mgrAuthority.IsProductManagerEnabled;
                IsHistoryDataManagerEnabled = mgrAuthority.IsHistoryDataManagerEnabled;
                ExchangeRateWater = mgrAuthority.ExchangeRateWater;
            }
        }

        #endregion

    }
}
