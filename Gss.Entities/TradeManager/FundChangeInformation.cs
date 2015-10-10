using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.TradeManager
{
   public class FundChangeInformation:BaseInfo
    {
       private string _OrgName;
        /// <summary>
       /// 所属会员
        /// </summary>
       public string OrgName
        {
            get { return _OrgName; }
            set
            {
                _OrgName = value;
                RaisePropertyChanged("OrgName");
            }
        }

       private string _Account;
       /// <summary>
       /// 用户账号
       /// </summary>
       public string Account
       {
           get { return _Account; }
           set
           {
               _Account = value;
               RaisePropertyChanged("Account");
           }
       }

       private string _UserName;
       /// <summary>
       /// 用户名称
       /// </summary>
       public string UserName
       {
           get { return _UserName; }
           set
           {
               _UserName = value;
               RaisePropertyChanged("UserName");
           }
       }

       private string _Telephone;
       /// <summary>
       /// 会员编码
       /// </summary>
       public string Telephone
       {
           get { return _Telephone; }
           set
           {
               _Telephone = value;
               RaisePropertyChanged("Telephone");
           }
       }

        private double _Amt;
        /// <summary>
        /// 金额
        /// </summary>
        public double Amt
        {
            get { return _Amt; }
            set
            {
                _Amt = value;
                RaisePropertyChanged("Amt");
            }
        }
        private DateTime _OpTime;
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime OpTime
        {
            get { return _OpTime; }
            set
            {
                _OpTime = value;
                RaisePropertyChanged("OpTime");
            }
        }


        private string _Reason;
        /// <summary>
        /// "4"-入金，"5"-出金	"6"-调节
        /// </summary>
        public string Reason
        {
            get { return _Reason; }
            set
            {
                _Reason = value;
                RaisePropertyChanged("Reason");
            }
        }

        private string _ReasonString;
        /// <summary>
        /// "4"-入金，"5"-出金	
        /// </summary>
        public string ReasonString
        {
            get
            {
                if (!string.IsNullOrEmpty(Reason))
                {
                    if (Reason == "4")
                        return "入金";
                    else if (Reason == "5")
                        return "出金";
                    else if (Reason == "6")
                        return "调节";
                    else if (Reason == "9")
                        return "经纪人提成";
                    else if (Reason == "12")
                        return "赠金";
                 
                    else
                    {
                        return "未知";
                    }
                }
                else
                    return _ReasonString;

//4----银行入金 (用户操作);
//5----银行出金 (用户操作);
//6----手工调账(金商或管理员操作)

//9----（系统月初自动计算上月提成）；
                //12 
            }
            set
            {
                _ReasonString = value;
                RaisePropertyChanged("ReasonString");
            }
        }

 
    }
}
