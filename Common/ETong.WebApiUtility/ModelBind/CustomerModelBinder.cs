using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace ETong.WebApiUtility.ModelBind
{
    public class CustomerModelBinder<T> : IModelBinder
          where T : class,new()
    {
        public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext, ModelBindingContext bindingContext)
        {

            T model = new T();
            Dictionary<string, object> obje = new Dictionary<string, object>();
            foreach (var metadata in bindingContext.PropertyMetadata)
            {
                var value = bindingContext.ValueProvider.GetValue(metadata.Key);
                if (value != null)
                    obje.Add(metadata.Key, value.RawValue);
            }
            var str = Newtonsoft.Json.JsonConvert.SerializeObject(obje);
            //ILog log = LogManager.GetLogger(typeof(CustomerModelBinder<T>));
            //log.Info("自定义模型绑定拦截："+str);
            model = JsonConvert.DeserializeObject<T>(str);
            bindingContext.Model = model;
            return true;
        }
    }
}
