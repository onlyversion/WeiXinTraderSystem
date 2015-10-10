namespace Gss.Entities.Enums
{
    /// <summary>
    /// 功能：枚举转换
    /// 创建人：马友春
    /// 创建时间：2013年12月23日
    /// </summary>
    public class EnumConverter
    {
        /// <summary>
        /// 用户类型转换字符串
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static string ConverterUserType(UserTypeInfo info)
        {
            switch (info)
            {
                case UserTypeInfo.RootType:
                    return "超级管理员";
                    break;
                case UserTypeInfo.AdminType:
                    return "管理员类型";
                    break;
                case UserTypeInfo.OrgType:
                    return "会员类型";
                    break;
                case UserTypeInfo.NormalType:
                    return "普通类型";
                    break;
            }
            return "普通类型";
        }

        /// <summary>
        ///字符串转换用户类型
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>
        public static UserTypeInfo ConverterBackUserType(string userType)
        {
            switch (userType)
            {
                case "超级管理员":
                    return UserTypeInfo.RootType;
                    break;
                case "管理员类型":
                    return UserTypeInfo.AdminType;
                    break;

                case "会员类型":
                    return UserTypeInfo.OrgType;
                    break;
                case "普通类型":
                    return UserTypeInfo.NormalType;
                    break;
            }
            return UserTypeInfo.NormalType;
        }

        /// <summary>
        /// 证件类型转换
        /// </summary>
        /// <param name="cer"></param>
        /// <returns></returns>
        public static string ConverterCeritificateEnum(CeritificateEnum cer)
        {
            switch (cer)
            {
                case CeritificateEnum.ID:
                    return "身份证";
                    break;
                case CeritificateEnum.Company:
                    return "机构代码";
                    break;
                case CeritificateEnum.BusinessLicense:
                    return "营业执照";
                    break;
            }
            return "身份证";
        }

        /// <summary>
        /// 证件类型转换
        /// </summary>
        /// <param name="cer"></param>
        /// <returns></returns>
        public static CeritificateEnum ConverterBackCeritificateEnum(string str)
        {
            switch (str)
            {
                case "身份证":
                    return CeritificateEnum.ID;
                    break;
                case "机构代码":
                    return CeritificateEnum.Company;
                    break;
                case "其它":
                    return CeritificateEnum.BusinessLicense;
                    break;
            }
            return CeritificateEnum.ID;
        }
    }
}
