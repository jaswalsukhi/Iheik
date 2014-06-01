using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace Iheik.ServiceInteractions.ServiceContracts.PickupTypeOne
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "http://pickuprequest.tollfast.com.au")]
    public class PickupTypeOne
    {
        [XmlElement(ElementName = "MessageHeader", Namespace = "", Order = 1)]
        public PickypeTypeOneHeader MessageHeader { get; set; }

        [XmlElement(ElementName = "Booking", Namespace = "", Order = 2)]
        public PickypeTypeOneBookingDetail Booking { get; set; }

    }

    [Serializable]
    [XmlType]
    public class PickypeTypeOneHeader
    {
        [StringLength(25)]
        [DataMember(IsRequired = true, Name = "MessageType", Order = 1)]
        public string MessageType { get; set; }

        [StringLength(25)]
        [DataMember(IsRequired = true, Name = "SourceSystem", Order = 2)]
        public string SourceSystem { get; set; }

        [StringLength(10)]
        [DataMember(IsRequired = true, Name = "BusinessId", Order = 3)]
        public string BusinessId { get; set; }

        [StringLength(25)]
        [DataMember(IsRequired = true, Name = "BusinessName", Order = 4)]
        public string BusinessName { get; set; }
    }

    [Serializable]
    [XmlType]
    public class PickypeTypeOneBookingDetail
    {
        [StringLength(25)]
        [DataMember(IsRequired = true, Name = "AccountId", Order = 0)]
        public string AccountId { get; set; }

        [StringLength(200)]
        [DataMember(IsRequired = true, Name = "CompanyName", Order = 1)]
        public string CompanyName { get; set; }

        [StringLength(80)]
        [DataMember(IsRequired = true, Name = "CollectionAddress1", Order = 2)]
        public string CollectionAddress1 { get; set; }

        [StringLength(80)]
        [DataMember(IsRequired = false, Name = "CollectionAddress2", Order = 3)]
        public string CollectionAddress2 { get; set; }

        [StringLength(40)]
        [DataMember(IsRequired = true, Name = "CollectionSuburb", Order = 4)]
        public string CollectionSuburb { get; set; }

        [StringLength(5)]
        [DataMember(IsRequired = false, Name = "CollectionState", Order = 5)]
        public string CollectionState { get; set; }

        [StringLength(5)]
        [DataMember(IsRequired = true, Name = "CollectionPostcode", Order = 6)]
        public string CollectionPostcode { get; set; }

        [StringLength(3)]
        [DataMember(IsRequired = true, Name = "CollectionCountryCode", Order = 7)]
        public string CollectionCountryCode { get; set; }

        [StringLength(15)]
        [DataMember(IsRequired = true, Name = "CollectionContactPhone", Order = 8)]
        public string CollectionContactPhone { get; set; }

        [StringLength(100)]
        [DataMember(IsRequired = true, Name = "CollectionContactName", Order = 9)]
        public string CollectionContactName { get; set; }

        [StringLength(270)]
        [DataMember(IsRequired = false, Name = "CollectionInstructions", Order = 10)]
        public string CollectionInstructions { get; set; }

        [StringLength(15)]
        [DataMember(IsRequired = true, Name = "CallerPhone", Order = 11)]
        public string CallerPhone { get; set; }

        [StringLength(100)]
        [DataMember(IsRequired = true, Name = "CallerName", Order = 12)]
        public string CallerName { get; set; }

        [StringLength(30)]
        [DataMember(IsRequired = false, Name = "ReceiverCompanyName", Order = 13)]
        public string ReceiverCompanyName { get; set; }

        [StringLength(80)]
        [DataMember(IsRequired = false, Name = "ReceiverAddress1", Order = 14)]
        public string ReceiverAddress1 { get; set; }

        [DataMember(IsRequired = false, Name = "ReceiverAddress2", Order = 15)]
        [StringLength(80)]
        public string ReceiverAddress2 { get; set; }

        [StringLength(40)]
        [DataMember(IsRequired = false, Name = "ReceiverSuburb", Order = 30)]
        public string ReceiverSuburb { get; set; }

        [StringLength(5)]
        [DataMember(IsRequired = false, Name = "ReceiverPostcode", Order = 30)]
        public string ReceiverPostcode { get; set; }

        [StringLength(5)]
        [DataMember(IsRequired = false, Name = "ReceiverState", Order = 18)]
        public string ReceiverState { get; set; }

        [StringLength(3)]
        [DataMember(IsRequired = false, Name = "ReceiverCountryCode", Order = 19)]
        public string ReceiverCountryCode { get; set; }

        [StringLength(15)]
        [DataMember(IsRequired = false, Name = "ReceiverContactPhone", Order = 20)]
        public string ReceiverContactPhone { get; set; }

        [StringLength(100)]
        [DataMember(IsRequired = false, Name = "ReceiverContactName", Order = 21)]
        public string ReceiverContactName { get; set; }

        [StringLength(160)]
        [DataMember(IsRequired = false, Name = "DeliveryInstructions", Order = 22)]
        public string DeliveryInstructions { get; set; }

        [StringLength(25)]
        [DataMember(IsRequired = true, Name = "Product", Order = 23)]
        public string Product { get; set; }

        [StringLength(25)]
        [DataMember(IsRequired = true, Name = "Service", Order = 24)]
        public string Service { get; set; }

        [StringLength(40)]
        [DataMember(IsRequired = true, Name = "Reference1", Order = 25)]
        public string Reference1 { get; set; }

        [StringLength(40)]
        [DataMember(IsRequired = false, Name = "Reference2", Order = 26)]
        public string Reference2 { get; set; }

        [StringLength(40)]
        [DataMember(IsRequired = false, Name = "Reference3", Order = 27)]
        public string Reference3 { get; set; }

        [StringLength(10)]
        [DataMember(IsRequired = true, Name = "CollectionDate", Order = 28)]
        public string CollectionDate { get; set; }

        [StringLength(5)]
        [DataMember(IsRequired = true, Name = "ReadyTime", Order = 29)]
        public string ReadyTime { get; set; }

        [StringLength(5)]
        [DataMember(IsRequired = true, Name = "CloseTime", Order = 30)]
        public string CloseTime { get; set; }

        [DataMember(IsRequired = false, Name = "Items", Order = 31)]
        public int Items { get; set; }

        [DataMember(IsRequired = true, Name = "TotalWeight", Order = 32)]
        public float TotalWeight { get; set; }

        [DataMember(IsRequired = true, Name = "DimensionHeight", Order = 33)]
        public int DimensionHeight { get; set; }

        [DataMember(IsRequired = true, Name = "DimensionWidth", Order = 34)]
        public int DimensionWidth { get; set; }

        [DataMember(IsRequired = true, Name = "DimensionLength", Order = 35)]
        public int DimensionLength { get; set; }

        [StringLength(25)]
        [DataMember(IsRequired = false, Name = "DangerousGoodsDescription", Order = 36)]
        public string DangerousGoodsDescription { get; set; }

        [StringLength(25)]
        [DataMember(IsRequired = false, Name = "Connote", Order = 37)]
        public string Connote { get; set; }

        [StringLength(10)]
        [DataMember(IsRequired = true, Name = "CreatedDate", Order = 38)]
        public string CreatedDate { get; set; }

        [StringLength(5)]
        [DataMember(IsRequired = true, Name = "CreatedTime", Order = 39)]
        public string CreatedTime { get; set; }

    }

}
