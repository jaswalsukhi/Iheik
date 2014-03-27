using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iheik.Attributes
{
    //this attribute does not seem toi work 
    //can be used like         
    //[PlaceHolder("Address, Company or Contact")]
    //public string OtherSearch { get; set; }
    public class PlaceHolderAttribute : Attribute, IMetadataAware
    {
        private readonly string _placeholder;

        public PlaceHolderAttribute(string placeholder)
        {
            _placeholder = placeholder;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["placeholder"] = _placeholder;
        }
    }

}