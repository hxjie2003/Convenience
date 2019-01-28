using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ETong.Utility.Configuration
{
    /// <summary>
    /// ClassFunction:此类用来提供对DLL配置文件的读写操作,目前只支持AppSettings和ConnectionStrings节点  
    /// </summary> 
    public class DllConfigurationManager
    {
        //实现 AppSettings 节点的读取    
        public static Hashtable AppSettings
        {
            get
            {
                string path = Assembly.GetCallingAssembly().GetName().CodeBase;
                return GetNameAndValue(path, "appSettings", "key", "value");
            }
        }
        /// <summary>       
        ///  实现对AppSettings节点对应key的value设置 
        ///   </summary>  
        ///   <param name="keyNameValue"></param> 
        ///   <param name="value"></param>    
        public static void SetAppSettings(string keyNameValue, string value)
        {
            string path = Assembly.GetCallingAssembly().GetName().CodeBase;
            SetNameAndValue(path, "appSettings", "key", keyNameValue, value);
        }

        public static Hashtable ConnectionStrings
        {
            get
            {
                string path = Assembly.GetCallingAssembly().GetName().CodeBase;
                return GetNameAndValue(path, "connectionStrings", "name", "connectionString");
            }
        }
        /// <summary>        
        /// 实现对connectionStrings 节点对应name的value设置       
        ///  </summary>     
        ///   <param name="keyNameValue"></param> 
        ///    <param name="value"></param>       
        public static void SetConnectionStrings(string keyNameValue, string value)
        {
            string path = Assembly.GetCallingAssembly().GetName().CodeBase;
            SetNameAndValue(path, "connectionStrings", "name", keyNameValue, value);
        }
        /// <summary>   
        ///  实现对相应节点的对应节点对应key或者name对应value值的设置  
        ///  </summary>   
        ///  <param name="sectionTag">对应节点</param>  
        ///  <param name="KeyOrName">对应key或者name</param>  
        ///  <param name="keyNameValue">key或者name的值</param>       
        ///   <param name="valueOrConnectionString">对应key或者name 的value值</param>    
        private static void SetNameAndValue(string path, string sectionTag, string KeyOrName, string keyNameValue, string valueOrConnectionString)
        {
            string assemblyPath = path; //获取运行项目当然DLL的路径         
            assemblyPath = assemblyPath.Remove(0, 8);//去除路径前缀       
            string configUrl = assemblyPath + ".config"; //添加.config后缀，得到配置文件路径     
            var doc = XDocument.Load(configUrl);
            var nodes = from node in doc.Descendants(sectionTag).First().Elements()
                        where node.Attribute(KeyOrName).Value == keyNameValue
                        select node;
            if (nodes != null && nodes.Count() > 0)
            {
                nodes.First().SetAttributeValue("value", valueOrConnectionString);
                doc.Save(configUrl);
            }
        }
        /// <summary> 
        /// 根据节点名，子节点名，获取指定值         
        ///  </summary>        
        /// <param name="sectionTag">对应节点</param>           
        /// <param name="KeyOrName">key或者name</param>        
        /// <param name="valueOrConnectionString">key或者name的值</param>   
        ///  <returns>key或者name对应value值</returns>     
        private static Hashtable GetNameAndValue(string path, string sectionTag, string KeyOrName, string valueOrConnectionString)
        {
            Hashtable settings = new Hashtable(5);//初始化Hashtable  
            string assemblyPath = path;//获取运行项目当然DLL的路径 
            assemblyPath = assemblyPath.Remove(0, 8); //去除前缀       
            string configUrl = assemblyPath + ".config"; //添加 .config 后缀，得到配置文件路径        

            var doc = XDocument.Load(configUrl);
            var nodes = doc.Descendants(sectionTag).First().Elements();
            nodes.ToList().ForEach(o => settings.Add(o.Attribute(KeyOrName).Value, o.Attribute(valueOrConnectionString).Value));
            return settings;
        }
    }
}
