using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ETong.Utility.Xml
{

    /// <summary>
    /// 对象序列化器，可序列化及反序列成字符串或文件。
    /// </summary>
    public class ObjectXmlSerializer
    {
        /// <summary>
        /// 从文件中反序列化。
        /// </summary>
        /// <typeparam name="T">反序列化类型</typeparam>
        /// <param name="fileName">路径</param>
        /// <returns>返回对应类型</returns>
        public static T LoadFromXml<T>(string fileName) where T : class
        {
            FileStream fs = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof (T));
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                return (T) serializer.Deserialize(fs);
            }
            catch (Exception e)
            {
               throw e;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }


        /// <summary>
        /// 将对象序列化到文件. 
        /// </summary>
        /// <typeparam name="T">序列化类型</typeparam>
        /// <param name="fileName">文件路径</param>
        public static void SaveToXml<T>(string fileName, T data) where T : class
        {
            FileStream fs = null;
            try
            {

                XmlSerializer serializer = new XmlSerializer(typeof(T));
                fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                serializer.Serialize(fs, data);
            }
            catch (Exception e)
            {
                 throw;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

       
        /// <summary>
        /// 序列化成字符串
        /// </summary>
        /// <typeparam name="T">序列化的类型</typeparam>
        /// <param name="serialObject">序死化的对象</param>
        /// <returns>xml字符串</returns>
        public static string XmlSerializer(object serialObject)
        {
            XmlSerializer ser = new XmlSerializer(serialObject.GetType());
            System.IO.MemoryStream mem = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mem, Encoding.UTF8);
            ser.Serialize(writer, serialObject);
            writer.Close();

            return Encoding.UTF8.GetString(mem.ToArray());
        }


        /// <summary>
        /// 序列化成字符串
        /// </summary>
        /// <typeparam name="T">序列化的类型</typeparam>
        /// <param name="serialObject">序死化的对象</param>
        /// <param name="xmlnamespaces">命名空间</param>
        /// <returns>xml字符串</returns>
        public static string XmlSerializer(object serialObject,XmlSerializerNamespaces xmlnamespaces) 
        {
            XmlSerializer ser = new XmlSerializer(serialObject.GetType());
            System.IO.MemoryStream mem = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mem, Encoding.UTF8);
            ser.Serialize(writer, serialObject, xmlnamespaces);
            writer.Close();

            return Encoding.UTF8.GetString(mem.ToArray());
        }

        /// <summary>
        /// 将字符串反序列化成T类型。
        /// </summary>
        /// <typeparam name="T">反序列化的目标类型</typeparam>
        /// <param name="str">反序列化的字符串</param>
        /// <returns>T类型的结果</returns>
        public static T XmlDeserialize<T>(string str) where T : class
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(T));
            StreamReader mem2 = new StreamReader(
                    new MemoryStream(System.Text.Encoding.UTF8.GetBytes(str)),
                    System.Text.Encoding.UTF8);
            return (T)mySerializer.Deserialize(mem2);
        }


        /// <summary>
        /// 数据契约的反序列化。{[DataContract]特性的类型}
        /// </summary>
        /// <typeparam name="T">反序列化的类型</typeparam>
        /// <param name="xmlData">反序列化的xml字符串</param>
        /// <returns>T类型的结果</returns>
        public static T DataContractDeserializer<T>(string xmlData) where T : class
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xmlData));
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(T));
            T deserializedPerson = (T)ser.ReadObject(reader, true);
            reader.Close();
            stream.Close();
            return deserializedPerson;
        }

        /// <summary>
        /// 数据契约的序列化。{[DataContract]特性的类型}
        /// </summary>
        /// <typeparam name="T">序列化的类型</typeparam>
        /// <param name="myObject">T类型实例</param>
        /// <returns>序列化的xml字符串结果</returns>
        public static string DataContractSerializer(object myObject)
        {
            MemoryStream stream = new MemoryStream();
            DataContractSerializer ser = new DataContractSerializer(myObject.GetType());
            ser.WriteObject(stream, myObject);
            stream.Close();

            return Encoding.UTF8.GetString(stream.ToArray());
        }



    }
}
