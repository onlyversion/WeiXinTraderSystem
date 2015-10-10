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
    /// RecordRealWeight.xaml 的交互逻辑
    /// </summary>
    public partial class RecordRealWeightWindow : Window
    {
        public RecordRealWeightWindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty RealWeightProperty =
          DependencyProperty.Register("RealWeight", typeof(double),
          typeof(RecordRealWeightWindow));

        //public static readonly DependencyProperty TotalWeightProperty =
        //DependencyProperty.Register("TotalWeight", typeof(double),
        //typeof(RecordRealWeightWindow));

        ////public  double TotalWeight { get; set; }

        ///// <summary>
        ///// 总重量
        ///// </summary>
        //public  double TotalWeight
        //{
        //    get { return (double)GetValue(TotalWeightProperty); }
        //    set
        //    {
        //        SetValue(TotalWeightProperty, value);
        //    }
        //}

        /// <summary>
        /// 实际克重
        /// </summary>
        public double RealWeight
        {
            get { return (double)GetValue(RealWeightProperty); }
            set
            {
                //if (value > TotalWeight)
                //    throw new ArgumentException("您输入的重量大于您的库存");
                SetValue(RealWeightProperty, value);
            }
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
