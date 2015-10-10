using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gss.Common.Utility {
    /// <summary>
    /// 文件序列化静态辅助类
    /// </summary>
    /// <typeparam name="T">序列化对象泛型</typeparam>
    public static class FileSerialize<T> where T : class {
        /// <summary>
        /// 从二进制文件反序列化为T所指对象
        /// </summary>
        /// <param name="file">二进制序列化文件</param>
        /// <returns>T对象</returns>
        public static T Deserialize( string file ) {
            FileStream fs = null;
            if( !File.Exists( file ) ) {
                return default( T );
            }

            try {
                IFormatter fmt = new BinaryFormatter( );
                fs = new FileStream( file, FileMode.Open, FileAccess.Read, FileShare.Read );
                return ( T )fmt.Deserialize( fs );
            } catch( Exception ) {
                return default( T );
            } finally {
                if( fs != null )
                    fs.Close( );
            }
        }

        /// <summary>
        /// 序列化T对象到二进制文件中
        /// </summary>
        /// <param name="info">要序列化的T对象</param>
        /// <param name="file">存储的二进制文件</param>
        /// <returns>序列化成功或失败</returns>
        public static bool Serialize( T info, string file ) {
            FileStream fs = null;
            try {
                IFormatter fmt = new BinaryFormatter( );
                if( File.Exists( file ) ) {
                    File.Delete( file );
                }
                fs = new FileStream( file, FileMode.Create );
                fmt.Serialize( fs, info );
                return true;
            } catch( Exception ) {
                return false;
            } finally {
                if( fs != null )
                    fs.Close( );
            }
        }
    }
}
