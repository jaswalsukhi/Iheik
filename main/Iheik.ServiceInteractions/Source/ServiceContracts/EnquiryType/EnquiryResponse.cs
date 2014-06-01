using System;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Iheik.ServiceInteractions.ServiceContracts.EnquiryType
{
    [MessageContract(IsWrapped = false)]
    public class EnquiryResponseWrapper
    {
        [MessageBodyMember(Namespace = "urn:tollgroup:162:xsd:unite:enquiry-v1.0", Order = 0)]
        public EnquiryResponse EnquiryResponse;

        public EnquiryResponseWrapper()
        {
        }

        public EnquiryResponseWrapper(EnquiryResponse enquiryResponse)
        {
            this.EnquiryResponse = enquiryResponse;
        }
    }


    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "urn:tollgroup:162:xsd:unite:enquiry-v1.0")]
    public class EnquiryResponse
    {
        [XmlElement(Order = 0)]
        public string EnquiryNumber { get; set; }

        [XmlElement(Order = 1)]
        public string Result { get; set; }

        [XmlElement(Order = 2)]
        public string Error { get; set; }

        [XmlElement(Order = 3)]
        public string ErrorDescription { get; set; }
    }
}
