using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.JTWEntityes
{
    /// <summary>
    /// 功能：角色权限信息
    /// 创建人：马友春
    /// 创建时间：2013年12月24日
    /// </summary>
    public class RolePrivilegeInfo:BaseInfo
    {
        private string _RoleID;
        public string RoleID
        {
            get { return _RoleID; }
            set
            {
                _RoleID = value;
                RaisePropertyChanged("RoleID");
            }
        }
        private string _PrivilegeID;
        public string PrivilegeID
        {
            get { return _PrivilegeID; }
            set
            {
                _PrivilegeID = value;
                RaisePropertyChanged("PrivilegeId");
            }
        }
    }
}
