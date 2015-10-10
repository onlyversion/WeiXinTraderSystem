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

namespace Gss.PopUpWindow.TradeManager
{
    /// <summary>
    /// ModifyBackTradeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyBackTradeWindow : Window
    {
        public static readonly DependencyProperty PayTimeProperty =
          DependencyProperty.Register("PayTime", typeof(DateTime), typeof(ModifyBackTradeWindow), new UIPropertyMetadata(DateTime.Today));

        /// <summary>
        /// 获取或设置允许最大价格差
        /// </summary>
        public DateTime PayTime
        {
            get { return (DateTime)GetValue(PayTimeProperty); }
            set { SetValue(PayTimeProperty, value); }
        }

        public ModifyBackTradeWindow()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
