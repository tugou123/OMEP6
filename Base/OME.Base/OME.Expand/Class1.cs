using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OME.Expand
{
    /// <summary>
    /// 两个实体类型转换
    /// </summary>
    public static class MapToC
    {
        public static T MapTo<T>(this object obj)
        {
            T d = Activator.CreateInstance<T>();
            try
            {
                var Types = obj.GetType();//获得类型  
                var Typed = typeof(T);

                foreach (PropertyInfo sp in Types.GetProperties())//获得类型的属性字段  
                {
                    foreach (PropertyInfo dp in Typed.GetProperties())
                    {
                        if (dp.Name == sp.Name)//判断属性名是否相同  
                        {
                            dp.SetValue(d, sp.GetValue(obj, null), null);//获得s对象属性的值复制给d对象的属性  
                        }
                    }
                }
                return d;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
