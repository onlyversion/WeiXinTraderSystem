
namespace Gss.Entities.JTWEntityes
{
    /// <summary>
    /// 功能：系统角色Model
    /// 创建人：马友春
    /// 创建时间：2012年12月24日
    /// </summary>
    public class RoleInfo:BaseInfo
    {
        private string _RoleID;
        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleID
        {
            get { return _RoleID; }
            set
            {
                _RoleID = value;
                RaisePropertyChanged("RoleID");
            }
        }

        private string _RoleName;
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            get { return _RoleName; }
            set
            {
                _RoleName = value;
                RaisePropertyChanged("RoleName");
            }
        }

        private string _Remark;
        /// <summary>
        /// 备注
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
