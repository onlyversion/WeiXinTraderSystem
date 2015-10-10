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
using Gss.ViewModel.Management;
using Gss.ManagementMenu.CustomControl;

namespace Gss.ManagementMenu.AccountManager.Org
{
    /// <summary>
    /// OrgManagerControl.xaml 的交互逻辑
    /// </summary>
    public partial class OrgManagerControl : UserControl
    {
        public OrgManagerControl()
        {
            InitializeComponent();
            this.Loaded += (e, v) =>
            {
                vm = this.DataContext as ManagementViewModel;
                //vm.GetOrgsListExecute();
            };
        }

        private ManagementViewModel vm;
        void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
            vm.GetOrgsListExecute();
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

        private void CommandBinding_CanExecute_RolePrivilege(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_RolePrivilege(object sender, ExecutedRoutedEventArgs e)
        {
            vm.ConfigRolePrivilegeEx();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AutoComboBoxState sf = this.ACB_Search.State;
            if (sf == AutoComboBoxState.AlterState)
            {
                vm.CanGetOrgsListExecute = false;
                MessageBox.Show("请选择正确的会员名称！");
            }
            else
            {
                vm.CanGetOrgsListExecute = true;
            }
        }

        private void CommandBinding_Executed_OrgTicket(object sender, ExecutedRoutedEventArgs e)
        {
            vm.ShowOrgTicket();
        }

        private void CommandBinding_Executed_SetCommissionRatio(object sender, ExecutedRoutedEventArgs e)
        {
            vm.SetCommissionRatio(1);
        }

        private void CommandBinding_Executed_SetDefaultCommissionRatio(object sender, ExecutedRoutedEventArgs e)
        {
            vm.SetCommissionRatio(2);
        }

        private void CommandBinding_Executed_SetAllCommissionRatio(object sender, ExecutedRoutedEventArgs e)
        {
            vm.SetCommissionRatio(3);
        }

       
    }
}
