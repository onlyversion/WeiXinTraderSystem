using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Gss.Entities.TradeManager
{
    public class ClientHedgingInfo:BaseInfo
    {
        public ClientHedgingInfo()
        {
            LTdOrderList = new ObservableCollection<HedgingTradeData>();
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


        private double _ProfitValue;
        /// <summary>
        /// 盈亏
        /// </summary>
        public double ProfitValue
        {
            get { return _ProfitValue; }
            set
            {
                _ProfitValue = value;
                RaisePropertyChanged("ProfitValue");
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
        private ObservableCollection<HedgingTradeData> _LTdOrderList;
        /// <summary>
        /// 对冲列表
        /// </summary>
        public ObservableCollection<HedgingTradeData> LTdOrderList
        {
            get { return _LTdOrderList; }
            set
            {
                _LTdOrderList = value;
                RaisePropertyChanged("LTdOrderList");
            }
        }

        
    }
}
