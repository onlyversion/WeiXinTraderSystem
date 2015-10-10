using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Gss.Common.Utility;
using Gss.Entities;
using Gss.Entities.Enums;
using System.Windows.Data;
using System.Windows.Controls;
using Gss.Entities.ValidationHelper;
using Xceed.Wpf.Toolkit;

namespace Gss.PopUpWindow {
    /// <summary>
    /// MarketOrderWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MarketOrderWindow {
        #region 成员/属性

        private NewMarketOrderInfo _newOrderInfo;

        /// <summary>
        /// 获取或设置选中的商品
        /// </summary>
        public ProductInformation SelectedProduct {
            get { return CbProductName.SelectedValue as ProductInformation; }
            set { CbProductName.SelectedValue = value; }
        }
        
        #endregion

        #region 依赖属性

       
       
        public static readonly DependencyProperty AllowMaxPriceDiffProperty =
            DependencyProperty.Register( "AllowMaxPriceDiff", typeof( double ), typeof( MarketOrderWindow ), new UIPropertyMetadata( 0.0 ) );

        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register( "Count", typeof( double ), typeof( MarketOrderWindow ), new UIPropertyMetadata( 1d) );

        public static readonly DependencyProperty EnableStopLossProperty =
            DependencyProperty.Register("EnableStopLoss", typeof(bool), typeof(MarketOrderWindow), new UIPropertyMetadata(false, OnEnableStopLossChanged));

