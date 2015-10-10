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

namespace Gss.PopUpWindow.AccountManager
{
    /// <summary>
    /// EntityAcceptWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EntityAcceptWindow : Window
    {
        public static readonly DependencyProperty ProductNameProperty =
         DependencyProperty.Register("ProductName", typeof(string), typeof(EntityAcceptWindow), new UIPropertyMetadata(""));
        /// <summary>
        /// 商品名
        /// </summary>
        public string ProductName
        {
            get { return (string)GetValue(ProductNameProperty); }
            set { SetValue(ProductNameProperty, value); }
        }

        public static readonly DependencyProperty TotalProperty =
        DependencyProperty.Register("Total", typeof(double), typeof(EntityAcceptWindow), new UIPropertyMetadata(0.0));
        /// <summary>
        /// 价格
        /// </summary>
        public double Total
        {
            get { return (double)GetValue(TotalProperty); }
            set { SetValue(TotalProperty, value); }
        }

        public EntityAcceptWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
