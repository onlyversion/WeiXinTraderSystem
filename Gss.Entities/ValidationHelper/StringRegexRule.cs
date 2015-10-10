using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace Gss.Entities.ValidationHelper
{
    /// <summary>
    /// 只能是数字，英文字母，汉字，下划线组成的N位字符串验证
    /// </summary>
   public  class StringRegexRule : ValidationRule
    {
        /// <summary>
        /// 是否包含中文
        /// </summary>
        public bool HasChinese { get; set; }
       /// <summary>
       /// 是否包含下划线
       /// </summary>
        public bool HasUnderline { get; set; }
       /// <summary>
       /// 是否仅包含数字
       /// </summary>
        public bool IsNumberOnly { get; set; }

        public StringRegexRule()
        {
            HasChinese = true;
            HasUnderline = true;
        }
       /// <summary>
       /// 验证规则
       /// </summary>
        string rule = string.Empty;
       /// <summary>
       /// 最大长度
       /// </summary>
        public int MaxLength { get; set; }
       /// <summary>
       /// 最小长度
       /// </summary>
        public int MinLength { get; set; }
       /// <summary>
       /// 能否为空字符串
       /// </summary>
        public bool CanEmpty { get; set; }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        { 
            string str = (string)value;
            
            if (string.IsNullOrEmpty(str))
            {
                if (MinLength >0 && !CanEmpty)
                {
                    return new ValidationResult(false, string.Format("不能为空"));
                }
                else
                {
                    return new ValidationResult(true, null);
                }


            }
            #region 构建验证规则
            rule = string.Empty;
            if (IsNumberOnly)
            {
                rule += @"^[0-9";
            }
            else
            {
                
                rule += @"^[a-zA-Z0-9";
                if (HasUnderline)
                {
                    rule += "_";
                }
                if (HasChinese)
                {
                    rule += "\u4e00-\u9fa5";
                }
            }
            rule += "(),!@#$&*]{" + MinLength.ToString() + "," + MaxLength.ToString() + "}$";
            //string rule = string.Empty;
            //rule += @"^[a-zA-Z0-9_\u4e00";
            //if (HasUnderline)
            //{
            //    rule += "_";
            //}
            //if (HasChinese)
            //{
            //    rule += "\u4e00-\u9fa5";
            //}


            //rule += "]{" + MinLength.ToString() + "," + MaxLength.ToString() + "}$";

            #endregion
          

            if (Regex.IsMatch(str, rule))
                return new ValidationResult(true, null);
            else
            {
                if (IsNumberOnly)
                {
                    return new ValidationResult(false, string.Format("只能是数字组成的{0}-{1}位字符串", MinLength, MaxLength));
                }
                if (HasChinese && HasUnderline)
                {
                    return new ValidationResult(false, string.Format("只能是数字，英文字母，汉字，下划线组成的{0}-{1}位字符串", MinLength, MaxLength));
                }
                else if (HasChinese && !HasUnderline)
                {
                    return new ValidationResult(false, string.Format("只能是数字，英文字母，汉字组成的{0}-{1}位字符串", MinLength, MaxLength));
                }
                else
                {
                    return new ValidationResult(false, string.Format("只能是数字，英文字母，(),!@#$&*,下划线组成的{0}-{1}位字符串", MinLength, MaxLength));
                }
                
            }
                
        }
    }
}
