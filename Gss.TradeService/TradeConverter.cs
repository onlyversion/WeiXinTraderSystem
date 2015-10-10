using System;
using System.Globalization;
using Gss.Entities;
using Gss.Entities.Enums;
using Gss.Entities.JTWEntityes;
using Gss.Entities.TradeManager;
using Gss.TradeService.TradeService;

namespace Gss.TradeService {
    internal static class TradeConverter {
        internal static LQueryCon ToLQuery( HistorySearchInfo searchInfo, string loginID ) {
            return new LQueryCon {
                EndTime = searchInfo.EndDateTime,
                LoginID = loginID,
                OrderType = searchInfo.OrdersType,
                ProductName = searchInfo.ProductName,
                //Todo:用户类型待处理
                //UserType = searchInfo.UserType,
                StartTime = searchInfo.StartDateTime,
                TradeAccount = searchInfo.TradeAccount,
                OrgName = searchInfo.OrgName,
            };
        }
        /// <summary>
        /// Convert TradeOrder to MarketOrdersData
        /// </summary>
        /// <param name="order">TradeOrder</param>
        /// <returns>MarketOrdersData</returns>
        internal static MarketOrderData ToMarketOrderData(TradeOrder order)
        {
            return new MarketOrderData
            {
                OccupiedDeposit = order.OccMoney,
                OrderID = order.OrderId,
                OrderPrice = order.OrderPrice,
                OrderQuantity = order.UseQuantity,
                OrderTime = order.OrderTime,
                OrderType = (TRANSACTION_TYPE)Enum.Parse(typeof(TRANSACTION_TYPE), order.OrderType),
                ProductCode = order.ProductCode,
                ProductName = order.ProductName,
                RemainingQuantity = order.UseQuantity,
                StopLoss = order.LossPrice,
                StopProfit = order.ProfitPrice,
                StorageFee = order.StorageFee,
                TradeAccount = order.TradeAccount,
                TradeFee = order.TradeFee,
                AllowStore = order.AllowStore,//马友春
                TotalWeight = order.TotalWeight,
            };
        }

        internal static PendingOrderData ToPendingOrderData(TradeHoldOrder order)
        {
            return new PendingOrderData
            {
                OrderQuantity = order.Quantity,
                FrozenDeposit = order.FrozenMoney,
                ProductCode = order.ProductCode,
                ProductName = order.ProductName,
                OrderID = order.HoldOrderID,
                OrderPrice = order.HoldPrice,
                OrderTime = order.OrderTime,
                OrderType = (TRANSACTION_TYPE)Enum.Parse(typeof(TRANSACTION_TYPE), order.OrderType),
                StopLoss = order.LossPrice,
                StopProfit = order.ProfitPrice,
                DueDate = order.ValidTime
            };
        }

        internal static MarketHistoryData ToMarketHistoryData( LTradeOrder item ) {
            return new MarketHistoryData {
                BasicLaborCharge = item.TradeFee,
                HistoryID = item.HistoryOrderId,
                LossOrProfit = item.ProfitValue,
                OrderID = item.OrderId,
                OrderPrice = item.OrderPrice,
                OrderTime = item.OrderTime,
                OrderType = ( TRANSACTION_TYPE )Enum.Parse( typeof( TRANSACTION_TYPE ), item.OrderType ),
                ProductCode = item.ProductCode,
                ProductName = item.ProductName,
                StopLoss = item.LossPrice,
                StopProfit = item.ProfitPrice,
                StorageCharge = item.StorageFee,
                TradeAccount = item.TradeAccount,
                TradeCount = item.Quantity,
                TradePrice = item.OverPrice,
                TradeTime = item.OverTime,
                OrgName=item.OrgName,
                TradeType = ( CHARGEBACK_MODE )Enum.Parse( typeof( CHARGEBACK_MODE ), item.OverType ),
            };
        }

        internal static WarehousingHistoryData ToWarehousingHistory( LTradeOrder item ) {
            MarketHistoryData baseData = ToMarketHistoryData( item );
            WarehousingHistoryData data = new WarehousingHistoryData( );
            data.CopyFrom( baseData );
            data.Payment = item.ProductMoney;
            return data;
        }

        internal static MarOrdersLn ToMarOrdersLn( string loginID, string clientAccountName, int userType, NewMarketOrderInfo newOrderInfo ) {
            return new MarOrdersLn {
                CurrentTime = newOrderInfo.RealTimeTime,
                LoginID = loginID,
                LossPrice = newOrderInfo.StopLossPrice,
                Mac = newOrderInfo.MAC,
                MaxPrice = newOrderInfo.AllowMaxPriceDeviation,
                OrderMoney = newOrderInfo.PercentageOfDeposit,
                OrderType = ( ( int )newOrderInfo.OrderType ).ToString( CultureInfo.InvariantCulture ),
                ProductCode = newOrderInfo.ProductCode,
                ProfitPrice = newOrderInfo.StopProfitPrice,
                Quantity = newOrderInfo.Count,
                RtimePrices = newOrderInfo.RealTimePrice,
                TradeAccount = clientAccountName,
                //Todo:用户类型待处理
                //UserType = userType,
            };
        }

