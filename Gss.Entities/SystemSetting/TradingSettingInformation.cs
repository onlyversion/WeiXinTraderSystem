
namespace Gss.Entities {
    /// <summary>
    /// 交易设置信息类
    /// </summary>
    //[Serializable]
    //public class TradingSettingInformation : ObservableObject {
    //    #region 属性

    //    private PENDINGORDER_VALID _pendingOrderValid;

    //    /// <summary>
    //    /// 获取或设置挂单有效期类型
    //    /// </summary>
    //    public PENDINGORDER_VALID PendingOrderValid {
    //        get { return _pendingOrderValid; }
    //        set {
    //            if( _pendingOrderValid != value ) {
    //                _pendingOrderValid = value;
    //                RaisePropertyChanged( "PendingOrderValid" );
    //            }
    //        }
    //    }

    //    private DateTime _storageChargeBillableTime;

    //    /// <summary>
    //    /// 获取或设置仓储费计费时间
    //    /// </summary>
    //    public DateTime StorageChargeBillableTime {
    //        get { return _storageChargeBillableTime; }
    //        set {
    //            if( _storageChargeBillableTime != value ) {
    //                _storageChargeBillableTime = value;
    //                RaisePropertyChanged( "StorageChargeBillableTime" );
    //            }
    //        }
    //    }

    //    private bool _weekendBilling;

    //    /// <summary>
    //    /// 获取或设置是否周末计费
    //    /// </summary>
    //    public bool WeekBilling {
    //        get { return _weekendBilling; }
    //        set {
    //            if( _weekendBilling != value ) {
    //                _weekendBilling = value;
    //                RaisePropertyChanged( "WeekBilling" );
    //            }
    //        }
    //    }

    //    private DateTime _settlementTime;

    //    /// <summary>
    //    /// 获取或设置结算时间
    //    /// </summary>
    //    public DateTime SettlementTime {
    //        get { return _settlementTime; }
    //        set {
    //            if( _settlementTime != value ) {
    //                _settlementTime = value;
    //                RaisePropertyChanged( "SettlementTime" );
    //            }
    //        }
    //    }

    //    private string _riskRateFormula;

    //    /// <summary>
    //    /// 获取或设置风险率计算公式
    //    /// </summary>
    //    public string RiskRateFormula {
    //        get { return _riskRateFormula; }
    //        set {
    //            _riskRateFormula = value;
    //            RaisePropertyChanged( "RiskRateFormula" );
    //        }
    //    }

    //    private string _lossOrProfitFormula;

    //    /// <summary>
    //    /// 获取或设置盈亏计算公式
    //    /// </summary>
    //    public string LossOrProfitFormula {
    //        get { return _lossOrProfitFormula; }
    //        set {
    //            _lossOrProfitFormula = value;
    //            RaisePropertyChanged( "LossOrProfitFormula" );
    //        }
    //    }

    //    private string _brokeFormula;

    //    /// <summary>
    //    /// 获取或设置爆仓计算公式
    //    /// </summary>
    //    public string BrokeFormula {
    //        get { return _brokeFormula; }
    //        set {
    //            _brokeFormula = value;
    //            RaisePropertyChanged( "BrokeFormula" );
    //        }
    //    }

    //    #endregion

    //    /// <summary>
    //    /// 克隆一个完整的用户账户信息类
    //    /// </summary>
    //    /// <returns></returns>
    //    public object Clone( ) {
    //        return CloneHelper.CloneObject( this );
    //    }

    //    /// <summary>
    //    /// 同步交易设置信息
    //    /// </summary>
    //    /// <param name="syncInfo">同步数据源</param>
    //    public void Sync( TradingSettingInformation syncInfo ) {
    //        PendingOrderValid = syncInfo.PendingOrderValid;
    //        StorageChargeBillableTime = syncInfo.StorageChargeBillableTime;
    //        WeekBilling = syncInfo.WeekBilling;
    //        SettlementTime = syncInfo.SettlementTime;
    //        RiskRateFormula = syncInfo.RiskRateFormula;
    //        LossOrProfitFormula = syncInfo.LossOrProfitFormula;
    //        BrokeFormula = syncInfo.BrokeFormula;
    //    }
    //}
}
