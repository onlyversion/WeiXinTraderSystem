using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Gss.Entities.TradeManager
{
    /// <summary>
    /// 有效订单分页查询结果
    /// </summary>
    public class ClientTradeOrderInfo:BaseInfo
    {
        public ClientTradeOrderInfo()
        {
            TdOrderList = new ObservableCollection<MarketOrderData>();
            
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

        private double _OccMoney;
        /// <summary>
        /// 占有资金
        /// </summary>
        public double OccMoney
        {
            get { return _OccMoney; }
            set
            {
                _OccMoney = value;
                RaisePropertyChanged("OccMoney");
            }
        }
        private double _Tradefee;
        /// <summary>
        /// 基础工费
        /// </summary>
        public double Tradefee
        {
            get { return _Tradefee; }
            set
            {
                _Tradefee = value;
                RaisePropertyChanged("Tradefee");
            }
        }
        private double _Storagefee;
        /// <summary>
        /// 仓储费
        /// </summary>
        public double Storagefee
        {
            get { return _Storagefee; }
            set
            {
                _Storagefee = value;
                RaisePropertyChanged("Storagefee");
            }
        }

        private double _TotalLossOrProfit;
        /// <summary>
        /// 总盈亏
        /// </summary>
        public double TotalLossOrProfit
        {
            get
            {

                return _TotalLossOrProfit;
            }
            set
            {
                _TotalLossOrProfit = value;

                RaisePropertyChanged("TotalLossOrProfit");
            }
        }

        private ObservableCollection<MarketOrderData> _TdOrderList;
        /// <summary>
        /// 有效订单列表
        /// </summary>
        public ObservableCollection<MarketOrderData> TdOrderList
        {
            get { return _TdOrderList; }
            set
            {
                _TdOrderList = value;
                RaisePropertyChanged("TdOrderList");
            }
        }

        


    }
}
