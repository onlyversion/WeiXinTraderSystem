

namespace Gss.Entities.JTWEntityes
{
    /// <summary>
    /// 功能：交易设置Model
    /// 创建人：马友春
    /// 创建时间：2014年1月3日
    /// </summary>
    public class TradeConfigInfo : BaseInfo
    {
        private string _ObjName;
        /// <summary>
        /// Gets or sets 名称
        /// </summary>
        public string ObjName
        {
            get { return _ObjName; }
            set
            {
                _ObjName = value;
                RaisePropertyChanged("ObjName");
            }
        }
        private string _ObjCode;
        /// <summary>
        /// Gets or sets 名称编码
        /// </summary>
        public string ObjCode
        {
            get { return _ObjCode; }
            set
            {
                _ObjCode = value;
                RaisePropertyChanged("ObjCode");
            }
        }
        private string _ObjValue;
        /// <summary>
        /// Gets or sets 对象的值
        /// </summary>
        public string ObjValue
        {
            get { return _ObjValue; }
            set
            {
                _ObjValue = value;
                RaisePropertyChanged("ObjValue");
            }
        }
        private string _Remark;
        /// <summary>
        /// Gets or sets 备注
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set
            {
                _Remark = value;
                RaisePropertyChanged("Remark");
            }
        }
    }
}
