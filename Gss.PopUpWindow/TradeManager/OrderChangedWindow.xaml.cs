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
using Gss.Entities;
using Gss.Entities.ValidationHelper;
using Xceed.Wpf.Toolkit;

namespace Gss.PopUpWindow {
    /// <summary>
    /// OrderChangedWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OrderChangedWindow : Window {

        



        public OrderChangedInformation _orderChangedInfo
        {
            get { return (OrderChangedInformation)GetValue(_orderChangedInfoProperty); }
            set { SetValue(_orderChangedInfoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for _orderChangedInfo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty _orderChangedInfoProperty =
            DependencyProperty.Register("_orderChangedInfo", typeof(OrderChangedInformation), typeof(OrderChangedWindow));



        #region 依赖属性

        public static readonly DependencyProperty AllowMaxPriceDiffProperty =
            DependencyProperty.Register( "AllowMaxPriceDiff", typeof( double ), typeof( OrderChangedWindow ), new UIPropertyMetadata( 0d) );

        public static readonly DependencyProperty IsTradingProperty =
            DependencyProperty.Register( "IsTrading", typeof( bool ), typeof( OrderChangedWindow ), new UIPropertyMetadata( false ) );

        /// <summary>
        /// 获取或设置允许最大价格差
        /// </summary>
        public double AllowMaxPriceDiff {
            get { return ( double )GetValue( AllowMaxPriceDiffProperty ); }
            set { SetValue( AllowMaxPriceDiffProperty, value ); }
        }

        /// <summary>
        /// 获取或设置是否正在交易
        /// </summary>
        public bool IsTrading {
            get { return ( bool )GetValue( IsTradingProperty ); }
            set { SetValue( IsTradingProperty, value ); }
        }
      
        
        #endregion

        #region 构造函数

        /// <summary>
        /// 根据窗口类型实例化包含不同标题、按钮文字等信息的定单改变窗口
        /// </summary>
        /// <param name="type">窗口类型</param>
        public OrderChangedWindow( OrderChangedWindowType type ) {
            InitializeComponent( );
            _orderChangedInfo = new OrderChangedInformation( );

            string windowTitle;
            string waterMark;
            string buttonContent;

            if( type == OrderChangedWindowType.Chargeback ) {
                windowTitle = "平仓";
                waterMark = "请输入平仓数量";
                buttonContent = "平仓";
            } else {
                windowTitle = "入库";
                waterMark = "请输入入库数量";
                buttonContent = "入库";
            }

            Title = windowTitle;
            DudCount.Watermark = waterMark;
            BtOk.Content = buttonContent;
        }

        #endregion

        #region 自定义事件 -- OrderChanged

        /// <summary>
        /// 定单改变事件
        /// </summary>
        public event EventHandler<OrderChangedEventArgs> OrderChanged;

        /// <summary>
        /// 触发定单改变事件
        /// </summary>
        private void RaiseOrderChanged( ) {
            IsTrading = true;

            if( OrderChanged != null )
                OrderChanged( this, new OrderChangedEventArgs( _orderChangedInfo ) );
        }

        #endregion

        #region 命令

        /// <summary>
        /// Ok命令的执行方法
        /// </summary>
        /// <param name="sender">命令发送方</param>
        /// <param name="e">命令参数</param>
        private void CommandBinding_Executed_Ok( object sender, ExecutedRoutedEventArgs e ) {
            AssignmentOrderChangedInfo( );
            RaiseOrderChanged( );
            e.Handled = true;
        }

        /// <summary>
        /// 判断Ok命令是否可执行的方法
        /// </summary>
        /// <param name="sender">命令发送方</param>
        /// <param name="e">命令参数</param>
        private void CommandBinding_CanExecute_Ok( object sender, CanExecuteRoutedEventArgs e ) {
            e.CanExecute = !Validation.GetHasError(DudCount);
        }
        #endregion

        #region 公有接口

        /// <summary>
        /// 重置窗口状态
        /// </summary>
        public void RevertWindowState( ) {
            IsTrading = false;
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 为定单改变信息赋值
        /// </summary>
        private void AssignmentOrderChangedInfo( ) {
            MarketOrderData selectedItem = DataContext as MarketOrderData;

            _orderChangedInfo.AllowMaxPriceDeviation = ( CbDeviation.IsChecked == true ? AllowMaxPriceDiff : 0.0 );
            //_orderChangedInfo.Count = DudCount.Value.HasValue ? DudCount.Value.Value : 0.0;
            _orderChangedInfo.OrderID = selectedItem.OrderID;
            _orderChangedInfo.RealTimePrice = selectedItem.RealTimePrice;
            _orderChangedInfo.RealTimeTime = selectedItem.OwnedProduct.RealTimeTime;
            _orderChangedInfo.TradeAccount = selectedItem.TradeAccount;
        }

        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MarketOrderData data = this.DataContext as MarketOrderData;
            _orderChangedInfo.Count = data.OrderQuantity;
            Binding b = new Binding();
            b.Path = new PropertyPath("Count");
            b.Source = _orderChangedInfo;
            b.Mode = BindingMode.TwoWay;
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            b.NotifyOnValidationError = true;


            ValidationRule rule = new DoubleExactDivisionRule() { Dividend = data.Orderunit, MinValue = data.Orderunit, MaxValue = data.OrderQuantity };
            b.ValidationRules.Add(rule);
            this.DudCount.SetBinding(DoubleUpDown.ValueProperty, b);
        }

    }

    /// <summary>
    /// 定单改变事件参数类
    /// </summary>
    public class OrderChangedEventArgs : EventArgs {
        /// <summary>
        /// 获取定单改变的详细信息
        /// </summary>
        public OrderChangedInformation OrderChangedInfo { get; private set; }

        /// <summary>
        /// 用定单改变的详细信息实例化定单改变事件参数类
        /// </summary>
        /// <param name="info">定单改变的详细信息类</param>
        public OrderChangedEventArgs( OrderChangedInformation info ) {
            OrderChangedInfo = info;
        }
    }

    /// <summary>
    /// 定单改变的窗口类型
    /// </summary>
    public enum OrderChangedWindowType {
        /// <summary>
        /// 平仓
        /// </summary>
        Chargeback,

        /// <summary>
        /// 入库
        /// </summary>
        Warehousing,
    }
}
