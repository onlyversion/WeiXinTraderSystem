using System;
using System.IO;
using System.Xml.Serialization;

namespace Gss.Common.Utility {
    /// <summary>
    /// XML文件类型序列化静态辅助类
    /// </summary>
    /// <typeparam name="T">序列化对象泛型</typeparam>
    public static class XmlSerialize<T> where T : class {
        /// <summary>
        /// 从XML文件反序列化为T所指对象
        /// </summary>
        /// <param name="file">XML序列化文件</param>
        /// <returns>T对象</returns>
        public static T Deserialize( string file ) {
            FileStream fs = null;
            if( !File.Exists( file ) ) {
                return default( T );
            }

            try {
                var serializer = new XmlSerializer( typeof( T ) );
                fs = new FileStream( file, FileMode.Open );
                return ( T )serializer.Deserialize( fs );
            } catch( Exception ) {
                return default( T );
            } finally {
                if( fs != null )
                    fs.Close( );
            }
        }

        /// <summary>
        /// 序列化T对象到XML文件中
        /// </summary>
        /// <param name="info">要序列化的T对象</param>
        /// <param name="file">存储的XML文件</param>
        /// <returns>序列化成功或失败</returns>
        public static bool Serialize( T info, string file ) {
            FileStream fs = null;
            try {
                var serializer = new XmlSerializer( typeof( T ) );
                if( File.Exists( file ) ) {
                    File.Delete( file );
                }
                fs = new FileStream( file, FileMode.Create );
                serializer.Serialize( fs, info );
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
