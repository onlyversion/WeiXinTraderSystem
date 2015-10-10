using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Gss.Common.Utility {
    /// <summary>
    /// 加解密辅助类
    /// </summary>
    public class SecurityHelper {
        /// <summary>
        /// Key 串
        /// </summary>
        private const string Key64 = "eqVR@<7#";

        /// <summary>
        /// Iv 串
        /// </summary>
        private const string Iv64 = "yJ*NV{%p";

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="data">要加密的数据字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt( string data ) {
            byte[] key = Encoding.Default.GetBytes( Key64 );
            byte[] iv = Encoding.Default.GetBytes( Iv64 );
            byte[] buf = Encoding.Default.GetBytes( data );

            DESCryptoServiceProvider des = new DESCryptoServiceProvider( );
            MemoryStream ms = new MemoryStream( );
            CryptoStream encStream = new CryptoStream( ms, des.CreateEncryptor( key, iv ), CryptoStreamMode.Write );
            encStream.Write( buf, 0, buf.Length );
            encStream.FlushFinalBlock( );

            ms.Flush( );

            string retStr = Convert.ToBase64String( ms.ToArray( ) );
            encStream.Close( );
            ms.Close( );
            return retStr;
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="data">要解密的字符串</param>
        /// <returns>解密后的字符串</returns>
        public static string Decrypt( string data ) {
            byte[] key = Encoding.Default.GetBytes( Key64 );
            byte[] iv = Encoding.Default.GetBytes( Iv64 );
            byte[] buf = Convert.FromBase64String( data );

            DES des = new DESCryptoServiceProvider( );
            MemoryStream ms = new MemoryStream( );
            CryptoStream decStream = new CryptoStream( ms, des.CreateDecryptor( key, iv ), CryptoStreamMode.Write );
            decStream.Write( buf, 0, buf.Length );
            decStream.FlushFinalBlock( );

            string retStr = Encoding.Default.GetString( ms.ToArray( ) );
            ms.Close( );
            decStream.Close( );

            return retStr;
        }
    }
}
