using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Gss.Common.Infrastructure;
using Gss.Entities;
using Gss.Entities.BzjEntities;
using Gss.Entities.Enums;
using Gss.Entities.JTWEntityes;
using Gss.PopUpWindow.AccountManager;
using Gss.PopUpWindow.AuthWindows;
using Gss.PopUpWindow.SystemSetting;
using Gss.PopUpWindow.DataManager;
using Gss.PopUpWindow.ModifyPassword;
using Gss.Entities.AccountManager;

namespace Gss.ViewModel.Management
{
    public partial class ManagementViewModel
    {
        #region 查询条件
        private SelectCondition _OrgSelectCondition;
        /// <summary>
        /// 微会员查询
        /// </summary>
        public SelectCondition OrgSelectCondition
        {
            get { return _OrgSelectCondition; }
            private set
            {
                _OrgSelectCondition = value;
                RaisePropertyChanged("OrgSelectCondition");
            }
        }
        private SelectCondition _GetNewsCondition;
        /// <summary>
        /// 新闻
        /// </summary>
        public SelectCondition GetNewsCondition
        {
            get { return _GetNewsCondition; }
            private set
            {
                _GetNewsCondition = value;
                RaisePropertyChanged("GetNewsCondition");
            }
        }

        private SelectCondition _GetArticlesCondition;
        /// <summary>
        /// 理财师说
        /// </summary>
        public SelectCondition GetArticlesCondition
        {
            get { return _GetArticlesCondition; }
            private set
            {
                _GetArticlesCondition = value;
                RaisePropertyChanged("GetArticlesCondition");
            }
        }

       

        #endregion

        #region 属性定义

        private OrgInfo _CurOrgInfo;
        /// <summary>
        /// 当前会员账户
        /// </summary>
        public OrgInfo CurOrgInfo
        {
            get { return _CurOrgInfo; }
            set
            {
                _CurOrgInfo = value;
                RaisePropertyChanged("CurOrgInfo");
            }
        }
        private RoleInfo _CurentRoleInfo;
        /// <summary>
        /// 当前角色
        /// </summary>
        public RoleInfo CurentRoleInfo
        {
            get { return _CurentRoleInfo; }
            set
            {
                _CurentRoleInfo = value;
                RaisePropertyChanged("CurentRoleInfo");
            }
        }

        private bool _IsBusy;
        /// <summary>
        /// 是否操作繁忙
        /// </summary>
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }
        private PrivilegeNode _CurPrivilegeNode;
        /// <summary>
        /// 当前操作的权限节点（权限管理用）
        /// </summary>
        public PrivilegeNode CurPrivilegeNode
        {
            get { return _CurPrivilegeNode; }
            set
            {
                _CurPrivilegeNode = value;
                RaisePropertyChanged("CurPrivilegeNode");
            }
        }

        private PrivilegeInfo _CurPrivilegeInfo;
        /// <summary>
        /// 当前操作的权限（权限管理用）
        /// </summary>
        public PrivilegeInfo CurPrivilegeInfo
        {
            get { return _CurPrivilegeInfo; }
            set
            {
                _CurPrivilegeInfo = value;
                RaisePropertyChanged("CurPrivilegeInfo");
            }
        }

        private NewsInfo _CurNewsInfo;
        /// <summary>
        /// 当前操作的新闻公告
        /// </summary>
        public NewsInfo CurNewsInfo
        {
            get { return _CurNewsInfo; }
            set
            {
                _CurNewsInfo = value;
                RaisePropertyChanged("CurNewsInfo");
            }
        }

        private NewsInfo _CurArticlesInfo;
        /// <summary>
        /// 当前理财师说记录
        /// </summary>
        public NewsInfo CurArticlesInfo
        {
            get { return _CurArticlesInfo; }
            set
            {
                _CurArticlesInfo = value;
                RaisePropertyChanged("CurArticlesInfo");
            }
        }
        #endregion

        #region 数据集
        private ObservableCollection<OrgInfo> _OrgList;
        /// <summary>
        /// 微会员数据集
        /// </summary>
        public ObservableCollection<OrgInfo> OrgList
        {
            get { return _OrgList; }
            private set
            {
                _OrgList = value;
                RaisePropertyChanged("POrgList");
                RaisePropertyChanged("OrgList");
            }
        }

        private ObservableCollection<OrgInfo> _POrgList;
        /// <summary>
        /// 上级微会员数据集（用于Combox绑定）
        /// </summary>
        public ObservableCollection<OrgInfo> POrgList
        {
            get { return _POrgList; }
            private set
            {
                _POrgList = value;
                RaisePropertyChanged("POrgList");
            }
        }

        private ObservableCollection<RoleInfo> _RoleList;
        /// <summary>
        /// 角色列表
        /// </summary>
        public ObservableCollection<RoleInfo> RoleList
        {
            get { return _RoleList; }
            private set
            {
                _RoleList = value;
                RaisePropertyChanged("RoleList");
            }
        }

        private ObservableCollection<PrivilegeInfo> _PrivilegeList;
        /// <summary>
        /// 所有权限数据集
        /// </summary>
        public ObservableCollection<PrivilegeInfo> PrivilegeList
        {
            get { return _PrivilegeList; }
            private set
            {
                _PrivilegeList = value;
                RaisePropertyChanged("PrivilegeList");
            }
        }

        private ObservableCollection<PrivilegeNode> _privilegeTreeNodeList;
        /// <summary>
        /// 所有权限树节点数据集(用于绑定)
        /// </summary>
        public ObservableCollection<PrivilegeNode> PrivilegeTreeNodeList
        {
            get { return _privilegeTreeNodeList; }
            private set
            {
                _privilegeTreeNodeList = value;

                RaisePropertyChanged("PrivilegeTreeNodeList");
            }
        }

        private ObservableCollection<PrivilegeNode> _privilegeNodeList;
        /// <summary>
        /// 所有权限树节点数据集（用于临时存储同步数据用）
        /// </summary>
        public ObservableCollection<PrivilegeNode> PrivilegeNodeList
        {
            get { return _privilegeNodeList; }
            private set
            {
                _privilegeNodeList = value;
                RaisePropertyChanged("PrivilegeNodeList");
            }
        }

        private ObservableCollection<NewsInfo> _NewsList;
        /// <summary>
        /// 新闻公告数据集
        /// </summary>
        public ObservableCollection<NewsInfo> NewsList
        {
            get { return _NewsList; }
            private set
            {
                _NewsList = value;
                RaisePropertyChanged("NewsList");
            }
        }

