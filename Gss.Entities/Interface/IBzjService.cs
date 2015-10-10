using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Gss.Entities.BzjEntities;

namespace Gss.Entities.Interface
{
    public interface IBzjService
    {
        /// <summary>
        ///用户库存信息查询
        /// </summary>
        /// <param name="userId"></param>
        ErrType GetAdminUserStockInfo(string loginID, string userId, ref BzjInfoInformation bzjInfoInformation, int roleType);

        /// <summary>
        /// 实物入库\增加库存
        /// </summary>
        /// <param name="userID">客户用户ID</param>
        /// <param name="loginAccountName">登录用户名</param>
        /// <param name="accountName">被操作用户名</param>
        /// <param name="orderType">定单类型 1入库 2 买跌</param>
        /// <param name="Product">入库商品类别XAU黄金 XAG白银 XPT铂金 XPD巴金</param>
        /// <param name="loginID">登录标识ID</param>
        /// <param name="deliverNo">定单编码</param>
        /// <param name="total">数量</param>
        /// <param name="price">价格</param>
        /// <param name="direction">交割单表方向 9 实物入库 13 库存调整</param>
        /// <returns></returns>
         ErrType CreateDeliverAdmin(string userID, string loginAccountName, string userName, string orderType,
                                          string Product, string loginID, string deliverNo, decimal total, double price,
                                          int direction, int roleType);
         /// <summary>
         /// 金生金用户绑定
         /// </summary>
         /// <param name="entity"></param>
         /// <returns></returns>
         ErrType CreateAdminGssUser(BzjUserBindEntity entity, string loginID, string userID, int roleType);

         /// <summary>
         ///金生金账户是否已存在
         /// </summary>
         /// <param name="certificate">用户证件类型：身份证1，机构代码2，营业执照3 </param>
         /// <param name="cardNum">用户证件号</param>
         /// <returns> 0表示不存在  1表示存在</returns>
         int JgjIsUserExist(int certificate, string cardNum);

         /// <summary>
         /// 注册金生金账户
         /// </summary>
         /// <param name="certificate">用户证件类型：身份证1，机构代码2，营业执照3 </param>
         /// <param name="accountLoginId">用户证件号</param>
         /// <param name="pwd">没加密的密码</param>
         ///  <param name="agency">代理商名称</param>
         /// <param name="category">用户类型</param>
         /// <param name="username">真实姓名</param>
         /// <param name="tel">手机</param>
         /// <returns>1000表示用户已经存在，2000表示系统错误，guid表示注册成功，返回用户主键</returns>
         string JgjUserRegister(int certificate, string accountLoginId, string pwd, string agency, int category,
                                       string userName, string tel);

        /// <summary>
        /// 减少库存数量
        /// </summary>
        /// <param name="operationID">操作员的ID或用户名</param>
        /// <param name="loginID">登录ID</param>
        /// <param name="userID">用户id</param>
        /// <param name="accountName">用户名</param>
        /// <param name="au">黄金数量</param>
        /// <param name="ag">白银数量</param>
        /// <param name="pt">铂金数量</param>
        /// <param name="pd">钯金数量</param>
        /// <returns></returns>
        ErrType CreateStockDeliverAdmin(string operationID, string loginID,
                                        string userID, string accountName, double au, double ag, double pt, double pd, int roleType);

        /// <summary>
        /// 定单明细
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="orderCode"></param>
        /// <param name="bzjInfo"></param>
        /// <returns></returns>
        ErrType GetOrderNOInfo(string loginID, string orderCode, ref BzjOrderEntity bzjOrderEntiyt, int roleType);

        /// <summary>
        /// 金商管理客户提货
        /// </summary>
        /// <param name="loginAccount">登录用户账户名</param>
        /// <param name="loginID">登录标识ID</param>
        /// <param name="agentInfoID">金商账户名</param>
        /// <param name="orderNo">定单编码</param>
        /// <param name="orderCode">提货买跌验证号</param>
        /// <param name="accountName">用户名</param>
        /// <param name="agentName">金商帐户</param>
        /// <param name="userID"></param>
        /// <param name="au">黄金</param>
        /// <param name="ag">白银</param>
        /// <returns></returns>
        ErrType UpdateOrder(string loginAccount, string loginID, string agentInfoID,
            string orderNo, string orderCode, string accountName, string agentName, string userID, decimal au, decimal ag, decimal pt, decimal pd, int roleType);

        /// <summary>
        /// 金商提货受理明细
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="agentInfoID"></param>
        /// <param name="orderNo">定单编码</param>
        /// <param name="orderCode">提货买跌验证号</param>
        /// <param name="accountName">用户名</param>
        /// <param name="createDate">提货开始时间</param>
        /// <param name="endDate">提货结束时间</param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        ErrType GetAgentOrderList(string agentInfoID, string loginID, string account,
                                  string orderNo, string orderCode, string accountName, string createDate,
                                  string endDate, int pageindex, int pagesize, ref int page,
                                  ref ObservableCollection<BzjTakeGoodsDetailEntity> list, int roleType);

        /// <summary>
        /// 金商绑定账户
        /// </summary>
        /// <param name="account">绑定账户名</param>
        /// <param name="agentid">金商ID，当前登录金商</param>
        /// <param name="cardNum">证件号</param>
        /// <param name="loginID">登录ID</param>
        /// <returns></returns>
        ErrType AgentBind(string account, string agentid, string cardNum, string loginID, int roleType);

        /// <summary>
        /// 金商交割单查询
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="bzjEntity">查询实体</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="page">总页面</param>
        /// <param name="bzjDeliverList">返回数据集</param>
        /// <returns></returns>
         ErrType GetDeliverOrderList(string loginID, BzjDeliverEntity bzjEntity, string userName,
                                           int pageindex, int pagesize, ref int page,
                                           ref ObservableCollection<BzjDeliverEntity> bzjDeliverList, int roleType);

        /// <summary>
        /// 提货单查询
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="bzjEntity">查询实体</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="page">总页面</param>
        /// <param name="bzjDeliverList">返回数据集</param>
        /// <returns></returns>
         ErrType GetOrderTakeList(string loginID, BzjOrderEntity bzjEntity, int pageindex, int pagesize,
                                        ref int page, ref ObservableCollection<BzjOrderEntity> retrnList, int roleType);

        /// <summary>
        /// 买跌单查询
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="bzjEntity">查询实体</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="page">总页面</param>
        /// <param name="bzjDeliverList">返回数据集</param>
        /// <returns></returns>
         ErrType GetOrderBackList(string loginID, BzjOrderEntity bzjEntity,
                                        int pageindex, int pagesize, ref int page,
                                        ref ObservableCollection<BzjOrderEntity> retrnList, int roleType);

        /// <summary>
        /// 金生金单查询
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="bzjEntity">查询实体</param>
        /// <param name="userName">用户姓名</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="page">总页面</param>
        /// <param name="bzjDeliverList">返回数据集</param>
        /// <returns></returns>
         ErrType GetOrderJsjList(string loginID, BzjOrderEntity bzjEntity, int pageindex,
                                       int pagesize, ref int page, ref ObservableCollection<BzjOrderEntity> retrnList, int roleType);

        /// <summary>
        ///	金商买跌单更新
        /// </summary>
        /// <param name="loginID">登录ID</param>
        /// <param name="OrderNO">定单编号</param>
        /// <param name="agentName">金商账号</param>
        /// <returns></returns>
         ErrType UpdateBuyBackOrder(string loginID, string OrderNO, string agentName, int roleType);
    }
}
