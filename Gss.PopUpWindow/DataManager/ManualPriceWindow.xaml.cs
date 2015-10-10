using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Gss.Entities;
using System.IO;
using Gss.Common.Utility;
using System.Text;
using System.ComponentModel;

namespace Gss.PopUpWindow.DataManager
{
    /// <summary>
    /// ManualPriceWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ManualPriceWindow : Window
    {
        ProductInformation productInformation;
        ManualPriceSet manualPriceSet = new ManualPriceSet();
        public ManualPriceWindow()
        {
            InitializeComponent();
            this.Grid1.DataContext = manualPriceSet;
            this.grid_set.DataContext = manualPriceSet;

        }


        public bool BtnIsEnabled
        {
            get { return (bool)GetValue(BtnIsEnabledProperty); }
            set { SetValue(BtnIsEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BtnIsEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BtnIsEnabledProperty =
            DependencyProperty.Register("BtnIsEnabled", typeof(bool), typeof(ManualPriceWindow), new UIPropertyMetadata(true));


        public event ManualPriceChangeEventHander ManualPriceChangeEvent;

        public static readonly DependencyProperty ManualPriceProperty =
     DependencyProperty.Register("ManualPrice", typeof(Double), typeof(ManualPriceWindow), new UIPropertyMetadata(0.0));

        string file = string.Empty;

        /// <summary>
        /// 手工价
        /// </summary>
        public Double ManualPrice
        {
            get { return (Double)GetValue(ManualPriceProperty); }
            set { SetValue(ManualPriceProperty, value); }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void CommandBinding_Executed_OK(object sender, ExecutedRoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            if (btn != null)
            {
                this.BtnIsEnabled = false;//把按钮设置为不可用
                ManualPrice = 0;
                ProductInformation product = this.DataContext as ProductInformation;
                ManualPrice += product.RealTimePrice + System.Convert.ToDouble(btn.Content);
                if (ManualPriceChangeEvent != null)
                {
                    //ManualPriceChangeEvent.Invoke(this, null);
                    //改为异步调用
                    PriceEventArgs args = new PriceEventArgs();
                    args.ManualPrice = ManualPrice;
                    args.StockCode = product.StockCode;
                    ManualPriceChangeEvent.BeginInvoke(null, args, ManualPriceChangeEventCallBack, null);
                }
            }
            e.Handled = true;
        }
        /// <summary>
        /// 手工报价异步调用回调方法
        /// </summary>
        /// <param name="ar"></param>
        private void ManualPriceChangeEventCallBack(IAsyncResult ar)
        {
            ManualPriceChangeEventHander mchandler = (ManualPriceChangeEventHander)((System.Runtime.Remoting.Messaging.AsyncResult)ar).AsyncDelegate;
            mchandler.EndInvoke(ar);
            this.Dispatcher.Invoke(new Action(SetBtnEnable), null);
            //Console.WriteLine("==================================>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        }
        /// <summary>
        /// 把调节按钮设置为可用
        /// </summary>
        private void SetBtnEnable()
        { 
            this.BtnIsEnabled = true; 
        }

        private void acc_Loaded(object sender, RoutedEventArgs e)
        {
            productInformation = this.DataContext as ProductInformation;
            this.Title = productInformation.ProductName + "报价";
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductInformation p = this.DataContext as ProductInformation;
            if (p == null)
            {
                return;
            }
             file = file = AppDomain.CurrentDomain.BaseDirectory + p.ProductName + @".XML";
            if (this.tc.SelectedIndex == 0)
            {
              
                if (File.Exists(file))
                {
                    try
                    {
                        ManualPriceSet mps = XmlHelper.XmlDeserializeFromFile<ManualPriceSet>(file, Encoding.UTF8);
                        manualPriceSet.Number1 = mps.Number1;
                        manualPriceSet.Number2 = mps.Number2;
                        manualPriceSet.Number3 = mps.Number3;
                        manualPriceSet.Number4 = mps.Number4;
                        manualPriceSet.Number5 = mps.Number5;
                        manualPriceSet.Number6 = mps.Number6;
                        manualPriceSet.Number7 = mps.Number7;
                        manualPriceSet.Number8 = mps.Number8;
                    }
                    catch
                    {
                        decimal d1 = (decimal)(1 * Math.Pow(10, -p.SpreadDigit));
                        decimal d2 = (decimal)(2 * Math.Pow(10, -p.SpreadDigit));
                        decimal d4 = (decimal)(4 * Math.Pow(10, -p.SpreadDigit));
                        decimal d8 = (decimal)(8 * Math.Pow(10, -p.SpreadDigit));
                        manualPriceSet.Number1 = d1;
                        manualPriceSet.Number2 = d2;
                        manualPriceSet.Number3 = d4;
                        manualPriceSet.Number4 = d8;

                        manualPriceSet.Number5 = -d1;
                        manualPriceSet.Number6 = -d2;
                        manualPriceSet.Number7 = -d4;
                        manualPriceSet.Number8 = -d8;


                        XmlHelper.XmlSerializeToFile(manualPriceSet, file, Encoding.UTF8);
                    }
                    
                }
                else
                {
                    decimal d1 = (decimal)(1 * Math.Pow(10, -p.SpreadDigit));
                    decimal d2 = (decimal)(2 * Math.Pow(10, -p.SpreadDigit));
                    decimal d4 = (decimal)(4 * Math.Pow(10, -p.SpreadDigit));
                    decimal d8 = (decimal)(8 * Math.Pow(10, -p.SpreadDigit));
                    manualPriceSet.Number1 = d1;
                    manualPriceSet.Number2 = d2;
                    manualPriceSet.Number3 = d4;
                    manualPriceSet.Number4 = d8;

                    manualPriceSet.Number5 =-d1;
                    manualPriceSet.Number6 =-d2;
                    manualPriceSet.Number7 =-d4;
                    manualPriceSet.Number8 =-d8;


                    XmlHelper.XmlSerializeToFile(manualPriceSet, file, Encoding.UTF8);
                }

              

            }
          
        }
        /// <summary>
        /// 手工报价配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.BindingGroup bg = this.grid_set.BindingGroup;
            bool isValid = bg.ValidateWithoutUpdate();
            if (!isValid)
            {
                MessageBox.Show("设置失败");
                return;
            }


            XmlHelper.XmlSerializeToFile(manualPriceSet, file, Encoding.UTF8);
            MessageBox.Show("配置成功");
        }
    }
    public delegate void ManualPriceChangeEventHander(object sender, PriceEventArgs args);

    public class PriceEventArgs : EventArgs
    {
        public string StockCode { get; set; }
        public double ManualPrice { get; set; }
    }
    public class ManualPriceSet : Gss.Common.Infrastructure.ObservableObject
    {
        private decimal number1;

        public decimal Number1
        {
            get { return number1; }
            set
            {
                number1 = value;
                RaisePropertyChanged("Number1");
            }
        }
        private decimal number2;

        public decimal Number2
        {
            get { return number2; }
            set
            {
                number2 = value;
                RaisePropertyChanged("Number2");
            }
        }
        private decimal number3;
        public decimal Number3
        {
            get { return number3; }
            set
            {
                number3 = value;
                RaisePropertyChanged("Number3");
            }
        }

        private decimal number4;
        public decimal Number4
        {
            get { return number4; }
            set
            {
                number4 = value;
                RaisePropertyChanged("Number4");
            }
        }

        private decimal number5;
        public decimal Number5
        {
            get { return number5; }
            set
            {
                number5 = value;
                RaisePropertyChanged("Number5");
            }
        }

        private decimal number6;
        public decimal Number6
        {
            get { return number6; }
            set
            {
                number6 = value;
                RaisePropertyChanged("Number6");
            }
        }

        private decimal number7;
        public decimal Number7
        {
            get { return number7; }
            set
            {
                number7 = value;
                RaisePropertyChanged("Number7");
            }
        }

        private decimal number8;
        public decimal Number8
        {
            get { return number8; }
            set
            {
                number8 = value;
                RaisePropertyChanged("Number8");
            }
        }

    }
   
}
