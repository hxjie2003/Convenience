using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web.Services.Description;
using System.Web.Services.Discovery;
using System.Web.Services.Protocols;
using System.Xml.Schema;
using System.Xml.Serialization;
using ETong.Utility.Cache;

namespace ETong.Utility
{
    public class WebServiceHelper
    {
        //private static readonly Cache.CacheManager CacheStore = new Cache.CacheManager();

        /// <summary>
        /// 动态加载 WebService 服务内容
        /// </summary>
        /// <param name="wsdlUrl">服务地址</param>
        /// <param name="serviceName">服务名（如FW0001）</param>
        /// <param name="className">类名</param>
        /// <param name="methodName">方法名</param>
        /// <param name="parameters">参数列表</param>
        /// <returns></returns>
        public static object Load(string wsdlUrl, string serviceName, string className, string methodName, params object[] parameters)
        {
            wsdlUrl = wsdlUrl.EndsWith("?wsdl", StringComparison.CurrentCultureIgnoreCase) ? wsdlUrl : wsdlUrl + "?wsdl";

            var assemblyKey = SecurityHelper.MD5.Encrypt(wsdlUrl);

            var assembly = CacheManager.Get(assemblyKey) as Assembly;
            
            if (assembly != null)
                return InvokeServices(assembly, serviceName, className, methodName, parameters);

            assembly = CreateProxyAssembly(wsdlUrl, serviceName, className);

            CacheManager.Set(assemblyKey, assembly);

            return InvokeServices(assembly, serviceName, className, methodName, parameters);
        }

