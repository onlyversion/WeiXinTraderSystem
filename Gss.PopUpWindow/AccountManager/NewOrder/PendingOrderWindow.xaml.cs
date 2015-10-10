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
    /// PendingOrderWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PendingOrderWindow {
        #region 成员/属性

        private NewPendingOrderInfo _newOrderInfo;

        /// <summary>
        /// 获取或设置选中的商品
        /// </summary>
        public ProductInformation SelectedProduct {
            get { return CbProductName.SelectedValue as ProductInformation; }
            set { CbProductName.SelectedValue = value; }
        }

        #endregion

        #region 依赖属性

        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register( "Count", typeof( double ), typeof( PendingOrderWindow ), new UIPropertyMetadata( 1.0 ) );

        public static readonly DependencyProperty DueDateProperty =
            DependencyProperty.Register( "DueDate", typeof( DateTime ), typeof( PendingOrderWindow ), new UIPropertyMetadata( DateTime.Today ) );

        public static readonly DependencyProperty EnableStopLossProperty =
            DependencyProperty.Register("EnableStopLoss", typeof(bool), typeof(PendingOrderWindow), new UIPropertyMetadata(false, OnEnableStopLossChanged));
        private static void OnEnableStopLossChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PendingOrderWindow win = d as PendingOrderWindow;
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
            DependencyProperty.Register("EnableStopProfit", typeof(bool), typeof(PendingOrderWindow), new UIPropertyMetadata(false, OnEnableStopProfitChanged));

        private static void OnEnableStopProfitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PendingOrderWindow win = d as PendingOrderWindow;
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
            DependencyProperty.Register( "IsTrading", typeof( bool ), typeof( PendingOrderWindow ), new UIPropertyMetadata( false ) );

        public static readonly DependencyProperty PendingOrderPriceProperty =
            DependencyProperty.Register( "PendingOrderPrice", typeof( double ), typeof( PendingOrderWindow ), new UIPropertyMetadata( 0.0 ) );

        public static readonly DependencyProperty ProductListProperty =
            DependencyProperty.Register( "ProductList", typeof( ObservableCollection<ProductInformation> ), typeof( PendingOrderWindow ), new UIPropertyMetadata( null ) );

        public static readonly DependencyProperty StopLossProperty =
            DependencyProperty.Register( "StopLoss", typeof( double ), typeof( PendingOrderWindow ), new UIPropertyMetadata( 0.0 ) );

        public static readonly DependencyProperty StopProfitProperty =
            DependencyProperty.Register( "StopProfit", typeof( double ), typeof( PendingOrderWindow ), new UIPropertyMetadata( 0.0 ) );

        /// <summary>
        /// 获取或设置定单数量
        /// </summary>
        public double Count {
            get { return ( double )GetValue( CountProperty ); }
            set { SetValue( CountProperty, value ); }
        }

        /// <summary>
        /// Gets or sets the due date of this pending order.
        /// 获取或设置定单日期
        /// </summary>
        public DateTime DueDate {
            get { return ( DateTime )GetValue( DueDateProperty ); }
            set { SetValue( DueDateProperty, value ); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether stop loss function is enabled.
        /// 获取或设置启用止损
        /// </summary>
        public bool EnableStopLoss {
            get { return ( bool )GetValue( EnableStopLossProperty ); }
            set { SetValue( EnableStopLossProperty, value ); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether stop profit function is enabled.
        /// 获取或设置启用止盈
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
        /// 获取或设置挂单价格
        /// </summary>
        public double PendingOrderPrice {
            get { return ( double )GetValue( PendingOrderPriceProperty ); }
            set { SetValue( PendingOrderPriceProperty, value ); }
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

        public PendingOrderWindow( ) {
            InitializeComponent( );
            _newOrderInfo = new NewPendingOrderInfo( );
        } 

        #endregion

        #region 自定义事件 -- PendingOrder

        /// <summary>
        /// 限价挂单事件
        /// </summary>
        public event EventHandler<PendingOrderEventArgs> PendingOrder;

        /// <summary>
        /// 触发限价单事件
        /// </summary>
        private void RaisePendingOrder( ) {
            IsTrading = true;

            if( PendingOrder != null )
                PendingOrder( this, new PendingOrderEventArgs( _newOrderInfo, SelectedProduct ) );
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
        /// 买涨或买跌命令是否可用的判断方法
        /// </summary>
        /// <param name="sender">命令发送方</param>
        /// <param name="e">命令参数</param>
        private void CommandBinding_CanExecute( object sender, CanExecuteRoutedEventArgs e ) {

            bool rst = false;
            ProductInformation p = this.CbProductName.SelectedItem as ProductInformation;
            if (p != null&&( Math.Abs( PendingOrderPrice ) > 0.00000001) && (p.State == PRODUCT_STATE.All || p.State == PRODUCT_STATE.AllowOrder) && !CommonHelper.GetUIElementError(this))
            {
                rst = true;
            }
            e.CanExecute = rst;
            e.Handled = true;
        }

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
            RaisePendingOrder( );
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
            RaisePendingOrder( );
            e.Handled = true;
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// Assignment pending order information.
        /// </summary>
        /// <param name="type">transaction type</param>
        private void AssignmentOrderInfo( TRANSACTION_TYPE type ) {
            ProductInformation selectedData = SelectedProduct;

            _newOrderInfo.Count = Count;
            _newOrderInfo.DueDate = DueDate;
            _newOrderInfo.MAC = MacAddress.LocalMAC;
            _newOrderInfo.OrderType = type;
            _newOrderInfo.PendingOrdersPrice = PendingOrderPrice;
            _newOrderInfo.PercentageOfDeposit = selectedData.PercentageOfDeposit;
            _newOrderInfo.ProductCode = selectedData.ProductCode;
            _newOrderInfo.RealTimeTime = selectedData.RealTimeTime;
            _newOrderInfo.RealTimePrice = ( type == TRANSACTION_TYPE.Order ? selectedData.OrderPrice : selectedData.RecoveryPrice );
            _newOrderInfo.StopLossPrice = ( EnableStopLoss ? DataDigitFilter.FilterDouble( StopLoss, selectedData.SpreadDigit ) : 0 );
            _newOrderInfo.StopProfitPrice = ( EnableStopProfit ? DataDigitFilter.FilterDouble( StopProfit, selectedData.SpreadDigit ) : 0 );
        }

        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ClientAccount ca = this.DataContext as ClientAccount;
            this.Count = 1;


            Binding b = new Binding();
            b.Path = new PropertyPath("Count");
            b.Source = this;
            b.Mode = BindingMode.TwoWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            b.NotifyOnValidationError = true;


            ValidationRule rule = new DoubleExactDivisionRule()
            {
                Dividend = System.Convert.ToDouble(ca.TransactionSettings.OrderUnit),
                MinValue = ca.TransactionSettings.MinTrade,
                MaxValue = ca.TransactionSettings.MaxTrade
            };

            b.ValidationRules.Add(rule);
            this.IntCount.SetBinding(DoubleUpDown.ValueProperty, b);

        }

        private void CommandBindingRecovery_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool rst = false;
            ProductInformation p = this.CbProductName.SelectedItem as ProductInformation;
            if (p != null && (Math.Abs(PendingOrderPrice) > 0.00000001) && (p.State == PRODUCT_STATE.All || p.State == PRODUCT_STATE.AllowRecovery) && !CommonHelper.GetUIElementError(this))
            {
                rst = true;
            }
            e.CanExecute = rst;
            e.Handled = true;
        }

    }

    /// <summary>
    /// 限价单事件参数类
    /// </summary>
    public class PendingOrderEventArgs : EventArgs {
        /// <summary>
        /// 获取限价挂单的定单信息
        /// </summary>
        public NewPendingOrderInfo NewOrderInfo { get; private set; }

        /// <summary>
        /// 获取选中的商品信息类
        /// </summary>
        public ProductInformation SelectedProduct { get; private set; }

        /// <summary>
        /// 用新的限价挂单的详细参数信息和选中的某个商品实例化限价单消息参数实例
        /// </summary>
        /// <param name="info">新限价挂单的详细参数信息</param>
        /// <param name="selectedProduct">选中的某个商品</param>
        public PendingOrderEventArgs( NewPendingOrderInfo info, ProductInformation selectedProduct ) {
            NewOrderInfo = info;
            SelectedProduct = selectedProduct;
        }
    }
}
