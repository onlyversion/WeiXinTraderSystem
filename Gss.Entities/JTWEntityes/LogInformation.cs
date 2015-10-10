using System;
using Gss.Entities.Enums;

namespace Gss.Entities.JTWEntityes
{
	/// <summary>
	/// 服务器返回的日志信息类
	/// </summary>
	public class LogInformation : BaseInfo
	{
		/// <summary>
		/// Gets or sets 操作时间
		/// </summary>
		public DateTime OperTime
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets 操作账号
		/// </summary>
		public string Account
		{
			get;
			set;
		}

		private UserTypeInfo _UTpe;
		/// <summary>
		/// 用户类型
		/// </summary>
		public UserTypeInfo UType
		{
			get { return _UTpe; }
			set
			{
                _UTpe = value;
                _UTypeString = EnumConverter.ConverterUserType(value);
                RaisePropertyChanged("UTypeString");
                RaisePropertyChanged("UType");
			}
		}

		private string _UTypeString;
		/// <summary>
		/// 用户类型
		/// </summary>
		public string UTypeString
		{
			get
			{
				return _UTypeString;
			}
			set
			{
				if (_UTypeString != value)
				{
					_UTypeString = value;
					_UTpe = EnumConverter.ConverterBackUserType(value);
					RaisePropertyChanged("UType");
					RaisePropertyChanged("UTypeString");
				}
			}
		}

		/// <summary>
		/// Gets or sets 操作描述
		/// </summary>
		public string Desc
		{
			get;
			set;
		}
	}
}
