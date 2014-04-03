using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Iheik.Attributes
{
    public class FromJsonAttribute : CustomModelBinderAttribute
    {
        public override IModelBinder GetBinder()
        {
            return new JsonModelBinder();
        }

        private class JsonModelBinder : IModelBinder
        {
            private JsonSerializerSettings SerializerSettings { get; set; }

            public JsonModelBinder()
                : base()
            {
                // create serializer settings
                this.SerializerSettings = new JsonSerializerSettings();

                // setup default serializer settings
                this.SerializerSettings.Converters.Add(new IsoDateTimeConverter { Culture = new CultureInfo("en-AU") });
            }

            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var stringified = controllerContext.HttpContext.Request[bindingContext.ModelName];

                if (string.IsNullOrEmpty(stringified))
                {
                    return null;
                }

                object model = JsonConvert.DeserializeObject(stringified, bindingContext.ModelType, this.SerializerSettings);

                return model;
            }
        }
    }
}
