using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities
{
    /// <summary>
    /// 功能：资源文件
    /// 创建人：马友春
    /// 创建时间：2013年12月26日
    /// 注意：把所有资源文件的访问权限改为public
    /// </summary>
    public  class ResourceWrapper
    {
        public static AppPrivilegeConfig AppPrivilegeConfig
        {
            get { return AppPrivilegeConfig; }
        }
    }
}
