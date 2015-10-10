using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using Gss.BzjService.BZJServiceReference;
using Gss.Entities.BzjEntities;

namespace Gss.BzjService
{
    internal class MyConverter
    {
        /// <summary>
        /// 保证金
        /// </summary>
        /// <param name="entity">StockEntity</param>
        /// <param name="bzjInfo"> ref BzjInfoInformation</param>
        internal static BzjInfoInformation ToBzjInfo(StockEntity entity)
        {
            return new BzjInfoInformation()
                       {
                           Au = entity.Au,
                           Ag = entity.Ag,
                           Pt = entity.Pt,
                           Pd = entity.Pd,

                           AuPrice = entity.AuPrice,
                           AgPrice = entity.AgPrice,
                           PdPrice = entity.PdPrice,
                           PtPrice = entity.PtPrice,
                           StockID = entity.StockID,
                       };




            //BidOrder = orderTypeTotal == null ? BidOrder : orderTypeTotal.BidOrder;
            //BidSuccess = orderTypeTotal == null ? BidSuccess : orderTypeTotal.BidSuccess;
            //AskOrder = orderTypeTotal == null ? AskOrder : orderTypeTotal.AskOrder;
            //AskSuccess = orderTypeTotal == null ? AskSuccess : orderTypeTotal.AskSuccess;
        }


        internal static UserBindEntity ToUserBindEntity(BzjUserBindEntity entity)
        {
            UserBindEntity uEntity = new UserBindEntity();
            uEntity.CreateDate = entity.CreateDate;
            uEntity.UserId = entity.UserId;
            uEntity.IsEnable = entity.IsEnable;
            uEntity.JUserId = entity.JUserId;
            uEntity.UserBindId = entity.UserBindId;
            return uEntity;
        }

        internal static BzjOrderEntity ToBzjOrderEntity(OrderEntity entity)
        {
            //string orderType = "";
            //switch (entity.OrderType)
            //{
            //    case 1:
            //        orderType = "提货单";
            //        break;
            //    case 2:
            //        orderType = "买跌单";
            //        break;
            //    case 3:
            //        orderType = "买跌单";
            //        break;
            //    case4:
            //        orderType = "金生金";
            //        break;
            //}
            //string state = "";
            //switch (entity.State)
            //{
            //    case 1:
            //        state = "新定单";
            //        break;
            //    case 2:
            //        state = "已完成";
            //        break;
            //    case 3:
            //        state = "已取消";
            //        break;
            //    case4:
            //        state = "已过期";
            //        break;
            //}
            return new BzjOrderEntity()
                       {
                           OrderNO = entity.OrderNo,//单号
                           Name = entity.Name,	//	姓名
                           OrderCode = entity.OrderCode,	//	提货码
                           Au = entity.Au,	//	au数量
                           Ag = entity.Ag, 	//	Ag数量
                           Pt = entity.Pt,
                           Pd = entity.Pd,

                           AuT = entity.AuT,//	au可开发票总额
                           AgT = entity.AgT,//	ag可开发票总额
                           PtT = entity.PtT,
                           PdT = entity.PdT,

                           //CardType = entity.CardType == 1 ? "身份证" : "营业执照", 	//	卡类别 1，身份证，2.营业执照
                           CardType = entity.CardType == 1 ? "身份证" : (entity.CardType == 2 ? "机构代码" : "其它"), 	//	 身份证号 = 1, 机构代码 = 2, 营业执照 = 3
                           CardNum = entity.CardNum,//	身份证号
                           PhoneNum = entity.PhoneNum,//	电话
                           State = entity.State,//	状态 新定单 = 1,已完成 = 2,已取消 = 3,已过期 = 4
                           OrderType = entity.OrderType,//	定单类别 提货单 = 1,买跌单 = 2, 买跌单 = 3,金生金 = 4 
                           //todo:调整版本
                           //IDType = entity.IDType,//定单卡类别
                           IDNo = entity.IDNo,//定单号
                           Phone = entity.Phone,//定单电话
                           UserId = entity.UserId,
                           Account = entity.Account,

                           AgP=entity.AgP,//平均价
                           AuP=entity.AuP,
                           PdP=entity.PdP,
                           PtP = entity.PtP,

                           
                       };
        }


        internal static ObservableCollection<BzjTakeGoodsDetailEntity> ToBzjTakeGoodsDetailEntity(DataTable table)
        {
            List<BzjTakeGoodsDetailEntity> list = new List<BzjTakeGoodsDetailEntity>();
            foreach (DataRow row in table.Rows)
            {
                BzjTakeGoodsDetailEntity entity = new BzjTakeGoodsDetailEntity();
                entity.Account = row.Field<string>("Account");
                entity.Ag = Convert.ToDouble(row["Ag"]);
                entity.AgAvailable = Convert.ToDouble(row["AvailableAg"]);
                entity.Au = Convert.ToDouble(row["Au"]);
                entity.AuAvailable = Convert.ToDouble(row["AvailableAu"]);
                int carryWay = row.Field<int>("CarryWay");//非提货买跌 = 0,在线提货 = 1,金店提货 = 2,邮寄买跌 = 3,金店买跌 = 4
                switch (carryWay)
                {
                    case 0:
                        entity.CarryWay = "非提货买跌";
                        break;
                    case 1:
                        entity.CarryWay = "在线提货";
                        break;
                    case 2:
                        entity.CarryWay = "金店提货";
                        break;
                    case 3:
                        entity.CarryWay = "邮寄买跌";
                        break;
                    case 4:
                        entity.CarryWay = "金店买跌";
                        break;
                }
                DateTime time = row.Field<DateTime>("OperationDate");
                entity.CreateDate = time == null ? "" : time.ToString();
                entity.OrderCode = row.Field<string>("OrderCode");
                entity.OrderId = row.Field<string>("OrderId");
                entity.OrderNo = row.Field<string>("OrderNo");
                int type = row.Field<int>("OrderType");//定单类别 提货单 = 1, 买跌单 = 2, 买跌单 = 3,金生金 = 4,到期定单 = 5,已生金定单 = 6,提成定单 = 7
                switch (type)
                {
                    case 1:
                        entity.OrderType = "提货单";
                        break;
                    case 2:
                        entity.OrderType = "买跌单";
                        break;
                    case 3:
                        entity.OrderType = "买跌单";
                        break;
                    case 4:
                        entity.OrderType = "金生金";
                        break;
                    case 5:
                        entity.OrderType = "到期订单";
                        break;
                    case 6:
                        entity.OrderType = "已生金订单";
                        break;
                    case 7:
                        entity.OrderType = "提成订单";
                        break;
                }
                entity.Pd = Convert.ToDouble(row["Pd"]);
                entity.PdAvailable = Convert.ToDouble(row["AvailablePd"]);
                entity.Pt = Convert.ToDouble(row["Pt"]);
                entity.PtAvailable = Convert.ToDouble(row["AvailablePt"]);
                entity.UserId = row.Field<string>("UserId");
                entity.UserName = row.Field<string>("UserName");
                entity.TradeAccount = row.Field<string>("tradeAccount");
                entity.AgentId = row.Field<string>("AgentId");
                entity.ClerkId = row.Field<string>("ClerkId");
               
                entity.OperationDate = row.Field<string>("OperationDate");
                list.Add(entity);
            }

            return new ObservableCollection<BzjTakeGoodsDetailEntity>(list.OrderByDescending(p => p.CreateDate));
        }
    }
}
