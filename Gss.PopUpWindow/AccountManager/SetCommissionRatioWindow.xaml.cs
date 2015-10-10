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
using Gss.Common.Utility;

namespace Gss.PopUpWindow.AccountManager
{
    /// <summary>
    /// SetCommissionRatioWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SetCommissionRatioWindow : Window
    {
        public SetCommissionRatioWindow()
        {
            InitializeComponent();
        }

        public double Ratio1
        {
            get { return (double)GetValue(Ratio1Property); }
            set { SetValue(Ratio1Property, value); }
        }

        public static readonly DependencyProperty Ratio1Property =
            DependencyProperty.Register("Ratio1", typeof(double), typeof(SetCommissionRatioWindow), new UIPropertyMetadata(0d));

        public double Ratio2
        {
            get { return (double)GetValue(Ratio2Property); }
            set { SetValue(Ratio2Property, value); }
        }

        public static readonly DependencyProperty Ratio2Property =
            DependencyProperty.Register("Ratio2", typeof(double), typeof(SetCommissionRatioWindow), new UIPropertyMetadata(0d));

        public double Ratio3
        {
            get { return (double)GetValue(Ratio3Property); }
            set { SetValue(Ratio3Property, value); }
        }

        public static readonly DependencyProperty Ratio3Property =
            DependencyProperty.Register("Ratio3", typeof(double), typeof(SetCommissionRatioWindow), new UIPropertyMetadata(0d));


        public int SelectItem
        {
            get { return (int)GetValue(SelectItemProperty); }
            set { SetValue(SelectItemProperty, value); }
        }

        public static readonly DependencyProperty SelectItemProperty =
            DependencyProperty.Register("SelectItem", typeof(int), typeof(SetCommissionRatioWindow), new UIPropertyMetadata(1));



        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            //if (CommonHelper.GetUIElementError(win))
                
            //else
            //    MessageBox.Show("请输入正确的数据！","提示信息",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute= !CommonHelper.GetUIElementError(win);
        }

        private void CommandBinding_Executed_Submit(object sender, ExecutedRoutedEventArgs e)
        {
        //    if (radCur.IsChecked == true)
        //        SelectItem = 1;
        //    else if (radAll.IsChecked == true)
        //        SelectItem = 2;
        //    else
        //        SelectItem = 3;
            if (Ratio3 + Ratio2 + Ratio1 > 1)
                MessageBox.Show("返佣比例之和不能大于1", "提示信息", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            this.DialogResult = true;
        }

      

    }
}
