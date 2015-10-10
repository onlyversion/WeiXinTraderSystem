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
using Gss.Entities.Enums;

namespace JxSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow( ) {
            InitializeComponent( );
        }

        private void TvManager_SelectedItemChanged( object sender, RoutedPropertyChangedEventArgs<object> e ) {
            //采用响应SelectedItemChanged事件是因为直接绑定Title的方式无效，待深入研究。
            TreeView tv = sender as TreeView;
            if( tv.SelectedItem == null )
                return;

            GssTreeViewItem gssTvItem = tv.SelectedItem as GssTreeViewItem;
            if( gssTvItem != null )
                MainContainer.Title = gssTvItem.Title;
        }

        private void CommandBinding_Executed_About( object sender, ExecutedRoutedEventArgs e ) {
            //AboutBox aboutBox = new AboutBox( this );
            //aboutBox.ShowDialog( );
            string path = AppDomain.CurrentDomain.BaseDirectory + "AppHelp.pdf";
            System.Diagnostics.Process.Start(path);
        }

        private void Window_Loaded( object sender, RoutedEventArgs e ) {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            if (vm.AccountAuthority.EnableTradeMoneyInfo == false)
                PBtn.IsPopOpen = false;
            vm.QuotationDistribution( );
            App.Current.Deactivated += new EventHandler(Current_Deactivated);
            App.Current.Activated += new EventHandler(Current_Activated);
            App.Current.MainWindow.SizeChanged += new SizeChangedEventHandler(MainWindow_SizeChanged);
        }

        void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //PBtn.IsPopOpen = false;
            //ChangeBtnState();
        }
        private void CommandBinding_Executed_ModifyPassword(object sender, ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;

            vm.ModifyPassword();
           
        }

        private int clickTime = 0;
        private void PBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeBtnState();
        }

        private void ChangeBtnState()
        {
            if (PBtn.IsPopOpen)
            {
                ArrowR1.Visibility = Visibility.Collapsed;
                ArrowR2.Visibility = Visibility.Visible;
            }
            else
            {
                ArrowR1.Visibility = Visibility.Visible;
                ArrowR2.Visibility = Visibility.Collapsed;
            }
        }

        private bool isPopOpen = false;
        void Current_Deactivated(object sender, EventArgs e)
        {
            //isPopOpen = PBtn.IsPopOpen;
            //PBtn.IsPopOpen = false;
            //ChangeBtnState();
        }
        void Current_Activated(object sender, EventArgs e)
        {
            //PBtn.IsPopOpen = isPopOpen;
            //ChangeBtnState();
        }

    }
}
