using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gss.Common.Infrastructure;
using Gss.Entities.AccountManager.Authority;

namespace Gss.Entities
{
    /// <summary>
    /// 金商权限类
    /// </summary>
    [Serializable]
    public class DealerAuthority : ObservableObject
    {
        #region 属性
        #region 提货受理权限

        private bool _ShouLiMingXi;
        /// <summary>
        /// Gets or sets a value indicating whether 受理明细
        /// </summary>
        public bool ShouLiMingXi
        {
            get { return _ShouLiMingXi; }
            set
            {
                _ShouLiMingXi = value;
                RaisePropertyChanged("ShouLiMingXi");
                ConstraintTiHuoShouLi();
            }
        }

        private bool _TiHuo;
        /// <summary>
        /// Gets or sets a value indicating whether 提货
        /// </summary>
        public bool TiHuo
        {
            get { return _TiHuo; }
            set
            {
                _TiHuo = value;
                RaisePropertyChanged("TiHuo");
                ConstraintTiHuoShouLi();
            }
        }

        private bool _BangDingUser;
        /// <summary>
        /// Gets or sets a value indicating whether 绑定账号
        /// </summary>
        public bool BangDingUser
        {
            get { return _BangDingUser; }
            set
            {
                _BangDingUser = value;
                RaisePropertyChanged("BangDingUser");
                ConstraintTiHuoShouLi();
            }
        }



        private bool? _TiHuoShouLi;
        /// <summary>
        /// Gets or sets a value indicating whether 提货受理 （父级）
        /// </summary>
        public bool? TiHuoShouLi
        {
            get { return _TiHuoShouLi; }
            set
            {
                _TiHuoShouLi = value;
                RaisePropertyChanged("TiHuoShouLi");
                if (value.HasValue)
                    ConstraintTiHuoShouLiSub(value.Value);
            }
        }

        /// <summary>
        /// 约束所有子级管理权限与父级账户管理的权限同步
        /// </summary>
        /// <param name="status">父级提货受理权限状态</param>
        protected virtual void ConstraintTiHuoShouLiSub(bool status)
        {
            _ShouLiMingXi = _TiHuo = _BangDingUser = status;
            RaisePropertyChanged("ShouLiMingXi");
            RaisePropertyChanged("TiHuo");
            RaisePropertyChanged("BangDingUser");
        }

        /// <summary>
        /// 约束父级客户账户管理的权限
        /// </summary>
        protected virtual void ConstraintTiHuoShouLi()
        {
            //当2个子级管理权限都禁用时，将账号管理权限禁用
            bool status1 = ShouLiMingXi || TiHuo || BangDingUser;
            bool status2 = ShouLiMingXi && TiHuo && BangDingUser;
            if (status1 == status2)
                TiHuoShouLi = status1;
            else
                TiHuoShouLi = null;
        }
        #endregion

        #region 管理权限

        private bool _accMgrReadOnly;

        /// <summary>
        /// 获取或设置是否是只读方式（该属性对管理员权限无效）
        /// </summary>
        public bool AccMgrReadonly
        {
            get { return _accMgrReadOnly; }
            set
            {
                _accMgrReadOnly = value;
                RaisePropertyChanged("AccMgrReadonly");
            }
        }

        private bool? _accountManager;

        /// <summary>
        /// 获取或设置是否启用账号管理权限（父级）
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

