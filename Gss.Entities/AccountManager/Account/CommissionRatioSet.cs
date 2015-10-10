using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.AccountManager.Account
{
    /// <summary>
    /// 返佣比例
    /// </summary>
    public class CommissionRatioSet
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { set; get; }

        /// <summary>
        /// 组织机构ID
        /// </summary>
        public string OrgID { set; get; }

        /// <summary>
        /// 一级返佣比例
        /// </summary>
        public double Ratio1 { set; get; }

        /// <summary>
        ///二级返佣比例
        /// </summary>
        public double Ratio2 { set; get; }

        /// <summary>
        /// 三级返佣比例
        /// </summary>
        public double Ratio3 { set; get; }
    }
}