        private static void OnEnableStopLossChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MarketOrderWindow win = d as MarketOrderWindow;
            if ((bool)e.NewValue)
            {
                ProductInformation p = win.CbProductName.SelectedItem as ProductInformation;
                if (p != null)
                {
                    win.StopLoss = p.OrderPrice;
                }

            }
            else
            {
                win.StopLoss = 0.00;
            }
        }

        public static readonly DependencyProperty EnableStopProfitProperty =
            DependencyProperty.Register("EnableStopProfit", typeof(bool), typeof(MarketOrderWindow), new UIPropertyMetadata(false, OnEnableStopProfitChanged));

        private static void OnEnableStopProfitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MarketOrderWindow win = d as MarketOrderWindow;
            if ((bool)e.NewValue)
            {
                ProductInformation p = win.CbProductName.SelectedItem as ProductInformation;
                if (p != null)
                {
                    win.StopProfit = p.OrderPrice;
                }

            }
            else
            {
                win.StopProfit = 0.00;
            }
        }

        public static readonly DependencyProperty IsTradingProperty =
            DependencyProperty.Register( "IsTrading", typeof( bool ), typeof( MarketOrderWindow ), new UIPropertyMetadata( false ) );

        public static readonly DependencyProperty ProductListProperty =
            DependencyProperty.Register( "ProductList", typeof( ObservableCollection<ProductInformation> ), typeof( MarketOrderWindow ), new UIPropertyMetadata( null ) );

        public static readonly DependencyProperty StopLossProperty =
            DependencyProperty.Register( "StopLoss", typeof( double ), typeof( MarketOrderWindow ), new UIPropertyMetadata( 0d ) );

        public static readonly DependencyProperty StopProfitProperty =
            DependencyProperty.Register( "StopProfit", typeof( double ), typeof( MarketOrderWindow ), new UIPropertyMetadata( 0d ) );

        /// <summary>
        /// 获取或设置允许最大价格差
        /// </summary>
        public double AllowMaxPriceDiff {
            get { return ( double )GetValue( AllowMaxPriceDiffProperty ); }
            set { SetValue( AllowMaxPriceDiffProperty, value ); }
        }

        /// <summary>
        /// 获取或设置定单数量
        /// </summary>
        public double Count {
            get { return ( double )GetValue( CountProperty ); }
            set { SetValue( CountProperty, value ); }
        }

        /// <summary>
        /// 获取或设置是否启用止损
        /// </summary>
        public bool EnableStopLoss {
            get { return ( bool )GetValue( EnableStopLossProperty ); }
            set {
               
                SetValue( EnableStopLossProperty, value ); 
            }
        }

        /// <summary>
        /// 获取或设置是否启用止盈
        /// </summary>
        public bool EnableStopProfit {
            get { return ( bool )GetValue( EnableStopProfitProperty ); }
            set { SetValue( EnableStopProfitProperty, value ); }
        }

        /// <summary>
        /// 获取或设置是否正在交易
        /// </summary>
        public bool IsTrading {
            get { return ( bool )GetValue( IsTradingProperty ); }
            set { SetValue( IsTradingProperty, value ); }
        }

        /// <summary>
        /// 获取或设置商品列表
        /// </summary>
        public ObservableCollection<ProductInformation> ProductList {
            get { return ( ObservableCollection<ProductInformation> )GetValue( ProductListProperty ); }
            set { SetValue( ProductListProperty, value ); }
        }

        /// <summary>
        /// 获取或设置止损值
        /// </summary>
        public double StopLoss {
            get { return ( double )GetValue( StopLossProperty ); }
            set { SetValue( StopLossProperty, value ); }
        }

        /// <summary>
        /// 获取或设置止盈值
        /// </summary>
        public double StopProfit {
            get { return ( double )GetValue( StopProfitProperty ); }
            set { SetValue( StopProfitProperty, value ); }
        }
        #endregion

        #region 构造函数

        public MarketOrderWindow( ) {
            InitializeComponent( );
            _newOrderInfo = new NewMarketOrderInfo( );
        }

        #endregion
      

        #region 自定义事件 -- MarketOrder

        /// <summary>
        /// 市价单事件
        /// </summary>
        public event EventHandler<MarketOrderEventArgs> MarketOrder;

        /// <summary>
        /// 触发市价单事件
        /// </summary>
        private void RaiseMarketOrder( ) {
            IsTrading = true;

            if( MarketOrder != null )
                MarketOrder( this, new MarketOrderEventArgs( _newOrderInfo, SelectedProduct ) );
        }

        #endregion

        #region 公用接口

        /// <summary>
        /// 重置窗口状态
        /// </summary>
        public void RevertWindowState( ) {
            IsTrading = false;
        }

        #endregion

        #region 命令

        /// <summary>
        /// 买涨命令执行方法
        /// </summary>
        /// <param name="sender">命令发送方</param>
        /// <param name="e">命令参数</param>
        private void CommandBinding_Executed_Order( object sender, ExecutedRoutedEventArgs e ) {
            if (Validation.GetHasError(this.IntCount))
            {
                return;
            }
            AssignmentOrderInfo( TRANSACTION_TYPE.Order );
            RaiseMarketOrder( );
            e.Handled = true;
        }

        /// <summary>
        /// 买跌命令执行方法
        /// </summary>
        /// <param name="sender">命令发送方</param>
        /// <param name="e">命令参数</param>
        private void CommandBinding_Executed_Recovery( object sender, ExecutedRoutedEventArgs e ) {
            if (Validation.GetHasError(this.IntCount))
            {
                return;
            }
            AssignmentOrderInfo( TRANSACTION_TYPE.Recovery );
            RaiseMarketOrder( );
            e.Handled = true;
        } 

        #endregion

        #region 辅助方法

        /// <summary>
        /// 为市价单定单信息赋值
        /// </summary>
        /// <param name="type">定单类型，买跌或买涨</param>
        private void AssignmentOrderInfo( TRANSACTION_TYPE type ) {
            ProductInformation selectedPt = SelectedProduct;

            _newOrderInfo.AllowMaxPriceDeviation = ( CbDeviation.IsChecked == true ? AllowMaxPriceDiff : 0 );
            _newOrderInfo.Count = Count;
            _newOrderInfo.MAC = MacAddress.LocalMAC;
            _newOrderInfo.OrderType = type;
            _newOrderInfo.PercentageOfDeposit = selectedPt.PercentageOfDeposit;
            _newOrderInfo.ProductCode = selectedPt.ProductCode;
            _newOrderInfo.RealTimeTime = selectedPt.RealTimeTime;
            _newOrderInfo.RealTimePrice = ( type == TRANSACTION_TYPE.Order ? selectedPt.OrderPrice : selectedPt.RecoveryPrice );
            _newOrderInfo.StopLossPrice = ( EnableStopLoss ? DataDigitFilter.FilterDouble( StopLoss, selectedPt.SpreadDigit ) : 0 );
            _newOrderInfo.StopProfitPrice = ( EnableStopProfit ? DataDigitFilter.FilterDouble( StopProfit, selectedPt.SpreadDigit ) : 0 );
        }

        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ClientAccount ca = this.DataContext as ClientAccount;
            this.Count = 1;

            ClientAccount ClientA = this.DataContext as ClientAccount;

            Binding b = new Binding();
            b.Path = new PropertyPath("Count");
            b.Source = this;
            b.Mode = BindingMode.TwoWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            b.NotifyOnValidationError = true;


            ValidationRule rule = new DoubleExactDivisionRule() 
            { Dividend = System.Convert.ToDouble(ClientA.TransactionSettings.OrderUnit),
                MinValue = ClientA.TransactionSettings.MinTrade, 
                MaxValue = ClientA.TransactionSettings.MaxTrade 
            };

            b.ValidationRules.Add(rule);
            this.IntCount.SetBinding(DoubleUpDown.ValueProperty, b);
        }

       

        private void CommandBindingRecovery_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool rst = false;
            ProductInformation p = this.CbProductName.SelectedItem as ProductInformation;
            if (p!=null && (p.State == PRODUCT_STATE.All || p.State == PRODUCT_STATE.AllowRecovery) && !CommonHelper.GetUIElementError(this))
            {
                rst = true;
            }
            e.CanExecute = rst;
            e.Handled = true;
        }

        private void CommandBindingOrder_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool rst = false;
            ProductInformation p = this.CbProductName.SelectedItem as ProductInformation;
            if (p != null && (p.State == PRODUCT_STATE.All || p.State == PRODUCT_STATE.AllowOrder) && !CommonHelper.GetUIElementError(this))
            {
                rst = true;
            }
            e.CanExecute = rst;
            e.Handled = true;
        }
    }

    /// <summary>
    /// 市价单事件参数类
    /// </summary>
    public class MarketOrderEventArgs : EventArgs {
        /// <summary>
        /// 用新市价单的详细参数信息和选中的某个商品实例化市价单消息参数实例
        /// </summary>
        /// <param name="newOrderInfo">新市价单的详细参数信息</param>
        /// <param name="selectedProduct">选中的某个商品</param>
        public MarketOrderEventArgs( NewMarketOrderInfo newOrderInfo, ProductInformation selectedProduct ) {
            NewOrderInfo = newOrderInfo;
            SelectedProduct = selectedProduct;
        }

        /// <summary>
        /// 获取新定单的详细信息
        /// </summary>
        public NewMarketOrderInfo NewOrderInfo { get; private set; }

        /// <summary>
        /// 获取选中的商品信息类
        /// </summary>
        public ProductInformation SelectedProduct { get; private set; }
    }

}
