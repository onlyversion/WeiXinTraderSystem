using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Gss.Common.Utility;
using Gss.Entities;
using Gss.Entities.Enums;
using Gss.ViewModel.Management;
using System.Net;

namespace JxSystem {
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : INotifyPropertyChanged { 
        #region 成员
        private const string ConstUserInfoFile = "Config.dat";

        private BackgroundWorker _worker;
        private ManagementViewModel _vm;

        #endregion

        #region 属性

        private bool _logging;

        /// <summary>
        /// 获取或设置正在登陆标识符
        /// </summary>
        public bool Logging {
            get { return _logging; }
            set {
                if( _logging != value ) {
                    _logging = value;
                    RaisePropertyChanged( "Logging" );

                    if( _logging ) {
                        ReadyToLogin = LoginFailed = false;
                    }
                }
            }
        }

        private bool _readyToLogin;

        /// <summary>
        /// 获取或设置准备登陆标识符
        /// </summary>
        public bool ReadyToLogin {
            get { return _readyToLogin; }
            set {
                if( _readyToLogin != value ) {
                    _readyToLogin = value;
                    RaisePropertyChanged( "ReadyToLogin" );

                    if( _readyToLogin ) {
                        LoginFailed = Logging = false;
                    } 
                }
            }
        }

        private bool _loginFailed;

        /// <summary>
        /// 获取或设置登陆失败标识符
        /// </summary>
        public bool LoginFailed {
            get { return _loginFailed; }
            set {
                if( _loginFailed != value ) {
                    _loginFailed = value;
                    RaisePropertyChanged( "LoginFailed" );

                    if( _loginFailed )
                        Logging = ReadyToLogin = false; 
                }
            }
        }

        #endregion

        #region 依赖属性

        public string ErrorMessage {
            get { return ( string )GetValue( ErrorMessageProperty ); }
            set { SetValue( ErrorMessageProperty, value ); }
        }

        // Using a DependencyProperty as the backing store for ErrorMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register( "ErrorMessage", typeof( string ), typeof( LoginWindow ), new UIPropertyMetadata( "" ) );

        /// <summary>
        /// 获取或设置是否记住用户名
        /// </summary>
        public bool RememberUserName {
            get { return ( bool )GetValue( RememberUserNameProperty ); }
            set { SetValue( RememberUserNameProperty, value ); }
        }

        // Using a DependencyProperty as the backing store for RememberUserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RememberUserNameProperty =
            DependencyProperty.Register( "RememberUserName", typeof( bool ), typeof( LoginWindow ), new UIPropertyMetadata( false ) );

        /// <summary>
        /// 获取或设置是否记住密码
        /// </summary>
        public bool RememberPassword {
            get { return ( bool )GetValue( RememberPasswordProperty ); }
            set { SetValue( RememberPasswordProperty, value ); }
        }

        // Using a DependencyProperty as the backing store for RememberPassword.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RememberPasswordProperty =
            DependencyProperty.Register( "RememberPassword", typeof( bool ), typeof( LoginWindow ), new UIPropertyMetadata( false ) );

        /// <summary>
        /// 获取或设置账户名
        /// </summary>
        public string AccountName {
            get { return ( string )GetValue( AccountNameProperty ); }
            set { SetValue( AccountNameProperty, value ); }
        }

        // Using a DependencyProperty as the backing store for AccountName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccountNameProperty =
            DependencyProperty.Register( "AccountName", typeof( string ), typeof( LoginWindow ), new UIPropertyMetadata( "" ) );

        /// <summary>
        /// 获取或设置账户类型
        /// </summary>
        public ACCOUNT_TYPE AccType {
            get { return ( ACCOUNT_TYPE )GetValue( AccTypeProperty ); }
            set { SetValue( AccTypeProperty, value ); }
        }

        // Using a DependencyProperty as the backing store for AccType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccTypeProperty =
            DependencyProperty.Register( "AccType", typeof( ACCOUNT_TYPE ), typeof( LoginWindow ), new UIPropertyMetadata( ACCOUNT_TYPE.Manager ) );

        #endregion

        #region 构造函数

        public LoginWindow( ) {
            ReadyToLogin = true;

            InitializeComponent( );

            InitializeUserInfo( );
            this.Closing += (e, v) =>
                                {
                                    if (_worker!=null&&_worker.IsBusy)
                                        v.Cancel = true;
                                    else
                                        v.Cancel = false;
                                };
        }

        #endregion

        #region 命令

        private void CommandBinding_Executed_Login( object sender, ExecutedRoutedEventArgs e ) {
            Logging = true;
             
            //ACCOUNT_TYPE accType;
            //if(CbAccType.SelectedIndex == 0 ) 
            //{
            //    accType = ACCOUNT_TYPE.Manager;
            //} else
            //{
            //    accType = ACCOUNT_TYPE.Dealer;
            //}

            ComboBoxItem cmbItem = cmbServeceAddress.SelectedItem as ComboBoxItem;
            if (cmbItem != null)
            {
                if (cmbItem.Content.ToString() == "模拟服务器")
                    ServceConnectType.ConnectType = ConnectType.ImitateServiec;
                else
                    ServceConnectType.ConnectType = ConnectType.StockServiec;

            }

            _worker = new BackgroundWorker( );
            _worker.DoWork += BackgroundWorker_DoWork;
            _worker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            _worker.WorkerSupportsCancellation = true;

            _worker.RunWorkerAsync(new LoginInformation(TbAccountName.Text, PbPassword.Password, AccType));
        }

        private void CommandBinding_CanExecute_Login( object sender, CanExecuteRoutedEventArgs e ) {
            if( this.IsInitialized )
                e.CanExecute = TbAccountName.Text.Length > 0 && PbPassword.Password.Length > 0;
            else
                e.CanExecute = false;
        }

        private void CommandBinding_Executed_Cancel( object sender, ExecutedRoutedEventArgs e ) {
            ReadyToLogin = true;
            _worker.CancelAsync( );
        }

        private void CommandBinding_Executed_Back( object sender, ExecutedRoutedEventArgs e ) {
            ReadyToLogin = true;
        }

        #endregion

        #region 后台登陆
        private void BackgroundWorker_DoWork( object sender, System.ComponentModel.DoWorkEventArgs e ) {
            try {
                LoginInformation loginInfo = ( LoginInformation )e.Argument;

                if( _worker.CancellationPending ) {
                    e.Cancel = true;
                    return;
                }

                if( _vm != null ) 
                {
                    ErrType err = _vm.Login( loginInfo.AccountName, loginInfo.Password, loginInfo.AccountType );

                    if( _worker.CancellationPending ) 
                    {
                        e.Cancel = true;
                        return;
                    }
                    e.Result = err;
                }
                CheckUpdateProgram();
            } 
            catch( Exception ex ) {
                e.Result = new ErrType(ERR.EXEPTION, ErrorText.ServiceError);
            }

        }

        private void BackgroundWorker_RunWorkerCompleted( object sender, System.ComponentModel.RunWorkerCompletedEventArgs e ) {
            if( e.Cancelled ) {
                ReadyToLogin = true;
                return;
            }

            ErrType err = e.Result as ErrType;
            if( err == GeneralErr.Success )
            {
                MainWindow mainWnd = new MainWindow
                {
                    DataContext = this.DataContext,
                };
                Application.Current.MainWindow = mainWnd;
                mainWnd.Closed += (s, eg) =>
                {
                   Application. Current.Shutdown();
                   _vm.Dispose();
                };
                //登陆后的一些初始化动作
                _vm.Initialize();
                _vm.GetPOrgsList();
                mainWnd.Show();

                SaveUserInfo( );
                DialogResult = true;
                Close();
            }
            else {
                LoginFailed = true;
                ErrorMessage = err.ErrMsg;
            }
        }

        #endregion

        #region 检查更新程序
        /// <summary>
        /// 检查更新程序
        /// </summary>
        private void CheckUpdateProgram()
        {
            try
            {
                //当前目录
                string curDir = Directory.GetCurrentDirectory() + "\\";
                //要检查的文件
                string file = "Jtw.exe";

                //是否需要更新
                bool NeedUpdate = false;
                if (File.Exists(curDir + file))
                {
                    FileVersionInfo FileVersion = FileVersionInfo.GetVersionInfo(curDir + file);
                    if (ConnectConfigData.srvUptFileVersion != FileVersion.FileVersion)
                    {
                        NeedUpdate = true;
                    }

                    //if ("3.0.0.0" != FileVersion.FileVersion)
                    //{
                    //    NeedUpdate = true;
                    //}
                }
                else
                {
                    NeedUpdate = true;
                }
                if (!NeedUpdate)
                {
                    return;
                }
                //服务器更新地址
                string srvUpdateAddr = ConnectConfigData.srvUpdateAddr;

                //建临时目录，缓存下载的文件
                string strTemp = Environment.GetEnvironmentVariable("Temp") + "\\_Jtw_u_p_t1\\";


                if (!Directory.Exists(strTemp))
                {
                    Directory.CreateDirectory(strTemp);
                }
                else
                {
                    Directory.Delete(strTemp, true);
                }

                //利用WebService从远程服务器上下载文件
                WebRequest req = WebRequest.Create(srvUpdateAddr);
                WebResponse res = req.GetResponse();
                if (res.ContentLength > 0)
                {
                    WebClient wClient = new WebClient();
                    //将远程服务器UpdaterUrl指定的文件下载到本地目录serverXmlFile指定的文件夹下
                    wClient.DownloadFile(srvUpdateAddr + file, strTemp + file);

                    File.Copy(strTemp + file, curDir + file, true);
                    //删除缓存中的所有文件
                    Directory.Delete(strTemp, true);
                }
            }
            catch
            {

            }
        }
        #endregion

        #region 实现INotifyPropertyChanged接口

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged( PropertyChangedEventArgs e ) {
            var handler = this.PropertyChanged;
            if( handler != null ) {
                handler( this, e );
            }
        }

        protected void RaisePropertyChanged( String propertyName ) {
            VerifyPropertyName( propertyName );
            OnPropertyChanged( new PropertyChangedEventArgs( propertyName ) );
        }

        /// <summary>
        /// Warns the developer if this Object does not have a public property with
        /// the specified name. This method does not exist in a Release build.
        /// </summary>
        [Conditional( "DEBUG" )]
        [DebuggerStepThrough]
        public void VerifyPropertyName( String propertyName ) {
            // verify that the property name matches a real,  
            // public, instance property on this Object.
            if( TypeDescriptor.GetProperties( this )[propertyName] == null ) {
                Debug.Fail( "Invalid property name: " + propertyName );
            }
        } 
        #endregion

        #region 窗口加载事件
        private void Window_Loaded( object sender, RoutedEventArgs e ) {
            _vm = DataContext as ManagementViewModel;
        } 
        #endregion

        #region 用户信息处理

        private void InitializeUserInfo( ) {
            string file = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, ConstUserInfoFile );
            UserInformation userInfo;
            if( File.Exists( file ) ) {
                userInfo = FileSerialize<UserInformation>.Deserialize( file );
                userInfo.Decrypt( );
            } else
                userInfo = new UserInformation( );

            AccountName = userInfo.AccountName;
            PbPassword.Password = userInfo.Password;
            AccType = userInfo.AccType;
            RememberPassword = userInfo.RememberPassword;
            RememberUserName = userInfo.RememberUserName;
        }

        private void SaveUserInfo( ) {
            string file = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, ConstUserInfoFile );

            string account = RememberUserName ? AccountName : string.Empty;
            string password = RememberPassword ? PbPassword.Password : string.Empty;
            UserInformation userInfo = new UserInformation {
                AccountName = account,
                Password = password,
                RememberUserName = RememberUserName,
                RememberPassword = RememberPassword,
                AccType = AccType,
            };

            userInfo.Encrypt( );
            bool ret = FileSerialize<UserInformation>.Serialize( userInfo, file );
            if( ret ) {
                FileInfo fileInfo = new FileInfo( file );
                fileInfo.Attributes = FileAttributes.Hidden;
            }
        }

        #endregion

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void close_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point curpoint = e.GetPosition(this);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            if (e.Uri != null && string.IsNullOrEmpty(e.Uri.OriginalString) == false)
            {
                string uri = e.Uri.AbsoluteUri;
                Process.Start(new ProcessStartInfo(uri));
                e.Handled = true;
            }
        }
    }
}
