using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities {
    public class NewPendingOrderInfo : NewOrderInfoBase {
        /// <summary>
        /// 获取或设置挂单价格
        /// </summary>
        public double PendingOrdersPrice { get; set; }

        /// <summary>
        /// 获取或设置有效期
        /// </summary>
        public DateTime DueDate { get; set; }
    }
}
