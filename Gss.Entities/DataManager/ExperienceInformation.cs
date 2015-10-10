using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.DataManager
{
    public class ExperienceInformation:BaseInfo
    {
        private int _id;
        /// <summary>
        /// ID
        /// </summary>
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }

        private string _name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        private int _type;
        /// <summary>
        /// 类型
        /// </summary>
        public int Type
        {
            get { return _type; }
            set
            {
                _type = value;
                RaisePropertyChanged("Type");
            }
        }

        private decimal _annount;
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Annount
        {
            get { return _annount; }
            set
            {
                _annount = value;
                RaisePropertyChanged("Annount");
            }
        }

        private decimal _rceharge;
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal Rceharge
        {
            get { return _rceharge; }
            set
            {
                _rceharge = value;
                RaisePropertyChanged("Rceharge");
            }
        }

        private int _num;
        /// <summary>
        /// 张数
        /// </summary>
        public int Num
        {
            get { return _num; }
            set
            {
                _num = value;
                RaisePropertyChanged("Num");
            }
        }

        private DateTime _startDate;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                RaisePropertyChanged("StartDate");
            }
        }

        private DateTime _endDate;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                RaisePropertyChanged("EndDate");
            }
        }

        private string _creatID;
        /// <summary>
        /// 创建人ID
        /// </summary>
        public string CreatID
        {
            get { return _creatID; }
            set
            {
                _creatID = value;
                RaisePropertyChanged("CreatID");
            }
        }

        private int _effective;
        /// <summary>
        /// 是否有效 0:有效 1:失效
        /// </summary>
        public int Effective
        {
            get { return _effective; }
            set
            {
                _effective = value;
                RaisePropertyChanged("Effective");
            }
        }

        private DateTime _effectiveTime;
        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime EffectiveTime
        {
            get { return _effectiveTime; }
            set
            {
                _effectiveTime = value;
                RaisePropertyChanged("EffectiveTime");
            }
        }
    }
}
