using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Gss.Common.Utility {
    public static class CloneHelper {
        /// <summary>
        /// 复制某个对象
        /// </summary>
        /// <param name="obj">要复制的对象</param>
        /// <returns>复制后的对象</returns>
        public static object CloneObject( object obj ) {
            BinaryFormatter Formatter = new BinaryFormatter( null, new StreamingContext( StreamingContextStates.Clone ) );
            MemoryStream stream = new MemoryStream( );
            Formatter.Serialize( stream, obj );
            stream.Position = 0;
            object clonedObj = Formatter.Deserialize( stream );
            stream.Close( );
            return clonedObj;
        }
    }
}
