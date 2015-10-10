using System;
using Gss.Entities.Enums;

namespace Gss.Entities.JTWEntityes
{
    /// <summary>
    /// 功能：新闻公告Model
    /// 创建人：马友春
    /// 创建时间：2014年1月7日
    /// </summary>
    public  class NewsInfo:BaseInfo
    {
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

        private string _NewsTitle;
        /// <summary>
        /// 标题
        /// </summary>
        public string NewsTitle
        {
            get { return _NewsTitle; }
            set
            {
                _NewsTitle = value;
                RaisePropertyChanged("NewsTitle");
            }
        }

        private string _NewsContent;
        /// <summary>
        /// 内容
        /// </summary>
        public string NewsContent
        {
            get { return _NewsContent; }
            set
            {
                _NewsContent = value;
                RaisePropertyChanged("NewsContent");
            }
        }

        private string _PubPerson;
        /// <summary>
        /// 发布人
        /// </summary>
        public string PubPerson
        {
            get { return _PubPerson; }
            set
            {
                _PubPerson = value;
                RaisePropertyChanged("PubPerson");
            }
        }

        private DateTime _PubTime;
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PubTime
        {
            get { return _PubTime; }
            set
            {
                _PubTime = value;
                RaisePropertyChanged("PubTime");
            }
        }

        private NewsStatusEnum _Status;
        /// <summary>
        /// 状态
        /// </summary>
        public NewsStatusEnum Status
        {
            get { return _Status; }
            set
            {
                if (value != _Status)
                {
                    _Status = value;
                    if (value != null)
                    {
                        _StatusBool = value == NewsStatusEnum.禁用 ? false : true;
                    }
                }
                RaisePropertyChanged("Status");
                RaisePropertyChanged("StatusString");
            }
        }

        private bool _StatusBool;
        /// <summary>
        /// 状态
        /// </summary>
        public bool StatusBool
        {
            get { return _StatusBool; }
            set
            {
                if (_StatusBool != value)
                {
                    _StatusBool = value;
                    _Status = value ? NewsStatusEnum.启用 : NewsStatusEnum.禁用;
                }
                RaisePropertyChanged("StatusBool");
                RaisePropertyChanged("Status");
            }
        }

        private NewsTypeEnum _NType;
        /// <summary>
        ///  新闻类型
        /// </summary>
        public NewsTypeEnum NType
        {
            get { return _NType; }
            set
            {
                if (value != NType)
                {
                    _NType = value;
                    NTypeString = value.ToString();
                }
                RaisePropertyChanged("NType");
                RaisePropertyChanged("NTypeString");
            }
        }

        private String _NTypeString;
        /// <summary>
        ///  新闻类型
        /// </summary>
        public String NTypeString
        {
            get { return _NTypeString; }
            set
            {
                if (value != _NTypeString)
                {
                    _NTypeString = value;
                    NType = (NewsTypeEnum)Enum.Parse(typeof(NewsTypeEnum), value);
                    RaisePropertyChanged("NTypeString");
                    RaisePropertyChanged("NType");
                }
            }
        }
    }
}
