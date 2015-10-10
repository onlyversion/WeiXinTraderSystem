using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gss.Common.Infrastructure;
using Gss.Common.Utility;

namespace Gss.Entities {
    /// <summary>
    /// 汇率和水信息类
    /// </summary>
    [Serializable]
    public class ExchangeRateWaterInformation : ObservableObject {
        /// <summary>
        /// 获取或设置行情编码
        /// </summary>
        public string StockCode { get; set; }

        private double _rate;

        /// <summary>
        /// 获取或设置汇率
        /// </summary>
        public double Rate {
            get { return _rate; }
            set {
                _rate = value;
                RaisePropertyChanged( "Rate" );
            }
        }

        private double _water;

        /// <summary>
        /// 获取或设置水
        /// </summary>
        public double Water {
            get { return _water; }
            set {
                _water = value;
                RaisePropertyChanged( "Water" );
            }
        }

        /// <summary>
        /// 克隆一个完整的汇率和水信息类
        /// </summary>
        /// <returns></returns>
        public object Clone( ) {
            return CloneHelper.CloneObject( this );
        }

        /// <summary>
        /// 同步汇率和水的数据
        /// </summary>
        /// <param name="clone">同步数据源</param>
        public void Sync( ExchangeRateWaterInformation clone ) {
            Rate = clone.Rate;
            Water = clone.Water;
        }

    }
}
