using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.BzjEntities
{
    /// <summary>
    /// 保证金用户实体
    /// </summary>
    public class BzjUserBindEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId
        {
            get;
            set;
        }

        /// <summary>
        /// 金生金用户绑定ID
        /// </summary>
        public string UserBindId
        {
            get;
            set;
        }

        /// <summary>
        /// 金生金用户ID
        /// </summary>
        public string JUserId
        {
            get;
            set;
        }

        /// <summary>
        /// 状态(1为启用，0为禁用)
        /// </summary>
        public int IsEnable
        {
            get;
            set;
        }

        /// <summary>
        /// 日期
        /// </summary>
        public string CreateDate
        {
            get;
            set;
        }
    }
}
