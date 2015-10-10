using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Gss.Entities;
using Gss.Entities.JTWEntityes;


namespace Gss.ManagementMenu.CustomControl {
    /// <summary>
    /// InquiryCustomControl.xaml 的交互逻辑
    /// </summary>
    public partial class InquiryCustomControl : INotifyPropertyChanged {
        #region ---实现属性改变事件接口 Interface-INotifyPropertyChanged ---
        /// <summary>
        /// PropertyChanged event of the INotifyPropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise the PropertyChanged event.
        /// </summary>
        /// <param name="name">name of the property has been changed</param>
        protected void RaisePropertyChanged( string name ) {
            if( PropertyChanged != null )
                PropertyChanged( this, new PropertyChangedEventArgs( name ) );
        }

        #endregion

        #region --- Data ---
        /// <summary>
        /// Whether is inquiring.
        /// </summary>
        private bool _isInquiring;
        #endregion

        #region ---附加属性 Dependency properties ---

        /// <summary>
        /// 行情编码列表
        /// </summary>
        public ObservableCollection<string> Stockcodes
        {
            get { return (ObservableCollection<string>)GetValue(StockcodesProperty); }
            set { SetValue(StockcodesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stockcodes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StockcodesProperty =
            DependencyProperty.Register("Stockcodes", typeof(ObservableCollection<string>), typeof(InquiryCustomControl));

        

        public Visibility AccountVisibility
        {
            get { return (Visibility)GetValue(AccountVisibilityProperty); }
            set { SetValue(AccountVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AccountVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccountVisibilityProperty =
            DependencyProperty.Register("AccountVisibility", typeof(Visibility), typeof(InquiryCustomControl), new UIPropertyMetadata(Visibility.Visible));


        /// <summary>
        /// 会员列表
        /// </summary>
        public ObservableCollection<OrgInfo> POrgList
        {
            get { return (ObservableCollection<OrgInfo>)GetValue(POrgListProperty); }
            set { SetValue(POrgListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for POrgList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty POrgListProperty =
            DependencyProperty.Register("POrgList", typeof(ObservableCollection<OrgInfo>), typeof(InquiryCustomControl));




        public string OrgName
        {
            get { return (string)GetValue(OrgNameProperty); }
            set { SetValue(OrgNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OrgName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrgNameProperty =
            DependencyProperty.Register("OrgName", typeof(string), typeof(InquiryCustomControl), new UIPropertyMetadata(null));




        public Visibility OrgNameVisibility
        {
            get { return (Visibility)GetValue(OrgNameVisibilityProperty); }
            set { SetValue(OrgNameVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OrgNameVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrgNameVisibilityProperty =
            DependencyProperty.Register("OrgNameVisibility", typeof(Visibility), typeof(InquiryCustomControl), new UIPropertyMetadata(Visibility.Collapsed));



        public Visibility AlterButtonVisibility
        {
            get { return (Visibility)GetValue(AlterButtonVisibilityProperty); }
            set { SetValue(AlterButtonVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AlterButtonVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AlterButtonVisibilityProperty =
            DependencyProperty.Register("AlterButtonVisibility", typeof(Visibility), typeof(InquiryCustomControl), new UIPropertyMetadata(Visibility.Collapsed));



        public static readonly DependencyProperty AccountNameProperty =
            DependencyProperty.Register( "AccountName", typeof( string ), typeof( InquiryCustomControl ), new UIPropertyMetadata( "" ) );

        public static readonly DependencyProperty CurrentPageItemCountProperty =
            DependencyProperty.Register( "CurrentPageItemCount", typeof( int ), typeof( InquiryCustomControl ), new UIPropertyMetadata( 0 ) );

        public static readonly DependencyProperty EndDateProperty =
            DependencyProperty.Register( "EndDate", typeof( DateTime ), typeof( InquiryCustomControl ), new UIPropertyMetadata( DateTime.Today, ( s, e ) => {
                InquiryCustomControl icc = s as InquiryCustomControl;
                if( icc != null )
                    icc.ResetStartDate( );
            } ) );

        public static readonly DependencyProperty PageCountProperty =
            DependencyProperty.Register( "PageCount", typeof( int ), typeof( InquiryCustomControl ), new UIPropertyMetadata( 0 ) );

        public static readonly DependencyProperty PageIndexProperty =
            DependencyProperty.Register( "PageIndex", typeof( int ), typeof( InquiryCustomControl ), new UIPropertyMetadata( 1 ) );

        public static readonly DependencyProperty PageSizeProperty =
            DependencyProperty.Register( "PageSize", typeof( int ), typeof( InquiryCustomControl ), new UIPropertyMetadata( 10 ) );

        /// <summary>
        /// 产品名称列表是否显示
        /// </summary>
        public static readonly DependencyProperty IsProductNameVisibilityProperty =
            DependencyProperty.Register("IsProductNameVisibility", typeof(Visibility), typeof(InquiryCustomControl), new UIPropertyMetadata(Visibility.Visible));

        /// <summary>
        /// 定单类型下拉列表是否显示
        /// </summary>
        public static readonly DependencyProperty IsOrdersTypeVisibilityProperty =
            DependencyProperty.Register("IsOrdersTypeVisibility", typeof(Visibility), typeof(InquiryCustomControl), new UIPropertyMetadata(Visibility.Visible));
        
        public static readonly DependencyProperty ProductListProperty =
            DependencyProperty.Register( "ProductList", typeof( IEnumerable<ProductInformation> ), typeof( InquiryCustomControl ), new UIPropertyMetadata( null, ( s, e ) => {
                InquiryCustomControl icc = s as InquiryCustomControl;

                var list = e.NewValue as ObservableCollection<ProductInformation>;
                if( list != null ) {
                    list.CollectionChanged += ( sdr, ea ) => {
                        if( icc != null )
                            icc.RaisePropertyChanged( "ProductItems" );
                    };
                }

                if( icc != null )
                    icc.RaisePropertyChanged( "ProductItems" );
            } ) );

        public static readonly DependencyProperty StartDateProperty =
            DependencyProperty.Register( "StartDate", typeof( DateTime ), typeof( InquiryCustomControl ), new UIPropertyMetadata( DateTime.Today.AddDays( 0 ), ( s, e ) => {
                InquiryCustomControl icc = s as InquiryCustomControl;
                if( icc != null )
                    icc.ResetEndDate( );
            } ) );

        /// <summary>
        /// 产品名称列表是否显示
        /// </summary>
        public Visibility IsProductNameVisibility
        {
            get { return (Visibility)GetValue(IsProductNameVisibilityProperty); }
            set { SetValue(IsProductNameVisibilityProperty, value); }
        }

        /// <summary>
        /// 定单类型下拉列表是否显示
        /// </summary>
        public Visibility IsOrdersTypeVisibility
        {
            get { return (Visibility)GetValue(IsOrdersTypeVisibilityProperty); }
            set { SetValue(IsOrdersTypeVisibilityProperty, value); }
        }

        /// <summary>
        /// 获取或设置客户账号
        /// </summary>
        public string AccountName
        {
            get { return (string)GetValue(AccountNameProperty); }
            set { SetValue(AccountNameProperty, value); }
        }

        /// <summary>
        /// Gets or sets current page item's count
        /// </summary>
        public int CurrentPageItemCount {
            get { return ( int )GetValue( CurrentPageItemCountProperty ); }
            set { SetValue( CurrentPageItemCountProperty, value ); }
        }

        /// <summary>
        /// Gets or sets the end date time to filter history result.
        /// </summary>
        public DateTime EndDate {
            get { return ( DateTime )GetValue( EndDateProperty ); }
            set { SetValue( EndDateProperty, value ); }
        }

        /// <summary>
        /// Gets or sets page count.
        /// </summary>
        public int PageCount {
            get { return ( int )GetValue( PageCountProperty ); }
            set { SetValue( PageCountProperty, value ); }
        }

        /// <summary>
        /// Gets or sets page index.
        /// </summary>
        public int PageIndex {
            get { return ( int )GetValue( PageIndexProperty ); }
            set { SetValue( PageIndexProperty, value ); }
        }

        /// <summary>
        /// Gets or sets page size.
        /// </summary>
        public int PageSize {
            get { return ( int )GetValue( PageSizeProperty ); }
            set { SetValue( PageSizeProperty, value ); }
        }

        ///<summary>
        ///Gets or sets product data list.
        ///</summary>
        public IEnumerable<ProductInformation> ProductList {
            get { return ( IEnumerable<ProductInformation> )GetValue( ProductListProperty ); }
            set { SetValue( ProductListProperty, value ); }
        }

        /// <summary>
        /// Gets or sets the start date time to filter history result.
        /// </summary>
        public DateTime StartDate {
            get { return ( DateTime )GetValue( StartDateProperty ); }
            set { SetValue( StartDateProperty, value ); }
        }
        #endregion

        #region --- Property 商品名称---
        private List<string> _productItems;

        /// <summary>
        /// Gets product items' name string.商品名称
        /// </summary>
        public List<string> ProductItems {
            get {
                if( _productItems == null )
                    _productItems = new List<string>( );

                _productItems.Clear( );
                _productItems.Add( "全部" );
                if( ProductList != null ) {
                    foreach( var item in ProductList ) {
                        _productItems.Add( item.ProductName );
                        if (!Stockcodes.Contains(item.StockCode))
                        {
                            Stockcodes.Add(item.StockCode);
                        }
                        
                    }
                }
                return _productItems;
            }
        }
        #endregion


      

        #region --- Constructor 构造函数 ---
        /// <summary>
        /// Constructor 构造函数
        /// </summary>
        public InquiryCustomControl( ) {
            InitializeComponent( );
            Stockcodes = new ObservableCollection<string>();
            Stockcodes.Add("全部");
        }
        #endregion

        #region --- Helper method 重置开始或结束时间---
        /// <summary>
        /// Reset end date time.设置结束时间，如果开始时间大于结束时间，则开始时间与结束时间相等
        /// </summary>
        private void ResetEndDate( ) {
            if( EndDate < StartDate ) {
                EndDate = StartDate;
            }
        }

        /// <summary>
        /// Reset start date time.设置开始时间，如果开始时间大于结束时间，则开始时间与结束时间相等
        /// </summary>
        private void ResetStartDate( ) {
            if( StartDate > EndDate ) {
                StartDate = EndDate;
            }
        }
        #endregion

        #region --- Custom event 自定义事件---
        public static readonly RoutedEvent DoSearchEvent
            = EventManager.RegisterRoutedEvent( "DoSearch", RoutingStrategy.Bubble, typeof( DoSearchEventHandler ), typeof( InquiryCustomControl ) );

        /// <summary>
        /// Do search event handler
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="args">event args</param>
        public delegate void DoSearchEventHandler( object sender, DoSearchEventArgs args );

        /// <summary>
        /// Do search event.
        /// </summary>
        public event DoSearchEventHandler DoSearch {
            add { AddHandler( DoSearchEvent, value ); }
            remove { RemoveHandler( DoSearchEvent, value ); }
        }


        public static readonly RoutedEvent DoExcelEvent 
            = EventManager.RegisterRoutedEvent("DoExcel", RoutingStrategy.Bubble, typeof(DoExcelEventHandler), typeof(InquiryCustomControl));

        /// <summary>
        /// DoExcel event handler
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="args">event args</param>
        public delegate void DoExcelEventHandler(object sender, DoSearchEventArgs args);

        /// <summary>
        /// DoExcel event.
        /// </summary>
        public event DoSearchEventHandler DoExcel
        {
            add { AddHandler(DoExcelEvent, value); }
            remove { RemoveHandler(DoExcelEvent, value); }
        }

        /// <summary>
        /// Get order's type string.获取定单类型
        /// </summary>
        /// <returns>order type string</returns>
        private string GetOrdersTypeString( ) {
            if( CbOrdersType.SelectedIndex == 0 )
                return "all";
            else if( CbOrdersType.SelectedIndex == 1 )
                return "0";//买涨
            else
                return "1";//买跌
        }

        /// <summary>
        /// Get selected product name 获取选择的产品名称
        /// </summary>
        /// <returns>selected product data name</returns>
        private string GetSelectedProductName( ) {
            return CbProductName.SelectedIndex == 0 ? "all" : CbProductName.SelectedValue as string;
        }

        private string GetSelectedStockCode()
        {
            return this.CbStockCode.SelectedIndex == 0 ? null : CbStockCode.SelectedValue as string;
        }

        /// <summary>
        /// Raise do search event.
        /// </summary>
        private void RaiseDoSearch( ) {
            _isInquiring = true;
            DoSearchEventArgs args = new DoSearchEventArgs( DoSearchEvent, this ) {
                PageIndex = PageIndex,
                PageSize = PageSize,
                ProductName = GetSelectedProductName( ),
                StartDate = StartDate,
                EndDate = EndDate.AddDays( 1 ).AddSeconds( -1 ),
                OrdersTypeString = GetOrdersTypeString( ),
                AccountName = AccountName,
                OrgName=OrgName,
                StockCode = GetSelectedStockCode(),
            };

            RaiseEvent( args );
            _isInquiring = false;
        }


        /// <summary>
        /// Raise do search event.
        /// </summary>
        private void RaiseDoExcel()
        {
            _isInquiring = true;
            DoSearchEventArgs args = new DoSearchEventArgs(DoExcelEvent, this)
            {
                PageIndex = PageIndex,
                PageSize = PageSize,
                ProductName = GetSelectedProductName(),
                StartDate = StartDate,
                EndDate = EndDate.AddDays(1).AddSeconds(-1),
                OrdersTypeString = GetOrdersTypeString(),
                AccountName = AccountName,
                StockCode= this.CbStockCode.SelectedItem.ToString(),
            };

            RaiseEvent(args);
            _isInquiring = false;
        }
        #endregion

        #region --- Command ---
        /// <summary>
        /// CanExecute command : Find
        /// </summary>
        /// <param name="sender">command sender</param>
        /// <param name="e">event args</param>
        private void CommandBinding_CanExecute_Find( object sender, CanExecuteRoutedEventArgs e ) {
            e.CanExecute = !_isInquiring;
            e.Handled = true;
        }

        /// <summary>
        /// Execute command : Find
        /// </summary>
        /// <param name="sender">command sender</param>
        /// <param name="e">event args</param>
        private void CommandBinding_Executed_Find( object sender, ExecutedRoutedEventArgs e ) {
            RaiseDoSearch( );
        }
        #endregion

        #region --- PageChanged event ---
        /// <summary>
        /// Page changed event.
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="args">event args</param>
        private void DataPagePicker_PageChanged( object sender, PageChangedEventArgs args ) {
            RaiseDoSearch( );
        }
        #endregion


        public Visibility IsUserIDVisbility
        {
            get { return (Visibility)GetValue(IsUserIDVisbilityProperty); }
            set { SetValue(IsUserIDVisbilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsUserIDVisbility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsUserIDVisbilityProperty =
            DependencyProperty.Register("IsUserIDVisbility", typeof(Visibility), typeof(InquiryCustomControl));

        private void CommandBinding_Executed_Excel(object sender, ExecutedRoutedEventArgs e)
        {
            RaiseDoExcel();
        }

        private void CommandBinding_CanExecute_Excel(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !_isInquiring;
            e.Handled = true;
        }

        public bool CanSearch { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AutoComboBoxState sf = this.ACB.State;
            if (sf == AutoComboBoxState.AlterState)
            {
                CanSearch = false;
                MessageBox.Show("请选择正确的会员名称！");
            }
            else
            {
                CanSearch = true;
            }
        }
    }

    /// <summary>
    /// Do search event args inherit RoutedEventArgs.
    /// </summary>
    public class DoSearchEventArgs : RoutedEventArgs {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="routedEvent">Routed event</param>
        /// <param name="source">source</param>
        public DoSearchEventArgs( RoutedEvent routedEvent, object source )
            : base( routedEvent, source ) {

        }

        /// <summary>
        /// 获取或设置客户账号
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets end date time.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets order's type string.
        /// </summary>
        public string OrdersTypeString { get; set; }

        /// <summary>
        /// Gets or sets page index.
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the selected product name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets start date time.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string OrgName { get; set; }
        /// <summary>
        /// 行情编码
        /// </summary>
        public string StockCode { get; set; }
       
    }

}
