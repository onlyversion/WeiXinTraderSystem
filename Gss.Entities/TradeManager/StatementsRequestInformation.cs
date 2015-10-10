using Gss.Entities.Enums;

namespace Gss.Entities {
    public class StatementsRequestInformation : RequestInformationBase {
        private STATEMENTS_TYPE _statementsType;

        /// <summary>
        /// 获取或设置报表类型
        /// </summary>
        public STATEMENTS_TYPE StatementsType {
            get { return _statementsType; }
            set {
                _statementsType = value;
                RaisePropertyChanged( "StatementsType" );
            }
        }

        public StatementsRequestInformation( ) {
            StatementsType = STATEMENTS_TYPE.NULL;
        }

    }
}
