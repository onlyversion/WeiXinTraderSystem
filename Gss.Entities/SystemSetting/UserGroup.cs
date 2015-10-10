using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.SystemSetting
{
    public class UserGroup : BaseInfo
    {
        public UserGroup()
        {
            UserGroupId = System.Guid.NewGuid().ToString("N");
        }
        private string _UserGroupId;
        /// <summary>
        /// 客户组ID
        /// </summary>
        public string UserGroupId
        {
            get { return _UserGroupId; }
            set
            {
                _UserGroupId = value;
                RaisePropertyChanged("UserGroupId");
            }
        }

        private string _UserGroupName;
        /// <summary>
        /// 客户组名称
        /// </summary>
        public string UserGroupName
        {
            get { return _UserGroupName; }
            set
            {
                _UserGroupName = value;
                RaisePropertyChanged("UserGroupName");
            }
        }

        private int _IsDefaultGroup;
        /// <summary>
        /// 1是默认组,0不是默认组
        /// </summary>
        public int IsDefaultGroup
        {
            get { return _IsDefaultGroup; }
            set
            {
                _IsDefaultGroup = value;
                RaisePropertyChanged("IsDefaultGroup");
            }
        }


        private int _AfterSecond;
        /// <summary>
        /// 平仓后多少秒不能下单
        /// </summary>
        public int AfterSecond
        {
            get { return _AfterSecond; }
            set
            {
                _AfterSecond = value;
                RaisePropertyChanged("AfterSecond");
            }
        }

        private int _PlaceOrderSlipPoint;
        /// <summary>
        /// 下单滑点
        /// </summary>
        public int PlaceOrderSlipPoint
        {
            get { return _PlaceOrderSlipPoint; }
            set
            {
                _PlaceOrderSlipPoint = value;
                RaisePropertyChanged("PlaceOrderSlipPoint");
            }
        }
        private int _FlatOrderSlipPoint;
        /// <summary>
        /// 平仓滑点
        /// </summary>
        public int FlatOrderSlipPoint
        {
            get { return _FlatOrderSlipPoint; }
            set
            {
                _FlatOrderSlipPoint = value;
                RaisePropertyChanged("FlatOrderSlipPoint");
            }
        }
        private double _DelayPlaceOrder;
        /// <summary>
        /// 下单延迟多少秒
        /// </summary>
        public double DelayPlaceOrder
        {
            get { return _DelayPlaceOrder; }
            set
            {
                _DelayPlaceOrder = value;
                RaisePropertyChanged("DelayPlaceOrder");
            }
        }
        private double _DelayFlatOrder;
        /// <summary>
        /// 平仓延迟多少秒 
        /// </summary>
        public double DelayFlatOrder
        {
            get { return _DelayFlatOrder; }
            set
            {
                _DelayFlatOrder = value;
                RaisePropertyChanged("DelayFlatOrder");
            }
        }

    }
}
