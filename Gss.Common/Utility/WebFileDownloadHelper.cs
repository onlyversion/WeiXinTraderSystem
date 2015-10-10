using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Gss.Common.Utility {
    /// <summary>
    /// 网络下载辅助类
    /// </summary>
    public static class WebFileDownloadHelper {
        /// <summary>
        /// 获取最后一次错误信息
        /// </summary>
        public static string LastErrMessage { get; private set; }

        /// <summary>
        /// 从指定的网络地址下载文件
        /// </summary>
        /// <param name="webAddr">网络地址</param>
        /// <param name="locFilePath">本地存储的文件地址</param>
        /// <returns></returns>
        public static bool DownloadFile( Uri webAddr, string locFilePath ) {
            try {
                using( var wc = new WebClient( ) ) {
                    wc.DownloadFile( webAddr, locFilePath );
                }
                return true;
            } catch( Exception ex ) {
                LastErrMessage = ex.Message;
                return false;
            }
        }
    }
}
