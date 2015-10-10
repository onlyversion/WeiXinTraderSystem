using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Gss.Common.Utility
{
    public class ClearDoubleProperty
    {
        public static void Clear(object obj)
        {
            try
            {
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    var ProValue = prop.GetValue(obj, null);
                    Type t = ProValue.GetType();
                    if (t == typeof(System.Double))
                    {
                        prop.SetValue(obj,
                                      0d,
                                       null);

                    }

                }
            }
            catch (Exception)
            {
                
               
            }
           
        }
    }
}
