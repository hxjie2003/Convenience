using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ETong.Utility.Xml
{
    public static class XElementExtensions
    {
        public static string GetElementValue(this XElement el, string name)
        {
            var n = el.Element(name);
            return n == null ? string.Empty : n.Value;
        }
    }
}
