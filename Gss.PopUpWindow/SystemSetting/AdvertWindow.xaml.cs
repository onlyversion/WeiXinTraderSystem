using System;
using System.Collections.Generic;
using System.IO;
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

namespace Gss.PopUpWindow.SystemSetting
{
    /// <summary>
    /// AdvertWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AdvertWindow : Window
    {
        public AdvertWindow()
        {
            InitializeComponent();
        }
        public event Action OpenImage;

        public string AdvertName
        {
            get { return (string)GetValue(AdvertNameProperty); }
            set { SetValue(AdvertNameProperty, value); }
        }
        public static readonly DependencyProperty AdvertNameProperty =
    DependencyProperty.Register("AdvertName", typeof(string), typeof(AdvertWindow), new PropertyMetadata(""));

        public string Creater
        {
            get { return (string)GetValue(CreaterProperty); }
            set { SetValue(CreaterProperty, value); }
        }
        public static readonly DependencyProperty CreaterProperty =
    DependencyProperty.Register("Creater", typeof(string), typeof(AdvertWindow), new PropertyMetadata(""));

        public string Remark
        {
            get { return (string)GetValue(RemarkProperty); }
            set { SetValue(RemarkProperty, value); }
        }
        public static readonly DependencyProperty RemarkProperty =
    DependencyProperty.Register("Remark", typeof(string), typeof(AdvertWindow), new PropertyMetadata(""));

        public bool State
        {
            get { return (bool)GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }
        public static readonly DependencyProperty StateProperty =
    DependencyProperty.Register("State", typeof(bool), typeof(AdvertWindow), new PropertyMetadata(true));



        private void btnUpLoad_Click(object sender, RoutedEventArgs e)
        {
            if (OpenImage != null)
            {
                OpenImage.Invoke();
            }
        }
        public void ShowImage(BitmapImage img)
        {
            image.Source = img;
            image.Width = img.PixelWidth;
            image.Height = img.PixelHeight;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
