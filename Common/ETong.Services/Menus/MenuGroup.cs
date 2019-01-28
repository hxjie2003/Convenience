using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ETong.Services.Menus
{
    [XmlRoot("MenuGroup")]
    public class MenuGroup
    {
        [XmlElement("MenuItems")]
        [JsonProperty("MenuItem")]
        public IList<MenuItem> MenuItems { get; set; }

        public static MenuGroup ParseFromXml(string xml)
        {
            var a = new XmlSerializer(typeof (MenuGroup), new[] {typeof (MenuItem)});
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            var menu = (MenuGroup) a.Deserialize(stream);
            return menu;
        }

        public static MenuGroup ParseFromJson(string json)
        {
            var menu = JsonConvert.DeserializeObject<MenuGroup>(json);
            return menu;
        }
    }

    [XmlRoot("MenuItem")]
    public class MenuItem
    {
        /*
        <Href>http://homeweb.etong.com/Home/StartPage</Href>
<Icon>icon mobil</Icon>
<IsDefault>true</IsDefault>
<IsEnabled>false</IsEnabled>
<Row>1</Row>
<Text>首页</Text>
<id>1</id>
         * */

        [XmlElement("id")]
        [JsonProperty("id")]
        public string Id { get; set; }

        [XmlElement("Icon")]
        public string Icon { get; set; }

        [XmlElement("Row")]
        public int Row { get; set; }

        [XmlElement("IsEnabled")]
        public bool IsEnabled { get; set; }

        [XmlElement("IsDefault")]
        public bool IsDefault { get; set; }

        public string Text { get; set; }
        public string Href { get; set; }
    }
}