using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Iheik.ServiceInteractions.ServiceContracts.PickupTypeTwo
{
    public abstract class PickupTypeTwoBase
    {
        [XmlElement(ElementName = "Header", Namespace = "", Order = 1)]
        [Required]
        public HeaderDetail HeaderDetail { get; set; }
    }

    [Serializable]
    [XmlType("Header")]
    public class HeaderDetail
    {
        [XmlElement(ElementName = "Sender", IsNullable = false, Order = 1)]
        public string Sender { get; set; }

        [XmlElement(ElementName = "Receiver", IsNullable = false, Order = 2)]
        public string Receiver { get; set; }

        [XmlElement(ElementName = "DocumentType", IsNullable = false, Order = 3)]
        public string DocumentType { get; set; }

        [XmlElement(ElementName = "DocumentID", IsNullable = false, Order = 4)]
        public string DocumentId { get; set; }

        [StringLength(24, MinimumLength = 24)]
        [XmlElement(ElementName = "DateTimeStamp", IsNullable = false, Order = 5)]
        public string DateTimeStamp { get; set; }
    }

}
