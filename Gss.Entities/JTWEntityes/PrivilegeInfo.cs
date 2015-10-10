using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.JTWEntityes
{
    /// <summary>
    /// 功能：权限Model
    /// 创建人：马友春
    /// 创建时间：2012年12月24日
    /// </summary>
   public  class PrivilegeInfo:BaseInfo
    {
       private string _PrivilegeID;
        /// <summary>
        /// 权限ID
        /// </summary>
        public string PrivilegeId
       {
           get { return _PrivilegeID; }
           set
           {
               _PrivilegeID = value;
               RaisePropertyChanged("PrivilegeId");
           }
       }

        private string _PrivilegeName;
        /// <summary>
        /// 权限名称
        /// </summary>
        public string PrivilegeName
        {
            get { return _PrivilegeName; }
            set
            {
                _PrivilegeName = value;
                RaisePropertyChanged("PrivilegeName");
            }
        }

        private string _ParentPrivilegeID;
        /// <summary>
        /// 上级权限ID
        /// </summary>
        public string ParentPrivilegeID
        {
            get { return _ParentPrivilegeID; }
            set
            {
                _ParentPrivilegeID = value;
                RaisePropertyChanged("ParentPrivilegeID");
            }
        }

        private string _ParentPrivilegeName;
        /// <summary>
        /// 上级权限名称
        /// </summary>
        public string ParentPrivilegeName
        {
            get { return _ParentPrivilegeName; }
            set
            {
                _ParentPrivilegeName = value;
                RaisePropertyChanged("ParentPrivilegeName");
            }
        }

        private int _Displayorder;
        /// <summary>
        /// 显示顺序
        /// </summary>
        public int Displayorder
        {
            get { return _Displayorder; }
            set
            {
                _Displayorder = value;
                RaisePropertyChanged("Displayorder");
            }
        }

        private bool _Check;
       /// <summary>
       /// 选中权限
       /// </summary>
        public bool Check
        {
            get { return _Check; }
            set
            {
                _Check = value;
                RaisePropertyChanged("Check");
            }
        }
        ///// <summary>
        ///// 权限编码
        ///// </summary>
        //public string PrivilegeCode
        //{ get; set; }
   
        ///// <summary>
        ///// 权限类别
        ///// </summary>
        //public PrivilegeType PrivilegeType
        //{
        //    get;
        //    set;
        //}
        ///// <summary>
        ///// 程序集
        ///// </summary>
        //public string Library
        //{ get; set; }
        ///// <summary>
        ///// 路径
        ///// </summary>
        //public string NameSpace
        //{ get; set; }
        ///// <summary>
        ///// 状态
        ///// </summary>
        //public Status Status
        //{ get; set; }

       

        //public string Displayorder
        //{ get; set; }

        //public string MenuPIC
        //{ get; set; }
    }
}
