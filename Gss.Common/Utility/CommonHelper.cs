using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Gss.Common.Utility
{
    /// <summary>
    /// 功能：公共帮助类
    /// 作用：应用程序中用到的公共静态方法
    /// 创建人：马友春
    /// </summary>
    public class CommonHelper
    {
        #region 获取客户端的网络IP
        /// <summary>
        /// 获取客户端的网络IP
        /// </summary>
        /// <returns></returns>
        public static string GetNetwork()
        {
            string tempip = "";
            try
            {
                WebRequest wr = WebRequest.Create("http://iframe.ip138.com/ic.asp");
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                tempip = sr.ReadToEnd(); //读取网站的数据
                sr.Close();
                s.Close();
            }
            catch
            {

            }
            //<html>\r\n<head>\r\n<meta http-equiv=\"content-type\" content=\"text/html; charset=gb2312\">\r\n<title> 您的IP地址 </title>\r\n</head>\r\n<body style=\"margin:0px\"><center>您的IP是：[61.139.124.89] 来自：四川省成都市 电信</center></body></html>"
            int start = tempip.IndexOf('[') + 1;
            int end = tempip.IndexOf(']') - tempip.IndexOf('[') - 1;
            return tempip.Substring(start, end);

        }
        #endregion


        #region 获取控件验证
        /// <summary>
        /// 获取界面元素是否包含错误验证
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool GetUIElementError(UIElement d)
        {
            if (d != null)
            {
                foreach (object child in LogicalTreeHelper.GetChildren(d))
                {
                    UIElement element = child as UIElement;
                    if (element == null)
                        continue;
                    if (Validation.GetHasError(element))
                    {
                        return true;
                    }
                    else
                    {
                        if (CommonHelper.GetUIElementError(element))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
