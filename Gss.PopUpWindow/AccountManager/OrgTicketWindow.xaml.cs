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
using Microsoft.Win32;

namespace Gss.PopUpWindow.AccountManager
{
    /// <summary>
    /// OrgTicketWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OrgTicketWindow : Window
    {
        public OrgTicketWindow()
        {
            InitializeComponent();
        }

        public void ShowImage(BitmapImage img)
        {
            image.Source = img;
            image.Width = img.PixelWidth;
            image.Height = img.PixelHeight;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveImage(image);
        }

        /// <summary>
        /// 保存图片到磁盘
        /// </summary>
        /// <param name="img"></param>
        public void SaveImage(Image img)
        {
            //img为Image控件
            BitmapSource bsrc = (BitmapSource)img.Source;
            //保存文件对话框
            SaveFileDialog sf = new SaveFileDialog();
            //设定默认保存类型为Png
            sf.DefaultExt = ".png";
            //指定用户只能下载jpg和png格式的图片
            sf.Filter = "JPG 图片 (*.jpg)|*.jpg|PNG 图片 (*.png)|*.png";
            if (sf.ShowDialog() == true)
            {
                PngBitmapEncoder pngE = new PngBitmapEncoder();
                pngE.Frames.Add(BitmapFrame.Create(bsrc));
                using (Stream stream = File.Create(sf.FileName))
                {
                    pngE.Save(stream);
                }
            }
        }


        public void UpLoadPicture(string fkid, string currentExpNo)
        {
            //SaveFileDialog dlg = new SaveFileDialog(); //定义一个打开文件对话框
            
            //dlg.Filter = "JPG 图片 (*.jpg)|*.jpg|PNG 图片 (*.png)|*.png"; //指定用户只能上传jpg和png格式的图片
            //bool? result = dlg.ShowDialog(); //打开对话框

            //if (result != null && result == true) //如果单击了确定按钮并且选择了文件
            //{
            //    FileStream inputStream = dlg.File.OpenRead();
            //    string name = dlg.File.Name; //获得文件名
            //    string extension = name.Substring(name.LastIndexOf('.'), name.Length - name.LastIndexOf('.')); //取得扩展名（包括“.”） 
            //    byte[] buffer = new Byte[dlg.File.Length];//定义图片的字节数
            //    int byteRead = inputStream.Read(buffer, 0, (int)dlg.File.Length);//读取图片的字节流

            //    BitmapImage image = new BitmapImage(); //image就是要预览的图片
            //    image.SetSource(inputStream);
            //    inputStream.Close();//关闭输入流
             
            //}
        }



        #region 保存对话框
        private void ShowSaveFileDialog()
        {
            //string localFilePath, fileNameExt, newFileName, FilePath; 
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型 
            sfd.Filter = "JPG 图片 (*.jpg)|*.jpg|PNG 图片 (*.png)|*.png"; //指定用户只能上传jpg和png格式的图片

            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //点了保存按钮进入 
            if (sfd.ShowDialog() ==true)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                //获取文件路径，不带文件名 
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\")); 

                //给文件名前加上时间 
                //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt; 

                //在文件名里加字符 
                //saveFileDialog1.FileName.Insert(1,"dameng"); 

                //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件 

                ////fs输出带文字或图片的文件，就看需求了 
            }
        }

        #endregion


    }
}
