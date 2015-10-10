using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.gss.cnt;
using com.gss.common;

namespace Gss.StockQuotations
{
    /// <summary>
    /// 交易行情分发
    /// </summary>
    public class StockQuotationsDistribution
    {
        private Tcpcnt _tcpCnt;

        /// <summary>
        /// 实时数据更新事件
        /// </summary>
        public event EventHandler<RealTimeDataUpdateEventArgs> RealTimeDataUpdate;

        /// <summary>
        /// 实例化一个行情分发数据类 构造函数
        /// </summary>
        /// <param name="accountName">账户名</param>
        /// <param name="userType">账户类型，0：用户，1：管理员，2：金商</param>
        /// <param name="mac">MAC地址</param>
        /// <param name="addr">行情源地址</param>
        /// <param name="port">行情源端口</param>
        public StockQuotationsDistribution(string accountName, int userType, string mac, string addr, int port)
        {
            _tcpCnt = new Tcpcnt(accountName, userType, mac, addr, port);
            _tcpCnt.RealCompleteEvent += (sender, e) =>
            {
                string str = e.Obj.ToString();
                string[] array = str.Split('\t', ' ');

                string stockCode = array[1];
                string dataStr = str.Substring(array[0].Length + stockCode.Length + 2);
                CandleData data = CandleData.GetCandleDataFromString(dataStr);

                OnRealTimeDataUpdated(stockCode, data);
            };
        }

        /// <summary>
        /// 触发实时数据更新事件
        /// </summary>
        /// <param name="stockCode">行情名称</param>
        /// <param name="data">蜡状图数据源</param>
        private void OnRealTimeDataUpdated(string stockCode, CandleData data)
        {
            if (RealTimeDataUpdate != null)
                RealTimeDataUpdate(this, new RealTimeDataUpdateEventArgs(stockCode, data.Close, data.Time));
        }

        /// <summary>
        /// 尝试连接到数据服务
        /// </summary>
        public void StartConnect()
        {
            _tcpCnt.ReadData();
        }
    }
}
