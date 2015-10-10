using System;
using System.Windows.Controls;

namespace Gss.Common.Utility {
    /// <summary>
    /// 验证辅助类
    /// </summary>
    public static class ValidationHelper {
        /// <summary>
        /// 验证止损值是否有效
        /// </summary>
        /// <param name="stopLossPrice">带验证的止损值</param>
        /// <param name="rtPrice">当前的实时价格</param>
        /// <param name="transactionType">定单类型, 0 : 买涨, 1 : 买跌</param>
        /// <param name="spreadBaseValue">点差基值</param>
        /// <param name="lossProfitSpread">止盈止损点差</param>
        /// <returns>ValidationResult</returns>
        public static ValidationResult StopLossPriceValidation( double stopLossPrice, double rtPrice, int transactionType, double spreadBaseValue, double lossProfitSpread ) {
            bool isVilid = false;
            string symbolDirection;

            double validationPrice = CalculateHelper.CalcStopLossPrice( rtPrice, transactionType, spreadBaseValue, lossProfitSpread );

            if( transactionType == 0 ) {//买涨
                symbolDirection = "小于等于";
                if( stopLossPrice <= validationPrice )
                    isVilid = true;
            } else {//买跌
                symbolDirection = "大于等于";
                if( stopLossPrice >= validationPrice )
                    isVilid = true;
            }

            if( !isVilid ) {
                string errMsg = string.Format( "无效的止损价\r\n止损价必须{0}:{1}", symbolDirection, validationPrice );
                return new ValidationResult( false, errMsg );
            }

            return new ValidationResult( true, null );
        }

        /// <summary>
        /// 验证止盈值是否有效
        /// </summary>
        /// <param name="stopLossPrice">带验证的止盈值</param>
        /// <param name="rtPrice">当前的实时价格</param>
        /// <param name="transactionType">定单类型, 0 : 买涨, 1 : 买跌</param>
        /// <param name="spreadBaseValue">点差基值</param>
        /// <param name="lossProfitSpread">止盈止损点差</param>
        /// <returns>ValidationResult</returns>
        public static ValidationResult StopProfitPriceValidation( double stopProfitPrice, double rtPrice, int transactionType, double spreadBaseValue, double lossProfitSpread ) {
            bool isVilid = false;
            string symbolDirection;

            double validationPrice = CalculateHelper.CalcStopProfitPrice( rtPrice, transactionType, spreadBaseValue, lossProfitSpread );

            if( transactionType == 0 ) {//买涨
                symbolDirection = "大于等于";
                if( stopProfitPrice >= validationPrice )
                    isVilid = true;
            } else {//买跌
                symbolDirection = "小于等于";
                if( stopProfitPrice <= validationPrice )
                    isVilid = true;
            }

            if( !isVilid ) {
                string errMsg = string.Format( "无效的止盈价\r\n止盈价必须{0}:{1}", symbolDirection, validationPrice );
                return new ValidationResult( false, errMsg );
            }

            return new ValidationResult( true, null );
        }

        /// <summary>
        /// 验证定单数量的小数位数是否有效
        /// </summary>
        /// <param name="orderCount">定单数量</param>
        /// <param name="orderUnit">允许的定单有效单位</param>
        /// <returns>ValidationResult</returns>
        public static ValidationResult OrderCountValidation( double orderCount, double orderUnit ) {
            double divValue = orderCount / orderUnit;
            string divStr = Convert.ToString( divValue );
            if( divStr.Contains( "." ) )
                return new ValidationResult( false, "订单数量的有效位数不匹配" );

            return new ValidationResult( true, null );
        }
    }
}
