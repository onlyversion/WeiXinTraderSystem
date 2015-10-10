using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities {
    /// <summary>
    /// 返回值类
    /// </summary>
    public class ErrType {
        /// <summary>
        /// 获取错误类型
        /// </summary>
        public ERR Err { get; private set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Dec { get;  set; }

        /// <summary>
        /// 获取错误信息
        /// </summary>
        public string ErrMsg { get; private set; }

        /// <summary>
        /// 获取错误标题
        /// </summary>
        public string ErrTitle {
            get {
                string msg = "提示";
                switch( Err ) {
                    case ERR.SUCCESS:
                        msg = "操作成功";
                        break;
                    case ERR.ERROR:
                        msg = "错误";
                        break;
                    case ERR.EXEPTION:
                        msg = "异常";
                        break;
                    case ERR.SERVICE:
                        msg = "服务器返回错误";
                        break;
                    case ERR.TIMEOUT :
                        msg = "请求超时";
                        break;
                    case ERR.VALIDATE_FAIL:
                        msg = "数据验证失败";
                        break;
                    default:
                        break;
                }
                return msg;
            }
        }

        public ErrType( ERR err, string msg ) {
            Err = err;
            ErrMsg = msg;
        }

        public ErrType( ERR err ) : this( err, "" ) { }
    }

    /// <summary>
    /// General ErrType class.
    /// </summary>
    public static class GeneralErr {
        private static readonly ErrType _error = new ErrType( ERR.ERROR );
        private static readonly ErrType _success = new ErrType( ERR.SUCCESS );

        public static ErrType Error {
            get { return _error; }
        }

        public static ErrType Success {
            get { return _success; }
        }
    }

    /// <summary>
    /// 错误类型枚举
    /// </summary>
    public enum ERR {
        /// <summary>
        /// 成功
        /// </summary>
        SUCCESS,

        /// <summary>
        /// 错误
        /// </summary>
        ERROR,

        /// <summary>
        /// 异常
        /// </summary>
        EXEPTION,

        /// <summary>
        /// 登陆失败
        /// </summary>
        LOGIN_FAIL,

        /// <summary>
        /// 服务器返回错误
        /// </summary>
        SERVICE,

        /// <summary>
        /// 超时
        /// </summary>
        TIMEOUT,

        VALIDATE_FAIL,
    }
}
