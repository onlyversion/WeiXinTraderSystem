using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities {
    public class NewMarketOrderInfo : NewOrderInfoBase {
        /// <summary>
        /// 获取或设置允许成交价的最大偏差
        /// </summary>
        public double AllowMaxPriceDeviation { get; set; }
    }
}
