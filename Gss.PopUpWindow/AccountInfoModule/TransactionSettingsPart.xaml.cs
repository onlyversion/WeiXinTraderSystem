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
using Gss.Entities;
using Xceed.Wpf.Toolkit;
using Gss.Entities.ValidationHelper;

namespace Gss.PopUpWindow.AccountInfoModule {
    /// <summary>
    /// AccountTransactionSettings.xaml 的交互逻辑
    /// </summary>
    public partial class TransactionSettingsPart {
        TransactionSettings ts;
        public TransactionSettingsPart( ) {
            InitializeComponent( );
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ts = this.DataContext as TransactionSettings;
        }

      

        private void DoubleUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            //Binding b = new Binding();
            //b.Path = new PropertyPath("MinTrade");
            //b.Mode = BindingMode.TwoWay;
            //b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //b.NotifyOnValidationError = true;
            

            //ValidationRule rule = new DoubleExactDivisionRule() { Dividend = System.Convert.ToDouble(e.NewValue) };

            //b.ValidationRules.Add(rule);
            //this.min.SetBinding(DoubleUpDown.ValueProperty, b);





            //Binding b2 = new Binding();
            //b2.Path = new PropertyPath("MaxTrade");
            //b2.Mode = BindingMode.TwoWay;
            //b2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //b2.NotifyOnValidationError = true;


            //ValidationRule rule2 = new DoubleExactDivisionRule() { Dividend = System.Convert.ToDouble(e.NewValue) };

            //b2.ValidationRules.Add(rule2);
            //this.max.SetBinding(DoubleUpDown.ValueProperty, b2);




            //BindingGroup bg = this.RootGrid.BindingGroup;
            //foreach (var item in bg.BindingExpressions)
            //{
            //    item.UpdateSource();
            //}
            
        }

       
    }
}
