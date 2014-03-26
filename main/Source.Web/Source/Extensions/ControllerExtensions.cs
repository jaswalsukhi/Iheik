using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iheik.Plumbing;

namespace Iheik.Extensions
{
    /// <summary>
    /// https://json.codeplex.com/discussions/347099
    ///  protected void Application_Start()
    //{
    //    // setup ASP.Net MVC
    //    AreaRegistration.RegisterAllAreas();
    //    RegisterGlobalFilters(GlobalFilters.Filters);
    //    RegisterRoutes(RouteTable.Routes);
    //    // setup value providers
    //    ValueProviderFactories.Factories.Remove(ValueProviderFactories.Factories.OfType<JsonValueProviderFactory>().FirstOrDefault());
    //    ValueProviderFactories.Factories.Add(new JsonNetValueProviderFactory());
    //}
    //public class JsonNetValueProviderFactory : ValueProviderFactory
    //{
    //    public override IValueProvider GetValueProvider(ControllerContext controllerContext)
    //    {
    //        // first make sure we have a valid context
    //        if (controllerContext == null)
    //            throw new ArgumentNullException("controllerContext");

    //        // now make sure we are dealing with a json request
    //        if (!controllerContext.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
    //            return null;

    //        // get a generic stream reader (get reader for the http stream)
    //        StreamReader streamReader = new StreamReader(controllerContext.HttpContext.Request.InputStream);
    //        // convert stream reader to a JSON Text Reader
    //        JsonTextReader JSONReader = new JsonTextReader(streamReader);
    //        // tell JSON to read
    //        if (!JSONReader.Read())
    //            return null;

    //        // make a new Json serializer
    //        JsonSerializer JSONSerializer = new JsonSerializer();
    //        // add the dyamic object converter to our serializer
    //        JSONSerializer.Converters.Add(new ExpandoObjectConverter());

    //        // use JSON.NET to deserialize object to a dynamic (expando) object
    //        Object JSONObject;
    //        // if we start with a "[", treat this as an array
    //        if (JSONReader.TokenType == JsonToken.StartArray)
    //            JSONObject = JSONSerializer.Deserialize<List<ExpandoObject>>(JSONReader);
    //        else
    //            JSONObject = JSONSerializer.Deserialize<ExpandoObject>(JSONReader);

    //        // create a backing store to hold all properties for this deserialization
    //        Dictionary<string, object> backingStore = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    //        // add all properties to this backing store
    //        AddToBackingStore(backingStore, String.Empty, JSONObject);
    //        // return the object in a dictionary value provider so the MVC understands it
    //        return new DictionaryValueProvider<object>(backingStore, CultureInfo.CurrentCulture);
    //    }

    //    private static void AddToBackingStore(Dictionary<string, object> backingStore, string prefix, object value)
    //    {
    //        IDictionary<string, object> d = value as IDictionary<string, object>;
    //        if (d != null)
    //        {
    //            foreach (KeyValuePair<string, object> entry in d)
    //            {
    //                AddToBackingStore(backingStore, MakePropertyKey(prefix, entry.Key), entry.Value);
    //            }
    //            return;
    //        }

    //        IList l = value as IList;
    //        if (l != null)
    //        {
    //            for (int i = 0; i < l.Count; i++)
    //            {
    //                AddToBackingStore(backingStore, MakeArrayKey(prefix, i), l[i]);
    //            }
    //            return;
    //        }

    //        // primitive
    //        backingStore[prefix] = value;
    //    }

    //    private static string MakeArrayKey(string prefix, int index)
    //    {
    //        return prefix + "[" + index.ToString(CultureInfo.InvariantCulture) + "]";
    //    }

    //    private static string MakePropertyKey(string prefix, string propertyName)
    //    {
    //        return (String.IsNullOrEmpty(prefix)) ? propertyName : prefix + "." + propertyName;
    //    }
    //}
    //public class JsonNetResult : JsonResult
    //{
    //    public JsonSerializerSettings SerializerSettings { get; set; }

    //    public JsonNetResult()
    //        : base()
    //    {
    //        // create serializer settings
    //        this.SerializerSettings = new JsonSerializerSettings();
    //        // setup default serializer settings
    //        this.SerializerSettings.Converters.Add(new IsoDateTimeConverter());
    //    }

    //    public override void ExecuteResult(ControllerContext context)
    //    {
    //        // verify we have a contrex
    //        if (context == null)
    //            throw new ArgumentNullException("context");

    //        // get the current http context response
    //        var response = context.HttpContext.Response;
    //        // set content type of response
    //        response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
    //        // set content encoding of response
    //        if (ContentEncoding != null)
    //            response.ContentEncoding = this.ContentEncoding;

    //        // verify this response has data
    //        if (this.Data == null)
    //            return;

    //        // serialize the object to JSON using JSON.Net
    //        String JSONText = JsonConvert.SerializeObject(this.Data, Formatting.Indented, this.SerializerSettings);
    //        // write the response
    //        response.Write(JSONText);
    //    }
    //}
    //public static class ControllerExtensions
    //{
    //    public static JsonNetResult JsonNet(this Controller controller, object data)
    //    {
    //        return new JsonNetResult() { Data = data };
    //    }
    //}
    //public class StartController : Controller
    //{
    //    public ActionResult Index()
    //    {
    //        // setup start
    //        Start start = new Start();
    //        // return view
    //        return View(start);
    //    }

    //    [HttpPost]
    //    public ActionResult Test(Mob[] m)
    //    {
    //        return this.JsonNet(m);
    //    }
    //}
    /// </summary>
    public static class ControllerExtensions
    {
        public static JsonNetResult JsonNet(this Controller controller, object data)
        {
            return new JsonNetResult() { Data = data };
        }
    }
}