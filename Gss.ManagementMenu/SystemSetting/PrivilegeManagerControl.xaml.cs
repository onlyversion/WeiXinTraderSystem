using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Gss.Entities.JTWEntityes;
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu.SystemSetting
{
    /// <summary>
    /// 功能：权限管理
    /// 创建人：马友春
    /// 创建暗：2013年12月25日
    /// </summary>
    public partial class PrivilegeManagerControl : UserControl
    {
        public PrivilegeManagerControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(PrivilegeManagerControl_Loaded);
        }

        private ManagementViewModel vm;
        void PrivilegeManagerControl_Loaded(object sender, RoutedEventArgs e)
        {
            vm = this.DataContext as ManagementViewModel;
            vm.GetPrivileges();
            
        }

        private void TreeViewMain_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (TreeViewMain != null)
            {
                PrivilegeNode selNode = TreeViewMain.SelectedItem as PrivilegeNode;
                vm.CurPrivilegeNode = selNode;
                vm.GetCurCurPrivilege(selNode);
            }
        }

        private void imgRefresh_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vm.GetPrivileges();
        }
    }
}
　　
