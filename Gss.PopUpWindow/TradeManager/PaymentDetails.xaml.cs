using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Gss.Entities.TradeManager;

namespace Gss.PopUpWindow.TradeManager
{
    /// <summary>
    /// PaymentDetails.xaml 的交互逻辑
    /// 出入金详情
    /// </summary>
    public partial class PaymentDetails : Window
    {
        public PaymentDetails()
        {
            InitializeComponent();
        }
        #region 事件
        /// <summary>
        /// 付款事件
        /// </summary>
        public event Action<PaymentDetails> PaymentEvent;
        /// <summary>
        /// 拒绝付款事件
        /// </summary>
        public event Action<PaymentDetails> RefusedEvent;
        #endregion

        /// <summary>
        /// 出入金信息
        /// </summary>
        public TradeChuJinInformation ChuJinInfo
        {
            get { return (TradeChuJinInformation)GetValue(ChuJinInfoProperty); }
            set { SetValue(ChuJinInfoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChuJinInfo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChuJinInfoProperty =
            DependencyProperty.Register("ChuJinInfo", typeof(TradeChuJinInformation), typeof(PaymentDetails));



        /// <summary>
        /// 入金信息
        /// </summary>
        public ClientFundChangeInfo InFundInfo
        {
            get { return (ClientFundChangeInfo)GetValue(InFundInfoProperty); }
            set { SetValue(InFundInfoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InFundInfo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InFundInfoProperty =
            DependencyProperty.Register("InFundInfo", typeof(ClientFundChangeInfo), typeof(PaymentDetails), new PropertyMetadata(new PropertyChangedCallback(SetCmdEnable)));


        /// <summary>
        /// 设置按钮是否可以
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void SetCmdEnable(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PaymentDetails ower = d as PaymentDetails;
            if (ower.ChuJinInfo.State == "0")
            {
                ower.IsCmdEnable = true;
                ower.CanJuJue = true;
            }
            else
            {
                ower.IsCmdEnable = false;
                if (ower.ChuJinInfo.State == "4")
                {
                    ower.CanJuJue = true;
                }
                else
                {
                    ower.CanJuJue = false;
                }

            }

        }



        public bool CanJuJue
        {
            get { return (bool)GetValue(CanJuJueProperty); }
            set { SetValue(CanJuJueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanJuJue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanJuJueProperty =
            DependencyProperty.Register("CanJuJue", typeof(bool), typeof(PaymentDetails));




        /// <summary>
        /// 命令是否禁用
        /// </summary>
        public bool IsCmdEnable
        {
            get { return (bool)GetValue(IsCmdEnableProperty); }
            set { SetValue(IsCmdEnableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsCmdEnable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCmdEnableProperty =
            DependencyProperty.Register("IsCmdEnable", typeof(bool), typeof(PaymentDetails));



        /// <summary>
        /// 出金信息
        /// </summary>
        public ClientFundChangeInfo OutFundInfo
        {
            get { return (ClientFundChangeInfo)GetValue(OutFundInfoProperty); }
            set { SetValue(OutFundInfoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OutFundInfo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OutFundInfoProperty =
            DependencyProperty.Register("OutFundInfo", typeof(ClientFundChangeInfo), typeof(PaymentDetails));

        /// <summary>
        /// 付款
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.PaymentEvent != null)
            {
                PaymentEvent.Invoke(this);
            }
        }
        /// <summary>
        /// 拒绝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.RefusedEvent != null)
            {
                this.RefusedEvent.Invoke(this);
            }
        }





    }
}
