using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.JTWEntityes
{
    /// <summary>
    /// 功能：用户权限信息
    /// 创建人：马友春
    /// 创建时间：2013年12月27日
    /// </summary>
    public class UserPrivilegesInfo:BaseInfo
    {
        #region 属性

        #region 管理权限
        private bool? _accountManager;
        /// <summary>
        /// 账号管理权限（父级）
        /// </summary>
        public bool? AccountManager
        {
            get { return _accountManager; }
            set
            {
                if (_accountManager != value)
                {
                    _accountManager = value;
                    RaisePropertyChanged("AccountManager");
                }
            }
        }

        private bool _adminAccountManager;
        /// <summary>
        /// 管理员
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
                }
            }
        }
        private bool _adminAccountManagerAccountInfo;
        /// <summary>
        /// 管理员--管理员资料
        /// </summary>
        public bool AdminAccountManagerAccountInfo
        {
            get { return _adminAccountManagerAccountInfo; }
            set
            {
                if (_adminAccountManagerAccountInfo != value)
                {
                    _adminAccountManagerAccountInfo = value;
                    RaisePropertyChanged("AdminAccountManagerAccountInfo");
                }
            }
        }
        private bool _adminAccountManagerAddAccount;
        /// <summary>
        /// 管理员--新增管理员
        /// </summary>
        public bool AdminAccountManagerAddAccount
        {
            get { return _adminAccountManagerAddAccount; }
            set
            {
                if (_adminAccountManagerAddAccount != value)
                {
                    _adminAccountManagerAddAccount = value;
                    RaisePropertyChanged("AdminAccountManagerAddAccount");
                }
            }
        }
        private bool _adminAccountManagerDelAccount;
        /// <summary>
        /// 管理员--删除管理员
        /// </summary>
        public bool AdminAccountManagerDelAccount
        {
            get { return _adminAccountManagerDelAccount; }
            set
            {
                if (_adminAccountManagerDelAccount != value)
                {
                    _adminAccountManagerDelAccount = value;
                    RaisePropertyChanged("AdminAccountManagerDelAccount");
                }
            }
        }

        private bool _clientAccountManager;
        /// <summary>
        /// 客户账号管理权限
        /// </summary>
        public bool ClientAccountManager
        {
            get { return _clientAccountManager; }
            set
            {
                if (_clientAccountManager != value)
                {
                    _clientAccountManager = value;
                    RaisePropertyChanged("ClientAccountManager");
                }
            }
        }

        private bool _clientAccountManagerAccountInfo;
        /// <summary>
        /// 客户账号--客户账户资料
        /// </summary>
        public bool ClientAccountManagerAccountInfo
        {
            get { return _clientAccountManagerAccountInfo; }
            set
            {
                if (_clientAccountManagerAccountInfo != value)
                {
                    _clientAccountManagerAccountInfo = value;
                    RaisePropertyChanged("ClientAccountManagerAccountInfo");
                }
            }
        }
        private bool _clientAccountManagerAddAccount;
        /// <summary>
        /// 客户账号--新增客户账户
        /// </summary>
        public bool ClientAccountManagerAddAccount
        {
            get { return _clientAccountManagerAddAccount; }
            set
            {
                if (_clientAccountManagerAddAccount != value)
                {
                    _clientAccountManagerAddAccount = value;
                    RaisePropertyChanged("ClientAccountManagerAddAccount");
                }
            }
        }
        private bool _clientAccountManagerAdjustMoney;
        /// <summary>
        /// 客户账号--调节
        /// </summary>
        public bool ClientAccountManagerAdjustMoney
        {
            get { return _clientAccountManagerAdjustMoney; }
            set
            {
                if (_clientAccountManagerAdjustMoney != value)
                {
                    _clientAccountManagerAdjustMoney = value;
                    RaisePropertyChanged("ClientAccountManagerAdjustMoney");
                }
            }
        }
        private bool _clientAccountManagerDelAccount;
        /// <summary>
        /// 客户账号--删除客户账户
        /// </summary>
        public bool ClientAccountManagerDelAccount
        {
            get { return _clientAccountManagerDelAccount; }
            set
            {
                if (_clientAccountManagerDelAccount != value)
                {
                    _clientAccountManagerDelAccount = value;
                    RaisePropertyChanged("ClientAccountManagerDelAccount");
                }
            }
        }
        private bool _clientAccountManagerFundsInfo;
        /// <summary>
        /// 客户账号--客户资金信息
        /// </summary>
        public bool ClientAccountManagerFundsInfo
        {
            get { return _clientAccountManagerFundsInfo; }
            set
            {
                if (_clientAccountManagerFundsInfo != value)
                {
                    _clientAccountManagerFundsInfo = value;
                    RaisePropertyChanged("ClientAccountManagerFundsInfo");
                }
            }
        }
        private bool _clientAccountManagerMarketOrder;
        /// <summary>
        /// 客户账号--即时成交
        /// </summary>
        public bool ClientAccountManagerMarketOrder
        {
            get { return _clientAccountManagerMarketOrder; }
            set
            {
                if (_clientAccountManagerMarketOrder != value)
                {
                    _clientAccountManagerMarketOrder = value;
                    RaisePropertyChanged("ClientAccountManagerMarketOrder");
                }
            }
        }
        private bool _clientAccountManagerPendingOrder;
        /// <summary>
        /// 客户账号--挂单交易
        /// </summary>
        public bool ClientAccountManagerPendingOrder
        {
            get { return _clientAccountManagerPendingOrder; }
            set
            {
                if (_clientAccountManagerPendingOrder != value)
                {
                    _clientAccountManagerPendingOrder = value;
                    RaisePropertyChanged("ClientAccountManagerPendingOrder");
                }
            }
        }
        private bool _ClientAccountManagerOrderInfo;
        /// <summary>
        /// 客户账号--订单信息
        /// </summary>
            public bool ClientAccountManagerOrderInfo
        {
            get { return _ClientAccountManagerOrderInfo; }
            set
            {
                if (_ClientAccountManagerOrderInfo != value)
                {
                    _ClientAccountManagerOrderInfo = value;
                    RaisePropertyChanged("ClientAccountManagerOrderInfo");
                }
            }
        }

        
        private bool _dealerAccountManager;
        /// <summary>
        /// 会员账户
        /// </summary>
        public bool DealerAccountManager
        {
            get { return _dealerAccountManager; }
            set
            {
                if (_dealerAccountManager != value)
                {
                    _dealerAccountManager = value;
                    RaisePropertyChanged("DealerAccountManager");
                }
            }
        }
        private bool _dealerAccountManagerAccountInfo;
        /// <summary>
        /// 会员账户--会员账户资料
        /// </summary>
        public bool DealerAccountManagerAccountInfo
        {
            get { return _dealerAccountManagerAccountInfo; }
            set
            {
                if (_dealerAccountManagerAccountInfo != value)
                {
                    _dealerAccountManagerAccountInfo = value;
                    RaisePropertyChanged("DealerAccountManagerAccountInfo");
                }
            }
        }
        private bool _dealerAccountManagerAddAccount;
        /// <summary>
        /// 会员账户--新增会员账户
        /// </summary>
        public bool DealerAccountManagerAddAccount
        {
            get { return _dealerAccountManagerAddAccount; }
            set
            {
                if (_dealerAccountManagerAddAccount != value)
                {
                    _dealerAccountManagerAddAccount = value;
                    RaisePropertyChanged("DealerAccountManagerAddAccount");
                }
            }
        }
        private bool _dealerAccountManagerDelAccount;
        /// <summary>
        /// 会员账户--删除会员账户
        /// </summary>
        public bool DealerAccountManagerDelAccount
        {
            get { return _dealerAccountManagerDelAccount; }
            set
            {
                if (_dealerAccountManagerDelAccount != value)
                {
                    _dealerAccountManagerDelAccount = value;
                    RaisePropertyChanged("DealerAccountManagerDelAccount");
                }
            }
        }
        private bool _dealerAccountManagerRole;
        /// <summary>
        /// 会员账户--会员账户角色
        /// </summary>
        public bool DealerAccountManagerRole
        {
            get { return _dealerAccountManagerRole; }
            set
            {
                if (_dealerAccountManagerRole != value)
                {
                    _dealerAccountManagerRole = value;
                    RaisePropertyChanged("DealerAccountManagerRole");
                }
            }
        }

        private bool _clientOnlineAccountManager;
        /// <summary>
        /// 在线客户
        /// </summary>
           public bool ClientOnlineAccountManager
        {
            get { return _clientOnlineAccountManager; }
            set
            {
                if (_clientOnlineAccountManager != value)
                {
                    _clientOnlineAccountManager = value;
                    RaisePropertyChanged("ClientOnlineAccountManager");
                }
            }
        }
           private bool _clientOnlineAccountManagerAccountInfo;
           /// <summary>
           /// 在线客户--账户资料
           /// </summary>
           public bool ClientOnlineAccountManagerAccountInfo
           {
               get { return _clientOnlineAccountManagerAccountInfo; }
               set
               {
                   if (_clientOnlineAccountManagerAccountInfo != value)
                   {
                       _clientOnlineAccountManagerAccountInfo = value;
                       RaisePropertyChanged("ClientOnlineAccountManagerAccountInfo");
                   }
               }
           }
           private bool _clientOnlineAccountManagerDelAccount;
           /// <summary>
           /// 在线客户--删除账户
           /// </summary>
           public bool ClientOnlineAccountManagerDelAccount
           {
               get { return _clientOnlineAccountManagerDelAccount; }
               set
               {
                   if (_clientOnlineAccountManagerDelAccount != value)
                   {
                       _clientOnlineAccountManagerDelAccount = value;
                       RaisePropertyChanged("ClientOnlineAccountManagerDelAccount");
                   }
               }
           }
           private bool _clientOnlineAccountManagerFundsInfo;
           /// <summary>
           /// 在线客户--资金信息
           /// </summary>
           public bool ClientOnlineAccountManagerFundsInfo
           {
               get { return _clientOnlineAccountManagerFundsInfo; }
               set
               {
                   if (_clientOnlineAccountManagerFundsInfo != value)
                   {
                       _clientOnlineAccountManagerFundsInfo = value;
                       RaisePropertyChanged("ClientOnlineAccountManagerFundsInfo");
                   }
               }
           }
           private bool _ClientOnlineAccountManagerOrderInfo;
           /// <summary>
           /// 在线客户--订单信息
           /// </summary>
          public bool ClientOnlineAccountManagerOrderInfo
           {
               get { return _ClientOnlineAccountManagerOrderInfo; }
               set
               {
                   if (_ClientOnlineAccountManagerOrderInfo != value)
                   {
                       _ClientOnlineAccountManagerOrderInfo = value;
                       RaisePropertyChanged("ClientOnlineAccountManagerOrderInfo");
                   }
               }
           }
        
           private bool _orgManager;
        /// <summary>
        /// 微会员
        /// </summary>
            public bool OrgManager
        {
            get { return _orgManager; }
            set
            {
                if (_orgManager != value)
                {
                    _orgManager = value;
                    RaisePropertyChanged("OrgManager");
                }
            }
        }
            private bool _orgManagerAccountInfo;
            /// <summary>
            /// 微会员--微会员资料
            /// </summary>
            public bool OrgManagerAccountInfo
            {
                get { return _orgManagerAccountInfo; }
                set
                {
                    if (_orgManagerAccountInfo != value)
                    {
                        _orgManagerAccountInfo = value;
                        RaisePropertyChanged("OrgManagerAccountInfo");
                    }
                }
            }
            private bool _orgManagerAddAccount;
            /// <summary>
            /// 微会员--新增微会员
            /// </summary>
            public bool OrgManagerAddAccount
            {
                get { return _orgManagerAddAccount; }
                set
                {
                    if (_orgManagerAddAccount != value)
                    {
                        _orgManagerAddAccount = value;
                        RaisePropertyChanged("OrgManagerAddAccount");
                    }
                }
            }
            private bool _orgManagerDelAccount;
            /// <summary>
            /// 微会员--删除微会员
            /// </summary>
            public bool OrgManagerDelAccount
            {
                get { return _orgManagerDelAccount; }
                set
                {
                    if (_orgManagerDelAccount != value)
                    {
                        _orgManagerDelAccount = value;
                        RaisePropertyChanged("OrgManagerDelAccount");
                    }
                }
            }


            private bool _orgManagerRole;
            /// <summary>
            /// 微会员--微会员角色
            /// </summary>
            public bool orgManagerRole
            {
                get { return _orgManagerRole; }
                set
                {
                    if (_orgManagerRole != value)
                    {
                        _orgManagerRole = value;
                        RaisePropertyChanged("orgManagerRole");
                    }
                }
            }

            private bool _orgManagerSetCommissionRatio;
            /// <summary>
            /// 微会员--返佣比例
            /// </summary>
            public bool OrgManagerSetCommissionRatio
            {
                get { return _orgManagerSetCommissionRatio; }
                set
                {
                    if (_orgManagerSetCommissionRatio != value)
                    {
                        _orgManagerSetCommissionRatio = value;
                        RaisePropertyChanged("OrgManagerSetCommissionRatio");
                    }
                }
            }

            private bool _OrgManagerSetDefaultCommissionRatio;
            /// <summary>
            /// 微会员--返佣比例
            /// </summary>
            public bool OrgManagerSetDefaultCommissionRatio
            {
                get { return _OrgManagerSetDefaultCommissionRatio; }
                set
                {
                    if (_OrgManagerSetDefaultCommissionRatio != value)
                    {
                        _OrgManagerSetDefaultCommissionRatio = value;
                        RaisePropertyChanged("OrgManagerSetDefaultCommissionRatio");
                    }
                }
            }

            private bool _OrgManagerSetAllCommissionRatio;
            /// <summary>
            /// 微会员--返佣比例
            /// </summary>
            public bool OrgManagerSetAllCommissionRatio
            {
                get { return _OrgManagerSetAllCommissionRatio; }
                set
                {
                    if (_OrgManagerSetAllCommissionRatio != value)
                    {
                        _OrgManagerSetAllCommissionRatio = value;
                        RaisePropertyChanged("OrgManagerSetAllCommissionRatio");
                    }
                }
            }
        
            private bool _rolePrivilegeEnabled;
        /// <summary>
        /// 角色权限
        /// </summary>
              public bool RolePrivilegeEnabled
        {
            get { return _rolePrivilegeEnabled; ; }
            set
            {
                if (_rolePrivilegeEnabled != value)
                {
                    _rolePrivilegeEnabled = value;
                    RaisePropertyChanged("RolePrivilegeEnabled");
                }
            }
        }

        

        private bool _AgentClerk;
        /// <summary>
        /// 金商店员
        /// </summary>
        public bool AgentClerk
        {
            get { return _AgentClerk; }
            set
            {
                _AgentClerk = value;
                RaisePropertyChanged("AgentClerk");
            }
        }




        private bool _AllowExportPendingOrderReport;
        /// <summary>
        /// 允许导出限价单报表
        /// </summary>
        public bool AllowExportPendingOrderReport
        {
            get { return _AllowExportPendingOrderReport; }
            set
            {
                if (_AllowExportPendingOrderReport != value)
                {
                    _AllowExportPendingOrderReport = value;
                    RaisePropertyChanged("AllowExportPendingOrderReport");
                }
            }
        }

        private bool _AllowExportMarketOrderReport;
        /// <summary>
        /// 允许导出市价单报表
        /// </summary>
        public bool AllowExportMarketOrderReport
        {
            get { return _AllowExportMarketOrderReport; }
            set
            {
                if (_AllowExportMarketOrderReport != value)
                {
                    _AllowExportMarketOrderReport = value;
                    RaisePropertyChanged("AllowExportMarketOrderReport");
                }
            }
        }

        private bool _AllowExportFundReport;
        /// <summary>
        /// 允许导出资金报表
        /// </summary>
        public bool AllowExportFundReport
        {
            get { return _AllowExportFundReport; }
            set
            {
                if (_AllowExportFundReport != value)
                {
                    _AllowExportFundReport = value;
                    RaisePropertyChanged("AllowExportFundReport");
                }
            }
        }

        private bool _AllowExportAdjustReport;
        /// <summary>
        /// 允许导出平仓报表
        /// </summary>
        public bool AllowExportAdjustReport
        {
            get { return _AllowExportAdjustReport; }
            set
            {
                if (_AllowExportAdjustReport != value)
                {
                    _AllowExportAdjustReport = value;
                    RaisePropertyChanged("AllowExportAdjustReport");
                }
            }
        }



        #endregion

        #region 系统设置

        private bool? _isSystemSettingsEnabled;

        /// <summary>
        /// 系统设置（父类）
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
                }
            }
        }

        private bool _allowReleaseNews;

        /// <summary>
        /// 发布新闻
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
                }
            }
        }

        private bool _allowReleaseAnnouncement;

        /// <summary>
        /// 发布公告
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
                }
            }
        }

        private bool _AllowArticlesInfo;

        /// <summary>
        /// 获取或设置是否允许理财师说
        /// </summary>
        public bool AllowArticlesInfo
        {
            get { return _AllowArticlesInfo; }
            set
            {
                if (_AllowArticlesInfo != value)
                {
                    _AllowArticlesInfo = value;
                    RaisePropertyChanged("AllowArticlesInfo");

                }
            }
        }

        private bool _allowViewLog;

        /// <summary>
        ///查看日志
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
                }
            }
        }

        private bool _allowHolidaysSettings;

        /// <summary>
        /// 假日设置
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
                }
            }
        }

        private bool _allowTradingDaySettings;

        /// <summary>
        /// 交易日设置
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
                }
            }
        }

        private bool _allowTransactionSettings;

        /// <summary>
        /// 交易设置
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
                }
            }
        }

        private bool _enableIPAddressFiltering;

        /// <summary>
        /// IP地址过滤
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
                }
            }
        }

        private bool _enableRoleManager;

        /// <summary>
        /// 角色管理权限
        /// </summary>
        public bool EnableRoleManager
        {
            get { return _enableRoleManager; }
            set
            {
                if (_enableRoleManager != value)
                {
                    _enableRoleManager = value;
                    RaisePropertyChanged("EnableRoleManager");
                }
            }
        }

        private bool _enablePrivilegeManager;

        /// <summary>
        /// 权限管理（用于超级管理员配置权限）
        /// </summary>
        public bool EnablePrivilegeManager
        {
            get { return _enablePrivilegeManager; }
            set
            {
                if (_enablePrivilegeManager != value)
                {
                    _enablePrivilegeManager = value;
                    RaisePropertyChanged("EnablePrivilegeManager");
                }
            }
        }

        private bool _EnableTradeMoneyInfo;

        /// <summary>
        /// 出入金解约
        /// </summary>
        public bool EnableTradeMoneyInfo
        {
            get { return _EnableTradeMoneyInfo; }
            set
            {
                if (_EnableTradeMoneyInfo != value)
                {
                    _EnableTradeMoneyInfo = value;
                    RaisePropertyChanged("EnableTradeMoneyInfo");
                }
            }
        }

        private bool _GroupManager;
        /// <summary>
        /// 分组管理
        /// </summary>
        public bool GroupManager
        {
            get { return _GroupManager; }
            set
            {
                _GroupManager = value;
                RaisePropertyChanged("GroupManager");
            }
        }

        #endregion

        #region 数据管理

        private bool? _isDataManagerEnabled;

        /// <summary>
        /// 数据管理权限（父类）
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
                }
            }
        }

        private bool _isProductManagerEnabled;

        /// <summary>
        /// 商品管理权限
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
                }
            }
        }

        private bool _isHistoryDataManagerEnabled;

        /// <summary>
        /// 历史数据管理
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
                }
            }
        }

        private bool _manualPriceEnabled;

        /// <summary>
        /// 手工报价
        /// </summary>
           public bool ManualPriceEnabled
        {
            get { return _manualPriceEnabled; }
            set
            {
                if (_manualPriceEnabled != value)
                {
                    _manualPriceEnabled = value;
                    RaisePropertyChanged("ManualPriceEnabled");
                }
            }
        }

           private bool _EffectiveEnabled;

        /// <summary>
        /// 体验券
        /// </summary>
           public bool EffectiveEnabled
        {
            get { return _EffectiveEnabled; }
            set
            {
                if (_EffectiveEnabled != value)
                {
                    _EffectiveEnabled = value;
                    RaisePropertyChanged("EffectiveEnabled");
                }
            }
        }
        
        
        private bool _exchangeRateWater;

        /// <summary>
        /// 汇率/水
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
                }
            }
        }

        #endregion

        #region 提货受理权限

        private bool _ShouLiMingXi;
        /// <summary>
        ///  受理明细
        /// </summary>
        public bool ShouLiMingXi
        {
            get { return _ShouLiMingXi; }
            set
            {
                _ShouLiMingXi = value;
                RaisePropertyChanged("ShouLiMingXi");
            }
        }

        private bool _TiHuo;
        /// <summary>
        ///  提货
        /// </summary>
        public bool TiHuo
        {
            get { return _TiHuo; }
            set
            {
                _TiHuo = value;
                RaisePropertyChanged("TiHuo");
            }
        }

        private bool _BangDingUser;
        /// <summary>
        /// 绑定账号
        /// </summary>
        public bool BangDingUser
        {
            get { return _BangDingUser; }
            set
            {
                _BangDingUser = value;
                RaisePropertyChanged("BangDingUser");
            }
        }



        private bool? _TiHuoShouLi;
        /// <summary>
        ///提货受理 （父级）
        /// </summary>
        public bool? TiHuoShouLi
        {
            get { return _TiHuoShouLi; }
            set
            {
                _TiHuoShouLi = value;
                RaisePropertyChanged("TiHuoShouLi");
            }
        }
        #endregion
        
        #region 交易管理
        private bool? _isTradeManagerEnabled;

        /// <summary>
        /// 交易管理（父级）
        /// </summary>
        public bool? IsTradeManagerEnabled
        {
            get { return _isTradeManagerEnabled; }
            set
            {
                if (_isTradeManagerEnabled != value)
                {
                    _isTradeManagerEnabled = value;
                    RaisePropertyChanged("IsTradeManagerEnabled");
                }
            }
        }


        private bool _JgjOrder;
        /// <summary>
        /// 金生金单
        /// </summary>
        public bool JgjOrder
        {
            get { return _JgjOrder; }
            set
            {
                _JgjOrder = value;
                RaisePropertyChanged("JgjOrder");
            }
        }

        private bool _HuiGouOrder;
        /// <summary>
        ///  买跌单
        /// </summary>
        public bool HuiGouOrder
        {
            get { return _HuiGouOrder; }
            set
            {
                _HuiGouOrder = value;
                RaisePropertyChanged("HuiGouOrder");
            }
        }

        private bool _TihuoOrder;
        /// <summary>
        ///提货单
        /// </summary>
        public bool TihuoOrder
        {
            get { return _TihuoOrder; }
            set
            {
                _TihuoOrder = value;
                RaisePropertyChanged("TihuoOrder");
            }
        }

        private bool _DeliverOrder;
        /// <summary>
        ///交割单
        /// </summary>
        public bool DeliverOrder
        {
            get { return _DeliverOrder; }
            set
            {
                _DeliverOrder = value;
                RaisePropertyChanged("DeliverOrder");
            }
        }


        private bool _allowViewMarketOrder;

        /// <summary>
        ///市价定单（有效单）
        /// </summary>
        public bool AllowViewMarketOrder
        {
            get { return _allowViewMarketOrder; }
            set
            {
                if (_allowViewMarketOrder != value)
                {
                    _allowViewMarketOrder = value;
                    RaisePropertyChanged("AllowViewMarketOrder");
                }
            }
        }


        private bool _allowViewMarketOrderChargeback;

        /// <summary>
        ///市价定单（有效单）--平仓
        /// </summary>
        public bool AllowViewMarketOrderChargeback
        {
            get { return _allowViewMarketOrderChargeback; }
            set
            {
                if (_allowViewMarketOrderChargeback != value)
                {
                    _allowViewMarketOrderChargeback = value;
                    RaisePropertyChanged("AllowViewMarketOrderChargeback");
                }
            }
        }
        private bool _AllowViewMarketOrderOrderInfo;

        /// <summary>
        ///市价定单（有效单）--订单信息
        /// </summary>
          public bool AllowViewMarketOrderOrderInfo
        {
            get { return _AllowViewMarketOrderOrderInfo; }
            set
            {
                if (_AllowViewMarketOrderOrderInfo != value)
                {
                    _AllowViewMarketOrderOrderInfo = value;
                    RaisePropertyChanged("AllowViewMarketOrderOrderInfo");
                }
            }
        }

        
        private bool _allowViewPendingOrder;

        /// <summary>
        /// 限价定单
        /// </summary>
        public bool AllowViewPendingOrder
        {
            get { return _allowViewPendingOrder; }
            set
            {
                if (_allowViewPendingOrder != value)
                {
                    _allowViewPendingOrder = value;
                    RaisePropertyChanged("AllowViewPendingOrder");
                }
            }
        }

        private bool _allowViewPendingOrderCancel;

        /// <summary>
        /// 限价定单--撤销
        /// </summary>
        public bool AllowViewPendingOrderCancel
        {
            get { return _allowViewPendingOrderCancel; }
            set
            {
                if (_allowViewPendingOrderCancel != value)
                {
                    _allowViewPendingOrderCancel = value;
                    RaisePropertyChanged("AllowViewPendingOrderCancel");
                }
            }
        }

        private bool _AllowViewPendingOrderOrderInfo;

        /// <summary>
        /// 限价定单--订单信息
        /// </summary>
        public bool AllowViewPendingOrderOrderInfo
        {
            get { return _AllowViewPendingOrderOrderInfo; }
            set
            {
                if (_AllowViewPendingOrderOrderInfo != value)
                {
                    _AllowViewPendingOrderOrderInfo = value;
                    RaisePropertyChanged("AllowViewPendingOrderOrderInfo");
                }
            }
        }
        
        private bool _allowViewChargebackRecord;

        /// <summary>
        /// 平仓历史
        /// </summary>
        public bool AllowViewChargebackRecord
        {
            get { return _allowViewChargebackRecord; }
            set
            {
                if (_allowViewChargebackRecord != value)
                {
                    _allowViewChargebackRecord = value;
                    RaisePropertyChanged("AllowViewChargebackRecord");
                }
            }
        }
        private bool _AllowViewChargebackRecordOrderInfo;

        /// <summary>
        /// 平仓历史--订单信息
        /// </summary>
           public bool AllowViewChargebackRecordOrderInfo
        {
            get { return _AllowViewChargebackRecordOrderInfo; }
            set
            {
                if (_AllowViewChargebackRecordOrderInfo != value)
                {
                    _AllowViewChargebackRecordOrderInfo = value;
                    RaisePropertyChanged("AllowViewChargebackRecordOrderInfo");
                }
            }
        }
        
        private bool _allowViewWarehousing;

        /// <summary>
        /// 入库单
        /// </summary>
        public bool AllowViewWarehousing
        {
            get { return _allowViewWarehousing; }
            set
            {
                if (_allowViewWarehousing != value)
                {
                    _allowViewWarehousing = value;
                    RaisePropertyChanged("AllowViewWarehousing");
                }
            }
        }

        private bool _allowViewHedgingTransactions;

        /// <summary>
        ///对冲交易
        /// </summary>
        public bool AllowViewHedgingTransactions
        {
            get { return _allowViewHedgingTransactions; }
            set
            {
                if (_allowViewHedgingTransactions != value)
                {
                    _allowViewHedgingTransactions = value;
                    RaisePropertyChanged("AllowViewHedgingTransactions");
                }
            }
        }

        private bool _allowExportStatement;

        /// <summary>
        /// 导出报表
        /// </summary>
        public bool AllowExportStatement
        {
            get { return _allowExportStatement; }
            set
            {
                if (_allowExportStatement != value)
                {
                    _allowExportStatement = value;
                    RaisePropertyChanged("AllowExportStatement");
                }
            }
        }

        private bool _TradeChuJin;

        /// <summary>
        /// 出金处理
        /// </summary>
           public bool TradeChuJin
        {
            get { return _TradeChuJin; }
            set
            {
                if (_TradeChuJin != value)
                {
                    _TradeChuJin = value;
                    RaisePropertyChanged("TradeChuJin");
                }
            }
        }

           //private bool _TradeChuJinPay;

           ///// <summary>
           ///// 出金处理--付款
           ///// </summary>
           //public bool TradeChuJinPay
           //{
           //    get { return _TradeChuJinPay; }
           //    set
           //    {
           //        if (_TradeChuJinPay != value)
           //        {
           //            _TradeChuJinPay = value;
           //            RaisePropertyChanged("TradeChuJinPay");
           //        }
           //    }
           //}
           private bool _TradeChuJinDetails;

           /// <summary>
           /// 出金处理--拒绝
           /// </summary>
           public bool TradeChuJinDetails
           {
               get { return _TradeChuJinDetails; }
               set
               {
                   if (_TradeChuJinDetails != value)
                   {
                       _TradeChuJinDetails = value;
                       RaisePropertyChanged("TradeChuJinDetails");
                   }
               }
           }
          private bool _TradeChuJinOrderInfo;

           /// <summary>
           /// 出金处理--订单信息
           /// </summary>
            public bool TradeChuJinOrderInfo
           {
               get { return _TradeChuJinOrderInfo; }
               set
               {
                   if (_TradeChuJinOrderInfo != value)
                   {
                       _TradeChuJinOrderInfo = value;
                       RaisePropertyChanged("TradeChuJinOrderInfo");
                   }
               }
           }
        
          private bool _TradeTermination;

          /// <summary>
          /// 解约处理
          /// </summary>
          public bool TradeTermination
          {
              get { return _TradeTermination; }
              set
              {
                  if (_TradeTermination != value)
                  {
                      _TradeTermination = value;
                      RaisePropertyChanged("TradeTermination");
                  }
              }
          }

          private bool _TradeTerminationApproved;

          /// <summary>
          /// 解约处理--审核解约
          /// </summary>
          public bool TradeTerminationApproved
          {
              get { return _TradeTerminationApproved; }
              set
              {
                  if (_TradeTerminationApproved != value)
                  {
                      _TradeTerminationApproved = value;
                      RaisePropertyChanged("TradeTerminationApproved");
                  }
              }
          }

          private bool _TradeTerminationReject;

          /// <summary>
          /// 解约处理--拒绝解约
          /// </summary>
          public bool TradeTerminationReject
          {
              get { return _TradeTerminationReject; }
              set
              {
                  if (_TradeTerminationReject != value)
                  {
                      _TradeTerminationReject = value;
                      RaisePropertyChanged("TradeTerminationReject");
                  }
              }
          }

          private bool _TradeTerminationOrderInfo;

          /// <summary>
          /// 解约处理--订单信息
          /// </summary>
          public bool TradeTerminationOrderInfo
          {
              get { return _TradeTerminationOrderInfo; }
              set
              {
                  if (_TradeTerminationOrderInfo != value)
                  {
                      _TradeTerminationOrderInfo = value;
                      RaisePropertyChanged("TradeTerminationOrderInfo");
                  }
              }
          }
        
           private bool _AllowFundReport;

        /// <summary>
        /// 资金报表
        /// </summary>
          public bool AllowFundReport
        {
            get { return _AllowFundReport; }
            set
            {
                if (_AllowFundReport != value)
                {
                    _AllowFundReport = value;
                    RaisePropertyChanged("AllowFundReport");
                }
            }
        }

          private bool _AllowFundReportOrderInfo;

          /// <summary>
          /// 资金报表--订单信息
          /// </summary>
          public bool AllowFundReportOrderInfo
          {
              get { return _AllowFundReportOrderInfo; }
              set
              {
                  if (_AllowFundReportOrderInfo != value)
                  {
                      _AllowFundReportOrderInfo = value;
                      RaisePropertyChanged("AllowFundReportOrderInfo");
                  }
              }
          }


          private bool _AllowJujian;
         /// <summary>
         /// 居间
         /// </summary>
          public bool AllowJujian
          {
              get { return _AllowJujian; }
              set
              {
                  _AllowJujian = value;
                  RaisePropertyChanged("AllowJujian");
              }
          }


          private bool _IsCanAlterDJ;
          /// <summary>
          /// 修改冻结资金
          /// </summary>
          public bool IsCanAlterDJ
          {
              get { return _IsCanAlterDJ; }
              set
              {
                  _IsCanAlterDJ = value;
                  RaisePropertyChanged("IsCanAlterDJ");
              }
          }

        
        #endregion

        #region 操作权限
        private bool _OrderTakeReport;
        /// <summary>
        /// 买涨交割单报表
        /// </summary>
        public bool OrderTakeReport
        {
            get { return _OrderTakeReport; }
            set
            {
                _OrderTakeReport = value;
                RaisePropertyChanged("OrderTakeReport");
            }
        }

        private bool _OrderBackReport;
        /// <summary>
        /// 买跌单报表
        /// </summary>
        public bool OrderBackReport
        {
            get { return _OrderBackReport; }
            set
            {
                _OrderBackReport = value;
                RaisePropertyChanged("OrderBackReport");
            }
        }

        private bool _OrderCheckReport;
        /// <summary>
        /// 买跌交割单报表
        /// </summary>
        public bool OrderCheckReport
        {
            get { return _OrderCheckReport; }
            set
            {
                _OrderCheckReport = value;
                RaisePropertyChanged("OrderCheckReport");
            }
        }

        private bool _JgjReport;
        /// <summary>
        /// 转金生金报表
        /// </summary>
        public bool JgjReport
        {
            get { return _JgjReport; }
            set
            {
                _JgjReport = value;
                RaisePropertyChanged("JgjReport");
            }
        }

        private bool _AgentDoDetail;
        /// <summary>
        /// 提货受理报表
        /// </summary>
        public bool AgentDoDetail
        {
            get { return _AgentDoDetail; }
            set
            {
                _AgentDoDetail = value;
                RaisePropertyChanged("AgentDoDetail");
            }
        }



        private bool _CheckManage;
        /// <summary>
        /// 买跌检测
        /// </summary>
        public bool CheckManage
        {
            get { return _CheckManage; }
            set
            {
                _CheckManage = value;
                RaisePropertyChanged("CheckManage");
            }
        }

        private bool _CheckDel;
        /// <summary>
        /// 买跌处理
        /// </summary>
        public bool CheckDel
        {
            get { return _CheckDel; }
            set
            {
                _CheckDel = value;
                RaisePropertyChanged("CheckDel");
            }
        }


        private bool _allowCreateNewAccount;

        /// <summary>
        /// 允许开户
        /// </summary>
        public bool AllowCreateNewAccount
        {
            get { return _allowCreateNewAccount; }
            set
            {
                if (_allowCreateNewAccount != value)
                {
                    _allowCreateNewAccount = value;
                    RaisePropertyChanged("AllowCreateNewAccount");
                }
            }
        }

        private bool _allowViewClientInformation;

        /// <summary>
        /// 查看用户资料
        /// </summary>
        public bool AllowViewClientInformation
        {
            get { return _allowViewClientInformation; }
            set
            {
                if (_allowViewClientInformation != value)
                {
                    _allowViewClientInformation = value;
                    RaisePropertyChanged("AllowViewClientInformation");
                }
            }
        }

        private bool _allowDeleteClient;

        /// <summary>
        /// 删除用户
        /// </summary>
        public bool AllowDeleteClient
        {
            get { return _allowDeleteClient; }
            set
            {
                if (_allowDeleteClient != value)
                {
                    _allowDeleteClient = value;
                    RaisePropertyChanged("AllowDeleteClient");
                }
            }
        }

        private bool _allowViewTradeDetail;

        /// <summary>
        ///查看交易详情
        /// </summary>
        public bool AllowViewTradeDetail
        {
            get { return _allowViewTradeDetail; }
            set
            {
                if (_allowViewTradeDetail != value)
                {
                    _allowViewTradeDetail = value;
                    RaisePropertyChanged("AllowViewTradeDetail");
                }
            }
        }

        private bool _allowCashIO;

        /// <summary>
        /// 出入金
        /// </summary>
        public bool AllowCashIO
        {
            get { return _allowCashIO; }
            set
            {
                if (_allowCashIO != value)
                {
                    _allowCashIO = value;
                    RaisePropertyChanged("AllowCashIO");
                }
            }
        }

        private bool _allowAdjustmentAmount;

        /// <summary>
        ///调整金额
        /// </summary>
        public bool AllowAdjustmentAmount
        {
            get { return _allowAdjustmentAmount; }
            set
            {
                if (_allowAdjustmentAmount != value)
                {
                    _allowAdjustmentAmount = value;
                    RaisePropertyChanged("AllowAdjustmentAmount");
                }
            }
        }

        private bool _allowMarketOrder;

        /// <summary>
        /// 持仓新单
        /// </summary>
        public bool AllowMarketOrder
        {
            get { return _allowMarketOrder; }
            set
            {
                if (_allowMarketOrder != value)
                {
                    _allowMarketOrder = value;
                    RaisePropertyChanged("AllowMarketOrder");
                }
            }
        }

        private bool _allowPendingOrder;

        /// <summary>
        /// 限价挂单
        /// </summary>
        public bool AllowPendingOrder
        {
            get { return _allowPendingOrder; }
            set
            {
                if (_allowPendingOrder != value)
                {
                    _allowPendingOrder = value;
                    RaisePropertyChanged("AllowPendingOrder");
                }
            }
        }

        private bool _allowChargebackOrder;

        /// <summary>
        /// 有效定单平仓
        /// </summary>
        public bool AllowChargebackOrder
        {
            get { return _allowChargebackOrder; }
            set
            {
                if (_allowChargebackOrder != value)
                {
                    _allowChargebackOrder = value;
                    RaisePropertyChanged("AllowChargebackOrder");
                }
            }
        }

        private bool _allowWarehousingOrder;

        /// <summary>
        /// 有效定单入库
        /// </summary>
        public bool AllowWarehousingOrder
        {
            get { return _allowWarehousingOrder; }
            set
            {
                if (_allowWarehousingOrder != value)
                {
                    _allowWarehousingOrder = value;
                    RaisePropertyChanged("AllowWarehousingOrder");
                }
            }
        }

        private bool _allowRevocationOrder;

        /// <summary>
        /// 撤销限价挂单
        /// </summary>
        public bool AllowRevocationOrder
        {
            get { return _allowRevocationOrder; }
            set
            {
                if (_allowRevocationOrder != value)
                {
                    _allowRevocationOrder = value;
                    RaisePropertyChanged("AllowRevocationOrder");
                }
            }
        }

        private bool _marketOrderStatements;

        /// <summary>
        /// 有效定单报表
        /// </summary>
        public bool MarketOrderStatements
        {
            get { return _marketOrderStatements; }
            set
            {
                if (_marketOrderStatements != value)
                {
                    _marketOrderStatements = value;
                    RaisePropertyChanged("MarketOrderStatements");
                }
            }
        }

        private bool _warehousingStatements;

        /// <summary>
        /// 入库单报表
        /// </summary>
        public bool WarehousingStatements
        {
            get { return _warehousingStatements; }
            set
            {
                if (_warehousingStatements != value)
                {
                    _warehousingStatements = value;
                    RaisePropertyChanged("WarehousingStatements");
                }
            }
        }

        private bool _chargebackStatements;

        /// <summary>
        /// 平仓报表
        /// </summary>
        public bool ChargebackStatements
        {
            get { return _chargebackStatements; }
            set
            {
                if (_chargebackStatements != value)
                {
                    _chargebackStatements = value;
                    RaisePropertyChanged("ChargebackStatements");
                }
            }
        }

        private bool _pendingOrderStatements;

        /// <summary>
        ///挂单报表
        /// </summary>
        public bool PendingOrderStatements
        {
            get { return _pendingOrderStatements; }
            set
            {
                if (_pendingOrderStatements != value)
                {
                    _pendingOrderStatements = value;
                    RaisePropertyChanged("PendingOrderStatements");
                }
            }
        }

        private bool _adjustDepositStatements;

        /// <summary>
        /// 资金变动报表
        /// </summary>
        public bool AdjustDepositStatements
        {
            get { return _adjustDepositStatements; }
            set
            {
                if (_adjustDepositStatements != value)
                {
                    _adjustDepositStatements = value;
                    RaisePropertyChanged("AdjustDepositStatements");
                }
            }
        }


     
        #endregion

        #endregion
    }
}
