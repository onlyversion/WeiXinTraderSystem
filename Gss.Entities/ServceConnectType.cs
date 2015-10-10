using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities
{
    /// <summary>
    /// 服务连接类型
    /// </summary>
    public static class ServceConnectType
    {
        /// <summary>
        /// 连接类型
        /// </summary>
        public static ConnectType ConnectType { get; set; }
    }
    /// <summary>
    /// 连接类型
    /// </summary>
    public enum ConnectType
    {
        /// <summary>
        /// 交易服务器
        /// </summary>
        StockServiec=1,
        /// <summary>
        /// 模拟服务器
        /// </summary>
        ImitateServiec=2
    }
}
