using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace ETong.Utility.Converts
{
    /// <summary>
    /// 常用数据格式转换
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="value">目标值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>string</returns>
        public static string ToString(object value, string defaultValue = "")
        {

            if (value != null && value != System.DBNull.Value)
                defaultValue = value.ToString();
            return defaultValue;
        }

        /// <summary>
        /// 转换为布尔值
        /// </summary>
        /// <param name="value">目标值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>bool</returns>
        public static bool ToBool(object value, bool defaultValue = false)
        {
            if (value != null && value != System.DBNull.Value && value.ToString().Trim().Length > 0)
            {
                if (value.ToString() == "0")
                    defaultValue = false;
                else if (value.ToString() == "1")
                    defaultValue = true;
                else
                    defaultValue = System.Convert.ToBoolean(value);
            }
            return defaultValue;
        }

        /// <summary>
        /// 转换为整数
        /// </summary>
        /// <param name="value">目标值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>Int32</returns>
        public static int ToInt(object value, int defaultValue = -1)
        {
            if (value != null && value != System.DBNull.Value && value.ToString().Trim().Length > 0)
            {
                if (value.ToString().Trim().Length > 0)
                    try
                    {
                        defaultValue = System.Convert.ToInt32(value);
                    }
                    catch (Exception ex)
                    {
                         //
                    }
                    
            }
            return defaultValue;
        }

        /// <summary>
        /// 转换为short整数
        /// </summary>
        /// <param name="value">目标值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>short</returns>
        public static short ToShort(object value, short defaultValue = 0)
        {
            if (value == null || value == System.DBNull.Value) return defaultValue;
            short.TryParse(value.ToString(), out defaultValue);
            return defaultValue;
        }

        /// <summary>
        /// 转换为浮点数
        /// </summary>
        /// <param name="value">目标值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>Double</returns>
        public static Double ToFloat(object value, Double defaultValue = -1)
        {
            if (value != null && value != System.DBNull.Value && value.ToString().Trim().Length > 0)
                defaultValue = System.Convert.ToDouble(value);
            return defaultValue;
        }

        /// <summary>
        /// 转换类型为 decimal
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object value, decimal defaultValue = 0)
        {
            if (value == null || value == System.DBNull.Value) return defaultValue;
            decimal d;
            
            var b = decimal.TryParse(value.ToString(), out d);

            if (!b)
                d = defaultValue;

            return d;
        }

        /// <summary>
        /// 将对象转换成 long 类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long ToLong(object value, long defaultValue = 0)
        {
            if (value == null || value == System.DBNull.Value) return defaultValue;
            long l;

            var f = long.TryParse(value.ToString(), out l);

            return f ? l : defaultValue;
        }

        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="value">目标值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>DateTime</returns>
        public static DateTime? ToDateTime(object value, DateTime? defaultValue = null)
        {
            if (value != null && value != System.DBNull.Value && value.ToString().Trim().Length > 0)
            try
            {
                defaultValue = System.Convert.ToDateTime(value);
            }
            catch (Exception ex)
            { 

            }
                
            return defaultValue;
        }

        /// <summary>
        /// 比较两个字符串是否相等（不区分大小写，忽略左右两边的空格）
        /// </summary>
        /// <param name="str1">字符串1</param>
        /// <param name="str2">字符串2</param>
        /// <returns>bool</returns>
        public static bool ToCompare(string str1, string str2)
        {
            return (str1.Trim().ToLower() == str2.Trim().ToLower());
        }

        /// <summary>
        /// 批量替换字符串
        /// </summary>
        /// <param name="source">要替换的字符串{0}{1}{2}...</param>
        /// <param name="values">替换的值数组</param>
        /// <returns>string</returns>
        public static string ToReplace(string source, string[] values)
        {
            for (int i = 0; i <= values.Length - 1; i++)
            {
                source = source.Replace("{" + i.ToString() + "}", values[i]);
            }
            return source;
        }

        /// <summary>
        /// 格式化日期格式为统一格式的字符串(不带时间部分)
        /// </summary>
        /// <param name="value">日期</param>
        /// <returns>string</returns>
        public static string ToFormatDate(DateTime? value)
        {
            if (value != null)
                return value.Value.ToString("yyyy/MM/dd");
            return "";
        }

        /// <summary>
        /// 格式化日期格式为统一格式的字符串
        /// </summary>
        /// <param name="value">日期</param>
        /// <returns>string</returns>
        public static string ToFormatDateTime(DateTime? value)
        {
            if (value != null)
                return value.Value.ToString("yyyy/MM/dd HH:mm:ss");
            return "";
        }

        /// <summary>
        /// 转换为数据行值
        /// </summary>
        public static object ToDataRowValue(object value)
        {
            if (value == null)
                return System.DBNull.Value;
            if (value.ToString() == "")
                return System.DBNull.Value;
            return value;
        }

        /// <summary>
        /// 行转为字典
        /// </summary>
        /// <param name="dbRow">数据行</param>
        /// <returns>字典集合</returns>
        public static Dictionary<string, string> ToDictionary(DataTable dt, DataRow dbRow)
        {
            Dictionary<string, string> pars = new Dictionary<string, string>();
            foreach (DataColumn col in dt.Columns)
                pars.Add(col.ColumnName, Converter.ToString(dbRow[col]));
            return pars;
        }

        public static byte[] SerializeToByteArray(this object obj)
        {
            if (obj == null)
            {
                return null;
            }
            try
            {
                var bf = new BinaryFormatter();
                using (var ms = new MemoryStream())
                {
                    bf.Serialize(ms, obj);
                    return ms.ToArray();
                }
            }
            catch 
            {
                return null;
            }
        }

        public static T Deserialize<T>(this byte[] byteArray) where T : class
        {
            if (byteArray == null)
            {
                return null;
            }
            try
            {
                using (var memStream = new MemoryStream())
                {
                    var binForm = new BinaryFormatter();
                    memStream.Write(byteArray, 0, byteArray.Length);
                    memStream.Seek(0, SeekOrigin.Begin);
                    var obj = (T)binForm.Deserialize(memStream);
                    return obj;
                }
            }
            catch 
            {
                return null;
            }
        }

        /// <summary>
        /// 转换为系统变量值
        /// </summary>
        /// <param name="variable">变量名称</param>
        /// <returns>string</returns>
        public static string ToSysVar(string variable)
        {
            string[] vars = variable.Split(':');
            if (vars.Length == 2)
                variable = vars[1];
            else
                variable = vars[0];
            string value = variable;
            if (variable == "sys_user_id")
                value = "";
            else if (variable == "sys_user_name")
                value = "";
            else if (variable == "sys_user_role_id")
                value = "";
            else if (variable == "sys_user_dept_id")
                value = "";
            else if (variable == "sys_datetime")
                value = DateTime.Now.ToString();
            return value;
        }

        #region DAO To DTO / DTO To DAO
        /// <summary>
        /// 类型转换
        /// </summary>
        /// <typeparam name="Tint">输入类型</typeparam>
        /// <typeparam name="Tout">输出类型</typeparam>
        //public static Tout ConvertTo<Tint, Tout>(Tint Ti)
        //    where Tint : class
        //    where Tout : class
        //{
        //    var obj = default(Tout);

        //    // 转成namevalue
        //    var coll = KK.Framework.General.Common.ConvertTo<Tint>(Ti);

        //    // 类型转换
        //    obj = KK.Framework.General.Common.ConvertTo<Tout>(coll);

        //    return obj;
        //}

        /// <summary>
        /// 类型转换，目前只支持类型相同的属性转换
        /// </summary>
        /// <typeparam name="TSource">输入类型</typeparam>
        /// <typeparam name="TResult">输出类型</typeparam>
        //public static Tout ConvertTo<Tint, Tout>(Tint Ti)
        public static TResult ConvertTo<TSource, TResult>(TSource source)
            where TSource : class
            where TResult : class
        {
            if (source==null)
            {
                return null;
            }
            var parExr = Expression.Parameter(typeof(TSource), "x");
            var mbs = GetModelPropertyBinds<TSource, TResult>(parExr);
            var mExpr = Expression.MemberInit(Expression.New(typeof(TResult)), mbs);
            var t = Expression.Lambda<Func<TSource, TResult>>(mExpr, parExr).Compile();
            return t(source);
        }

        /// <summary>
        /// 获取模型属性绑定
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="pExpr"></param>
        /// <returns></returns>
        private static List<MemberBinding> GetModelPropertyBinds<TSource, TResult>(ParameterExpression pExpr)
        {
            var mbs = new List<MemberBinding>();

            Type sourceType = typeof(TSource);
            Type resultType = typeof(TResult);
            var p1Property = sourceType.GetProperties();
            var p2Property = resultType.GetProperties();

            p2Property.ToList().ForEach(p2 =>
            {
                var p1 = p1Property.Where(x => x.CanRead && x.CanWrite && x.Name.Equals(p2.Name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                if (p1 != null)
                {
                    try
                    {
                        MemberExpression prop = Expression.Property(pExpr, p1);;
                        var t = Expression.Bind(p2, prop);
                        mbs.Add(t);
                    }
                    catch (Exception ex)
                    {
                        var mes = ex.Message;
                    }
                }
            });

            return mbs;
        }
        #endregion

        /// <summary>
        /// Unicode转中文
        /// </summary>
        /// <param name="s">Unicode字符串</param>
        /// <returns></returns>
        public static string UnicodeToChinese(string unicodeString)
        {
            Regex reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
            return reg.Replace(unicodeString, delegate(Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });
        }
    }
}
