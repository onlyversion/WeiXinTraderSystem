using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities
{
    public class WarehousingHistoryData : MarketHistoryData {
        /// <summary>
        /// Gets or sets payment.
        /// 获取或设置入库货款
        /// </summary>
        public double Payment { get; set; }

        /// <summary>
        /// Copy data from MarketHistoryData.
        /// </summary>
        /// <param name="data">the src data MarketHistoryData</param>
        public void CopyFrom( MarketHistoryData data ) {
            base.BasicLaborCharge = data.BasicLaborCharge;
            base.HistoryID = data.HistoryID;
            base.LossOrProfit = data.LossOrProfit;
            base.OrderID = data.OrderID;
            base.OrderPrice = data.OrderPrice;
            base.OrderTime = data.OrderTime;
            base.OrderType = data.OrderType;
            base.ProductCode = data.ProductCode;
            base.ProductName = data.ProductName;
            base.StorageCharge = data.StorageCharge;
            base.TradeAccount = data.TradeAccount;
            base.TradeCount = data.TradeCount;
            base.TradePrice = data.TradePrice;
            base.TradeTime = data.TradeTime;
            base.TradeType = data.TradeType;
            this.Payment = 0.0;
        }
    }
}

