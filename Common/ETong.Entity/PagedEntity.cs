using System.Collections.Generic;

namespace ETong.Entity
{
    /// <summary>
    /// 分页集合
    /// </summary>
    /// <typeparam name="T">分页的实体</typeparam>
    public class PagedEntity<T>
    {
        public List<T> Items { get; set; }

        /// <summary>
        /// 总记录数量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 页记录数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 分页总数
        /// </summary>
        public int PageCount { get; set; }
    }
}