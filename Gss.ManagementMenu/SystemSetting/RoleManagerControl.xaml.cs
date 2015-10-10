using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gss.Entities.JTWEntityes;
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu.SystemSetting
{
    /// <summary>
    /// RoleManagerControl.xaml 的交互逻辑
    /// </summary>
    public partial class RoleManagerControl : UserControl
    {
        public RoleManagerControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(RoleManagerControl_Loaded);
        }

        private ManagementViewModel vm;
        void RoleManagerControl_Loaded(object sender, RoutedEventArgs e)
        {
            vm = this.DataContext as ManagementViewModel;
            vm.GetAllRoles();
            vm.GetPrivileges();
        }

        private void ContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            ContextMenu cMenu = sender as ContextMenu;
            cMenu.DataContext = DataContext;
            if (cMenu.HasItems && cMenu.Items != null)
            {
                foreach (Control item in cMenu.Items)
                {
                    if (item is MenuItem && item.Visibility == Visibility.Visible)
                        return;
                }
            }
            cMenu.Visibility = Visibility.Collapsed;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid != null && vm!=null)
            {
                vm.GetRolePrivileges();
            }
            
        }
    }
}
