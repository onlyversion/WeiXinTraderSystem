using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.BzjEntities
{
    /// <summary>
    /// 功能：查询条件
    /// 创建人：马友春
    /// 创建时间：2013年11月20日
    /// </summary>
    public class SelectCondition : BaseInfo
    {
        private bool _IsBusy;
        /// <summary>
        /// 是否繁忙
        /// </summary>
        public bool IsBusy
        {
            get { return _IsBusy;}
            set
            {
                _IsBusy = value;
                RaisePropertyChanged("IsBusy");
            }    
        }
        private string _OrderNO;
        /// <summary>
        /// 定单号
        /// </summary>
        public string OrderNO
        {
            get { return _OrderNO; }
            set
            {
                _OrderNO = value;
                RaisePropertyChanged("OrderNO");
            }
        }

        private string _CardNum;
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CardNum
        {
            get { return _CardNum; }
            set
            {
                _CardNum = value;
                RaisePropertyChanged("CardNum");
            }
        }

        private string _account="";
        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account
        {
            get { return _account; }
            set
            {
                _account = value;
                RaisePropertyChanged("Account");
            }
        }

        private string _UserName = "";
        /// <summary>
        /// 客户姓名
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

        private string _Phone = "";
        /// <summary>
        /// 电话号码
        /// </summary>
          public string Phone
        {
            get { return _Phone; }
            set
            {
                _Phone = value;
                RaisePropertyChanged("Phone");
            }
        }
      

        private string _orderCode;
        /// <summary>
        /// 定单 提货或买跌验证码 200000ssffff(没有则为空)
        /// </summary>
        public string OrderCode
        {
            get { return _orderCode; }
            set
            {
                _orderCode = value;
                RaisePropertyChanged("OrderCode");
            }
        }

        private int _CurrentPageItemCount;
        /// <summary>
        /// 当前页的项总数
        /// </summary>
        public int CurrentPageItemCount
        {
            get { return _CurrentPageItemCount; }
            set
            {
                _CurrentPageItemCount = value;
                RaisePropertyChanged("CurrentPageItemCount");
            }
        }

        public int _PageCount;
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get { return _PageCount; }
            set
            {
                _PageCount = value;
                RaisePropertyChanged("PageCount");
            }
        }

        private int _PageIndex = 1;
        /// <summary>
        /// 当前页索引
        /// </summary>
        public int PageIndex
        {
            get { return _PageIndex; }
            set
            {
                _PageIndex = value;
                RaisePropertyChanged("PageIndex");
            }
        }

        private int _PageSize = 10;
        /// <summary>
        /// 当前页大小
        /// </summary>
        public int PageSize
        {
            get { return _PageSize; }
            set
            {
                _PageSize = value;
                RaisePropertyChanged("PageSize");
            }
        }

        private string _DeliverType = "全部";
        /// <summary>
        /// 方向：1 入库 2买跌
        /// </summary>
        public string DeliverType
        {
            get { return _DeliverType; }
            set
            {
                _DeliverType = value;
                RaisePropertyChanged("DeliverType");
            }
        }

        private DateTime _StartTime = DateTime.Today.AddDays(0);
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return _StartTime; }
            set
            {
                _StartTime = value;
                RaisePropertyChanged("StartTime");
            }
        }

        private DateTime _EndTime = DateTime.Today;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return _EndTime; }
            set
            {
                _EndTime = value;
                RaisePropertyChanged("EndTime");
            }
        }

        private string _GoodsType = "全部";
        /// <summary>
        /// 商品类别1黄金，2白银3铂金4钯金
        /// </summary>
        public string GoodsType
        {
            get { return _GoodsType; }
            set
            {
                _GoodsType = value;
                RaisePropertyChanged("GoodsType");
            }
        }

        private string _NewsType = "全部";
        /// <summary>
        /// 新闻公告类型
        /// </summary>
        public string NewsType
        {
            get { return _NewsType; }
            set
            {
                _NewsType = value;
                RaisePropertyChanged("NewsType");
            }
        }

        private string productNumber;
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProductNumber
        {
            get { return productNumber; }
            set { productNumber = value; }
        }

        private string cycle;
        /// <summary>
        /// 周期
        /// </summary>
        public string Cycle
        {
            get { return cycle; }
            set { cycle = value; }
        }

        private string _State="全部";
        /// <summary>
        /// 状态
        /// </summary>
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        private string _OrgName = "";
        /// <summary>
        /// 会员名称
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
        private DateTime _PayStartTime = DateTime.Now.AddDays(0);
        /// <summary>
        /// 付款开始时间
        /// </summary>
        public DateTime PayStartTime
        {
            get { return _PayStartTime; }
            set
            {
                _PayStartTime = value;
                RaisePropertyChanged("PayStartTime");
            }
        }
        private DateTime _PayEndTime = DateTime.Now;
        /// <summary>
        /// 付款结束时间
        /// </summary>
        public DateTime PayEndTime
        {
            get { return _PayEndTime; }
            set
            {
                _PayEndTime = value;
                RaisePropertyChanged("PayEndTime");
            }
        }

        private string _weektime;

        public string weektime
        {
            get { return _weektime; }
            set
            {
                _weektime = value;
                RaisePropertyChanged("weektime");
            }
        }


        private string _isBroker = "全部";
        /// <summary>
        /// 是否经济人，0全部，1是，2，否
        /// </summary>
        public string IsBroker
        {
            get { return _isBroker; }
            set
            {
                _isBroker = value;
                RaisePropertyChanged("IsBroker");
            }
        }

        private string _broker = "";
        /// <summary>
        /// 经济人
        /// </summary>
        public string Broker
        {
            get { return _broker; }
            set
            {
                _broker = value;
                RaisePropertyChanged("IsBroker");
            }
        }
    }
}