        private ObservableCollection<NewsInfo> _ArtilesList;
        /// <summary>
        /// 理财师说数据集
        /// </summary>
        public ObservableCollection<NewsInfo> ArtilesList
        {
            get { return _ArtilesList; }
            private set
            {
                _ArtilesList = value;
                RaisePropertyChanged("ArtilesList");
            }
        }

        #endregion

        #region Command
        private ICommand _AddRoleCommand;
        /// <summary>
        /// 添加角色
        /// </summary>
        public ICommand AddRoleCommand
        {
            get
            {
                if (_AddRoleCommand == null)
                    _AddRoleCommand = new RelayCommand(AddRoleExecute);
                return _AddRoleCommand;
            }
        }

        private ICommand _DelRoleCommand;
        /// <summary>
        /// 删除角色
        /// </summary>
        public ICommand DelRoleCommand
        {
            get
            {
                if (_DelRoleCommand == null)
                    _DelRoleCommand = new RelayCommand(DelRoleExecute);
                return _DelRoleCommand;
            }
        }

        private ICommand _EditRoleCommand;
        /// <summary>
        /// 编辑角色
        /// </summary>
        public ICommand EditRoleCommand
        {
            get
            {
                if (_EditRoleCommand == null)
                    _EditRoleCommand = new RelayCommand(EditRoleExecute);
                return _EditRoleCommand;
            }
        }

        private ICommand _ConfigRolePrivilegesCommand;
        /// <summary>
        /// 配置角色权限
        /// </summary>
        public ICommand ConfigRolePrivilegesCommand
        {
            get
            {
                if (_ConfigRolePrivilegesCommand == null)
                    _ConfigRolePrivilegesCommand = new RelayCommand(ConfigRolePrivilegesExecute);
                return _ConfigRolePrivilegesCommand;
            }
        }

        private ICommand _SelectRoleCommand;
        /// <summary>
        /// 选择角色
        /// </summary>
        public ICommand SelectRoleCommand
        {
            get
            {
                if (_SelectRoleCommand == null)
                    _SelectRoleCommand = new RelayCommand(SelectRoleExecute);
                return _SelectRoleCommand;
            }
        }

        private ICommand _AddPrivilegeCommand;
        /// <summary>
        /// 添加权限
        /// </summary>
        public ICommand AddPrivilegeCommand
        {
            get
            {
                if (_AddPrivilegeCommand == null)
                    _AddPrivilegeCommand = new RelayCommand(AddPrivilegeExecute);
                return _AddPrivilegeCommand;
            }
        }

        private ICommand _DelPrivilegeCommand;
        /// <summary>
        /// 删除权限
        /// </summary>
        public ICommand DelPrivilegeCommand
        {
            get
            {
                if (_DelPrivilegeCommand == null)
                    _DelPrivilegeCommand = new RelayCommand(DelPrivilegeExecute);
                return _DelPrivilegeCommand;
            }
        }

        private ICommand _SavePrivilegeCommand;
        /// <summary>
        /// 保存权限
        /// </summary>
        public ICommand SavePrivilegeCommand
        {
            get
            {
                if (_SavePrivilegeCommand == null)
                    _SavePrivilegeCommand = new RelayCommand(SavePrivilegeExecute);
                return _SavePrivilegeCommand;
            }
        }

        private ICommand _ShowOrgDetialCommand;
        /// <summary>
        /// 微会员详细资料
        /// </summary>
        public ICommand ShowOrgDetialCommand
        {
            get
            {
                if (_ShowOrgDetialCommand == null)
                    _ShowOrgDetialCommand = new RelayCommand(ShowOrgDetialExecute);
                return _ShowOrgDetialCommand;
            }
        }

        private ICommand _AddOrgCommand;
        /// <summary>
        /// 添加微会员
        /// </summary>
        public ICommand AddOrgCommand
        {
            get
            {
                if (_AddOrgCommand == null)
                    _AddOrgCommand = new RelayCommand(AddOrgExecute);
                return _AddOrgCommand;
            }
        }

        private ICommand _DeleteOrgCommand;
        /// <summary>
        /// 删除微会员
        /// </summary>
        public ICommand DeleteOrgCommand
        {
            get
            {
                if (_DeleteOrgCommand == null)
                    _DeleteOrgCommand = new RelayCommand(DeleteOrgCommandExecute);
                return _DeleteOrgCommand;
            }
        }

        private ICommand _GetOrgsListCommand;
        /// <summary>
        /// 获取微会员信息
        /// </summary>
        public ICommand GetOrgsListCommand
        {
            get
            {
                if (_GetOrgsListCommand == null)
                    _GetOrgsListCommand = new RelayCommand(GetOrgsListExecute);
                return _GetOrgsListCommand;
            }
        }

        private ICommand _CreateOrgCodeCommand;
        /// <summary>
        /// 生成微会员编码
        /// </summary>
           public ICommand CreateOrgCodeCommand
        {
            get
            {
                if (_CreateOrgCodeCommand == null)
                    _CreateOrgCodeCommand = new RelayCommand(CreateOrgCodeExecute,CareateOrgCodeCanExecute);
                return _CreateOrgCodeCommand;
            }
        }

       
        

        private ICommand _GetNewsCommand;
        /// <summary>
        /// 获取新闻公告信息
        /// </summary>
        public ICommand GetNewsCommand
        {
            get
            {
                if (_GetNewsCommand == null)
                    _GetNewsCommand = new RelayCommand(GetNewsListExecute);
                return _GetNewsCommand;
            }
        }
        private ICommand _AddNewsCommand;
        /// <summary>
        /// 添加新闻公告信息
        /// </summary>
        public ICommand AddNewsCommand
        {
            get
            {
                if (_AddNewsCommand == null)
                    _AddNewsCommand = new RelayCommand(AddNewsExecute);
                return _AddNewsCommand;
            }
        }
        private ICommand _DelNewsCommand;
        /// <summary>
        /// 删除新闻公告信息
        /// </summary>
        public ICommand DelNewsCommand
        {
            get
            {
                if (_DelNewsCommand == null)
                    _DelNewsCommand = new RelayCommand(DelNewsExecute);
                return _DelNewsCommand;
            }
        }
        private ICommand _EditNewsCommand;
        /// <summary>
        /// 编辑新闻公告信息
        /// </summary>
        public ICommand EditNewsCommand
        {
            get
            {
                if (_EditNewsCommand == null)
                    _EditNewsCommand = new RelayCommand(EditNewsExecute);
                return _EditNewsCommand;
            }
        }

