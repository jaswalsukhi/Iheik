using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Iheik.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RequireOneOfAttribute : ValidationAttribute
    {
        private string Property1 { get; set; }
        private string Property2 { get; set; }
        private string Property3 { get; set; }

        public RequireOneOfAttribute(string propertyName1, string propertyName2, string propertyName3)
        {
            Property1 = propertyName1;
            Property2 = propertyName2;
            Property3 = propertyName3;
        }

        public override Boolean IsValid(Object value)
        {
            if (Property1 == null && Property2 == null && Property3 == null)
            {
                return false;
            }
            else
            {
                // get the properties form the class the attribute has been assigned to
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);

                // get the value from each of the properties passed in for validation
                object property1Value = properties.Find(Property1, true).GetValue(value);
                object property2Value = properties.Find(Property2, true).GetValue(value);
                object property3Value = properties.Find(Property3, true).GetValue(value);

                // may sure at least one of the properties has a value
                if (property1Value != null || property2Value != null || property3Value != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }



}