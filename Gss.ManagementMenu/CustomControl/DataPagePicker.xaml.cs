using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gss.ManagementMenu.CustomControl
{
    /// <summary>
    /// DataPagePicker.xaml 的交互逻辑
    /// </summary>
    public partial class DataPagePicker : INotifyPropertyChanged {
        #region --- Interface-INotifyPropertyChanged ---
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

        #region --- Constructor ---
        /// <summary>
        /// Constructor
        /// </summary>
        public DataPagePicker() {
            InitializeComponent();
        } 
        #endregion
        
        #region --- Dependency properties ---

        // Using a DependencyProperty as the backing store for CurrentPageItemCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageItemCountProperty =
            DependencyProperty.Register( "CurrentPageItemCount", typeof( int ), typeof( DataPagePicker ), new UIPropertyMetadata( 0 ) );

        // Using a DependencyProperty as the backing store for PageCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageCountProperty =
            DependencyProperty.Register( "PageCount", typeof( int ), typeof( DataPagePicker ), new UIPropertyMetadata( 0, ( s, e ) => {
                DataPagePicker dp = s as DataPagePicker;
                if( dp != null ) {
                    dp.CoercePageCount();
                }
            } ) );

        // Using a DependencyProperty as the backing store for PageIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageIndexProperty =
            DependencyProperty.Register( "PageIndex", typeof( int ), typeof( DataPagePicker ), new UIPropertyMetadata( 1, ( s, e ) => {
                DataPagePicker dp = s as DataPagePicker;
                if( dp != null ) 
                {
                    dp.CoercePageIndex();
                }
            } ) );

        // Using a DependencyProperty as the backing store for PageSizeList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageSizeListProperty =
            DependencyProperty.Register( "PageSizeList", typeof( string ), typeof( DataPagePicker ), new UIPropertyMetadata( "5,10,20,30", ( s, e ) => {
                DataPagePicker dp = s as DataPagePicker;
                if( dp == null ) {
                    return;
                }

                if( dp.PageSizeItems == null )
                    dp.PageSizeItems = new List<int>();
                else
                    dp.PageSizeItems.Clear();
                dp.RaisePropertyChanged( "PageSizeItems" );
            } ) );

        // Using a DependencyProperty as the backing store for PageSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageSizeProperty =
            DependencyProperty.Register( "PageSize", typeof( int ), typeof( DataPagePicker ), new UIPropertyMetadata( 10, ( s, e ) => {
                DataPagePicker dp = s as DataPagePicker;
                if( dp != null ) {
                    dp.CoercePageSize();
                }
            } ) );

        /// <summary>
        /// Gets or sets current page item's count
        /// </summary>
        public int CurrentPageItemCount {
            get { return ( int )GetValue( CurrentPageItemCountProperty ); }
            set { SetValue( CurrentPageItemCountProperty, value ); }
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

        /// <summary>
        /// Gets or sets page size list, split by comma.
        /// </summary>
        public string PageSizeList {
            get { return ( string )GetValue( PageSizeListProperty ); }
            set { SetValue( PageSizeListProperty, value ); }
        }
        #endregion

        #region --- Custom event ---
        public static readonly RoutedEvent PageChangedEvent = EventManager.RegisterRoutedEvent( "PageChanged", RoutingStrategy.Bubble, typeof( PageChangedEventHandler ), typeof( DataPagePicker ) );

        private PageChangedEventArgs _pageChangedEventArgs;

        /// <summary>
        /// Page changed event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public delegate void PageChangedEventHandler( object sender, PageChangedEventArgs args );

        /// <summary>
        /// Add or remove PageChanged event.
        /// </summary>
        public event PageChangedEventHandler PageChanged {
            add { AddHandler( PageChangedEvent, value ); }
            remove { RemoveHandler( PageChangedEvent, value ); }
        }

        /// <summary>
        /// Raise PageChanged event.
        /// </summary>
        private void RaisePageChanged() {
            if( _pageChangedEventArgs == null ) {
                _pageChangedEventArgs = new PageChangedEventArgs( PageChangedEvent, PageSize, PageIndex );
            } else {
                _pageChangedEventArgs.PageSize = PageSize;
                _pageChangedEventArgs.PageIndex = PageIndex;
            }
            RaiseEvent( _pageChangedEventArgs );
        }
        #endregion

        #region property
        private bool IsFirstLosd = true;
        private List<int> _pageSizeItems;

        public List<int> PageSizeItems {
            get {
                if( _pageSizeItems == null ) {
                    _pageSizeItems = new List<int>();
                }
                if( PageSizeList != null ) {
                    List<string> strs = PageSizeList.Split( new[] { ',' }, StringSplitOptions.RemoveEmptyEntries ).ToList();
                    _pageSizeItems.Clear();
                    strs.ForEach( c => _pageSizeItems.Add( Convert.ToInt32( c ) ) );
                }
                return _pageSizeItems;
            }
            set {
                if( _pageSizeItems != value ) {
                    _pageSizeItems = value;
                    RaisePropertyChanged( "PageSizeItems" );
                }
            }
        } 
        #endregion

        #region --- Helper method ---
        /// <summary>
        /// Coerce page count.
        /// </summary>
        public void CoercePageCount() {
            if( PageIndex >= PageCount )
                PageIndex = 1;
        }

        /// <summary>
        /// Coerce page index.
        /// </summary>
        public void CoercePageIndex() {
            if( PageIndex < 0 )
                PageIndex = 1;
            else if( PageCount != 0 && PageIndex > PageCount )
                PageIndex = PageCount;
        }

        /// <summary>
        /// Coerce page size.
        /// </summary>
        public void CoercePageSize() {
            PageIndex = 1;
            if( PageCount != 0 )
                RaisePageChanged();
        }
        #endregion

        #region --- Event ---
        /// <summary>
        /// TextBlock preview key down event.
        /// </summary>
        /// <param name="sender">TextBlock</param>
        /// <param name="e">event args</param>
        private void tbPageIndex_PreviewKeyDown( object sender, KeyEventArgs e ) {
            if( ( e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 ) || ( ( e.Key >= Key.D0 && e.Key <= Key.D9 ) && e.KeyboardDevice.Modifiers != ModifierKeys.Shift ) || e.Key == Key.Tab || e.Key == Key.Enter || e.Key == Key.Back || e.Key == Key.Delete ) {
                if( e.Key == Key.Enter ) {
                    int pIdx;
                    if( !Int32.TryParse( tbPageIndex.Text, out pIdx ) ) {
                        pIdx = 1;
                    }

                    PageIndex = pIdx;
                    RaisePageChanged();
                }

                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }

        /// <summary>
        /// TextBlock text changed event.
        /// </summary>
        /// <param name="sender">TextBlock</param>
        /// <param name="e">event args</param>
        private void tbPageIndex_TextChanged( object sender, TextChangedEventArgs e ) {
            TextBox textBox = sender as TextBox;
            if( e.Changes.Count == 0 )
                return;
            TextChange[] change = new TextChange[e.Changes.Count];
            e.Changes.CopyTo( change, 0 );

            int offset = change[0].Offset;
            if( change[0].AddedLength > 0 ) {
                double num = 0;
                if( !Double.TryParse( textBox.Text, out num ) ) {
                    textBox.Text = textBox.Text.Remove( offset, change[0].AddedLength );
                    textBox.Select( offset, 0 );
                }
            }

        }
        #endregion

        #region --- Command ---
        /// <summary>
        /// CanExecute command : Backward
        /// </summary>
        /// <param name="sender">command sender</param>
        /// <param name="e">event args</param>
        private void CommandBinding_CanExecute_Backward( object sender, CanExecuteRoutedEventArgs e ) {
            e.CanExecute = PageIndex < PageCount;

            e.Handled = true;
        }

        /// <summary>
        /// CanExecute command : Forward
        /// </summary>
        /// <param name="sender">command sender</param>
        /// <param name="e">event args</param>
        private void CommandBinding_CanExecute_Forward( object sender, CanExecuteRoutedEventArgs e ) {
            e.CanExecute = PageIndex > 1;

            e.Handled = true;
        }

        /// <summary>
        /// Executed command : FirstPage
        /// </summary>
        /// <param name="sender">command sender</param>
        /// <param name="e">event args</param>
        private void CommandBinding_Executed_FirstPage( object sender, ExecutedRoutedEventArgs e ) {
            PageIndex = 1;
            RaisePageChanged();
        }

        /// <summary>
        /// Executed command : LastPage
        /// </summary>
        /// <param name="sender">command sender</param>
        /// <param name="e">event args</param>
        private void CommandBinding_Executed_LastPage( object sender, ExecutedRoutedEventArgs e ) {
            PageIndex = PageCount;
            RaisePageChanged();
        }

        /// <summary>
        /// Executed command : NextPage
        /// </summary>
        /// <param name="sender">command sender</param>
        /// <param name="e">event args</param>
        private void CommandBinding_Executed_NextPage( object sender, ExecutedRoutedEventArgs e ) {
            if( PageIndex < PageCount )
                PageIndex++;
            RaisePageChanged();
        }

        /// <summary>
        /// Executed command : PreviousPage
        /// </summary>
        /// <param name="sender">command sender</param>
        /// <param name="e">event args</param>
        private void CommandBinding_Executed_PreviousPage( object sender, ExecutedRoutedEventArgs e ) {
            if( PageIndex > 1 )
                PageIndex--;
            RaisePageChanged();
        }

        /// <summary>
        /// Executed command : Refresh
        /// </summary>
        /// <param name="sender">command sender</param>
        /// <param name="e">event args</param>
        private void CommandBinding_Executed_Refresh( object sender, ExecutedRoutedEventArgs e ) {
            RaisePageChanged();
        }
        #endregion

        private void dp_Loaded(object sender, RoutedEventArgs e)
        {
            //if (IsFirstLosd)
            //{
            //    RaisePageChanged();
            //    IsFirstLosd = false;
            //}           
        }
    }

    /// <summary>
    /// Page changed event args inherit RoutedEventArgs.
    /// </summary>
    public class PageChangedEventArgs : RoutedEventArgs {
        public PageChangedEventArgs( RoutedEvent routeEvent, int pageSize, int pageIndex )
            : base( routeEvent ) {
            PageSize = pageSize;
            PageIndex = pageIndex;
        }

        /// <summary>
        /// Gets or sets page index.
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets page size.
        /// </summary>
        public int PageSize { get; set; }
    }
}