        private ICommand _GetArticlesCommand;
        /// <summary>
        /// 获取理财师说
        /// </summary>
        public ICommand GetArticlesCommand
        {
            get
            {
                if (_GetArticlesCommand == null)
                    _GetArticlesCommand = new RelayCommand(GetArticlesListExecute);
                return _GetArticlesCommand;
            }
        }
        private ICommand _AddArticlesCommand;
        /// <summary>
        /// 添加理财师说
        /// </summary>
        public ICommand AddArticlesCommand
        {
            get
            {
                if (_AddArticlesCommand == null)
                    _AddArticlesCommand = new RelayCommand(AddArticlesExecute);
                return _AddArticlesCommand;
            }
        }
        private ICommand _DelArticlesCommand;
        /// <summary>
        /// 删除理财师说
        /// </summary>
        public ICommand DelArticlesCommand
        {
            get
            {
                if (_DelArticlesCommand == null)
                    _DelArticlesCommand = new RelayCommand(DelArticlesExecute);
                return _DelArticlesCommand;
            }
        }
        private ICommand _EditArticlesCommand;
        /// <summary>
        /// 编辑理财师说
        /// </summary>
        public ICommand EditArticlesCommand
        {
            get
            {
                if (_EditArticlesCommand == null)
                    _EditArticlesCommand = new RelayCommand(EditArticlesExecute);
                return _EditArticlesCommand;
            }
        }

        #endregion


        #region 角色及权限管理
        #region 获取当前角色对应的权限数据
        /// <summary>
        /// 获取当前角色对应的权限数据
        /// </summary>
        public void GetRolePrivileges()
        {
            ObservableCollection<PrivilegeInfo> rolePrivilegeList = new ObservableCollection<PrivilegeInfo>();
            if (CurentRoleInfo == null)
                CurentRoleInfo = RoleList.FirstOrDefault();
            if (CurentRoleInfo != null)
            {
                ErrType err = _businessService.GetPrivilegesRole(_loginID, CurentRoleInfo.RoleID, ref rolePrivilegeList);
                if (err.Err == ERR.SUCCESS)
                {
                    foreach (PrivilegeInfo privilege in PrivilegeList)
                    {
                        PrivilegeInfo info = rolePrivilegeList.Where(p => p.PrivilegeId == privilege.PrivilegeId).FirstOrDefault();
                        if (info != null)
                            privilege.Check = true;
                        else
                            privilege.Check = false;
                    }
                }
            }

        }
        #endregion

