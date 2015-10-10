using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Common.Utility {
    public class DataDigitFilter {
        /// <summary>
        /// Filter double value
        /// </summary>
        /// <param name="data">src double value</param>
        /// <param name="digit">value's digit</param>
        /// <returns>after filter double value</returns>
        public static double FilterDouble( double data, int digit ) {
            return Convert.ToDouble( FilterString( data, digit ) );
        }

        /// <summary>
        /// Filter double to string.
        /// </summary>
        /// <param name="data">src double value</param>
        /// <param name="digit">value's digit</param>
        /// <returns>after filter string</returns>
        public static string FilterString( double data, int digit ) {
            return data.ToString( "F" + digit );
        }
    }
}
