using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.JTWEntityes
{
    public class HisData : BaseInfo
    {
        /// <summary>
        /// Gets or sets 周期时间
        /// </summary>
        private string weektime;

        public string Weektime
        {
            get { return weektime; }
            set
            {
                weektime = value;
                RaisePropertyChanged("Weektime");
            }
        }


        /// <summary>
        /// Gets or sets 开盘价
        /// </summary>
        private string openprice;

        public string Openprice
        {
            get { return openprice; }
            set
            {
                openprice = value;
                RaisePropertyChanged("Openprice");
            }
        }


        /// <summary>
        /// Gets or sets 最高价
        /// </summary>
        private string highprice;

        public string Highprice
        {
            get { return highprice; }
            set
            {
                highprice = value;
                RaisePropertyChanged("Highprice");
            }
        }


        /// <summary>
        /// Gets or sets 最低价
        /// </summary>
        private string lowprice;

        public string Lowprice
        {
            get { return lowprice; }
            set
            {
                lowprice = value;
                RaisePropertyChanged("Lowprice");
            }
        }


        /// <summary>
        /// Gets or sets 收盘价
        /// </summary>
        private string closeprice;

        public string Closeprice
        {
            get { return closeprice; }
            set
            {
                closeprice = value;
                RaisePropertyChanged("Closeprice");
            }
        }


        /// <summary>
        /// Gets or sets 成交量
        /// </summary>
        private string volnum;

        public string Volnum
        {
            get { return volnum; }
            set
            {
                volnum = value;
                RaisePropertyChanged("Volnum");
            }
        }
        /// <summary>
        /// 行情编码
        /// </summary>
        public string ProductCod { get; set; }
        /// <summary>
        /// 周期
        /// </summary>
        public string Cycle { get; set; }

    }
}
