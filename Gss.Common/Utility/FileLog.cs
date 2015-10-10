using System;
using System.IO;

namespace Gss.Common.Utility
{
    public class FileLog
    {
        /// <summary>
        /// 写日志文件
        /// </summary>
        /// <param name="errContent">错误内容</param>
        public static void WriteLog(string errContent)
        {
            WriteLog(errContent, "Log.txt");
        }

        /// <summary>
        /// 写日志文件
        /// </summary>
        /// <param name="errContent">错误内容</param>
        /// <param name="path">文件路径</param>
        public static void WriteLog(string errContent, string path)
        {
            try
            {
                FileStream aFile = new FileStream(path, FileMode.OpenOrCreate);
                aFile.Seek(0, SeekOrigin.End);//将流指针移动到文件尾部
                StreamWriter sw = new StreamWriter(aFile);
                sw.WriteLine(errContent);
                sw.Close();
            }
            catch (Exception)
            {
                return;
            }
        }

        /// <summary>
        /// 写日志文件
        /// </summary>
        /// <param name="account">用户账户</param>
        /// <param name="modelName">模块名</param>
        /// <param name="className">类名</param>
        /// <param name="methodName">方法名</param>
        /// <param name="errContent">错误内容</param>
        public static void WriteLog(string account,string modelName,string className,string methodName,string errContent)
        {
            string err = DateTime.Now + "\t" + account + "\t" + modelName + "\t" + className + "\t" + methodName + "\t" + errContent;
            WriteLog(err);
        }

        /// <summary>
        /// 写日志文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="account">用户账户</param>
        /// <param name="modelName">模块名</param>
        /// <param name="className">类名</param>
        /// <param name="methodName">方法名</param>
        /// <param name="errContent">错误内容</param>
        public static void WriteLog(string path,string account, string modelName, string className, string methodName,string errContent)
        {
            string err = DateTime.Now + "\t" + account + "\t" + modelName + "\t" + className + "\t" + methodName + "\t" + errContent;
            WriteLog(err,path);
        }
    }
}
