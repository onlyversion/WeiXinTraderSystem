using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Gss.Common.Utility;
using System.Collections.ObjectModel;
using Gss.Entities.JTWEntityes;

namespace Gss.Entities {
    /// <summary>
    /// 普通用户账户类
    /// </summary>
    [Serializable]
    public class ClientAccount : ICloneable {
       
        /// <summary>
        /// 获取用户账户基本信息
        /// </summary>
        public ClientAccountInformation AccInfo { get; private set; }

        /// <summary>
        /// 获取或设置资金信息
        /// </summary>
        public FundsInformation FundsInfo { get; set; }

        /// <summary>
        /// 获取交易设置信息
        /// </summary>
        public TransactionSettings TransactionSettings { get; private set; }

        /// <summary>
        /// 实例化一个普通用户账户类
        /// </summary>、
        public ClientAccount( ) {
            AccInfo = new ClientAccountInformation( );
            FundsInfo = new FundsInformation( );
            TransactionSettings = new TransactionSettings( );
        }
      
        /// <summary>
        /// 克隆一个完整的用户账户信息类
        /// </summary>
        /// <returns></returns>
        public object Clone( ) {
            return CloneHelper.CloneObject( this );
        }

        /// <summary>
        /// 同步客户资料数据
        /// </summary>
        /// <param name="clone">同步数据源</param>
        public void Sync( ClientAccount clone ) {
            AccInfo.Sync( clone.AccInfo );
            TransactionSettings.Sync( clone.TransactionSettings );
        }
    }
}
