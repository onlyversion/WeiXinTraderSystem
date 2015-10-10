using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities {
    public class OrderChangedInformation:BaseInfo
    {
        /// <summary>
        /// 获取或设置允许交易价的最大偏差
        /// </summary>
        public double AllowMaxPriceDeviation { get; set; }

        private double _Count;
        /// <summary>
        /// 平仓数量
        /// </summary>
        public double Count
        {
            get { return _Count; }
            set
            {
                _Count = value;
                RaisePropertyChanged("Count");
            }
        }


        /// <summary>
        /// 获取或设置平仓的编号
        /// </summary>
        public string OrderID { get; set; }

        /// <summary>
        /// 获取或设置客户端实时价
        /// </summary>
        public double RealTimePrice { get; set; }

        /// <summary>
        /// 获取或设置客户端实时价的时间
        /// </summary>
        public DateTime RealTimeTime { get; set; }

        /// <summary>
        /// 获取或设置客户账户名
        /// </summary>
        public string TradeAccount { get; set; }
    }
}
