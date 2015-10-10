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

namespace Gss.ManagementMenu {
    /// <summary>
    /// ManagementMenu.xaml 的交互逻辑
    /// </summary>
    public partial class ManagementMenu {
        public ManagementMenu( ) {
            InitializeComponent( );
        }

        private void TreeView_Loaded( object sender, RoutedEventArgs e )
        {
            //直接绑定TreeViewItem的Items到ListBox的ItemsSource未成功，待深入研究。
            //lbAccMgr.ItemsSource = tvAccMgr.Items;
            //lbDataMgr.ItemsSource = tvDataMgr.Items;
            //lbSysSet.ItemsSource = tvSysSet.Items;
            //lbTradeMgr.ItemsSource = tvTradeMgr.Items;
            //lbTakeGoodsAccept.ItemsSource = tvTakeGoodsAccept.Items;
        }
    }
}
