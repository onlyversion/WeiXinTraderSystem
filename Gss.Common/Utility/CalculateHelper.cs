using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Common.Utility {
    /// <summary>
    /// 计算辅助类
    /// </summary>
    public static class CalculateHelper {
        /// <summary>
        /// 计算止损价
        /// </summary>
        /// <param name="rtPrice">当前实时价</param>
        /// <param name="transactionType">定单类型, 0 : 买涨, 1 : 买跌</param>
        /// <param name="spreadBaseValue">点差基值</param>
        /// <param name="lossProfitSpread">止盈止损点差</param>
        /// <returns>计算后的止损值</returns>
        public static double CalcStopLossPrice( double rtPrice, int transactionType, double spreadBaseValue, double lossProfitSpread ) {
            double priceDiff = spreadBaseValue * lossProfitSpread;

            return transactionType == 0 ? rtPrice - priceDiff : rtPrice + priceDiff;
        }

        /// <summary>
        /// 计算止盈价
        /// </summary>
        /// <param name="rtPrice">当前实时价</param>
        /// <param name="transactionType">定单类型, 0 : 买涨, 1 : 买跌</param>
        /// <param name="spreadBaseValue">点差基值</param>
        /// <param name="lossProfitSpread">止盈止损点差</param>
        /// <returns>计算后的止盈值</returns>
        public static double CalcStopProfitPrice( double rtPrice, int transactionType, double spreadBaseValue, double lossProfitSpread ) {
            double priceDiff = spreadBaseValue * lossProfitSpread;

            return transactionType == 0 ? rtPrice + priceDiff : rtPrice - priceDiff;
        }
    }
}
