using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Gss.Entities;
using Gss.PopUpWindow.DataManager;

namespace Gss.PopUpWindow {
    /// <summary>
    /// ProductInfoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ProductInfoWindow : Window {
        public ProductInfoWindow( ) {
            InitializeComponent( );
        }

        public static readonly DependencyProperty RawMaterialsCodeListProperty =
DependencyProperty.Register("RawMaterialsCodeList", typeof(List<string>), typeof(ProductInfoWindow), new UIPropertyMetadata(null));

        /// <summary>
        /// 产品行情列表
        /// </summary>
        public List<string> RawMaterialsCodeList
        {
            get { return (List<string>)GetValue(RawMaterialsCodeListProperty); }
            set { SetValue(RawMaterialsCodeListProperty, value); }
        }

        public static readonly DependencyProperty IsNewProperty =
DependencyProperty.Register("IsNew", typeof(bool), typeof(ProductInfoWindow), new UIPropertyMetadata(false));

        /// <summary>
        /// 是否新增
        /// </summary>
        public bool IsNew
        {
            get { return (bool)GetValue(IsNewProperty); }
            set { SetValue(IsNewProperty, value); }
        }

        private void CommandBinding_Executed_Ok( object sender, ExecutedRoutedEventArgs e ) {
            if (string.IsNullOrEmpty(this.TbName.Text))
            {
                MessageBox.Show("商品名称不能为空","提示");
                return;
            }
            DialogResult = true;
        
            Close( );
        }

        private void CommandBinding_CanExecute_Ok( object sender, CanExecuteRoutedEventArgs e ) {
            if( IsInitialized ){
                ProductInformation productInfo = DataContext as ProductInformation;
                if (productInfo != null && !string.IsNullOrEmpty(productInfo.ProductCode) &&
                    !string.IsNullOrEmpty(productInfo.ProductName) && !string.IsNullOrEmpty(productInfo.StockCode))
                {
                    e.CanExecute = productInfo.ProductCode.Length > 0 && productInfo.ProductName.Length > 0 &&
                                   productInfo.StockCode.Length > 0;
                }
                else
                    e.CanExecute = false;
            }
        }

        private void CommandBinding_Executed_Cancel( object sender, ExecutedRoutedEventArgs e ) {
            Close( );
        }
    }
}
