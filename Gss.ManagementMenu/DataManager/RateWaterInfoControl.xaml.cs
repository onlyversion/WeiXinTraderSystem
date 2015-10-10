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

namespace Gss.ManagementMenu.DataManager {
    /// <summary>
    /// RateWaterInfoControl.xaml 的交互逻辑
    /// </summary>
    public partial class RateWaterInfoControl : UserControl {
        public RateWaterInfoControl( ) {
            InitializeComponent( );
        }

        private void DataGridRow_MouseDoubleClick( object sender, MouseEventArgs e ) {
            ManagementViewModel vm = DataContext as ManagementViewModel;

            ExchangeRateWaterInformation selectedRateWaterInfo = ( e.Source as DataGridRow ).DataContext as ExchangeRateWaterInformation;
            vm.ShowRateWaterInfo( selectedRateWaterInfo );
        }

        private void UserControl_Loaded( object sender, RoutedEventArgs e ) {
            ManagementViewModel vm = DataContext as ManagementViewModel;

            if( vm.RateWaterInfoes == null )
                vm.RefreshRateWaterInfoListExecuted( );
        }

        private void CommandBinding_Executed_ViewDetail( object sender, ExecutedRoutedEventArgs e ) {
            ManagementViewModel vm = DataContext as ManagementViewModel;

            ExchangeRateWaterInformation selectedRateWaterInfo = (e.OriginalSource as DataGridRow).DataContext as ExchangeRateWaterInformation;
            vm.ShowRateWaterInfo( selectedRateWaterInfo );
        }

        private void CommandBinding_Executed_Refresh(object sender, ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            vm.RefreshRateWaterInfoListExecuted();
        }
    }
}
