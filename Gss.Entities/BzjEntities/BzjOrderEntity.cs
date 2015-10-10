using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.BzjEntities
{
    /// <summary>
    /// 定单Model
    /// </summary>
    public class BzjOrderEntity : BaseInfo
    {
        #region 表字段
        private string _AgentId;
        /// <summary>
        /// 受理经商
        /// </summary>
        public string AgentId
        {
            get
            {
                return _AgentId;
            }
            set
            {
                _AgentId = value;
                RaisePropertyChanged("AgentId");
            }
        }

        private string _ClerkId;
        /// <summary>
        /// 金商店员
        /// </summary>
        public string ClerkId
        {
            get
            {
                return _ClerkId;
            }
            set
            {
                _ClerkId = value;
                RaisePropertyChanged("ClerkId");
            }
        }

        private string _TradeAccount;
        /// <summary>
        /// 转入金商库存账号
        /// </summary>
        public string TradeAccount
        {
            get
            {
                return _TradeAccount;
            }
            set
            {
                _TradeAccount = value;
                RaisePropertyChanged("TradeAccount");
            }
        }

        private string _OrderNO;
        /// <summary>
        /// 定单号
        /// </summary>
        public string OrderNO
        {
            get { return _OrderNO; }
            set
            {
                _OrderNO = value;
                RaisePropertyChanged("OrderNO");
            }
        }


        private string _orderCode;
        /// <summary>
        /// 定单 提货或买跌验证码 200000ssffff(没有则为空)
        /// </summary>
        public string OrderCode
        {
            get { return _orderCode; }
            set
            {
                _orderCode = value;
                RaisePropertyChanged("OrderCode");
            }
        }

        private int _orderType;
        /// <summary>
        /// 定单类型 1提货定单 2买跌定单 3 买跌定单 4金生金
        /// </summary>
        public int OrderType
        {
            get { return _orderType; }
            set
            {
                _orderType = value;
                switch (value)
                {
                    case 1:
                        _orderTypeString = "提货订单";
                        break;
                    case 2:
                        _orderTypeString = "买跌订单";
                        break;
                    case 3:
                        _orderTypeString = "买跌订单";
                        break;
                    case 4:
                        _orderTypeString = "金生金";
                        break;
                }
                RaisePropertyChanged("OrderTypeString");
                RaisePropertyChanged("OrderType");
            }
        }

        private String _orderTypeString;
        /// <summary>
        /// 定单类型 
        /// </summary>
        public String OrderTypeString
        {
            get { return _orderTypeString; }
            set
            {
                _orderTypeString = value;
                RaisePropertyChanged("OrderTypeString");
            }
        }



        private int _carryWay;
        /// <summary>
        /// 提货，买跌方式 1在线 2金店提货 3邮寄 4金店买跌 0非提货买跌
        /// </summary>
        public int CarryWay
        {
            get { return _carryWay; }
            set
            {
                _carryWay = value;
                switch (value)
                {
                    case 0:
                        _carryWayString = "非提货买跌";
                        break;
                    case 1:
                        _carryWayString = "在线";
                        break;
                    case 2:
                        _carryWayString = "金店提货";
                        break;
                    case 3:
                        _carryWayString = "邮寄";
                        break;
                    case 4:
                        _carryWayString = "金店买跌";
                        break;
                }
                RaisePropertyChanged("CarryWayString");
                RaisePropertyChanged("CarryWay");
            }
        }

        private String _carryWayString;
        /// <summary>
        /// 提货，买跌方式
        /// </summary>
        public String CarryWayString
        {
            get { return _carryWayString; }
            //set
            //{
            //    _carryWayString = value;
            //    RaisePropertyChanged("CarryWayString");
            ////}
        }

        private string _userId;
        /// <summary>
        /// 用户GUID
        /// </summary>
        public string UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                RaisePropertyChanged("UserId");
            }
        }

        private string _account;
        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account
        {
            get { return _account; }
            set
            {
                _account = value;
                RaisePropertyChanged("Account");
            }
        }

        private string _jUserId;
        /// <summary>
        /// 金生金账户
        /// </summary>
        public string JUserId
        {
            get { return _jUserId; }
            set
            {
                _jUserId = value;
                RaisePropertyChanged("JUserId");
            }
        }

        private decimal _au;
        /// <summary>
        /// 黄金重量
        /// </summary>
        public decimal Au
        {
            get { return _au; }
            set
            {
                _au = value;
                RaisePropertyChanged("Au");
            }
        }

        private decimal _ag;
        /// <summary>
        /// 白银重量
        /// </summary>
        public decimal Ag
        {
            get { return _ag; }
            set
            {
                _ag = value;
                RaisePropertyChanged("Ag");
            }
        }

        private decimal _pt;
        /// <summary>
        /// 铂金重量
        /// </summary>
        public decimal Pt
        {
            get { return _pt; }
            set
            {
                _pt = value;
                RaisePropertyChanged("Pt");
            }
        }

        private decimal _pd;
        /// <summary>
        /// 钯金
        /// </summary>
        public decimal Pd
        {
            get { return _pd; }
            set
            {
                _pd = value;
                RaisePropertyChanged("Pd");
            }
        }

        private string _createDate;
        /// <summary>
        /// 定单创建时间
        /// </summary>
        public string CreateDate
        {
            get { return _createDate; }
            set
            {
                _createDate = value;
                RaisePropertyChanged("CreateDate");
            }
        }

        private string _OperationDate;
        /// <summary>
        /// 提货时间
        /// </summary>
        public string OperationDate
        {
            get { return _OperationDate; }
            set
            {
                _OperationDate = value;
                RaisePropertyChanged("OperationDate");
            }
        }




        private string _endDate;
        /// <summary>
        /// 定单最后处理日期
        /// </summary>
        public string EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                RaisePropertyChanged("EndDate");
            }
        }

        private int _state;
        /// <summary>
        /// 定单状态 1新定单 2交易完成 3取消定单 4过期定单
        /// </summary>
        public int State
        {
            get { return _state; }
            set
            {
                _state = value;
                switch (value)
                {
                    case 1:
                        _stateString = "新订单";
                        break;
                    case 2:
                        _stateString = "交易完成";
                        break;
                    case 3:
                        _stateString = "取消订单";
                        break;
                    case 4:
                        _stateString = "过期订单";
                        break;
                }
                RaisePropertyChanged("StateString");
                RaisePropertyChanged("State");
            }
        }

        private String _stateString;
        /// <summary>
        /// 定单状态 1新定单 2交易完成 3取消定单 4过期定单
        /// </summary>
        public String StateString
        {
            get { return _stateString; }
            //set
            //{
            //    _stateString = value;
            //    RaisePropertyChanged("StateString");
            //}
        }

        ////private int _tmpId;
        /////// <summary>
        /////// 用于生成增ID
        /////// </summary>
        ////public int TmpId
        ////{
        ////    get { return _tmpId; }
        ////    set { _tmpId = value;
        ////    RaisePropertyChanged("OrderNO");
        ////    }
        ////}

        ////private int _version;
        /////// <summary>
        /////// 版本控制
        /////// </summary>
        ////public int Version
        ////{
        ////    get { return _version; }
        ////    set { _version = value;
        ////    RaisePropertyChanged("OrderNO");
        ////    }
        ////}



        private decimal _auQuantity;
        /// <summary>
        /// 黄金开票数量
        /// </summary>
        public decimal AuQuantity
        {
            get { return _auQuantity; }
            set
            {
                _auQuantity = value;
                RaisePropertyChanged("AuQuantity");
            }
        }
        private decimal _agQuantity;
        /// <summary>
        /// 白银开票数量
        /// </summary>
        public decimal AgQuantity
        {
            get { return _agQuantity; }
            set
            {
                _agQuantity = value;
                RaisePropertyChanged("AgQuantity");
            }
        }
        private decimal _ptQuantity;
        /// <summary>
        /// 铂金开票数量
        /// </summary>
        public decimal PtQuantity
        {
            get { return _ptQuantity; }
            set
            {
                _ptQuantity = value;
                RaisePropertyChanged("PtQuantity");
            }
        }
        private decimal _pdQuantity;
        /// <summary>
        /// 钯金开票数量
        /// </summary>
        public decimal PdQuantity
        {
            get { return _pdQuantity; }
            set
            {
                _pdQuantity = value;
                RaisePropertyChanged("PdQuantity");
            }
        }




        private decimal _auP;
        /// <summary>
        /// 黄金平均价
        /// </summary>
        public decimal AuP
        {
            get { return _auP; }
            set
            {
                _auP = value;
                RaisePropertyChanged("AuP");
            }
        }
        private decimal _agP;
        /// <summary>
        /// 白银平均价
        /// </summary>
        public decimal AgP
        {
            get { return _agP; }
            set
            {
                _agP = value;
                RaisePropertyChanged("AgP");
            }
        }
        private decimal _ptP;
        /// <summary>
        /// 铂金平均价
        /// </summary>
        public decimal PtP
        {
            get { return _ptP; }
            set
            {
                _ptP = value;
                RaisePropertyChanged("PtP");
            }
        }
        private decimal _pdP;
        /// <summary>
        /// 钯金平均价
        /// </summary>
        public decimal PdP
        {
            get { return _pdP; }
            set
            {
                _pdP = value;
                RaisePropertyChanged("PdP");
            }
        }

        private decimal _TotalBackPrice;
        /// <summary>
        /// 总买跌款
        /// </summary>
        public decimal TotalBackPrice
        {
            get { return _TotalBackPrice; }
            set
            {
                _TotalBackPrice = value;
                RaisePropertyChanged("TotalBackPrice");
            }
        }


        private decimal _auT;
        /// <summary>
        /// 黄金可开发票总额
        /// </summary>
        public decimal AuT
        {
            get { return _auT; }
            set
            {
                _auT = value;
                RaisePropertyChanged("AuT");
            }
        }
        private decimal _agT;
        /// <summary>
        /// 白银可开发票总额
        /// </summary>
        public decimal AgT
        {
            get { return _agT; }
            set
            {
                _agT = value;
                RaisePropertyChanged("AgT");
            }
        }
        private decimal _pdT;
        /// <summary>
        /// 钯金可开发票总额
        /// </summary>
        public decimal PdT
        {
            get { return _pdT; }
            set
            {
                _pdT = value;
                RaisePropertyChanged("PdT");
            }
        }
        private decimal _ptT;
        /// <summary>
        /// 铂金可开发票总额
        /// </summary>
        public decimal PtT
        {
            get { return _ptT; }
            set
            {
                _ptT = value;
                RaisePropertyChanged("PtT");
            }
        }

        #region 实际提货重量，仅提货时有效
        private decimal _AuK;
        /// <summary>
        /// 黄金实际提货重量，仅提货时有效
        /// </summary>
        public decimal AuK
        {
            get { return _AuK; }
            set
            {
                _AuK = value;
                if (value > Au)
                    throw new ArgumentException(string.Format("您最多可以提货{0}克", Au));
                
                AuQuantity = AuP *value;
                RaisePropertyChanged("AuQuantity");
                RaisePropertyChanged("AuK");
            }
        }
        private decimal _AgK;
        /// <summary>
        /// 白银实际提货重量，仅提货时有效
        /// </summary>
        public decimal AgK
        {
            get { return _AgK; }
            set
            {
                _AgK = value;
                if (value > Ag)
                    throw new ArgumentException(string.Format("您最多可以提货{0}千克", Ag));
                AgQuantity = AgP * value;
                RaisePropertyChanged("AgQuantity");
                RaisePropertyChanged("AgK");
            }
        }
        private decimal _PtK;
        /// <summary>
        /// 铂金实际提货重量，仅提货时有效
        /// </summary>
        public decimal PtK
        {
            get { return _PtK; }
            set
            {
                _PtK = value;
                if (value > Pt)
                    throw new ArgumentException(string.Format("您最多可以提货{0}克", Pt));
                PtQuantity = PtP * value;
                RaisePropertyChanged("PtQuantity");
                RaisePropertyChanged("PtK");
            }
        }
        private decimal _PdK;
        /// <summary>
        /// 钯金实际提货重量，仅提货时有效
        /// </summary>
        public decimal PdK
        {
            get { return _PdK; }
            set
            {
                _PdK = value;
                if (value > Pd)
                    throw new ArgumentException(string.Format("您最多可以提货{0}克", Pd));
                if (value > Pd)
                    throw new ArgumentException(string.Format("您最多可以提货{0}克",Pd));
                PdQuantity = PdP * value;
                RaisePropertyChanged("PdQuantity");
                RaisePropertyChanged("PdK");
            }
        } 
        #endregion

        #endregion

        #region 外键字段  定单附属信息

        private int _UserType;
        /// <summary>
        /// 用户提货买跌类型 1本人 2他人代提(或用户类型 个人、会员)
        /// </summary>
        public int UserType
        {
            get { return _UserType; }
            set
            {
                _UserType = value;
                RaisePropertyChanged("UserType");
            }
        }

        private string _Name;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }

        private string _Phone;
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone
        {
            get { return _Phone; }
            set
            {
                _Phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        private string _CardType;
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CardType
        {
            get { return _CardType; }
            set
            {
                _CardType = value;
                RaisePropertyChanged("CardType");
            }
        }

        private string _CardNum;
        /// <summary>
        /// 身份证号
        /// </summary>
        public string CardNum
        {
            get { return _CardNum; }
            set
            {
                _CardNum = value;
                RaisePropertyChanged("CardNum");
            }
        }

        private string _PhoneNum;
        /// <summary>
        /// 电话号码
        /// </summary>
        public string PhoneNum
        {
            get { return _PhoneNum; }
            set
            {
                _PhoneNum = value;
                RaisePropertyChanged("PhoneNum");
            }
        }

        private string _IDNo;
        /// <summary>
        /// 证件号
        /// </summary>
        public string IDNo
        {
            get { return _IDNo; }
            set
            {
                _IDNo = value;
                RaisePropertyChanged("IDNo");
            }
        }

        private int _IDType;
        /// <summary>
        /// 证件类型
        /// </summary>
        public int IDType
        {
            get { return _IDType; }
            set
            {
                _IDType = value;
                RaisePropertyChanged("CeritificateEnum");
            }
        }



        private string _Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set
            {
                _Remark = value;
                RaisePropertyChanged("Remark");
            }
        }

        #endregion

        #region 外键字段 定单买跌价信息

        private decimal _Au_b;
        /// <summary>
        /// 黄金买跌价
        /// </summary>
        public decimal Au_b
        {
            get { return _Au_b; }
            set
            {
                _Au_b = value;
                RaisePropertyChanged("Au_b");
            }
        }

        private decimal _Ag_b;
        /// <summary>
        /// 白银买跌价
        /// </summary>
        public decimal Ag_b
        {
            get { return _Ag_b; }
            set
            {
                _Ag_b = value;
                RaisePropertyChanged("Ag_b");
            }
        }

        private decimal _Pt_b;
        /// <summary>
        /// 铂金买跌价
        /// </summary>
        public decimal Pt_b
        {
            get { return _Pt_b; }
            set
            {
                _Pt_b = value;
                RaisePropertyChanged("Pt_b");
            }
        }

        private decimal _Pd_b;
        /// <summary>
        /// 钯金买跌价
        /// </summary>
        public decimal Pd_b
        {
            get { return _Pd_b; }
            set
            {
                _Pd_b = value;
                RaisePropertyChanged("Pd_b");
            }
        }


        private decimal _AuCost;
        /// <summary>
        /// 黄金成本价
        /// </summary>
        public decimal AuCost
        {
            get { return _AuCost; }
            set
            {
                _AuCost = value;
                RaisePropertyChanged("AuCost");
            }
        }

        private decimal _AgCost;
        /// <summary>
        /// 白银成本价
        /// </summary>
        public decimal AgCost
        {
            get { return _AgCost; }
            set
            {
                _Ag_b = value;
                RaisePropertyChanged("AgCost");
            }
        }

        private decimal _PtCost;
        /// <summary>
        /// 铂金成本价
        /// </summary>
        public decimal PtCost
        {
            get { return _PtCost; }
            set
            {
                _Pt_b = value;
                RaisePropertyChanged("PtCost");
            }
        }

        private decimal _PdCost;
        /// <summary>
        /// 钯金成本价
        /// </summary>
        public decimal PdCost
        {
            get { return _PdCost; }
            set
            {
                _Pd_b = value;
                RaisePropertyChanged("PdCost");
            }
        }
        #endregion

        #region 外键字段 定单用户信息

        private string _AgentName;
        /// <summary>
        /// 代理商名称
        /// </summary>
        public string AgentName
        {
            get { return _AgentName; }
            set
            {
                _AgentName = value;
                RaisePropertyChanged("Remark");
            }
        }

        #endregion
    }
}
