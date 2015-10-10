using System;
using Gss.Entities.Enums;

namespace Gss.Entities {
    /// <summary>
    /// 管理员类型的账户基本资料
    /// </summary>
    [Serializable]
    public class ManagerAccountInformation : AccountInformationBase {
        #region 属性

        private string _idNumber;
        private SEX? _sex;
        private string _userName;

        /// <summary>
        /// 获取或设置身份证号码
        /// </summary>
        public string IDNumber {
            get { return _idNumber; }
            set {
                _idNumber = value;
                RaisePropertyChanged( "IDNumber" );
            }
        }

        /// <summary>
        /// 获取或设置性别
        /// </summary>
        public SEX? Sex {
            get { return _sex; }
            set {
                _sex = value;
                RaisePropertyChanged( "Sex" );
            }
        }

        /// <summary>
        /// 获取或设置用户姓名
        /// </summary>
        public string UserName {
            get { return _userName; }
            set {
                _userName = value;
                RaisePropertyChanged( "UserName" );
            }
        }
        #endregion

        #region 同步数据

        /// <summary>
        /// 同步管理员账户信息
        /// </summary>
        /// <param name="mgrAccInfo">同步数据源</param>
        public void Sync( ManagerAccountInformation mgrAccInfo ) {
            base.Sync( mgrAccInfo );

            IDNumber = mgrAccInfo.IDNumber;
            Sex = mgrAccInfo.Sex;
            UserName = mgrAccInfo.UserName;
        }

        #endregion

    }
}
