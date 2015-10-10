using System.Management;

namespace Gss.Common.Utility {
    /// <summary>
    /// 获取MAC地址辅助类
    /// </summary>
    public static class MacAddress {
        /// <summary>
        /// Gets this PC's mac address.
        /// </summary>
        public static string LocalMAC { get; private set; }

        /// <summary>
        /// Static constructor
        /// </summary>
        static MacAddress( ) {
            LocalMAC = GetMacAddr();
        }

        /// <summary>
        /// Get mac address.
        /// </summary>
        /// <returns></returns>
        private static string GetMacAddr() {
            try {
                ManagementObjectSearcher query = new ManagementObjectSearcher( "SELECT * FROM Win32_NetworkAdapterConfiguration" );
                ManagementObjectCollection queryCollection = query.Get();
                foreach( ManagementObject mo in queryCollection ) {
                    if( mo["IPEnabled"].ToString() == "True" )
                        return mo["MacAddress"].ToString();
                }
                return string.Empty;
            } catch {
                return string.Empty;
            }
        }
    }
}
