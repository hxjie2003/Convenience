using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;
using System.Data;
namespace ETong.Utility.Converters
{
    public class DataTableConvertModel<T> where T:new ()
    {
        /// <summary>
        /// 将DataTable 转化成 Model 通用方法
        /// </summary>
        /// <param name="dt">DataTable表</param>
        /// <returns></returns>
        public static IList<T> ConvertToModel(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
                return null;

            IList<T> tList = new List<T>();
            Type modelType = typeof(T);

            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] propertys = modelType.GetProperties();
                foreach (PropertyInfo property in propertys)
                {
                    if (dt.Columns.Contains(property.Name))
                    {
                        if (!property.CanWrite)
                            continue;
                        object value = dr[property.Name];
                        if (value != DBNull.Value)
                        {
                            //进行数据类型转换
                            
                            switch (dr[property.Name].GetType().Name)
                            {
                                case "Decimal":
                                    property.SetValue(t, Convert.ToInt32(value), null);
                                    break;
                                default:
                                    property.SetValue(t, value, null);
                                    break;
                            }
                        }
                    }
                }
                tList.Add(t);
            }
            return tList;
        }
    }
}