        internal static OrdersLncoming ToOrdersLncoming( string loginID, string clientAccountName, int userType, NewPendingOrderInfo newOrderInfo ) {
            return new OrdersLncoming {
                CurrentTime = newOrderInfo.RealTimeTime,
                HoldPrice = newOrderInfo.PendingOrdersPrice,
                LoginID = loginID,
                LossPrice = newOrderInfo.StopLossPrice,
                Mac = newOrderInfo.MAC,
                OrderMoney = newOrderInfo.PercentageOfDeposit,
                OrderType = ( ( int )newOrderInfo.OrderType ).ToString( CultureInfo.InvariantCulture ),
                ProductCode = newOrderInfo.ProductCode,
                ProfitPrice = newOrderInfo.StopProfitPrice,
                Quantity = newOrderInfo.Count,
                RtimePrices = newOrderInfo.RealTimePrice,
                ValidTime = newOrderInfo.DueDate,
                TradeAccount = clientAccountName,
                //Todo:用户类型待处理
                //UserType = userType,
            };
        }

        internal static DeliveryEnter ToDeliveryEnter( string loginID, int userType, OrderChangedInformation orderInfo ) {
            return new DeliveryEnter {
                CurrentTime = orderInfo.RealTimeTime,
                LoginID = loginID,
                MaxPrice = orderInfo.AllowMaxPriceDeviation,
                Orderid = orderInfo.OrderID,
                Quantity = orderInfo.Count,
                RtimePrices = orderInfo.RealTimePrice,
                TradeAccount = orderInfo.TradeAccount,
                //Todo:用户类型待处理
                //UserType = userType,
            };
        }

        internal static DelHoldInfo ToDelHoldInfo( string loginID, int userType, PendingOrderData orderData ) {
            return new DelHoldInfo {
                CurrentTime = orderData.OwnedProduct.RealTimeTime,
                HoldOrderID = orderData.OrderID,
                LoginID = loginID,
                ReasonType = "1",//0为自动撤销，1为用户撤销   { 考虑是否增加  2 金商撤销，3，管理员撤销 }
                RtimePrices = orderData.RealTimePrice,
                TradeAccount = orderData.TradeAccount,
                //Todo:用户类型待处理
                //UserType = userType,
            };


        }

        internal static NewsInfo ToNewsInfo(TradeNews news)
        {
            NewsInfo tInfo = new NewsInfo();
            tInfo.ID = news.ID;
            tInfo.NewsContent = news.NewsContent;
            tInfo.NewsTitle = news.NewsTitle;
            //Todo:查看枚举是否可以如此转换
            tInfo.NType = (NewsTypeEnum)news.NType;
            tInfo.PubPerson = news.PubPerson;
            tInfo.PubTime = news.PubTime;
            tInfo.Status = (NewsStatusEnum)news.Status;
            return tInfo;
        }

        internal static Gss.Entities.JTWEntityes.HisData ToHisDataInfo(Gss.TradeService.TradeService.HisData hisdata)
        {
            Gss.Entities.JTWEntityes.HisData hd = new Entities.JTWEntityes.HisData();
            hd.Closeprice = hisdata.closeprice;
            hd.Highprice = hisdata.highprice;
            hd.Lowprice = hisdata.lowprice;
            hd.Openprice = hisdata.openprice;
            hd.Volnum = hisdata.volnum;
            hd.Weektime = hisdata.weektime;
            return hd;
        }

        /// <summary>
        /// Convert MoneyInventory to FundInformation.
        /// </summary>
        /// <param name="moneyInfo">MoneyInventory</param>
        /// <returns>FundInformation</returns>
        internal static FundInformation ToFundInformation(MoneyInventory moneyInfo)
        {
            return new FundInformation
            {
                AccountBalance = moneyInfo.FdInfo.Money,
                FrozenDeposit = moneyInfo.FdInfo.FrozenMoney,
                OccupiedDeposit = moneyInfo.FdInfo.OccMoney,
                DongJieMoney = moneyInfo.FdInfo.DongJieMoney,
            };
        }

        internal static Gss.TradeService.TradeService.HisData ToServiceHisDataInfo(Gss.Entities.JTWEntityes.HisData hisdata)
        {
            Gss.TradeService.TradeService.HisData hd = new TradeService.HisData();
            hd.closeprice = hisdata.Closeprice;
            hd.highprice = hisdata.Highprice;
            hd.lowprice = hisdata.Lowprice;
            hd.openprice = hisdata.Openprice;
            hd.volnum = hisdata.Volnum;
            hd.weektime = hisdata.Weektime;
            return hd;
        }
    }
}
