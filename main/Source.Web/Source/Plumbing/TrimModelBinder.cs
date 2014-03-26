using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iheik.Plumbing
{
    /// <summary>
    /// Model binder will trim the string values entered by user
    /// http://stackoverflow.com/questions/1718501/asp-net-mvc-best-way-to-trim-strings-after-data-entry-should-i-create-a-custo
    /// </summary>
    /// <remarks>Implements the default binder from the MVC stack.</remarks>
    /// This is a generic way to trim all string fields while being binded with model
    /// to user this we have to add following line in application_Start of Global.asax
    /// ModelBinders.Binders.DefaultBinder = new TrimModelBinder();
    /// This will change the default binding behaviour
    public class TrimModelBinder : DefaultModelBinder
    {
        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor, object value)
        {
            // check property is a string
            if (propertyDescriptor.PropertyType == typeof(string))
            {
                // Converting object to string for checking
                string stringValue = Convert.ToString(value);

                // check for something to trim
                if (!string.IsNullOrEmpty(stringValue))
                {
                    stringValue = stringValue.Trim();
                }

                value = stringValue;
            }

            // have the default implementation set the value of the property
            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
        }
    }

}