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
    /// MACFilterControl.xaml 的交互逻辑
    /// </summary>
    public partial class MACFilterControl : UserControl {
        public MACFilterControl( ) {
            InitializeComponent( );
        }

        private void CommandBinding_Executed_ViewDetail( object sender, ExecutedRoutedEventArgs e ) {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;

            MACFilterInformation selectedMACFilter = (e.OriginalSource as DataGridRow).DataContext as MACFilterInformation;
            vm.ShowMACFilterInfo( selectedMACFilter );
        }

        private void CommandBinding_Executed_Delete( object sender, ExecutedRoutedEventArgs e ) {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;

            MACFilterInformation selectedMACFilter = (e.OriginalSource as DataGridRow).DataContext as MACFilterInformation;
            vm.DeleteMACFilterInfo( selectedMACFilter );
        }

        private void DataGridRow_MouseDoubleClick( object sender, MouseEventArgs e ) {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;

            MACFilterInformation selectedMACFilter = ( e.Source as DataGridRow ).DataContext as MACFilterInformation;
            vm.ShowMACFilterInfo( selectedMACFilter );
        }

        private void UserControl_Loaded( object sender, RoutedEventArgs e ) {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;

            if( vm.MACFilterInfoes == null ) {
                vm.RefreshMACFilterListExecute( );
            }
        }

        private void CommandBinding_Executed_Add(object sender, ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            vm.AddMACFilterInfoExecute();
        }

        private void CommandBinding_Executed_Refresh(object sender, ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            vm.RefreshMACFilterListExecute();
        }
    }
}
