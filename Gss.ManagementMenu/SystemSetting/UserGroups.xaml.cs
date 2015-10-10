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

namespace Gss.ManagementMenu.SystemSetting
{
    /// <summary>
    /// UserGroups.xaml 的交互逻辑
    /// </summary>
    public partial class UserGroups : UserControl
    {
        ManagementViewModel ViewModel;
        public UserGroups()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(UserGroups_Loaded);
        }

        void UserGroups_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel = this.DataContext as ManagementViewModel;
            if (ViewModel != null)
            {
                ViewModel.GetUserGroupsEx();
            }
        }

        void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            vm.GetAccountsByGroupEx();
        }
    }
}
