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
using Gss.Entities.JTWEntityes;

namespace Gss.PopUpWindow.DataManager
{
    /// <summary>
    /// HistoryDataSetWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HistoryDataSetWindow : Window
    {
        public HistoryDataSetWindow()
        {
            InitializeComponent();
        }
        public HistoryDataSetWindow(HisData hisData)
        {
            InitializeComponent();
            this.ProductName = hisData.ProductCod;
            this.Cycle = hisData.Cycle;
            this.HistoryData = hisData;
            this.DataContext = this;

        }

        public string ProductName { get; set; }
        public string ProductCod { get; set; }
        public string Cycle { get; set; }

        public HisData HistoryData
        {
            get { return (HisData)GetValue(HistoryDataProperty); }
            set { SetValue(HistoryDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HistoryData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HistoryDataProperty =
            DependencyProperty.Register("HistoryData", typeof(HisData), typeof(HistoryDataSetWindow));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double h = System.Convert.ToDouble(HistoryData.Highprice);
            double l = System.Convert.ToDouble(HistoryData.Lowprice);
            double o = System.Convert.ToDouble(HistoryData.Openprice);
            double c = System.Convert.ToDouble(HistoryData.Closeprice);
            if (h<l )
            {
                MessageBox.Show("最高价不能小于最低价");
                return;
            }
            else if (o > h || o<l)
            {
                MessageBox.Show("开盘价只能在最高价与最低价之间");
                return;
            }
            else if (c< l || c>h)
            {
                MessageBox.Show("收盘价只能在最高价与最低价之间");
                return;
            }

            BindingGroup bg = this.gridRoot.BindingGroup;
            bool isValid = bg.ValidateWithoutUpdate();
            if (!isValid)
            {
                MessageBox.Show("设置未成功，请检查数据输入");
                return;
            }

            
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }


    }
}