        #region 给指定角色分配权限
        /// <summary>
        /// 给指定角色分配权限
        /// </summary>
        public void ConfigRolePrivilegesExecute()
        {
            if (PrivilegeList != null && CurentRoleInfo != null)
            {
                ErrType err = _businessService.AddRolePrivileges(_loginID, new ObservableCollection<PrivilegeInfo>(PrivilegeList.Where(p => p.Check)), CurentRoleInfo.RoleID);
                if (err.Err != ERR.SUCCESS)
                {
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("角色配置成功！", err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }
        #endregion

        #region 获取所有角色
        /// <summary>
        /// 获取所有角色
        /// </summary>
        public void GetAllRoles()
        {
            if (RoleList == null)
            {
                RoleList = new ObservableCollection<RoleInfo>();
            }
            ErrType err = _businessService.GetRoles(_loginID, ref _RoleList);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                //通过以下代码移出角色不准确（比如管理员添加了多个角色名字为"超级管理员"或"root管理员",这样移出是不正确的；
                //此限制已在服务接口中实现，所以这里的代码要注释掉）--2014-11-28 by ygj
                
                //if (_accName != "admin")
                //{
                //    RoleInfo role= _RoleList.Where(p => p.RoleName == "超级管理员").FirstOrDefault();
                //   _RoleList.Remove(role);
                //}
                //if (_accName != "root" && _accName != "admin")
                //{
                //    RoleInfo role = _RoleList.Where(p => p.RoleName == "root管理员").FirstOrDefault();
                //    _RoleList.Remove(role);
                //}
            }
        }
        #endregion

        #region 给账户配置角色及权限
        /// <summary>
        /// 给账户配置角色及权限
        /// </summary>
        /// <param name="selectAccount"></param>
        public void ConfigRolePrivilege(ClientAccount selectAccount)
        {
            GetAllRoles();
            GetPrivileges();
            string roleID = "";
            ErrType err = _businessService.ReadUserRole(_loginID, selectAccount.AccInfo.UserID, ref roleID);
            if (err.Err == ERR.SUCCESS && !string.IsNullOrEmpty(roleID))
            {
                CurentRoleInfo = RoleList.Where(p => p.RoleID == roleID).FirstOrDefault();
            }
            RolePrivilegesConfigWindow window = new RolePrivilegesConfigWindow()
            {
                Owner = Application.Current.MainWindow,
                DataContext = this,
            };
            window.DataGridSelectionChangedEvent += (e, v) =>
            {
                GetRolePrivileges();
            };
            if (window.ShowDialog() == true)
            {
                if (string.IsNullOrEmpty(roleID))
                {
                    err = _businessService.AddUserRole(_loginID, CurentRoleInfo.RoleID, selectAccount.AccInfo.UserID);
                }
                else
                {
                    err = _businessService.UpdateUserRole(_loginID, CurentRoleInfo.RoleID, selectAccount.AccInfo.UserID);
                }
                if (err.Err != ERR.SUCCESS)
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region 在微会员中中设置角色
        public void ConfigRolePrivilegeEx()
        {
            GetAllRoles();
            GetPrivileges();
            string roleID = "";
            string UserID = CurOrgInfo.OrgID;//在新增微会员时，默认会以微会员ID为UserId,会员编码为Account添加一个会员账户，所以在这里设置角色时，就通过会员ID获得会员账户ID
            ErrType err = _businessService.ReadUserRole(_loginID, UserID, ref roleID);
            if (err.Err == ERR.SUCCESS && !string.IsNullOrEmpty(roleID))
            {
                CurentRoleInfo = RoleList.Where(p => p.RoleID == roleID).FirstOrDefault();
            }
            RolePrivilegesConfigWindow window = new RolePrivilegesConfigWindow()
            {
                Owner = Application.Current.MainWindow,
                DataContext = this,
            };
            window.DataGridSelectionChangedEvent += (e, v) =>
            {
                GetRolePrivileges();
            };
            if (window.ShowDialog() == true)
            {
                if (string.IsNullOrEmpty(roleID))
                {
                    err = _businessService.AddUserRole(_loginID, CurentRoleInfo.RoleID, UserID);
                }
                else
                {
                    err = _businessService.UpdateUserRole(_loginID, CurentRoleInfo.RoleID, UserID);
                }
                if (err.Err != ERR.SUCCESS)
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region 添加角色
        /// <summary>
        /// 添加角色
        /// </summary>
        public void AddRoleExecute()
        {
            CurentRoleInfo = new RoleInfo();
            CurentRoleInfo.RoleID = Guid.NewGuid().ToString("n"); ;
            AddOrEditRoleWindow window = new AddOrEditRoleWindow()
            {
                Owner = Application.Current.MainWindow,
                DataContext = this,
            };
            if (window.ShowDialog() == true)
            {
                ErrType err = _businessService.AddRole(_loginID, CurentRoleInfo);
                if (err.Err == ERR.SUCCESS)
                {
                    RoleList.Add(CurentRoleInfo);
                }
                else
                {
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        #endregion

        #region 删除角色
        /// <summary>
        /// 删除角色
        /// </summary>
        public void DelRoleExecute()
        {
            MessageBoxResult result = MessageBox.Show("您确定删除当前角色吗？", "提示信息", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                ErrType err = _businessService.DeleteRole(_loginID, CurentRoleInfo.RoleID);
                if (err.Err == ERR.SUCCESS)
                {
                    MessageBox.Show("删除角色成功", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
                    RoleList.Remove(CurentRoleInfo);
                }
                else
                {
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        #endregion

        #region 编辑角色
        /// <summary>
        /// 编辑角色
        /// </summary>
        public void EditRoleExecute()
        {
            AddOrEditRoleWindow window = new AddOrEditRoleWindow()
            {
                Owner = Application.Current.MainWindow,
                DataContext = this,
            };
            if (window.ShowDialog() == true)
            {
                ErrType err = _businessService.UpdateRole(_loginID, CurentRoleInfo);
                if (err.Err != ERR.SUCCESS)
                {
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        #endregion

        #region 选择角色
        /// <summary>
        /// 选择角色
        /// </summary>
        public void SelectRoleExecute()
        {

        }
        #endregion

        #region 生成权限树
        /// <summary>
        /// 获取所有用户权限集合
        /// </summary>
        public void GetPrivileges()
        {
            IsBusy = true;
            if (_PrivilegeList == null)
                _PrivilegeList = new ObservableCollection<PrivilegeInfo>();
            else
                _PrivilegeList.Clear();
            ErrType err = _businessService.GetPrivileges(_loginID, ref _PrivilegeList);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_PrivilegeList != null)
            {
                
                PrivilegeTreeNodeList = new ObservableCollection<PrivilegeNode>();
                // PrivilegeNodeList = new ObservableCollection<PrivilegeNode>();
                IEnumerable<PrivilegeInfo> rootPrivilegeInfoList = _PrivilegeList.Where(p => string.IsNullOrEmpty(p.ParentPrivilegeID)).OrderBy(p => p.Displayorder);
                foreach (PrivilegeInfo privilegeInfo in rootPrivilegeInfoList)
                {
                    PrivilegeNode node = new PrivilegeNode(privilegeInfo);
                    PrivilegeTreeNodeList.Add(node);
                    //PrivilegeNodeList.Add(node);
                    CreateChildTree(node);
                }
            }
            IsBusy = false;
        }

        /// <summary>
        /// 创建权限树子节点
        /// </summary>
        /// <param name="pNode"></param>
        private void CreateChildTree(PrivilegeNode pNode)
        {
            IEnumerable<PrivilegeInfo> rootNodeList = _PrivilegeList.Where(p => p.ParentPrivilegeID == pNode.PrivilegeTreeNode.PrivilegeId).OrderBy(p => p.Displayorder);
            foreach (PrivilegeInfo privilegeInfo in rootNodeList)
            {
                PrivilegeNode node = new PrivilegeNode(privilegeInfo);
                if (_accName != "admin" && privilegeInfo.PrivilegeName == "权限管理")
                    continue;
                else
                   pNode.Add(node);
                CreateChildTree(node);
            }
        }
        #endregion

        #region 添加权限
        /// <summary>
        /// 添加权限
        /// </summary>
        public void AddPrivilegeExecute()
        {
            string id = Guid.NewGuid().ToString("n");
            CurPrivilegeInfo = new PrivilegeInfo();
            CurPrivilegeInfo.PrivilegeId = id;
            CurPrivilegeInfo.PrivilegeName = "";
            PrivilegeNode newNode = new PrivilegeNode(CurPrivilegeInfo);
            if (CurPrivilegeNode == null)//添加根级节点
            {
                CurPrivilegeInfo.ParentPrivilegeID = "";
                CurPrivilegeInfo.ParentPrivilegeName = "";
                PrivilegeTreeNodeList.Add(newNode);
            }
            else
            {
                //CurPrivilegeInfo.ParentPrivilegeID = CurPrivilegeNode.Id;
                //CurPrivilegeInfo.ParentPrivilegeName = CurPrivilegeNode.Text;
                //newNode.PID = CurPrivilegeNode.PID;
                CurPrivilegeInfo.ParentPrivilegeID = CurPrivilegeNode.PrivilegeTreeNode.PrivilegeId;
                CurPrivilegeInfo.ParentPrivilegeName = CurPrivilegeNode.PrivilegeTreeNode.PrivilegeName;
                //newNode.PrivilegeTreeNode.ParentPrivilegeID
                CurPrivilegeNode.Children.Add(newNode);
            }
            PrivilegeList.Add(CurPrivilegeInfo);
            newNode.IsNewNode = true;
            CurPrivilegeNode = newNode;
        }
        #endregion

        #region 删除权限
        /// <summary>
        /// 删除权限
        /// </summary>
        public void DelPrivilegeExecute()
        {

            //删除已保存到数据库的数据
            if (CurPrivilegeInfo != null)
            {
                MessageBoxResult result = MessageBox.Show("您确定删除当前权限信息吗？", "删除提示", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (result == MessageBoxResult.OK)
                {
                    string Info = "";
                    //删除新添加还没有保存的数据
                    if (CurPrivilegeNode.IsNewNode)
                    {
                        PrivilegeList.Remove(CurPrivilegeInfo);
                        DelNode();
                    }
                    else
                    {
                        ErrType err = _businessService.DeletePrivileges(_loginID, CurPrivilegeInfo.PrivilegeId);
                        if (err.Err == ERR.SUCCESS)
                        {
                            DelNode();
                        }
                        else
                            MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("您没有选中任何权限节点", "提示信息", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DelNode()
        {
            //删除一级节点
            PrivilegeNode delNode = PrivilegeTreeNodeList.Where(p => p.PrivilegeTreeNode.PrivilegeId == CurPrivilegeNode.PrivilegeTreeNode.PrivilegeId).FirstOrDefault();
            if (delNode != null)
            {
                PrivilegeTreeNodeList.Remove(delNode);
                MessageBox.Show("删除成功！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                foreach (PrivilegeNode node in PrivilegeTreeNodeList)
                {
                    DelCNode(node);
                }
            }
        }
        private void DelCNode(PrivilegeNode pNode)
        {
            foreach (PrivilegeNode node in pNode.Children)
            {
                if (node.PrivilegeTreeNode.PrivilegeId == CurPrivilegeNode.PrivilegeTreeNode.PrivilegeId)
                {
                    pNode.Children.Remove(node);
                    MessageBox.Show("删除成功！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    DelCNode(node);
                }
            }
        }
        #endregion

        #region 保存权限
        /// <summary>
        /// 保存权限
        /// </summary>
        public void SavePrivilegeExecute()
        {
            if (CurPrivilegeNode != null && CurPrivilegeInfo != null)
            {
                //配置为根节点
                if (string.IsNullOrEmpty(CurPrivilegeInfo.ParentPrivilegeName))
                {
                    CurPrivilegeInfo.ParentPrivilegeID = "";
                    CurPrivilegeInfo.ParentPrivilegeName = "";
                }
                else
                {
                    //检查上级权限是否已改变
                    PrivilegeInfo pInfo = PrivilegeList.Where(p => p.ParentPrivilegeName == CurPrivilegeInfo.ParentPrivilegeName).FirstOrDefault();
                    if (pInfo != null)
                    {
                        CurPrivilegeInfo.ParentPrivilegeID = pInfo.ParentPrivilegeID;
                        CurPrivilegeInfo.ParentPrivilegeName = pInfo.ParentPrivilegeName;
                    }
                    else
                    {
                        MessageBox.Show("您指定的上级权限不存在！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                if (CurPrivilegeNode.IsNewNode)//添加权限
                {
                    ErrType err = _businessService.AddPrivileges(_loginID, CurPrivilegeInfo);
                    if (err.Err == ERR.SUCCESS)
                    {
                        MessageBox.Show("保存成功！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
                        CurPrivilegeNode.IsNewNode = false;
                    }
                    else
                        MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else//保存更新
                {
                    ErrType err = _businessService.UpdatePrivileges(_loginID, CurPrivilegeInfo);
                    if (err.Err == ERR.SUCCESS)
                    {
                        MessageBox.Show("保存成功！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        #endregion

        #region 权限树选择项改变事件
        /// <summary>
        /// 权限树选择项改变事件
        /// </summary>
        /// <param name="curNode"></param>
        public void GetCurCurPrivilege(PrivilegeNode curNode)
        {
            if (PrivilegeList != null && curNode != null)
                //CurPrivilegeInfo = PrivilegeList.Where(p => p.PrivilegeId == curNode.PrivilegeTreeNode.PrivilegeId).FirstOrDefault();
                CurPrivilegeInfo = curNode.PrivilegeTreeNode;
        }
        #endregion

        #endregion

        #region 微会员相关
        /// <summary>
        /// 获取父级微会员信息
        /// </summary>
        public void GetPOrgsList()
        {
            if (_POrgList == null)
            {
                _POrgList = new ObservableCollection<OrgInfo>();
               _POrgList.Add(new OrgInfo() { OrgName = string.Empty });
            }


            else
            {
                _POrgList.Clear();

                _POrgList.Add(new OrgInfo() { OrgName = string.Empty });
            }
                
            RaisePropertyChanged("POrgList");
            ErrType err = _businessService.GetBaseOrgListAll(_loginID, ref _POrgList);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            POrgList = _POrgList;
        }

        #region 微会员详细资料
        /// <summary>
        /// 微会员详细资料
        /// </summary>
        private void ShowOrgDetialExecute()
        {
            window = new OrgDetialWindow()
            {
                DataContext = this,
                ParentOrgInfo = POrgList.FirstOrDefault(p => p.OrgID == CurOrgInfo.ParentOrgId),
                Owner = Application.Current.MainWindow,
                IsCanCreateOrgCode=false
            };
            window.ComitEvent += new Action(ShowOrgDetial);
            window.CancelEvent += new Action(window_CancelEvent);
            window.ShowDialog();
            //else
            //{
            //    string id= CurOrgInfo.OrgID;
            //    GetOrgsListExecute();
            //    CurOrgInfo = OrgList.Where(p => p.OrgID == id).FirstOrDefault();
            //}
                
        }

        void window_CancelEvent()
        {
            string id = CurOrgInfo.OrgID;
            GetOrgsListExecute();
            CurOrgInfo = OrgList.Where(p => p.OrgID == id).FirstOrDefault();
            window.Close();
        }
 
        private void ShowOrgDetial()
        {
            if (window.ParentOrgInfo != null)
            {
                CurOrgInfo.ParentOrgId = window.ParentOrgInfo.OrgID;//给父级会员ID赋值
                CurOrgInfo.ParentOrgName = window.ParentOrgInfo.OrgName;
            }
            if (CurOrgInfo.ParentOrgId == CurOrgInfo.OrgID)
            {
                MessageBox.Show("不能选择自身的会员作为上级会员", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ErrType err = _businessService.UpdateOrg(_loginID, CurOrgInfo);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                //修改微会员下拉数据源
                string id = CurOrgInfo.OrgID;
                GetOrgsListExecute();
                CurOrgInfo = OrgList.Where(p => p.OrgID == id).FirstOrDefault();
                window.Close();
            }
        }
        #endregion

        #region 添加微会员

        private OrgDetialWindow window;
        /// <summary>
        /// 添加微会员
        /// </summary>
        private void AddOrgExecute()
        {
            CurOrgInfo = new OrgInfo();
            CurOrgInfo.OrgID = Guid.NewGuid().ToString("n");
            CurOrgInfo.ParentOrgId = "";
            CurOrgInfo.CardType = CeritificateEnum.ID;

          
            window = new OrgDetialWindow()
                                         {
                                             POrgList = this.POrgList,
                                             DataContext = this,
                                             Owner = Application.Current.MainWindow,
                                             IsCanCreateOrgCode=true
                                         };
            window.ComitEvent += new Action(AddOrg);

            window.ShowDialog() ;
        }


        private void AddOrg()
        {
            CurOrgInfo.AddTime = DateTime.Now.ToString();
            if (string.IsNullOrEmpty(CurOrgInfo.ParentOrgName))
            {
                CurOrgInfo.ParentOrgId = "";
                CurOrgInfo.ParentOrgName = "";
            }
            if (window.ParentOrgInfo != null)
            {
                CurOrgInfo.ParentOrgId = window.ParentOrgInfo.OrgID;//给父级会员ID赋值
                CurOrgInfo.ParentOrgName = window.ParentOrgInfo.OrgName;
            }


            ErrType err = _businessService.AddOrg(_loginID, CurOrgInfo);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            OrgList.Add(CurOrgInfo);
            if (POrgList.Where(p => p.OrgName == CurOrgInfo.OrgName).Count() == 0)
            {
                OrgInfo item = new OrgInfo() { OrgID = CurOrgInfo.OrgID, OrgName = CurOrgInfo.OrgName, TelePhone = CurOrgInfo.TelePhone };
                POrgList.Add(item);
            }
            ErrType err2= _businessService.CreateOrgTicket(CurOrgInfo.OrgID);
            if (err2.Err == ERR.ERROR)
                MessageBox.Show("生成二维码失败！请联系管理员", "提示信息");
            window.Close();
        }

        /// <summary>
        /// 创建微会员代码
        /// </summary>
        public void CreateOrgCodeExecute()
        {
            string code = "";
            if (window.ParentOrgInfo!=null)
            {
                OrgInfo info = POrgList.FirstOrDefault(p => p.OrgID == window.ParentOrgInfo.OrgID);
                ErrType err = _businessService.GetOrgcode(info.OrgID, info.TelePhone, ref code);
                if (err.Err != ERR.SUCCESS)
                {
                    MessageBox.Show("生成微会员编码出错，请重试！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                CurOrgInfo.TelePhone = code; 
            }
        }
        private bool CareateOrgCodeCanExecute()
        {
            return CurOrgInfo!=null;
        }
        #endregion

        #region 删除微会员
        /// <summary>
        /// 删除微会员
        /// </summary>
        private void DeleteOrgCommandExecute()
        {
            MessageBoxResult result = MessageBox.Show("您确定删除当前选中的微会员信息？", "提示信息", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                ErrType err = _businessService.DeleteOrg(_loginID, CurOrgInfo.OrgID, CurOrgInfo.OrgName);
                if (err.Err == ERR.SUCCESS)
                {
                    MessageBox.Show("删除成功！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
                    POrgList.Remove(POrgList.Where(p => p.OrgID.ToString() == CurOrgInfo.OrgID).FirstOrDefault());
                    //OrgList.Remove(CurOrgInfo);
                    OrgList.Remove(OrgList.Where(p => p.OrgID == CurOrgInfo.OrgID).FirstOrDefault());
                    
                    return;
                }
                else
                {
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        #endregion

        #region 获取微会员信息
        public bool CanGetOrgsListExecute { get; set; }
        /// <summary>
        /// 获取微会员信息
        /// </summary>
        public void GetOrgsListExecute()
        {
            if (CanGetOrgsListExecute== false)
            {
                return;
            }
          
            int pageCount = 0;
            if (_OrgList == null)
                _OrgList = new ObservableCollection<OrgInfo>();
            else
                _OrgList.Clear();
            OrgInfo selOrgInfo = new OrgInfo();
            selOrgInfo.OrgName = OrgSelectCondition.Account;
            //selOrgInfo.CardType;
            selOrgInfo.CardNum = OrgSelectCondition.CardNum;
            selOrgInfo.Reperson = OrgSelectCondition.UserName;
            ErrType err = _businessService.GetOrgList(_loginID, selOrgInfo, OrgSelectCondition.PageIndex,
                                                      OrgSelectCondition.PageSize, ref pageCount, ref _OrgList);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            OrgList = _OrgList;
            OrgSelectCondition.PageCount = pageCount;
        }
        #endregion

        #region 会员账户绑定微会员
        public void BindingOrgExecute(ClientAccount selCaaount)
        {
            if (OrgList == null || OrgList.Count == 0)
                GetOrgsListExecute();
            BindingOrgWindow window = new BindingOrgWindow()
                                          {
                                              DataContext = this,
                                              Owner = Application.Current.MainWindow
                                          };
            if (window.ShowDialog() == true)
            {

            }
        }
        #endregion

        #region 显示微会员二维码
        /// <summary>
        /// 显示微会员二维码
        /// </summary>
        public void ShowOrgTicket()
        {
            string url = "";
            ErrType err = _tradeService.GetOrgTicketUrl(_loginID, CurOrgInfo.OrgID, ref url);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                long fileLength = 0;
                WebRequest webReq = WebRequest.Create(url);
                WebResponse webRes = webReq.GetResponse();
                fileLength = webRes.ContentLength;
                Stream srm = webRes.GetResponseStream();
                byte[] bufferbyte = new byte[fileLength];
                int allByte = (int)bufferbyte.Length;
                int startByte = 0;
                while (fileLength > 0)
                {
                    int downByte = srm.Read(bufferbyte, startByte, allByte);
                    if (downByte == 0)
                    { break; };
                    startByte += downByte;
                    allByte -= downByte;
                }

                BitmapImage image = new BitmapImage();
                //以流的形式初始化图片                                                                                                 
                image.BeginInit();
                image.StreamSource = new MemoryStream(bufferbyte);
                image.EndInit();
                OrgTicketWindow win = new OrgTicketWindow();
                win.ShowImage(image);
                win.ShowDialog();
                srm.Close();
                webRes.Close();
            }
        } 
        #endregion

        #endregion

     
        #region 新闻公告相关
        #region 获取新闻公告数据
        /// <summary>
        /// 获取新闻公告数据
        /// </summary>
        public void GetNewsListExecute()
        {
            int pageCount = 0;
            if (_NewsList == null)
                _NewsList = new ObservableCollection<NewsInfo>();
            else
                _NewsList.Clear();
            //界面设置为默认选中“全部”，所以type不可能为空
            NewsTypeEnum type = (NewsTypeEnum)Enum.Parse(typeof(NewsTypeEnum), GetNewsCondition.NewsType);
            ErrType err = _tradeService.GetTradeNewsInfoWithPage(_loginID, GetNewsCondition.StartTime,
                GetNewsCondition.EndTime.AddDays(1), type, GetNewsCondition.PageIndex, GetNewsCondition.PageSize, ref pageCount, ref _NewsList);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            NewsList = new ObservableCollection<NewsInfo>(_NewsList.Where(p => p.NType != NewsTypeEnum.理财师说));
            GetNewsCondition.PageCount = pageCount;
        } 
        #endregion

        #region 编辑新闻公告
        /// <summary>
        /// 编辑新闻公告
        /// </summary>
        private void EditNewsExecute()
        {
            NewsWindows window = new NewsWindows()
            {
                DataContext = this,
                Owner = Application.Current.MainWindow,
                NewsAddress=ConnectConfigData.NewsAddOrEdit+"?Account="+_accName+"&LoginId="+_loginID+"&ID="+CurNewsInfo.ID
            };
            
            window.Closed += (e, v) =>
            {
                GetNewsListExecute();
            };
            window.ShowDialog();
            //window.NewsContent = CurNewsInfo.NewsContent;
            //if (window.ShowDialog() == true)
            //{
            //    CurNewsInfo.NewsContent = window.NewsContent;
            //    ErrType err = _businessService.ModifyTradeNews(CurNewsInfo,_loginID);
            //    if (err.Err != ERR.SUCCESS)
            //    {
            //        MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            //        GetNewsListExecute();
            //    }
            //}
        }
        #endregion

        #region 添加新闻公告
        /// <summary>
        /// 添加新闻公告
        /// </summary>
        private void AddNewsExecute()
        {
            //CurNewsInfo = new NewsInfo();
            //CurNewsInfo.ID = Guid.NewGuid().ToString("n");
            //CurNewsInfo.NType = NewsTypeEnum.新闻;
            //CurNewsInfo.PubPerson = _accName;
            NewsWindows window = new NewsWindows()
            {
                DataContext = this,
                Owner = Application.Current.MainWindow,
                NewsAddress = ConnectConfigData.NewsAddOrEdit + "?Account=" + _accName + "&LoginId=" + _loginID
            };
            
            window.Closed += (e, v) =>
            {
                GetNewsListExecute();
            };
            window.ShowDialog();
            //if (window.ShowDialog() == true)
            //{
            //    CurNewsInfo.PubTime = DateTime.Now;
            //    CurNewsInfo.NewsContent = window.NewsContent;
            //    ErrType err = _businessService.AddTradeNews(CurNewsInfo,_loginID);
            //    if (err.Err != ERR.SUCCESS)
            //    {
            //        MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            //        return;
            //    }
            //    NewsList.Add(CurNewsInfo);
            //}
        }
        #endregion

        #region 删除新闻公告
        /// <summary>
        /// 删除新闻公告
        /// </summary>
        private void DelNewsExecute()
        {
            MessageBoxResult result = MessageBox.Show("您确定删除当前选中的记录？", "提示信息", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                ErrType err = _businessService.DelTradeNews(CurNewsInfo.ID,_loginID);
                if (err.Err == ERR.SUCCESS)
                {
                    MessageBox.Show("删除成功！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
                    NewsList.Remove(CurNewsInfo);
                    return;
                }
                else
                {
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        #endregion
        #endregion

        #region 现财师说相关
        #region 获取现财师说数据
        /// <summary>
        /// 获取现财师说数据
        /// </summary>
        public void GetArticlesListExecute()
        {
            int pageCount = 0;
            if (_ArtilesList == null)
                _ArtilesList = new ObservableCollection<NewsInfo>();
            else
                _ArtilesList.Clear();
            //界面设置为默认选中“全部”，所以type不可能为空
            NewsTypeEnum type = (NewsTypeEnum)Enum.Parse(typeof(NewsTypeEnum), GetArticlesCondition.NewsType);
            ErrType err = _tradeService.GetTradeNewsInfoWithPage(_loginID, GetArticlesCondition.StartTime,
                GetArticlesCondition.EndTime.AddDays(1), type, GetArticlesCondition.PageIndex, GetArticlesCondition.PageSize, ref pageCount, ref _ArtilesList);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ArtilesList = new ObservableCollection<NewsInfo>(_ArtilesList.Where(p => p.NType == NewsTypeEnum.理财师说));
            GetArticlesCondition.PageCount = pageCount;
        }
        #endregion

        #region 编辑现财师说
        /// <summary>
        /// 编辑现财师说
        /// </summary>
        private void EditArticlesExecute()
        {
            NewsWindows window = new NewsWindows()
            {
                DataContext = this,
                Owner = Application.Current.MainWindow,
                NewsAddress = ConnectConfigData.ArticlesAddOrEdit + "?Account=" + _accName + "&LoginId=" + _loginID + "&ID=" + CurArticlesInfo.ID
            };

            window.Closed += (e, v) =>
            {
                GetArticlesListExecute();
            };
            window.ShowDialog();
            //window.NewsContent = CurNewsInfo.NewsContent;
            //if (window.ShowDialog() == true)
            //{
            //    CurNewsInfo.NewsContent = window.NewsContent;
            //    ErrType err = _businessService.ModifyTradeNews(CurNewsInfo,_loginID);
            //    if (err.Err != ERR.SUCCESS)
            //    {
            //        MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            //        GetNewsListExecute();
            //    }
            //}
        }
        #endregion

        #region 添加现财师说
        /// <summary>
        /// 添加现财师说
        /// </summary>
        private void AddArticlesExecute()
        {
            //CurNewsInfo = new NewsInfo();
            //CurNewsInfo.ID = Guid.NewGuid().ToString("n");
            //CurNewsInfo.NType = NewsTypeEnum.新闻;
            //CurNewsInfo.PubPerson = _accName;
            NewsWindows window = new NewsWindows()
            {
                DataContext = this,
                Owner = Application.Current.MainWindow,
                NewsAddress = ConnectConfigData.ArticlesAddOrEdit + "?Account=" + _accName + "&LoginId=" + _loginID
            };

            window.Closed += (e, v) =>
            {
                GetArticlesListExecute();
            };
            window.ShowDialog();
        }
        #endregion

        #region 删除现财师说
        /// <summary>
        /// 删除现财师说
        /// </summary>
        private void DelArticlesExecute()
        {
            MessageBoxResult result = MessageBox.Show("您确定删除当前选中的记录？", "提示信息", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                ErrType err = _businessService.DelTradeNews(CurArticlesInfo.ID, _loginID);
                if (err.Err == ERR.SUCCESS)
                {
                    MessageBox.Show("删除成功！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
                    ArtilesList.Remove(CurArticlesInfo);
                    return;
                }
                else
                {
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        #endregion
        #endregion

        #region 历史数据
        private ObservableCollection<string> cycleSource = new ObservableCollection<string>() {  "M1","M5","M15","M30","H1","H4","D1","W1","MN"};

        public ObservableCollection<string> CycleSource
        {
            get { return cycleSource; }
            set
            {
                cycleSource = value;
                RaisePropertyChanged("CycleSource");
            }
        }

        private SelectCondition _GetHistoryDataCondition = new SelectCondition();
        /// <summary>
        /// 历史数据查询条件
        /// </summary>
        public SelectCondition GetHistoryDataCondition
        {
            get { return _GetHistoryDataCondition; }
            private set
            {
                _GetHistoryDataCondition = value;
                RaisePropertyChanged("GetHistoryDataCondition"); 
            }
        }
        private ObservableCollection<HisData>  hisDataLst=new ObservableCollection<HisData>();

        public ObservableCollection<HisData>  HisDataLst
        {
            get { return hisDataLst; }
            set
            {
                hisDataLst = value;
                RaisePropertyChanged("HisDataLst");
            }
        }
        private HisData curHisData;
        /// <summary>
        /// 历史数据当前选中项
        /// </summary>
        public HisData CurHisData
        {
            get { return curHisData; }
            set
            {
                curHisData = value;
                RaisePropertyChanged("CurHisData");
            }
        }

        private int hisDataPage;

        public int HisDataPage
        {
            get { return hisDataPage; }
            set
            {
                hisDataPage = value;
                RaisePropertyChanged("HisDataPage");
            }
        }

        #region 历史数据查询
        private ICommand getHisDatasCommand;
        /// <summary>
        /// 查询历史数据命令
        /// </summary>
        public ICommand GetHisDatasCommand
        {
            get
            {
                if (getHisDatasCommand == null)
                    getHisDatasCommand = new RelayCommand(GetHisDatasCommandEX, GetHisDatasCommandCanEX);
                return getHisDatasCommand;
            }
        }

        /// <summary>
        /// 查询历史数据
        /// </summary>
        public void GetHisDatasCommandEX()
        {
            if (string.IsNullOrWhiteSpace(GetHistoryDataCondition.ProductNumber) || string.IsNullOrWhiteSpace(GetHistoryDataCondition.Cycle))
            {
                return;
            }
            hisDataLst.Clear();
            CurHisData = null;
            try
            {
                _tradeService.GetHistoryDataInfoWithPage(_loginID, GetHistoryDataCondition.weektime, GetHistoryDataCondition.StartTime, GetHistoryDataCondition.EndTime, GetHistoryDataCondition.ProductNumber, GetHistoryDataCondition.Cycle,
                    GetHistoryDataCondition.PageIndex, GetHistoryDataCondition.PageSize, ref hisDataPage, ref hisDataLst);

                foreach (var item in HisDataLst)
                {
                    item.ProductCod = GetHistoryDataCondition.ProductNumber;
                    item.Cycle = GetHistoryDataCondition.Cycle;
                }
                GetHistoryDataCondition.PageCount = hisDataPage;
            }
            catch (Exception)
            {

                MessageBox.Show("获取历史数据失败");
            }
        }
        /// <summary>
        /// 查询历史数据命令是否可以
        /// </summary>
        /// <returns></returns>
        private bool GetHisDatasCommandCanEX()
        {
         
            if (string.IsNullOrWhiteSpace(GetHistoryDataCondition.ProductNumber) ||string.IsNullOrWhiteSpace(GetHistoryDataCondition.Cycle) )
            {
               return  false;
            }
            else
            {
                return  true;
            }
        }
        #endregion
        #region 历史数据修改
        private ICommand alterHisDatasCommand;
        /// <summary>
        /// 修改历史数据
        /// </summary>
        public ICommand AlterHisDatasCommand
        {
            get
            {
                if (alterHisDatasCommand == null)
                    alterHisDatasCommand = new RelayCommand(AlterHisDatasCommandEX, AlterHisDatasCommandCanEX);
                return alterHisDatasCommand;
            }
        }
       /// <summary>
       /// 修改了历史数据
       /// </summary>
        public void AlterHisDatasCommandEX()
        {
            HistoryDataSetWindow win = new HistoryDataSetWindow(CurHisData) { };
            win.ShowDialog();
            if (win.DialogResult == true)
            {
                var result = _tradeService.ModifyHisData(win.HistoryData, win.HistoryData.ProductCod, win.HistoryData.Cycle);
              if (result.Err == ERR.ERROR)
              {
                  MessageBox.Show("修改历史数据失败");
              }
              else
              {
                  MessageBox.Show("操作成功");
                  
              }
            }
            GetHisDatasCommandEX();//刷新数据
        }
        private bool AlterHisDatasCommandCanEX()
        {
            if (CurHisData ==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        #endregion

        #region 修改密码
        public void ModifyPassword()
        {
            ModifyPasswordWindow window = new ModifyPasswordWindow()
            {
                DataContext = this,
                Owner = Application.Current.MainWindow,
            };
            if (window.ShowDialog() == true)
            {
                if (window.PasswordType == PASSWORD_TYPE.Trade)
                    ModifyLoginPassword(window.OldPassword, window.NewPassword);
                else
                    ModifyFundsPassword(window.OldPassword, window.NewPassword);
            }
        }

        /// <summary>
        /// Modify login password
        /// </summary>
        /// <param name="oldPassword">old password</param>
        /// <param name="newPassword">new password</param>
        private void ModifyLoginPassword(string oldPassword, string newPassword)
        {
            ErrType err = _tradeService.ModifyLoginPassword(_loginID, oldPassword, newPassword);
            if (err != GeneralErr.Success)
            {
                MessageBox.Show("修改密码失败", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
               
            }
            else
            {
                MessageBox.Show("修改密码成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Modify funds password
        /// </summary>
        /// <param name="oldPassword">old password</param>
        /// <param name="newPassword">new password</param>
        private void ModifyFundsPassword(string oldPassword, string newPassword)
        {
            ErrType err = _tradeService.ModifyFundsPassword(_loginID, oldPassword, newPassword);
            if (err == GeneralErr.Success)
            {
                MessageBox.Show("修改密码成功", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("修改密码失败", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            
            }
        }
        #endregion 

        #region 获取所有的银行类型

        private ObservableCollection<Bank> _Banks;
        /// <summary>
        /// 银行列表
        /// </summary>
        public ObservableCollection<Bank> Banks
        {
            get { return _Banks; }
            set
            {
                _Banks = value;
                RaisePropertyChanged("Banks");
            }
        }

        /// <summary>
        /// 获取所有的银行类型
        /// </summary>
        private void GetBanks()
        {
            if (Banks == null)
            {
                Banks = new ObservableCollection<Bank>();
            }
            _businessService.GetTradeBank(Banks);
            Bank.BankLst = Banks;
        }
        #endregion
    }
}
