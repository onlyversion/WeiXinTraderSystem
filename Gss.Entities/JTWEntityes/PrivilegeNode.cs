using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Gss.Entities.JTWEntityes
{
    /// <summary>
    /// 功能：权限节点
    /// 创建人：马友春
    /// 创建时间：2013年12月25日
    /// </summary>
    public class PrivilegeNode : BaseInfo
    {
        /// <summary>
        /// 是否为新添加的节点
        /// </summary>
        public bool IsNewNode;
        //private String text;
        private ObservableCollection<PrivilegeNode> children;

        /// <summary>
        /// 子节点
        /// </summary>
        public ObservableCollection<PrivilegeNode> Children
        {
            get { return children; }
            set { children = value; }
        }

        private PrivilegeInfo _PrivilegeTreeNode;
            public PrivilegeInfo PrivilegeTreeNode
        {
            get { return _PrivilegeTreeNode; }
            set
            {
                _PrivilegeTreeNode = value;
                RaisePropertyChanged("PrivilegeTreeNode");
            }
        }

        public PrivilegeNode(PrivilegeInfo node)
        {
            Children = new ObservableCollection<PrivilegeNode>();
            PrivilegeTreeNode = node;
            //Text = text;
            //Id = id;
            //PID = pID;
        }
        ///// <summary>
        ///// 节点文本
        ///// </summary>
        //public String Text
        //{
        //    get { return text; }
        //    set
        //    {
        //        text = value;
        //        RaisePropertyChanged("Text");
        //    }
        //}
        //public PrivilegeNode(String text,string id,string pID)
        //{
        //    Children = new ObservableCollection<PrivilegeNode>();
        //    Text = text;
        //    Id = id;
        //    PID = pID;
        //}
        public void Add(PrivilegeNode node)
        {
            children.Add(node);
            RaisePropertyChanged ("Children");
        }
        public void Delete(PrivilegeNode node)
        {
            children.Remove(node);
            RaisePropertyChanged("Children");
        }

        //private string _ID;
        ///// <summary>
        ///// 节点ID
        ///// </summary>
        //public string Id
        //{
        //    get { return _ID; }
        //    set
        //    {
        //        _ID = value;
        //        RaisePropertyChanged("Id");
        //    }
        //}

        //private bool _IsCheck;
        ///// <summary>
        ///// 是否选中
        ///// </summary>
        //public bool IsCheck
        //{
        //    get { return _IsCheck; }
        //    set
        //    {
        //        _IsCheck = value;
        //        RaisePropertyChanged("IsCheck");
        //    }
        //}

        //private string _PrivilegeName;
        ///// <summary>
        ///// 权限名称
        ///// </summary>
        //public string PrivilegeName
        //{
        //    get { return _PrivilegeName; }
        //    set
        //    {
        //        _PrivilegeName = value;
        //        RaisePropertyChanged("PrivilegeName");
        //    }
        //}

        //private string _PID;
        ///// <summary>
        ///// 上级节点ID
        ///// </summary>
        //public string PID
        //{
        //    get { return _PID; }
        //    set
        //    {
        //        _PID = value;
        //        RaisePropertyChanged("PID");
        //    }
        //}
    }

}
