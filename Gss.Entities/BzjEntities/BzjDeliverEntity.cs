using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.BzjEntities
{
    /// <summary>
    /// 交割单Model
    /// </summary>
    public class BzjDeliverEntity : BaseInfo
    {
        #region 表字段

        private string _deliverId;
        /// <summary>
        /// 交割单GUID
        /// </summary>
        public string DeliverId
        {
            get { return _deliverId; }
            set
            {
                _deliverId = value;
                RaisePropertyChanged("DeliverId");
            }
        }

        private string _deliverNo;
        /// <summary>
        /// 交割单号
        /// </summary>
        public string DeliverNo
        {
            get { return _deliverNo; }
            set
            {
                _deliverNo = value;
                RaisePropertyChanged("DeliverNo");
            }
        }

        private string _account;
        /// <summary>
        /// 用户账号(软件同步过来的)
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

        private int _goods;
        /// <summary>
        /// 交割物品 黄金 = 1, 白银 = 2, 铂金 = 3, 钯金 = 4
        /// </summary>
        public int Goods
        {
            get { return _goods; }
            set
            {
                _goods = value;
                switch (_goods)
                {
                    case 1:
                        _GoodsString = "黄金";
                        break;
                    case 2:
                        _GoodsString = "白银";
                        break;
                    case 3:
                        _GoodsString = "铂金";
                        break;
                    case 4:
                        _GoodsString = "钯金";
                        break;
                }
                if (GoodsString.Contains("白银"))
                    _totalString = Total + "千克";
                else
                    _totalString = Total + "克";

                if (GoodsString.Contains("白银"))
                    _availableTotalString = _availableTotal + "千克";
                else
                    _availableTotalString = _availableTotal + "克";
                RaisePropertyChanged("GoodsString");
                RaisePropertyChanged("Goods");
                RaisePropertyChanged("TotalString");
                RaisePropertyChanged("AvailableTotalString");
            }
        }

        private string _GoodsString;
        /// <summary>
        /// 交割物品
        /// </summary>
        public string GoodsString
        {
            get { return _GoodsString; }
        }

        private int _direction;
        /// <summary>
        /// 交割的方向提货单 = 1, 买跌单 = 2,买跌单 = 3, 金生金 = 4,到期定单 = 5已生金定单 = 6, 提成定单 = 7, 库存调整=13

        /// </summary>
        public int Direction
        {
            get { return _direction; }
            set
            {
                _direction = value;
                switch (_direction)
                {
                    case 1:
                        _DirectionString = "提货单";
                        break;
                    case 2:
                        _DirectionString = "买跌单";
                        break;
                    case 3:
                        _DirectionString = "买跌单";
                        break;
                    case 4:
                        _DirectionString = "金生金";
                        break;
                    case 5:
                        _DirectionString = "到期订单";
                        break;
                    case 6:
                        _DirectionString = "已生金订单";
                        break;
                    case 7:
                        _DirectionString = "提成订单";
                        break;
                         case 8:
                        _DirectionString = "金店库存同步";
                        break;
                    case 9:
                        _DirectionString = "实物受理";
                        break;
                        case 10:
                        _DirectionString = "金商转库";
                        break;
                        case 11:
                        _DirectionString = "公司提成";
                        break;
                        case 12:
                        _DirectionString = "大区提成";
                        break;
                    case 13:
                        _DirectionString = "库存调整";
                        break;
                        break;
                }
                RaisePropertyChanged("DirectionString");
                RaisePropertyChanged("Direction");
            }
        }

        private string _DirectionString;
        /// <summary>
        /// 交割的方向
        /// </summary>
        public string DirectionString
        {
            get { return _DirectionString; }
        }



        private decimal _total;
        /// <summary>
        /// 交割总重量
        /// </summary>
        public decimal Total
        {
            get { return _total; }
            set
            {
                _total = value;
                RaisePropertyChanged("Total");
                RaisePropertyChanged("TotalString");
            }
        }

        private string _totalString;
        /// <summary>
        /// 交割总重量
        /// </summary>
        public string TotalString
        {
            get { return _totalString; }
            set
            {
                _totalString = value;
                
                RaisePropertyChanged("TotalString");
            }
        }

        private string _deliverDate;
        /// <summary>
        /// 交割日期
        /// </summary>
        public string DeliverDate
        {
            get { return _deliverDate; }
            set
            {
                _deliverDate = value;
                RaisePropertyChanged("DeliverDate");
            }
        }

        private decimal _lockPrice;
        /// <summary>
        /// 锁定价格
        /// </summary>
        public decimal LockPrice
        {
            get { return _lockPrice; }
            set
            {
                _lockPrice = value;
                RaisePropertyChanged("LockPrice");
            }
        }

        private decimal _availableTotal;
        /// <summary>
        /// 可用重量
        /// </summary>
        public decimal AvailableTotal
        {
            get { return _availableTotal; }
            set
            {
                _availableTotal = value;
                RaisePropertyChanged("AvailableTotal");
            }
        }

        private string _availableTotalString;
        /// <summary>
        /// 可用重量
        /// </summary>
        public string AvailableTotalString
        {
            get { return _availableTotalString; }
            set
            {
                _availableTotalString = value;
              
                RaisePropertyChanged("AvailableTotalString");
            }
        }

        private int _fromFlag;
        /// <summary>
        /// 来源 0软件同步 1系统操作
        /// </summary>
        public int FromFlag
        {
            get { return _fromFlag; }
            set
            {
                _fromFlag = value;
                RaisePropertyChanged("FromFlag");
            }
        }

        private int _state;
        /// <summary>
        /// 状态 1未完成 0完成
        /// </summary>
        public int State
        {
            get { return _state; }
            set
            {
                _state = value;
                switch (_state)
                {
                    case 0:
                        _StateString = "完成";
                        break;
                    case 1:
                        _StateString = "未完成";
                        break;

                }
                RaisePropertyChanged("DirectionString");
                RaisePropertyChanged("State");
            }
        }

        private string _StateString;
        /// <summary>
        /// 状态
        /// </summary>
        public string StateString
        {
            get { return _StateString; }
        }

        private string _createDate;
        /// <summary>
        /// 插入日期
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
        private string _EndDate;
        public string EndDate
        {
            get { return _EndDate; }
            set
            {
                _EndDate = value;
                RaisePropertyChanged("EndDate");
            }
        }
        private string _operationUserID;
        /// <summary>
        /// 操作用户ID
        /// </summary>
        public string OperationUserID
        {
            get { return _operationUserID; }
            set
            {
                _operationUserID = value;
                RaisePropertyChanged("OperationUserID");
            }
        }

        private string _UserID;
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID
        {
            get { return _UserID; }
            set
            {
                _UserID = value;
                RaisePropertyChanged("UserID");
            }
        }

        private string _UserName;
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                RaisePropertyChanged("UserName");
            }
        }


        #endregion
    }
}
