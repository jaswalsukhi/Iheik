using System;
using System.Xml.Serialization;
namespace Iheik.ServiceInteractions.ServiceContracts.EnquiryType
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "urn:tollgroup:162:xsd:unite:enquiry-v1.0")]
    public class Enquiry
    {
        [XmlElement(Order = 0)]
        public string EnquiryType { get; set; }

        [XmlElement(Order = 1)]
        public string ProductService { get; set; }

        [XmlElement(Order = 2)]
        public string EnquiryAbout { get; set; }

        [XmlElement(Order = 3)]
        public string BookingId { get; set; }

        [XmlElement(Order = 4)]
        public string Connote { get; set; }

        [XmlElement(Order = 5)]
        public string CollectionDate { get; set; }

        [XmlElement(Order = 6)]
        public string TATLNumber { get; set; }

        [XmlElement(Order = 7)]
        public string EnquiryNumber { get; set; }

        [XmlElement(Order = 8)]
        public string CustomerReference1 { get; set; }

        [XmlElement(Order = 9)]
        public string CustomerReference2 { get; set; }

        [XmlElement(Order = 10)]
        public string EnquiryMessage { get; set; }

        [XmlElement(Order = 11)]
        public string ExistingCustomer { get; set; }

        [XmlElement(Order = 12)]
        public string AccountId { get; set; }

        [XmlElement(Order = 13)]
        public string CompanyName { get; set; }

        [XmlElement(Order = 14)]
        public string ContactFirstName { get; set; }

        [XmlElement(Order = 15)]
        public string ContactLastName { get; set; }

        [XmlElement(Order = 16)]
        public string ContactNumber { get; set; }

        [XmlElement(Order = 17)]
        public string ContactEmailAddress { get; set; }

        [XmlElement(Order = 18)]
        public string Country { get; set; }

        [XmlElement(Order = 19)]
        public string State { get; set; }

        [XmlElement(Order = 20)]
        public string TownCity { get; set; }

        [XmlElement(Order = 21)]
        public string LocalityProvince { get; set; }

        [XmlElement(Order = 22)]
        public string Locality { get; set; }

        [XmlElement(Order = 23)]
        public string ROWCountry { get; set; }
    }
}
