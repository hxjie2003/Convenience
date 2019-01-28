using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETong.Entity.Presentation.Infrasture
{
    public class OpenApiReliableInfo
    {
        public string ApiId { get; set; }
        public string AppId { get; set; }

        public List<OpenReliableUrlInfo> ReliableUrls { get; set; }
    }

    public class OpenReliableUrlInfo
    {
        public string Url { get; set; }
    }
}