                    if (value.HasValue)
                        ConstraintAccountManagerSub(value.Value);
                }
            }
        }

        private bool _clientAccountManager;

        /// <summary>
        /// 获取或设置是否启用客户账号管理权限
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

                    ConstraintAccountManager();
                }
            }
        }

        private bool _dealerAccountManager;

        /// <summary>
        /// 获取或设置是否启用金商账号管理权限
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

                    ConstraintAccountManager();
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
                ConstraintAccountManager();
            }
        }

        /// <summary>
        /// 约束父级客户账户管理的权限
        /// </summary>
        protected virtual void ConstraintAccountManager()
        {
            //当2个子级管理权限都禁用时，将账号管理权限禁用
            bool status1 = ClientAccountManager || DealerAccountManager || AgentClerk;
            bool status2 = ClientAccountManager && DealerAccountManager && AgentClerk;
            if (status1 == status2)
                AccountManager = status1;
            else
                AccountManager = null;
        }

        /// <summary>
        /// 约束所有子级管理权限与父级账户管理的权限同步
        /// </summary>
        /// <param name="status">父级账户管理权限状态</param>
        protected virtual void ConstraintAccountManagerSub(bool status)
        {
            _clientAccountManager = _dealerAccountManager =_AgentClerk= status;
            RaisePropertyChanged("ClientAccountManager");
            RaisePropertyChanged("DealerAccountManager");
            RaisePropertyChanged("AgentClerk");
        }

        #endregion

        #region 操作权限
        private bool? _operatingAuthority;

        /// <summary>
        /// 获取或设置操作权限（父级）
        /// </summary>
        public bool? OperatingAuthority
        {
            get { return _operatingAuthority; }
            set
            {
                if (_operatingAuthority != value)
                {
                    _operatingAuthority = value;
                    RaisePropertyChanged("OperatingAuthority");

                    if (value.HasValue)
                        ConstraintOperatingAuthoritySub(value.Value);
                }
            }
        }
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
                ConstraintOperatingAuthority();
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
                ConstraintOperatingAuthority();
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
                ConstraintOperatingAuthority();
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
                ConstraintOperatingAuthority();
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
                ConstraintOperatingAuthority();
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
                ConstraintOperatingAuthority();
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
                ConstraintOperatingAuthority();
            }
        }

        ///// <summary>
        ///// 约束所有子级权限与父级操作权限同步
        ///// </summary>
        ///// <param name="status">父级操作权限状态</param>
        //public virtual void ConstraintOperatingAuthoritySub(bool status)
        //{
           
        //}

        ///// <summary>
        ///// 约束父级操作权限是否可用
        ///// </summary>
        //public void ConstraintOperatingAuthority()
        //{
        //    bool status1 = CheckManage || CheckDel;
        //    bool status2 = CheckManage && CheckDel;

        //    if (status1 == status2)
        //        OperatingAuthority = status1;
        //    else
        //        OperatingAuthority = null;
        //}
      

        private bool _allowCreateNewAccount;

        /// <summary>
        /// 获取或设置是否允许开户
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

                    ConstraintOperatingAuthority();
                }
            }
        }

        private bool _allowViewClientInformation;

        /// <summary>
        /// 获取或设置是否允许查看用户资料
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

                    ConstraintOperatingAuthority();
                }
            }
        }

        private bool _allowDeleteClient;

        /// <summary>
        /// 获取或设置是否允许删除用户
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

                    ConstraintOperatingAuthority();
                }
            }
        }

        private bool _allowViewTradeDetail;

        /// <summary>
        /// 获取或设置是否允许查看交易详情
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

                    ConstraintOperatingAuthority();
                }
            }
        }

        private bool _allowCashIO;

        /// <summary>
        /// 获取或设置是否允许出入金
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

                    ConstraintOperatingAuthority();
                }
            }
        }

        private bool _allowAdjustmentAmount;

        /// <summary>
        /// 获取或设置是否允许调整金额
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

                    ConstraintOperatingAuthority();
                }
            }
        }

        private bool _allowMarketOrder;

        /// <summary>
        /// 获取或设置是否允许持仓新单
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

                    ConstraintOperatingAuthority();
                }
            }
        }

        private bool _allowPendingOrder;

        /// <summary>
        /// 获取或设置是否允许限价挂单
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

                    ConstraintOperatingAuthority();
                }
            }
        }

        private bool _allowChargebackOrder;

        /// <summary>
        /// 获取或设置是否允许有效定单平仓
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

                    ConstraintOperatingAuthority();
                }
            }
        }

        private bool _allowWarehousingOrder;

        /// <summary>
        /// 获取或设置是否允许有效定单入库
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

                    ConstraintOperatingAuthority();
                }
            }
        }

        private bool _allowRevocationOrder;

        /// <summary>
        /// 获取或设置是否允许撤销限价挂单
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

                    ConstraintOperatingAuthority();
                }
            }
        }

        private bool _marketOrderStatements;

        /// <summary>
        /// 获取或设置是否允许查看有效定单报表
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

                    ConstraintOperatingAuthority();
                }
            }
        }

        private bool _warehousingStatements;

        /// <summary>
        /// 获取或设置是否允许查看入库单报表
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

                    ConstraintOperatingAuthority();
                }
            }
        }

        private bool _chargebackStatements;

        /// <summary>
        /// 获取或设置是否允许查看平仓报表
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

                    ConstraintOperatingAuthority();
                }
            }
        }

        private bool _pendingOrderStatements;

        /// <summary>
        /// 获取或设置是否允许查看挂单报表
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

                    ConstraintOperatingAuthority();
                }
            }
        }

        private bool _adjustDepositStatements;

        /// <summary>
        /// 获取或设置是否允许查看资金变动报表
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

                    ConstraintOperatingAuthority();
                }
            }
        }


        /// <summary>
        /// 约束所有子级权限与父级操作权限同步
        /// </summary>
        /// <param name="status">父级操作权限状态</param>
        public  void ConstraintOperatingAuthoritySub(bool status)
        {

            _CheckManage = _CheckDel = status;
            RaisePropertyChanged("CheckManage");
            RaisePropertyChanged("CheckDel");

            _allowCreateNewAccount = _allowDeleteClient = _allowViewClientInformation = _allowViewTradeDetail = _allowAdjustmentAmount = _allowCashIO = status;
            RaisePropertyChanged("AllowCreateNewAccount");
            RaisePropertyChanged("AllowDeleteClient");
            RaisePropertyChanged("AllowViewClientInformation");
            RaisePropertyChanged("AllowViewTradeDetail");
            RaisePropertyChanged("AllowAdjustmentAmount");
            RaisePropertyChanged("AllowCashIO");

            _allowMarketOrder = _allowPendingOrder = _allowChargebackOrder = _allowWarehousingOrder = _allowRevocationOrder = status;
            RaisePropertyChanged("AllowMarketOrder");
            RaisePropertyChanged("AllowPendingOrder");
            RaisePropertyChanged("AllowChargebackOrder");
            RaisePropertyChanged("AllowWarehousingOrder");
            RaisePropertyChanged("AllowRevocationOrder");

            _marketOrderStatements = _warehousingStatements = _chargebackStatements = _pendingOrderStatements = _adjustDepositStatements = status;
            RaisePropertyChanged("MarketOrderStatements");
            RaisePropertyChanged("WarehousingStatements");
            RaisePropertyChanged("ChargebackStatements");
            RaisePropertyChanged("PendingOrderStatements");
            RaisePropertyChanged("AdjustDepositStatements");
        }

        /// <summary>
        /// 约束父级操作权限是否可用
        /// </summary>
        public   void ConstraintOperatingAuthority()
        {
            bool status1 = AllowCreateNewAccount || AllowDeleteClient || AllowViewClientInformation || AllowViewTradeDetail || AllowAdjustmentAmount || AllowCashIO ||
                AllowMarketOrder || AllowPendingOrder || AllowChargebackOrder || AllowWarehousingOrder || AllowRevocationOrder ||
                MarketOrderStatements || WarehousingStatements || ChargebackStatements || PendingOrderStatements || AdjustDepositStatements 
                || CheckManage || CheckDel||
                OrderTakeReport || OrderBackReport || OrderCheckReport ||JgjReport || AgentDoDetail ;


            bool status2 = AllowCreateNewAccount && AllowDeleteClient && AllowViewClientInformation &&
                           AllowViewTradeDetail && AllowAdjustmentAmount && AllowCashIO &&
                           AllowMarketOrder && AllowPendingOrder && AllowChargebackOrder && AllowWarehousingOrder &&
                           AllowRevocationOrder &&
                           MarketOrderStatements && WarehousingStatements && ChargebackStatements &&
                           PendingOrderStatements && AdjustDepositStatements
                           && CheckManage && CheckDel &&
                           OrderTakeReport && OrderBackReport &&
                           OrderCheckReport && JgjReport &&AgentDoDetail;


            if (status1 == status2)
                OperatingAuthority = status1;
            else
                OperatingAuthority = null;
        }

        #endregion

        #region 交易管理
        private bool? _isTradeManagerEnabled;

        /// <summary>
        /// 获取或设置是否允许交易（父级）
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

                    if (value.HasValue)
                        ConstraintTradeManagerSub(value.Value);
                }
            }
        }
      

        /// <summary>
        /// 约束父级交易管理权限是否启用
        /// </summary>
        private void ConstraintIsTradeManagerEnabled()
        {
            //当所有子级都禁用时，将交易管理权限禁用
            bool status1 = AllowViewMarketOrder || AllowViewPendingOrder || AllowViewWarehousing || AllowViewChargebackRecord
                || AllowViewHedgingTransactions || AllowExportStatement || JgjOrder || HuiGouOrder || TihuoOrder || DeliverOrder;
            bool status2 = AllowViewMarketOrder && AllowViewPendingOrder && AllowViewWarehousing && AllowViewChargebackRecord
                && AllowViewHedgingTransactions && AllowExportStatement && JgjOrder && HuiGouOrder && TihuoOrder && DeliverOrder;

            if (status1 == status2)
                IsTradeManagerEnabled = status1;
            else
                IsTradeManagerEnabled = null;
        }

       
        private bool _JgjOrder;
        /// <summary>
        /// Gets or sets a value indicating whether 金生金单
        /// </summary>
        public bool JgjOrder
        {
            get { return _JgjOrder; }
            set
            {
                _JgjOrder = value;
                RaisePropertyChanged("JgjOrder");
                ConstraintIsTradeManagerEnabled();
            }
        }

        private bool _HuiGouOrder;
        /// <summary>
        /// Gets or sets a value indicating whether 买跌单
        /// </summary>
        public bool HuiGouOrder
        {
            get { return _HuiGouOrder; }
            set
            {
                _HuiGouOrder = value;
                RaisePropertyChanged("HuiGouOrder");
                ConstraintIsTradeManagerEnabled();
            }
        }

        private bool _TihuoOrder;
        /// <summary>
        /// Gets or sets a value indicating whether 提货单
        /// </summary>
        public bool TihuoOrder
        {
            get { return _TihuoOrder; }
            set
            {
                _TihuoOrder = value;
                RaisePropertyChanged("TihuoOrder");
                ConstraintIsTradeManagerEnabled();
            }
        }

        private bool _DeliverOrder;
        /// <summary>
        /// Gets or sets a value indicating whether 交割单
        /// </summary>
        public bool DeliverOrder
        {
            get { return _DeliverOrder; }
            set
            {
                _DeliverOrder = value;
                RaisePropertyChanged("DeliverOrder");
                ConstraintIsTradeManagerEnabled();
            }
        }
   

        private bool _allowViewMarketOrder;

        /// <summary>
        /// 获取或设置是否允许查看市价定单（有效单）
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

                    ConstraintIsTradeManagerEnabled();
                }
            }
        }

        private bool _allowViewPendingOrder;

        /// <summary>
        /// 获取或设置是否允许查看限价定单
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

                    ConstraintIsTradeManagerEnabled();
                }
            }
        }

        private bool _allowViewChargebackRecord;

        /// <summary>
        /// 获取或设置是否允许查看平仓历史
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

                    ConstraintIsTradeManagerEnabled();
                }
            }
        }

        private bool _allowViewWarehousing;

        /// <summary>
        /// 获取或设置是否允许查看入库单
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

                    ConstraintIsTradeManagerEnabled();
                }
            }
        }

        private bool _allowViewHedgingTransactions;

        /// <summary>
        /// 获取或设置是否允许对冲交易
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

                    ConstraintIsTradeManagerEnabled();
                }
            }
        }

        private bool _allowExportStatement;

        /// <summary>
        /// 获取或设置是否允许导出报表
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

                    ConstraintIsTradeManagerEnabled();
                }
            }
        }

        private bool _IsCanAlterDongJieMoney;
        /// <summary>
        /// 是否可以修改冻结资金
        /// </summary>
        public bool IsCanAlterDongJieMoney
        {
            get { return _IsCanAlterDongJieMoney; }
            set { _IsCanAlterDongJieMoney = value; }
        }



        /// <summary>
        /// 约束所有子级权限与父级交易管理权限同步
        /// </summary>
        /// <param name="status">父级交易管理权限状态</param>
        public  void ConstraintTradeManagerSub(bool status)
        {
            //base.ConstraintTradeManagerSub(status);
            _JgjOrder = _HuiGouOrder = _TihuoOrder = _DeliverOrder = status;
           
            _allowViewMarketOrder = _allowViewPendingOrder = _allowViewWarehousing = _allowViewChargebackRecord 
                = _allowViewHedgingTransactions = _allowExportStatement = status;
            RaisePropertyChanged("AllowViewMarketOrder");
            RaisePropertyChanged("AllowViewPendingOrder");
            RaisePropertyChanged("AllowViewWarehousing");
            RaisePropertyChanged("AllowViewChargebackRecord");
            RaisePropertyChanged("AllowViewHedgingTransactions");
            RaisePropertyChanged("AllowExportStatement");
            RaisePropertyChanged("JgjOrder");
            RaisePropertyChanged("HuiGouOrder");
            RaisePropertyChanged("TihuoOrder");
            RaisePropertyChanged("DeliverOrder");
        }

        #endregion

        #endregion

        #region 构造函数

        /// <summary>
        /// 实例化一个包含默认值的金商权限类
        /// </summary>
        public DealerAuthority()
        {
            AccMgrReadonly = false;
            AccountManager = false;
            OperatingAuthority = false;
            IsTradeManagerEnabled = false;
        }

        #endregion

        #region 数据同步


        /// <summary>
        /// 同步金商权限数据
        /// </summary>
        /// <param name="dealerAuthority">同步数据源</param>
        internal void Sync(DealerAuthority dealerAuthority)
        {
            AccMgrReadonly = dealerAuthority.AccMgrReadonly;

            //同步管理权限
            if (dealerAuthority.AccountManager.HasValue)
                AccountManager = dealerAuthority.AccountManager;
            else
            {
                ClientAccountManager = dealerAuthority.ClientAccountManager;
                DealerAccountManager = dealerAuthority.DealerAccountManager;
            }

            //同步操作权限
            if (dealerAuthority.OperatingAuthority.HasValue)
                OperatingAuthority = dealerAuthority.OperatingAuthority;
            else
            {
                AllowCreateNewAccount = dealerAuthority.AllowCreateNewAccount;
                AllowDeleteClient = dealerAuthority.AllowDeleteClient;
                AllowViewClientInformation = dealerAuthority.AllowViewClientInformation;
                AllowViewTradeDetail = dealerAuthority.AllowViewTradeDetail;
                AllowCashIO = dealerAuthority.AllowCashIO;
                AllowAdjustmentAmount = dealerAuthority.AllowAdjustmentAmount;

                AllowMarketOrder = dealerAuthority.AllowMarketOrder;
                AllowChargebackOrder = dealerAuthority.AllowChargebackOrder;
                AllowWarehousingOrder = dealerAuthority.AllowWarehousingOrder;
                AllowPendingOrder = dealerAuthority.AllowPendingOrder;
                AllowRevocationOrder = dealerAuthority.AllowRevocationOrder;

                MarketOrderStatements = dealerAuthority.MarketOrderStatements;
                WarehousingStatements = dealerAuthority.WarehousingStatements;
                ChargebackStatements = dealerAuthority.ChargebackStatements;
                PendingOrderStatements = dealerAuthority.PendingOrderStatements;
                AdjustDepositStatements = dealerAuthority.AdjustDepositStatements;
            }

            //同步交易管理权限
            if (dealerAuthority.IsTradeManagerEnabled.HasValue)
                IsTradeManagerEnabled = dealerAuthority.IsTradeManagerEnabled;
            else
            {
                AllowViewMarketOrder = dealerAuthority.AllowViewMarketOrder;
                AllowMarketOrder = dealerAuthority.AllowMarketOrder;
                AllowViewPendingOrder = dealerAuthority.AllowViewPendingOrder;
                AllowViewChargebackRecord = dealerAuthority.AllowViewChargebackRecord;
                AllowViewHedgingTransactions = dealerAuthority.AllowViewHedgingTransactions;
                AllowViewWarehousing = dealerAuthority.AllowViewWarehousing;
                AllowExportStatement = dealerAuthority.AllowExportStatement;
            }


            //店员权限
            //TradeManage = dealerAuthority.TradeManage;
            DeliverOrder = dealerAuthority.DeliverOrder;
            TihuoOrder = dealerAuthority.TihuoOrder;
            HuiGouOrder = dealerAuthority.HuiGouOrder;
            JgjOrder = dealerAuthority.JgjOrder;
            //TiHuoShouLi = dealerAuthority.TiHuoShouLi;
            BangDingUser = dealerAuthority.BangDingUser;
            TiHuo = dealerAuthority.TiHuo;
            ShouLiMingXi = dealerAuthority.ShouLiMingXi;
            CheckManage = dealerAuthority.CheckManage;
            CheckDel = dealerAuthority.CheckDel;
            AgentClerk = dealerAuthority.AgentClerk;

            OrderTakeReport = dealerAuthority.OrderTakeReport;
            OrderBackReport = dealerAuthority.OrderBackReport;
            OrderCheckReport = dealerAuthority.OrderCheckReport;
            JgjReport = dealerAuthority.JgjReport;
            AgentDoDetail = dealerAuthority.AgentDoDetail;

        }

        #endregion
    }
}
