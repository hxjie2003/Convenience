using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETong.WebApi.Core
{
    public class UrlQueryParser
    {
        /// <summary>
        /// 字典到Url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DataToUrl(string url, IEnumerable<KeyValuePair<string, string>> data)
        {

            if (data == null)

                throw new ArgumentNullException("data");



            bool first = true;

            var sb = new StringBuilder(url);

            foreach (var item in data)
            {

                if (first)
                {

                    sb.Append('?');

                    first = false;

                }

                else

                    sb.Append('&');



                sb.Append(Uri.EscapeDataString(item.Key) + "=" + Uri.EscapeDataString(item.Value));

            }



            return sb.ToString();

        }



       /// <summary>
       /// Url到字典
       /// </summary>
       /// <param name="url"></param>
       /// <returns></returns>
        public static Tuple<string, IEnumerable<KeyValuePair<string, string>>> UrlToData(string url)
        {

            if (url == null)

                throw new ArgumentNullException("url");



            url = url.Trim();

            try
            {

                var split = url.Split(new[] { '?', '&' }, StringSplitOptions.RemoveEmptyEntries);

                if (split.Length == 1)

                    return new Tuple<string, IEnumerable<KeyValuePair<string, string>>>(url, null);



                //获取前面的URL地址

                var host = split[0];



                var pairs = split.Skip(1).Select(s =>
                {

                    //没有用String.Split防止某些少见Query String中出现多个=，要把后面的无法处理的=全部显示出来

                    var idx = s.IndexOf('=');

                    return new KeyValuePair<string, string>(Uri.UnescapeDataString(s.Substring(0, idx)), Uri.UnescapeDataString(s.Substring(idx + 1)));

                }).ToList();



                return new Tuple<string, IEnumerable<KeyValuePair<string, string>>>(host, pairs);

            }

            catch (Exception ex)
            {

                throw new FormatException("URL格式错误", ex);

            }

        }
    }
}
