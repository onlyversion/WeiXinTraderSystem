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
using Gss.PopUpWindow.AccountInfoModule;
using Gss.Entities;
using Gss.Common.Utility;
using System.Collections.ObjectModel;
using Gss.Entities.JTWEntityes;
using Gss.Entities.AccountManager;

namespace Gss.PopUpWindow {
    /// <summary>
    /// ClientAccountInfoView.xaml 的交互逻辑
    /// </summary>
    public partial class ClientAccountInfoWindow {
        #region 成员
        public Action ComitEvent;
        private const string DEFAULT_TITLE = "客户账户资料";
        #endregion

        #region 构造函数

        public ClientAccountInfoWindow( ) {
            InitializeComponent( );
            Banks = new ObservableCollection<Bank>();
        }

        
        #endregion

        #region 依赖属性
        //private ObservableCollection<OrgInfo> _POrgList;
        ///// <summary>
        ///// 上级微会员数据集（用于Combox绑定）
        ///// </summary>
        //public ObservableCollection<OrgInfo> POrgList
        //{
        //    get { return _POrgList; }
        //    private set
        //    {
        //        _POrgList = value;
        //        RaisePropertyChanged("POrgList");
        //    }
        //}




        /// <summary>
        /// 会员列表
        /// </summary>
        public ObservableCollection<OrgInfo>  POrgList
        {
            get { return (ObservableCollection<OrgInfo> )GetValue(POrgListProperty); }
            set { SetValue(POrgListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for POrgList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty POrgListProperty =
            DependencyProperty.Register("POrgList", typeof(ObservableCollection<OrgInfo> ), typeof(ClientFundsInfoWindow));




        public ObservableCollection<Bank> Banks
        {
            get { return (ObservableCollection<Bank>)GetValue(BanksProperty); }
            set { SetValue(BanksProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Banks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BanksProperty =
            DependencyProperty.Register("Banks", typeof(ObservableCollection<Bank>), typeof(ClientFundsInfoWindow));




        /// <summary>
        /// 获取或设置本窗口是否为创建模式
        /// </summary>
        public bool CreateMode {
            get { return ( bool )GetValue( CreateModeProperty ); }
            set { SetValue( CreateModeProperty, value ); }
        }

        public static readonly DependencyProperty CreateModeProperty =
            DependencyProperty.Register( "CreateMode", typeof( bool ), typeof( ClientAccountInfoWindow ), new UIPropertyMetadata( false ) );

        /// <summary>
        /// 获取或设置是否为只读模式
        /// </summary>
        public bool IsReadOnly {
            get { return ( bool )GetValue( IsReadOnlyProperty ); }
            set { SetValue( IsReadOnlyProperty, value ); }
        }

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register( "IsReadOnly", typeof( bool ), typeof( ClientAccountInfoWindow ), new UIPropertyMetadata( false, ( s, e ) => {
                if( ( bool )e.NewValue ) {
                    ClientAccountInfoWindow wnd = s as ClientAccountInfoWindow;
                    wnd.SetRealOnlyWindowTitle( );
                } else {
                    ClientAccountInfoWindow wnd = s as ClientAccountInfoWindow;
                    wnd.SetNormalWindowTitle( );
                }
            } ) );

        #endregion

        #region 命令

        private void CommandBinding_Executed_Ok( object sender, ExecutedRoutedEventArgs e ) {
            if (this.ComitEvent != null)
            {
                this.ComitEvent.Invoke();
            }
        }

        private void CommandBinding_Executed_Cancel( object sender, ExecutedRoutedEventArgs e ) {
            this.Close( );
        }

        private void CommandBinding_CanExecute_Ok( object sender, CanExecuteRoutedEventArgs e ) {
            e.CanExecute = !CommonHelper.GetUIElementError(this);
            e.Handled = true;
        }

        #endregion
        
        #region 辅助方法

        private void SetRealOnlyWindowTitle( ) {
            Title = DEFAULT_TITLE + " (只读权限)";
        }

        private void SetNormalWindowTitle( ) {
            Title = DEFAULT_TITLE;
        }

        #endregion
    }
}
