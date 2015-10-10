using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Gss.PopUpWindow.CustomCotrol
{
    public class HeightLightTextBlock : TextBlock
    {

        public HeightLightTextBlock()
        {
            this.Margin = new Thickness(0, 2, 0, 0);
            this.Height = 26;


        }



        public object Sour
        {
            get { return (object)GetValue(SourProperty); }
            set { SetValue(SourProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Sour.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourProperty =
            DependencyProperty.Register("Sour", typeof(object), typeof(HeightLightTextBlock));


        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWords
        {
            get { return (string)GetValue(KeyWordsProperty); }
            set { SetValue(KeyWordsProperty, value); }
        }
        public static readonly DependencyProperty KeyWordsProperty =
            DependencyProperty.Register("KeyWords", typeof(string), typeof(HeightLightTextBlock), new PropertyMetadata(OnKeyWordsPropertyChange));

        private static void OnKeyWordsPropertyChange(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            HeightLightTextBlock txt = obj as HeightLightTextBlock;
            txt.SetKeyWordsColor(e.NewValue.ToString());
        }

        /// <summary>
        /// 关键字颜色设置
        /// </summary>
        /// <param name="keyWords">关键字</param>
        private void SetKeyWordsColor(string keyWords)
        {
            string str = this.Text;

            //获取关键字在文本中的索引
            int idx = str.ToLower().IndexOf(KeyWords.ToLower());

            if (idx < 0)
            {
                return;
            }
            this.Inlines.Clear();

            //关键字之前的字段
            string s1 = str.Substring(0, idx);
            Run runTxt1 = new Run();
            runTxt1.Text = s1;
            runTxt1.FontSize = this.FontSize + 2;
            runTxt1.FontWeight = FontWeights.Bold;

            //关键字
            string s2 = str.Substring(idx, KeyWords.Length);
            Run runTxt2 = new Run();
            runTxt2.Text = s2;
            runTxt2.Foreground = new SolidColorBrush(Colors.Red);

            //关键字之后的字段
            string s3 = str.Substring(idx + KeyWords.Length);
            Run runTxt3 = new Run();
            runTxt3.Text = s3;
            runTxt3.FontWeight = FontWeights.Bold;


            runTxt3.FontSize = this.FontSize + 2;
            this.Inlines.Add(runTxt1);
            this.Inlines.Add(runTxt2);
            this.Inlines.Add(runTxt3);
        }
    }
}
