using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Gss.ManagementMenu.CustomControl
{
    public class PopupButton : Button
    {
        public static readonly DependencyProperty TitleProperty =
       DependencyProperty.Register("Title", typeof(string), typeof(PopupButton), new UIPropertyMetadata(""));

        /// <summary>
        /// 按钮的标题文本
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// 按钮的图标
        /// </summary>
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(PopupButton));

        /// <summary>
        /// Popup弱窗内容
        /// </summary>
        public UserControl PopupWindow
        {
            get { return (UserControl)GetValue(PopupWindowProperty); }
            set { SetValue(PopupWindowProperty, value); }
        }

        public static readonly DependencyProperty PopupWindowProperty =
            DependencyProperty.Register("PopupWindow", typeof(UserControl), typeof(PopupButton));

        /// <summary>
        /// 是否显示弹窗
        /// </summary>
        public bool IsPopOpen
        {
            get { return (bool)GetValue(IsPopOpenProperty); }
            set { SetValue(IsPopOpenProperty, value); }
        }

        public static readonly DependencyProperty IsPopOpenProperty =
            DependencyProperty.Register("IsPopOpen", typeof(bool), typeof(PopupButton));

        /// <summary>
        /// 构造函数
        /// </summary>
        public PopupButton()
        {
            // MouseEnter += MyButtonMouseEnter;
            // MouseLeave += MyButtonMouseLeave;
            IsPopOpen = true;

            this.Click += new RoutedEventHandler(PopupButton_Click);
            // this.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(PopupButton_MouseDoubleClick);
        }

        void PopupButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            IsPopOpen = true;
        }

        void PopupButton_Click(object sender, RoutedEventArgs e)
        {

            IsPopOpen = !IsPopOpen;
        }



        /// <summary>
        /// 鼠标离开按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MyButtonMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //IsPopOpen = false;
        }

        /// <summary>
        /// 鼠标进入按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MyButtonMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // IsPopOpen = true;
        }
        //  public Visibility  IsLTriangleShow { get; set; }
        // public Visibility  IsRTriangleShow { get; set; }



        #region 对于左右拥有三角形的Button设置的属性
        /// <summary>
        /// 左侧三角形是否隐藏
        /// </summary>
        public Visibility IsLTriangleShow
        {
            get { return (Visibility)GetValue(IsLTriangleShowProperty); }
            set { SetValue(IsLTriangleShowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLTriangleShow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLTriangleShowProperty =
            DependencyProperty.Register("IsLTriangleShow", typeof(Visibility), typeof(PopupButton));



        /// <summary>
        /// 右侧三角形是否隐藏
        /// </summary>
        public Visibility IsRTriangleShow
        {
            get { return (Visibility)GetValue(IsRTriangleShowProperty); }
            set { SetValue(IsRTriangleShowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsRTriangleShow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsRTriangleShowProperty =
            DependencyProperty.Register("IsRTriangleShow", typeof(Visibility), typeof(PopupButton));
        #endregion






    }
}
