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

namespace Gss.ManagementMenu.AccountManager.Order
{
    /// <summary>
    /// PendingOrder.xaml 的交互逻辑
    /// </summary>
    public partial class PendingOrder : UserControl
    {
        public PendingOrder()
        {
            InitializeComponent();
        }
        #region --- Dependency property ---
        /// <summary>
        /// Gets or sets page count.
        /// </summary>
        public int PageCount
        {
            get { return (int)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }

        public static readonly DependencyProperty PageCountProperty =
            DependencyProperty.Register("PageCount", typeof(int), typeof(PendingOrder), new UIPropertyMetadata(0));

        public string AccountName
        {
            get { return (string)GetValue(AccountNameProperty); }
            set { SetValue(AccountNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AccountName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccountNameProperty =
            DependencyProperty.Register("AccountName", typeof(string), typeof(PendingOrder));
        #endregion
     
     

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ManagementViewModel mv = DataContext as ManagementViewModel;
            DgResult.ItemsSource = mv.GetPendingOrderList(AccountName);
        }
    }
}
