using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Gss.Entities.TradeManager
{
    public class ClientTradeHoldOrderInfo:BaseInfo
    {
        public ClientTradeHoldOrderInfo()
        {
            TdHoldOrderList = new ObservableCollection<PendingOrderData>();
        }
        private bool _Result;
        /// <summary>
        /// 返回结果
        /// </summary>
        public bool Result
        {
            get { return _Result; }
            set
            {
                _Result = value;
                RaisePropertyChanged("Result");
            }
        }
        private string _Desc;
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc
        {
            get { return _Desc; }
            set
            {
                _Desc = value;
                RaisePropertyChanged("Desc");
            }
        }
        private double _Quantity;
        /// <summary>
        /// 数量
        /// </summary>
        public double Quantity
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
                RaisePropertyChanged("Quantity");
            }
        }
        private double _FrozenMoney;
        /// <summary>
        /// 预付款
        /// </summary>
        public double FrozenMoney
        {
            get { return _FrozenMoney; }
            set
            {
                _FrozenMoney = value;
                RaisePropertyChanged("FrozenMoney");
            }
        }

        private ObservableCollection<PendingOrderData> _TdHoldOrderList;
        /// <summary>
        /// 挂单列表
        /// </summary>
        public ObservableCollection<PendingOrderData> TdHoldOrderList
        {
            get { return _TdHoldOrderList; }
            set
            {
                _TdHoldOrderList = value;
                RaisePropertyChanged("TdHoldOrderList");
            }
        }

        

    }
}
