using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Gss.Entities.TradeManager
{
    public class ClientTradeChuJinInfo:BaseInfo
    {
        public ClientTradeChuJinInfo()
        {
            TOrderLst = new ObservableCollection<TradeChuJinInformation>();
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
        private double _AMT;
        /// <summary>
        /// 已申请金额
        /// </summary>
        public double AMT
        {
            get { return _AMT; }
            set
            {
                _AMT = value;
                RaisePropertyChanged("AMT");
            }
        }
        private double _AMT2;
        /// <summary>
        /// 已付款金额
        /// </summary>
        public double AMT2
        {
            get { return _AMT2; }
            set
            {
                _AMT2 = value;
                RaisePropertyChanged("AMT2");
            }
        }

        private double _AMT3;
        /// <summary>
        /// 已拒绝金额
        /// </summary>
        public double AMT3
        {
            get { return _AMT3; }
            set
            {
                _AMT3 = value;
                RaisePropertyChanged("AMT3");
            }
        }

        private ObservableCollection<TradeChuJinInformation> _TOrderLst;
        /// <summary>
        /// 列表明细
        /// </summary>
        public ObservableCollection<TradeChuJinInformation> TOrderLst
        {
            get { return _TOrderLst; }
            set
            {
                _TOrderLst = value;
                RaisePropertyChanged("TOrderLst");
            }
        }

        
    }
}