        private static Assembly CreateProxyAssembly(string wsdlUrl, string serviceName, string className)
        {
            try
            {
                //使用WebClient下载WSDL信息                         
                var web = new WebClient();
                var stream = web.OpenRead(wsdlUrl);
                var description = ServiceDescription.Read(stream); //创建和格式化WSDL文档  

                //创建客户端代理代理类  
                var importer = new ServiceDescriptionImporter
                {
                    ProtocolName = "Soap",
                    Style = ServiceDescriptionImportStyle.Client,
                    CodeGenerationOptions =
                        CodeGenerationOptions.GenerateProperties | CodeGenerationOptions.GenerateNewAsync
                };
                importer.AddServiceDescription(description, null, null); //添加WSDL文档  

                //使用CodeDom编译客户端代理类                   
                var nmspace = new CodeNamespace(serviceName); //为代理类添加命名空间                  
                var unit = new CodeCompileUnit();
                unit.Namespaces.Add(nmspace);

                CheckForImports(wsdlUrl, importer);

                var warning = importer.Import(nmspace, unit);

                if (warning != 0)
                {
                    throw new Exception(warning.ToString());
                }

                var provider = CodeDomProvider.CreateProvider("CSharp");
                var parameter = new CompilerParameters();
                parameter.ReferencedAssemblies.Add("System.dll");
                parameter.ReferencedAssemblies.Add("System.XML.dll");
                parameter.ReferencedAssemblies.Add("System.Web.Services.dll");
                parameter.ReferencedAssemblies.Add("System.Data.dll");
                parameter.GenerateExecutable = false;
                parameter.GenerateInMemory = false;
                parameter.IncludeDebugInformation = false;

                var result = provider.CompileAssemblyFromDom(parameter, unit);
                provider.Dispose();

                if (result.Errors.HasErrors)
                {
                    var errors = string.Format(@"编译错误:{0}错误！", result.Errors.Count);
                    errors = result.Errors.Cast<CompilerError>().Aggregate(errors, (current, error) => current + error.ErrorText);

                    throw new Exception(errors);
                }

                return result.CompiledAssembly; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static object InvokeServices(Assembly assembly, string nmspace, string className, string methodName,
            params object[] parameters)
        {
            var t = assembly.GetType(nmspace + "." + className, true, true);

            var obj = Activator.CreateInstance(t);

            var mi = t.GetMethod(methodName);

            if (parameters == null || !parameters.Any())
                return mi.Invoke(obj, null);

            var paramInfos = mi.GetParameters();

            var p = AttachArguments(paramInfos, parameters);

            return mi.Invoke(obj, p);
        }

        private static object[] AttachArguments(ParameterInfo[] methodParameterInfos, object[] parameters)
        {
            var length = methodParameterInfos.Length;
            if (length != parameters.Count())
                throw new Exception("参数数量不正确");

            var result = new List<object>();
            for (var i = 0; i < length; i++)
            {
                var pType = methodParameterInfos[i];

                if (parameters[i] is Dictionary<string, object>)
                {
                    var dic = parameters[i] as Dictionary<string, object>;

                    //var valObj = Activator.CreateInstance(pType.ParameterType);

                    //foreach (var key in dic.Keys)
                    //{
                    //    var field = pType.ParameterType.GetProperty(key);
                    //    field.SetValue(valObj, dic[key], null);
                    //}
                    var valObj = AttachParameters(pType.ParameterType, dic);

                    result.Add(valObj);
                }
                else if(parameters[i] is List<Dictionary<string, object>>)
                {
                    var dicList = parameters[i] as List<Dictionary<string, object>>;

                    var valObj = AttachParameters(pType.ParameterType, dicList);

                    result.Add(valObj);

                    //var l = dicList.Count;

                    //if (pType.ParameterType.IsGenericType)
                    //{ 
                    //    var genericArgumentsType = pType.ParameterType.GetGenericArguments().First();

                    //    var valObj = Array.CreateInstance(genericArgumentsType, l);

                    //    var j = 0;
                    //    foreach (var dic in dicList)
                    //    {
                    //        var gObj = Activator.CreateInstance(genericArgumentsType);

                    //        dic.Keys.ToList()
                    //            .ForEach(key => genericArgumentsType.GetProperty(key).SetValue(gObj, dic[key], null));

                    //        valObj.SetValue(gObj, j);

                    //        j++;
                    //    }

                    //    result.Add(valObj);
                    //} 
                    //else if (pType.ParameterType.IsArray)
                    //{
                    //    var genericArgumentsType = pType.ParameterType.GetElementType();

                    //    var valObj = Array.CreateInstance(genericArgumentsType, l);

                    //    var j = 0;
                    //    foreach (var dic in dicList)
                    //    {
                    //        var gObj = Activator.CreateInstance(genericArgumentsType);

                    //        dic.Keys.ToList()
                    //            .ForEach(key => genericArgumentsType.GetProperty(key).SetValue(gObj, dic[key], null));

                    //        valObj.SetValue(gObj, j);

                    //        j++;
                    //    }

                    //    result.Add(valObj);
                    //}
                }
                else
                {
                    result.Add(parameters[i]);
                }
            }

            return result.ToArray();
        }

        private static object AttachParameters(Type t, Dictionary<string, object> dic)
        {
            var o = Activator.CreateInstance(t);

            foreach (var key in dic.Keys)
            {
                object ov;

                var item = dic[key];
                var property = t.GetProperty(key);
                var propertyType = property.PropertyType;
                if (item is Dictionary<string, object>)
                {
                    var itemDic = item as Dictionary<string, object>;
                    ov = AttachParameters(propertyType, itemDic); 
                }
                else if (item is List<Dictionary<string, object>>)
                { 
                    var list = item as List<Dictionary<string, object>>;

                    //var l = list.Count;

                    //Type ct = propertyType.IsGenericType ? propertyType.GetGenericArguments().First() : propertyType.GetElementType();

                    //var arr = Array.CreateInstance(ct, l);

                    //var j = 0;
                    //foreach (var d in list)
                    //{
                    //    var cto = Activator.CreateInstance(ct);

                    //    d.Keys.ToList().ForEach(k => ct.GetProperty(key).SetValue(cto, d[k], null));

                    //    arr.SetValue(cto, j);

                    //    j++;
                    //}

                    //ov = arr;

                    ov = AttachParameters(propertyType, list);
                }
                else
                {
                    ov = dic[key];
                }
                
                t.GetProperty(key).SetValue(o, ov, null);
            }

            return o;
        }
        private static object AttachParameters(Type t, List<Dictionary<string, object>> list)
        {
            var genericType = t.IsGenericType ? t.GetGenericArguments().First() : t.GetElementType();
            var count = list.Count;

            var arr = Array.CreateInstance(genericType, count);

            var i = 0;
            foreach (var item in list)
            {
                var cto = AttachParameters(genericType, item);

                arr.SetValue(cto, i);

                i += 1;
            }

            return arr; 
        }

        /// <summary>                       
        /// 根据web   service文档架构向代理类添加ServiceDescription和XmlSchema                             
        /// </summary>                                  
        /// <param name="url">web服务地址</param>                           
        /// <param name="importer">代理类</param>                              
        private static void CheckForImports(string url, ServiceDescriptionImporter importer)
        {
            var dcp = new DiscoveryClientProtocol();
            dcp.DiscoverAny(url);
            dcp.ResolveAll();

            if (dcp.Documents.Values == null) return;

            foreach (var osd in dcp.Documents.Values)
            {
                if (osd is ServiceDescription) importer.AddServiceDescription((ServiceDescription)osd, null, null);

                if (osd is XmlSchema) importer.Schemas.Add((XmlSchema)osd);
            }
        }
    } 
}