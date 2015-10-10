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
    /// ProductInfoControl.xaml 的交互逻辑
    /// </summary>
    public partial class ProductInfoControl : UserControl {
        public ProductInfoControl( ) {
            InitializeComponent( );
        }

        private void CommandBinding_Executed_ViewDetail( object sender, ExecutedRoutedEventArgs e ) {
            ManagementViewModel vm = DataContext as ManagementViewModel;

            ProductInformation selectedProduct = (e.OriginalSource as DataGridRow).DataContext as ProductInformation;
            vm.ShowProductInfo( selectedProduct );
        }

        private void CommandBinding_Executed_Delete( object sender, ExecutedRoutedEventArgs e ) {
            ManagementViewModel vm = DataContext as ManagementViewModel;

            ProductInformation selectedProduct = (e.OriginalSource as DataGridRow).DataContext as ProductInformation;
            vm.DeleteProductInfo( selectedProduct );
        }

        private void DataGridRow_MouseDoubleClick( object sender, MouseEventArgs e ) {
            ManagementViewModel vm = DataContext as ManagementViewModel;

            ProductInformation selectedProduct = ( e.Source as DataGridRow ).DataContext as ProductInformation;
            vm.ShowProductInfo( selectedProduct );
        }

        private void UserControl_Loaded( object sender, RoutedEventArgs e ) {
            //todo:此处无需再次加载数据
            //ManagementViewModel vm = DataContext as ManagementViewModel;

            //if( vm.ProductInfoes == null )
            //    vm.RefreshProductInfoListExecute( );
        }

        private void CommandBinding_Executed_ManualPrice(object sender, ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            ProductInformation selectedProduct = (e.OriginalSource as DataGridRow).DataContext as ProductInformation;
            vm.ManualPrice(selectedProduct);
        }

        private void CommandBinding_Executed_Add(object sender, ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            vm.AddProductInfoExecute();
        }

        private void CommandBinding_Executed_Refresh(object sender, ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            vm.RefreshProductInfoListExecute();
        }
    }
}
