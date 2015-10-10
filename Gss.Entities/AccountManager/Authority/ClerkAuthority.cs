using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gss.Common.Infrastructure;

namespace Gss.Entities.AccountManager.Authority
{
    /// <summary>
    /// 金商店员管理权限
    /// </summary>
    [Serializable]
    public class ClerkAuthority : ObservableObject
    {
        #region 提货受理权限

        //private bool isCanSelectedAllTiHuoShouLiSub = true;
        ///// <summary>
        ///// 是否能全部选中提货受理所有子级权限(仅用于店员权限设置)
        ///// </summary>
        //public bool IsCanSelectedAllTiHuoShouLiSub
        //{
        //    get { return isCanSelectedAllTiHuoShouLiSub; }
        //    set
        //    {
        //        isCanSelectedAllTiHuoShouLiSub = value;
        //        RaisePropertyChanged("IsCanSelectedAllTiHuoShouLiSub");
        //    }
        //}

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
                if (value.HasValue )
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

        #region 交易管理权限

        //private bool isCanSelcetedAllTrade = true;
        ///// <summary>
        ///// 是否能选中或取消所有交易权限
        ///// </summary>
        //public bool IsCanSelcetedAllTrade
        //{
        //    get { return isCanSelcetedAllTrade; }
        //    set
        //    {
        //        isCanSelcetedAllTrade = value;
        //        RaisePropertyChanged("IsCanSelcetedAllTrade");
        //    }
        //}

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
            bool status1 = JgjOrder || HuiGouOrder || TihuoOrder || DeliverOrder;
            bool status2 = JgjOrder && HuiGouOrder && TihuoOrder && DeliverOrder;

            if (status1 == status2)
                IsTradeManagerEnabled = status1;
            else
                IsTradeManagerEnabled = null;
        }



        /// <summary>
        /// 约束所有子级权限与父级交易管理权限同步
        /// </summary>
        /// <param name="status">父级交易管理权限状态</param>
        public virtual void ConstraintTradeManagerSub(bool status)
        {
            _JgjOrder = _HuiGouOrder = _TihuoOrder = _DeliverOrder = status;
            RaisePropertyChanged("JgjOrder");
            RaisePropertyChanged("HuiGouOrder");
            RaisePropertyChanged("TihuoOrder");
            RaisePropertyChanged("DeliverOrder");
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

        #endregion

        #region 操作权限
        //private bool isCanSelcetedAllOperating = true;
        ///// <summary>
        ///// 是否能选中或取消所有交易权限
        ///// </summary>
        //public bool IsCanSelcetedAllOperating
        //{
        //    get { return isCanSelcetedAllOperating; }
        //    set
        //    {
        //        isCanSelcetedAllOperating = value;
        //        RaisePropertyChanged("IsCanSelcetedAllOperating");
        //    }
        //}

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

        /// <summary>
        /// 约束所有子级权限与父级操作权限同步
        /// </summary>
        /// <param name="status">父级操作权限状态</param>
        public virtual void ConstraintOperatingAuthoritySub(bool status)
        {
            _CheckManage = _CheckDel = status;
            RaisePropertyChanged("CheckManage");
            RaisePropertyChanged("CheckDel");
        }

        /// <summary>
        /// 约束父级操作权限是否可用
        /// </summary>
        public void ConstraintOperatingAuthority()
        {
            bool status1 = CheckManage || CheckDel;
            bool status2 = CheckManage && CheckDel;

            if (status1 == status2)
                OperatingAuthority = status1;
            else
                OperatingAuthority = null;
        }
        #endregion



        internal void SyncClerk(ClerkAuthority authority)
        {
            //TradeManage = authority.TradeManage;
            DeliverOrder = authority.DeliverOrder;
            TihuoOrder = authority.TihuoOrder;
            HuiGouOrder = authority.HuiGouOrder;
            JgjOrder = authority.JgjOrder;
            //TiHuoShouLi = authority.TiHuoShouLi;
            BangDingUser = authority.BangDingUser;
            TiHuo = authority.TiHuo;
            ShouLiMingXi = authority.ShouLiMingXi;
            CheckManage = authority.CheckManage;
            CheckDel = authority.CheckDel;
        }
    }
}
