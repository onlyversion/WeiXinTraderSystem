using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Win32;
using System.Web;

namespace Gss.PopUpWindow.SystemSetting
{
    /// <summary>
    /// NewsWindows.xaml 的交互逻辑
    /// </summary>

    public partial class NewsWindows : Window
    {
        public NewsWindows()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty NewsAddressProperty =
DependencyProperty.Register("NewsAddress", typeof(string), typeof(NewsWindows), new UIPropertyMetadata(""));
        /// <summary>
        /// 新闻链接Web地址
        /// </summary>
        public string NewsAddress
        {
            set { SetValue(NewsAddressProperty, value); }
            get { return (string)GetValue(NewsAddressProperty); }
        }

    }

    #region Xaml新闻处理方式
    //   public partial class NewsWindows : Window
    //   {
    //       public NewsWindows()
    //       {
    //           InitializeComponent();
    //           this.Loaded += new RoutedEventHandler(NewsWindows_Loaded);
    //       }

    //       void NewsWindows_Loaded(object sender, RoutedEventArgs e)
    //       {
    //           if (!string.IsNullOrEmpty(NewsContent))
    //           {
    //               TextRange range = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
    //               byte[] buffer = System.Text.Encoding.ASCII.GetBytes(NewsContent);
    //               MemoryStream stream = new MemoryStream(buffer);
    //               range.Load(stream, DataFormats.Xaml);
    //           }

    //       }
    //       public static readonly DependencyProperty NewsContentProperty =
    //DependencyProperty.Register("NewsContent", typeof(string), typeof(NewsWindows), new UIPropertyMetadata(""));

    //       public string NewsContent
    //       {
    //           set { SetValue(NewsContentProperty, value); }
    //           get { return (string)GetValue(NewsContentProperty); }
    //       }
    //       private void btnOk_Click(object sender, RoutedEventArgs e)
    //       {
    //           TextRange range = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
    //           MemoryStream stream = new MemoryStream();
    //           range.Save(stream, DataFormats.Xaml);
    //           stream.Position = 0;
    //           StreamReader r = new StreamReader(stream);
    //           NewsContent = r.ReadToEnd();
    //           r.Close();
    //           stream.Close();
    //           this.DialogResult = true;
    //       }

    //       private void btnCancel_Click(object sender, RoutedEventArgs e)
    //       {
    //           this.DialogResult = false;
    //       }

    //       //加粗
    //       private void cmdBold_Click(object sender, RoutedEventArgs e)
    //       {
    //           if (richTextBox.Selection.Text == "")
    //           {
    //               if (richTextBox.Selection.Start.Paragraph != null)
    //               {
    //                   FontWeight fontWeight = richTextBox.Selection.Start.Paragraph.FontWeight;
    //                   if (fontWeight == FontWeights.Bold)
    //                       fontWeight = FontWeights.Normal;
    //                   else
    //                       fontWeight = FontWeights.Bold;

    //                   richTextBox.Selection.Start.Paragraph.FontWeight = fontWeight;
    //               }
    //           }
    //           else
    //           {
    //               Object obj = richTextBox.Selection.GetPropertyValue(TextElement.FontWeightProperty);
    //               if (obj == DependencyProperty.UnsetValue)
    //               {
    //                   TextRange range = new TextRange(richTextBox.Selection.Start,
    //                       richTextBox.Selection.Start);
    //                   obj = range.GetPropertyValue(TextElement.FontWeightProperty);
    //               }

    //               FontWeight fontWeight = (FontWeight)obj;

    //               if (fontWeight == FontWeights.Bold)
    //                   fontWeight = FontWeights.Normal;
    //               else
    //                   fontWeight = FontWeights.Bold;

    //               richTextBox.Selection.ApplyPropertyValue(
    //                 TextElement.FontWeightProperty, fontWeight);
    //           }
    //       }


    //       //打开
    //       private void cmdOpen_Click(object sender, RoutedEventArgs e)
    //       {
    //           OpenFileDialog openFile = new OpenFileDialog();
    //           openFile.Filter = "XAML Files (*.xaml)|*.xaml|RichText Files (*.rtf)|*.rtf|All Files (*.*)|*.*";

    //           if (openFile.ShowDialog() == true)
    //           {
    //               // Create a TextRange around the entire document.
    //               TextRange documentTextRange = new TextRange(
    //                   richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

    //               using (FileStream fs = File.Open(openFile.FileName, FileMode.Open))
    //               {
    //                   if (System.IO.Path.GetExtension(openFile.FileName).ToLower() == ".rtf")
    //                   {
    //                       documentTextRange.Load(fs, DataFormats.Rtf);
    //                   }
    //                   else
    //                   {
    //                       documentTextRange.Load(fs, DataFormats.Xaml);
    //                   }
    //               }
    //           }
    //       }

    //       //保存
    //       private void cmdSave_Click(object sender, RoutedEventArgs e)
    //       {
    //           SaveFileDialog saveFile = new SaveFileDialog();
    //           saveFile.Filter = "XAML Files (*.xaml)|*.xaml|RichText Files (*.rtf)|*.rtf|All Files (*.*)|*.*";

    //           if (saveFile.ShowDialog() == true)
    //           {
    //               // Create a TextRange around the entire document.
    //               TextRange documentTextRange = new TextRange(
    //                   richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

    //               // If this file exists, it's overwritten.
    //               using (FileStream fs = File.Create(saveFile.FileName))
    //               {
    //                   if (System.IO.Path.GetExtension(saveFile.FileName).ToLower() == ".rtf")
    //                   {
    //                       documentTextRange.Save(fs, DataFormats.Rtf);
    //                   }
    //                   else
    //                   {
    //                       documentTextRange.Save(fs, DataFormats.Xaml);
    //                   }
    //               }
    //           }
    //       }

    //       //新建
    //       private void cmdNew_Click(object sender, RoutedEventArgs e)
    //       {
    //           richTextBox.Document = new FlowDocument();
    //       }

    //       private void FontSize_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    //       {
    //           ComboBox cmb = sender as ComboBox;

    //           if (richTextBox!=null&&cmb != null && cmb.SelectedItem != null)
    //           {
    //               if (richTextBox.Selection.Text == "")
    //               {
    //                   if (richTextBox.Selection.Start.Paragraph != null)
    //                   {
    //                       richTextBox.Selection.Start.Paragraph.FontSize = (double)cmb.SelectedValue;
    //                   }
    //               }
    //               else
    //               { 
    //                   richTextBox.Selection.ApplyPropertyValue(
    //                     TextElement.FontSizeProperty, cmb.SelectedValue);
    //               } 
    //           }
    //       }

    //       private void FontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //       {
    //           ComboBox cmb = sender as ComboBox;

    //           if (richTextBox != null && cmb != null && cmb.SelectedItem != null)
    //           {
    //               FontFamily fontFamily = new FontFamily(cmb.SelectedValue.ToString());
    //               if (richTextBox.Selection.Text == "")
    //               {
    //                   if (richTextBox.Selection.Start.Paragraph != null)
    //                   {
    //                       richTextBox.Selection.Start.Paragraph.FontFamily = fontFamily;
    //                   }
    //               }
    //               else
    //               {
    //                   richTextBox.Selection.ApplyPropertyValue(
    //                     TextElement.FontFamilyProperty, fontFamily);
    //               }
    //           }
    //       }
    //   } 
    #endregion
}
