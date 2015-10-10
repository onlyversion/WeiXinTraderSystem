//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Gss.Entities.BzjEntities
//{
//    /// <summary>
//    /// 功能：金商店员权限
//    /// 创建人：
//    /// 创建时间：
//    /// </summary>
//    /// </summary>
//    public class BzjClerkAuth:BaseInfo
//    {
//        private bool _ShouLiMingXi;
//        /// <summary>
//        /// Gets or sets a value indicating whether 受理明细
//        /// </summary>
//        public bool ShouLiMingXi
//        {
//            get { return _ShouLiMingXi; }
//            set
//            {
//                _ShouLiMingXi = value;
//                RaisePropertyChanged("ShouLiMingXi");
//            }
//        }

//        private bool _TiHuo;
//        /// <summary>
//        /// Gets or sets a value indicating whether 提货
//        /// </summary>
//        public bool TiHuo
//        {
//            get { return _TiHuo; }
//            set
//            {
//                _TiHuo = value;
//                RaisePropertyChanged("TiHuo");
//            }
//        }

//        private bool _BangDingUser;
//        /// <summary>
//        /// Gets or sets a value indicating whether 绑定账号
//        /// </summary>
//        public bool BangDingUser
//        {
//            get { return _BangDingUser; }
//            set
//            {
//                _BangDingUser = value;
//                RaisePropertyChanged("BangDingUser");
//            }
//        }

//        private bool _TradeManage;
//        /// <summary>
//        /// Gets or sets a value indicating whether 交易管理
//        /// </summary>
//        public bool TradeManage
//        {
//            get { return _TradeManage; }
//            set
//            {
//                _TradeManage = value;
//                RaisePropertyChanged("TradeManage");
//            }
//        }

//        private bool _TiHuoShouLi;
//        /// <summary>
//        /// Gets or sets a value indicating whether 提货受理
//        /// </summary>
//        public bool TiHuoShouLi
//        {
//            get { return _TiHuoShouLi; }
//            set
//            {
//                _TiHuoShouLi = value;
//                RaisePropertyChanged("TiHuoShouLi");
//            }
//        }

//        private bool _JgjOrder;
//        /// <summary>
//        /// Gets or sets a value indicating whether 金商金单
//        /// </summary>
//        public bool JgjOrder
//        {
//            get { return _JgjOrder; }
//            set
//            {
//                _JgjOrder = value;
//                RaisePropertyChanged("JgjOrder");
//            }
//        }

//        private bool _HuiGouOrder;
//        /// <summary>
//        /// Gets or sets a value indicating whether 买跌单
//        /// </summary>
//        public bool HuiGouOrder
//        {
//            get { return _HuiGouOrder; }
//            set
//            {
//                _HuiGouOrder = value;
//                RaisePropertyChanged("HuiGouOrder");
//            }
//        }

//        private bool _TihuoOrder;
//        /// <summary>
//        /// Gets or sets a value indicating whether 提货单
//        /// </summary>
//        public bool TihuoOrder
//        {
//            get { return _TihuoOrder; }
//            set
//            {
//                _TihuoOrder = value;
//                RaisePropertyChanged("TihuoOrder");
//            }
//        }

//        private bool _DeliverOrder;
//        /// <summary>
//        /// Gets or sets a value indicating whether 交割单
//        /// </summary>
//        public bool DeliverOrder
//        {
//            get { return _DeliverOrder; }
//            set
//            {
//                _DeliverOrder = value;
//                RaisePropertyChanged("DeliverOrder");
//            }
//        }

//        private bool _CheckManage;
//        /// <summary>
//        /// 买跌检测
//        /// </summary>
//        public bool CheckManage
//        {
//            get { return _CheckManage; }
//            set
//            {
//                _CheckManage = value;
//                RaisePropertyChanged("CheckManage");
//            }
//        }

//        private bool _CheckDel;
//        /// <summary>
//        /// 买跌处理
//        /// </summary>
//        public bool CheckDel
//        {
//            get { return _CheckDel; }
//            set
//            {
//                _CheckDel = value;
//                RaisePropertyChanged("CheckDel");
//            }
//        }

//        private bool _AgentClerk;
//        /// <summary>
//        /// 金商店员
//        /// </summary>
//        public bool AgentClerk
//        {
//            get { return _AgentClerk; }
//            set
//            {
//                _AgentClerk = value;
//                RaisePropertyChanged("AgentClerk");
//            }
//        }
//    }
//}
