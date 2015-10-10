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
using System.Windows.Shapes;
using Gss.Entities;

namespace Gss.PopUpWindow {
    /// <summary>
    /// ClientFundsInfoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ClientFundsInfoWindow : Window {
        public ClientFundsInfoWindow( ) {
            InitializeComponent( );
        }

        public ClientFundsInfoWindow(bool IsCanAlter)
        {
            InitializeComponent();
            if (IsCanAlter)
            {
                BtnOkVisibility = Visibility.Visible;
            }
            else
            {
                BtnOkVisibility = Visibility.Collapsed;
            }
        }

        private void CommandBinding_Executed_Ok( object sender, ExecutedRoutedEventArgs e )
        {
            FundsInformation fi = this.DataContext as FundsInformation;
            if (fi.DongJieMoney > fi.CurrentBalance)
            {
                MessageBox.Show("冻结资金不能超过账户余额","提示");
                return;
            }

            DialogResult = true;
            Close( );
        }

        private void CommandBinding_Executed_Cancel( object sender, ExecutedRoutedEventArgs e ) {
            Close( );
        }


        public Visibility BtnOkVisibility
        {
            get { return (Visibility)GetValue(BtnOkVisibilityProperty); }
            set { SetValue(BtnOkVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BtnOkVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BtnOkVisibilityProperty =
            DependencyProperty.Register("BtnOkVisibility", typeof(Visibility), typeof(ClientFundsInfoWindow), new UIPropertyMetadata(Visibility.Collapsed));


    }
}
