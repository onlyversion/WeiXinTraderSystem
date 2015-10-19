
using System;
using Gss.Entities.Enums;

namespace Gss.Entities.JTWEntityes
{
    /// <summary>
    /// 功能：广告Model
    /// 创建人：马友春
    /// 创建时间：2014年1月7日
    /// </summary>
    public class AdvertInfo : BaseInfo
    {
        private string _Name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }

        private string _ID;
        /// <summary>
        /// ID标识
        /// </summary>
        public string ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                RaisePropertyChanged("ID");
            }
        }

        private string _Url;
        /// <summary>
        /// Url
        /// </summary>
        public string Url
        {
            get { return _Url; }
            set
            {
                _Url = value;
                RaisePropertyChanged("Url");
            }
        }



        private string _Creator;
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creator
        {
            get { return _Creator; }
            set
            {
                _Creator = value;
                RaisePropertyChanged("Creator");
            }
        }

        private DateTime _CreateDate;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set
            {
                _CreateDate = value;
                RaisePropertyChanged("CreateDate");
            }
        }



        private bool _Status;
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                RaisePropertyChanged("Status");
            }
        }

        private string _Remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set
            {
                _Remark = value;
                RaisePropertyChanged("Remark");
            }
        }
    }
}

