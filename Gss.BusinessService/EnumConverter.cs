using Gss.BusinessService.ManagementService;
using Gss.Entities.Enums;

namespace Gss.BusinessService
{
    /// <summary>
    /// 功能：枚举转换
    /// 创建人：马友春
    /// 创建时间：2013年12月23日
    /// </summary>
    public class EnumConverter
    {
        /// <summary>
        /// 用户类型转换
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static Gss.BusinessService.ManagementService.UserType  ConverterUserType(UserTypeInfo info)
        {
            switch(info)
            {
                case UserTypeInfo.AdminType:
                    return Gss.BusinessService.ManagementService.UserType.AdminType;
                    break;
                case UserTypeInfo.NormalType:
                    return Gss.BusinessService.ManagementService.UserType.NormalType;
                    break;
                case UserTypeInfo.OrgType:
                    return Gss.BusinessService.ManagementService.UserType.OrgType;
                    break;
                case UserTypeInfo.RootType:
                    return Gss.BusinessService.ManagementService.UserType.RootType;
                    break;
            }
            return Gss.BusinessService.ManagementService.UserType.NormalType;
        }

        /// <summary>
        /// 证件类型转换
        /// </summary>
        /// <param name="cer"></param>
        /// <returns></returns>
        public static IDType ConverterIDType(CeritificateEnum cer)
        {
            switch(cer)
            {
                case CeritificateEnum.ID:
                    return IDType.Identity;
                    break;
                case CeritificateEnum.Company:
                    return IDType.Company;
                    break;
                case CeritificateEnum.BusinessLicense:
                    return IDType.Business;
                    break;
            }
            return IDType.Identity;
        }

        /// <summary>
        /// 证件类型转换
        /// </summary>
        /// <param name="cer"></param>
        /// <returns></returns>
        public static CeritificateEnum ConverterCeritificateEnum(IDType cer)
        {
            switch (cer)
            {
                case IDType.Identity:
                    return CeritificateEnum.ID;
                    break;
                case IDType.Company:
                    return CeritificateEnum.Company;
                    break;
                case IDType.Business:
                    return CeritificateEnum.BusinessLicense;
                    break;
            }
            return CeritificateEnum.ID;
        }

  
    }
}
