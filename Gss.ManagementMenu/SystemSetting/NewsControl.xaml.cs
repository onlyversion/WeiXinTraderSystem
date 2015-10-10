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
    /// NewsControl.xaml 的交互逻辑
    /// </summary>
    public partial class NewsControl : UserControl
    {
        public NewsControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(NewsControl_Loaded);
        }

        void NewsControl_Loaded(object sender, RoutedEventArgs e)
        {
            vm = this.DataContext as ManagementViewModel;
           
        }

        private ManagementViewModel vm;
        void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
            vm.GetNewsListExecute();
        }

        //private void CommandBinding_Executed_Add(object sender, ExecutedRoutedEventArgs e)
        //{

        //}

        //private void CommandBinding_CanExecute_Add(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        //private void CommandBinding_Executed_Del(object sender, ExecutedRoutedEventArgs e)
        //{

        //}

        //private void CommandBinding_CanExecute_Del(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        //private void CommandBinding_Executed_Edit(object sender, ExecutedRoutedEventArgs e)
        //{

        //}

        //private void CommandBinding_CanExecute_Edit(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        private void cMenu_Opened(object sender, RoutedEventArgs e)
        {
            ContextMenu menu=sender as  ContextMenu;
            menu.DataContext = DataContext;
        }
    }
}
