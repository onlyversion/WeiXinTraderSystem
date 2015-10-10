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
using Gss.Entities;
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu.SystemSetting {
    /// <summary>
    /// IPAddrFilterControl.xaml 的交互逻辑
    /// </summary>
    public partial class IPAddrFilterControl : UserControl {
        public IPAddrFilterControl( ) {
            InitializeComponent( );
        }

        private void CommandBinding_Executed_ViewDetail( object sender, ExecutedRoutedEventArgs e ) {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;

            IPAddressFilterInformation selectedIPFilter = (e.OriginalSource as DataGridRow).DataContext as IPAddressFilterInformation;
            vm.ShowIPAddressFilterInfo( selectedIPFilter );
        }

        private void CommandBinding_Executed_Delete( object sender, ExecutedRoutedEventArgs e ) {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;

            IPAddressFilterInformation selectedIPFilter = (e.OriginalSource as DataGridRow).DataContext as IPAddressFilterInformation;
            vm.DeleteIPAddressFilterInfo( selectedIPFilter );
        }

        private void DataGridRow_MouseDoubleClick( object sender, MouseEventArgs e ) {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;

            IPAddressFilterInformation selectedIPFilter = ( e.Source as DataGridRow ).DataContext as IPAddressFilterInformation;
            vm.ShowIPAddressFilterInfo( selectedIPFilter );
        }

        private void UserControl_Loaded( object sender, RoutedEventArgs e ) {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;

            if( vm.IPAddrFilterInfoes == null ) {
                vm.RefreshIPAddrFilterListExecute( );
            }
        }

        private void CommandBinding_Executed_Add(object sender, ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            vm.AddIPAddrFilterInfoExecute();
        }

        private void CommandBinding_Executed_Refresh(object sender, ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            vm.RefreshIPAddrFilterListExecute();
        }
    }
}
