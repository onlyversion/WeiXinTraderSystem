using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Gss.Entities.TradeManager
{
    public class ClientFundChangeInfo:BaseInfo
    {
        public ClientFundChangeInfo()
        {
            TOderLst = new ObservableCollection<FundChangeInformation>();
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
        /// 入金
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
        /// 出金
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
        /// 调节入金
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

        private double _AMT4;
        /// <summary>
        /// 调节出金
        /// </summary>
        public double AMT4
        {
            get { return _AMT4; }
            set
            {
                _AMT4 = value;
                RaisePropertyChanged("AMT4");
            }
        }

        private double _AMT5;
        /// <summary>
        /// 经纪人提成
        /// </summary>
        public double AMT5
        {
            get { return _AMT5; }
            set
            {
                _AMT5 = value;
                RaisePropertyChanged("AMT5");
            }
        }

        private double _AMT6;
        /// <summary>
        /// 赠金
        /// </summary>
        public double AMT6
        {
            get { return _AMT6; }
            set
            {
                _AMT6 = value;
                RaisePropertyChanged("AMT6");
            }
        }

        private ObservableCollection<FundChangeInformation> _TOderLst;
        /// <summary>
        /// 明细列表
        /// </summary>
        public ObservableCollection<FundChangeInformation> TOderLst
        {
            get { return _TOderLst; }
            set
            {
                _TOderLst = value;
                RaisePropertyChanged("TOderLst");
            }
        }

        
        
    }
}
