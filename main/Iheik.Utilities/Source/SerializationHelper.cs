using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Iheik.Utilities
{
    public static class SerializationHelper
    {

        /// <summary>
        /// Converts a specified XML fragment to Object of Type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlFragment">The XML fragment.</param>
        /// <returns>Object of Type T.</returns>
        public static T To<T>(this string xmlFragment)
        {
            return (T)To(xmlFragment, typeof(T));
        }

        /// <summary>
        /// To the specified XML fragment.
        /// </summary>
        /// <param name="xmlFragment">The XML fragment.</param>
        /// <param name="type">The type.</param>
        /// <returns>Object - of Type passed in.</returns>
        public static object To(this string xmlFragment, Type type)
        {
            object returnObject = null;

            if (String.IsNullOrWhiteSpace(xmlFragment))
            {
                return null;
            }

            // read the xml string into the object 
            using (var reader = new StringReader(xmlFragment))
            {
                var serializer = new XmlSerializer(type);

                // convert string into class message structure
                returnObject = serializer.Deserialize(reader);
            }

            return returnObject;
        }

        /// <summary>
        /// Converts class message structure to XML.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns>String - xml coded message.</returns>
        public static string ConvertToXml<TMessage>(TMessage instance)
        {
            string returnString;

            var serializer = new XmlSerializer(instance.GetType());

            using (var stream = new MemoryStream())
            {
                using (TextWriter textWriter = new StreamWriter(stream))
                {
                    serializer.Serialize(textWriter, instance);
                    returnString = Encoding.UTF8.GetString(stream.ToArray());
                }
            }

            return returnString;
        }


    }
}
