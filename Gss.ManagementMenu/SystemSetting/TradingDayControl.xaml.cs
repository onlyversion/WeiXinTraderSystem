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
using Gss.Entities;

namespace Gss.ManagementMenu.SystemSetting {
    /// <summary>
    /// TradingDay.xaml 的交互逻辑
    /// </summary>
    public partial class TradingDayControl {
        public TradingDayControl( ) {
            InitializeComponent( );
        }

        private void CommandBinding_Executed_ViewDetail( object sender, ExecutedRoutedEventArgs e ) {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;

            TradingDayInformation selectedOne = (e.OriginalSource as DataGridRow).DataContext as TradingDayInformation;
            vm.ShowTradingDayInfo( selectedOne );
        }

        private void DataGridRow_MouseDoubleClick( object sender, MouseEventArgs e ) {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;

            TradingDayInformation selectedOne = ( e.Source as DataGridRow ).DataContext as TradingDayInformation;
            vm.ShowTradingDayInfo( selectedOne );
        }

        private void UserControl_Loaded( object sender, RoutedEventArgs e ) {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;

            if( vm.TradingDayInfoes == null ) {
                vm.RefreshTradingDayInfoExecute( );
            }
        }

        private void CommandBinding_Executed_Refresh(object sender, ExecutedRoutedEventArgs e)
        {
             ManagementViewModel vm = this.DataContext as ManagementViewModel;
             vm.GetTradingDayInfo();
        }

    }
}
