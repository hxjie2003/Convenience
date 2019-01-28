using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.JavaApi.Sdk
{
    /// <summary>
    /// 自定义区分大小写的自动排序字典类
    /// </summary>
    public class CaseSortedDictionary : SortedDictionary<string, string>
    {
        /// <summary>
        /// 区分大小写的自动排序字典
        /// </summary>
        public static SortedDictionary<string, string> Default
        {
            get
            {
                return new SortedDictionary<string, string>(new CaseStringComparer());
            }
        }
    }

    /// <summary>
    /// 真正区分大小写的字符串比较器
    /// </summary>
    [Serializable]
    internal class CaseStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.CompareOrdinal(x, y);

            //return x.CompareTo(y); //没区分大小写
            //return string.Compare(x, y, false); //没区分大小写
        }
    }

}
