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
    /// HolidayInfoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HolidayInfoWindow : Window {
        public HolidayInfoWindow( ) {
            InitializeComponent( );
            this.sp.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void CommandBinding_Executed_Ok( object sender, ExecutedRoutedEventArgs e ) {
            DialogResult = true;
            Close( );
        }

        private void CommandBinding_CanExecute_Ok( object sender, CanExecuteRoutedEventArgs e ) {
            if( IsInitialized )
                e.CanExecute = TbHoliday.Text.Length > 0;
        }

        private void CommandBinding_Executed_Cancel( object sender, ExecutedRoutedEventArgs e ) {
            Close( );
        }

        public List<string> Codes { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HolidayInformation vm = this.DataContext as HolidayInformation;
            CheckBox cb;
                foreach (var item in Codes)
                {
                    cb = new CheckBox() { Content = item, Width = 100 };
                    if (!string.IsNullOrEmpty(vm.StockCode)&& vm.StockCode.Contains(item))
                    {
                        cb.IsChecked = true;
                    }
                    this.wp.Children.Add(cb);
                }
           
            
        }

        private void wp_CancelClick(object sender, RoutedEventArgs e)
        {
            this.sp.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void wp_OkClick(object sender, RoutedEventArgs e)
        {
            string strCode = "";
            foreach (CheckBox item in wp.Children)
            {
                if (item.IsChecked == true)
                {
                    if (strCode.Length>0)
                    {
                        strCode +=",";
                    }
                    strCode += item.Content.ToString();
                }
            }
            this.txtCode.Text = strCode;
            this.sp.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.sp.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
