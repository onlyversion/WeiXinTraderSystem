

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
    public partial class AdvertControl : UserControl
    {
        public AdvertControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(AdvertControl_Loaded);
        }

        void AdvertControl_Loaded(object sender, RoutedEventArgs e)
        {
            vm = this.DataContext as ManagementViewModel;
        }

        private ManagementViewModel vm;
        void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
            vm.GetNewsListExecute();
        }

       
        private void cMenu_Opened(object sender, RoutedEventArgs e)
        {
            ContextMenu menu=sender as  ContextMenu;
            menu.DataContext = DataContext;
        }
    }
}

