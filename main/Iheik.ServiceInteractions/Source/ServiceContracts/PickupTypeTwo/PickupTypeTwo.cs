using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;


namespace Iheik.ServiceInteractions.ServiceContracts.PickupTypeTwo
{
    [Serializable]
    [XmlRoot(IsNullable = false, ElementName = "TollPickupRequest")]
    public class PickupTypeTwo : PickupTypeTwoBase
    {
        // Header from base

        [XmlElement("PickupRequest", Order = 2)]
        [Required]
        public PickupRequestDetail PickupRequest { get; set; }
    }

    [Serializable]
    [XmlRoot("PickupRequest")]
    public class PickupRequestDetail
    {
        [XmlElement("CarrierID")]
        [StringLength(5, MinimumLength = 2)]
        [Required]
        public string CarrierId { get; set; }

        [XmlElement("ConfirmationDetail")]
        public PickupConfirmation ConfirmationDetail { get; set; }

        [XmlElement("AccountDetail")]
        [Required]
        public AccountDetail AccountDetail { get; set; }

        [XmlElement("InitiatorDetail")]
        [Required]
        public InitiatorDetail InitiatorDetail { get; set; }

        [XmlElement("SenderDetail")]
        [Required]
        public SenderDetail SenderDetail { get; set; }

        [XmlElement("PickupDetail")]
        [Required]
        public PickupDetail PickupDetail { get; set; }

        [XmlElement("Items")]
        public List<PickupItem> PickupItems { get; set; }

    }


    [Serializable]
    [XmlRoot("ConfirmationDetail")]
    public class PickupConfirmation
    {
        [XmlElement("DeclarationAccepted")]
        public bool DeclarationAccepted { get; set; }

        [XmlElement("ConfirmationNumber")]
        public string ConfirmationNumber { get; set; }

        [XmlElement("ChargeAmount")]
        public float ChargeAmount { get; set; }
    }


    [Serializable]
    [XmlRoot("AccountDetail")]
    public class AccountDetail
    {
        [XmlElement("AccountCode")]
        [StringLength(10, MinimumLength = 2)]
        [Required]
        public string AccountCode { get; set; }

        [XmlElement("SubAccountID")]
        [StringLength(50)]
        public string SubAccountId { get; set; }
    }

    [Serializable]
    [XmlRoot("InitiatorDetail")]
    public class InitiatorDetail
    {
        [XmlElement("CompanyName")]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [XmlElement("ContactName")]
        [Required]
        [StringLength(40)]
        public string ContactName { get; set; }

        [XmlElement("ContactAreaCode")]
        [Required]
        [StringLength(5)]
        public string ContactAreaCode { get; set; }

        [XmlElement("ContactPhoneNumber")]
        [Required]
        [StringLength(15)]
        public string ContactPhoneNumber { get; set; }

        [XmlElement("ContactEmail")]
        [StringLength(50)]
        public string ContactEmail { get; set; }
    }


    [Serializable]
    [XmlRoot("SenderDetail")]
    public class SenderDetail
    {
        [XmlElement("CompanyName")]
        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [XmlElement("AddressLine1")]
        [Required]
        [StringLength(80)]
        public string AddressLine1 { get; set; }

        [XmlElement("AddressLine2")]
        [StringLength(80)]
        public string AddressLine2 { get; set; }

        [XmlElement("Suburb")]
        [Required]
        [StringLength(40)]
        public string Suburb { get; set; }

        [XmlElement("State")]
        [StringLength(5)]
        public string State { get; set; }

        [XmlElement("Postcode")]
        [Required]
        [StringLength(5)]
        public string Postcode { get; set; }

        [XmlElement("Country")]
        [Required]
        [StringLength(3)]
        public string Country { get; set; }

        [XmlElement("ContactName")]
        [Required]
        [StringLength(40)]
        public string ContactName { get; set; }

        [XmlElement("ContactAreaCode")]
        [Required]
        [StringLength(5)]
        public string ContactAreaCode { get; set; }

        [XmlElement("ContactPhoneNumber")]
        [Required]
        [StringLength(15)]
        public string ContactPhoneNumber { get; set; }

        [XmlElement("ContactEmail")]
        [StringLength(50)]
        public string ContactEmail { get; set; }

        [XmlElement("SpecialInstructions")]
        [StringLength(160)]
        public string SpecialInstructions { get; set; }
    }


    [Serializable]
    [XmlRoot("PickupDetail")]
    public class PickupDetail
    {
        [XmlElement("Reference")]
        public PickupDetailReference Reference { get; set; }

        [XmlElement("PickupDateTime")]
        [Required]
        [StringLength(24, MinimumLength = 24)]
        public string PickupDateTime { get; set; }

        [XmlElement("OpenTime")]
        public string OpenTime { get; set; }

        [XmlElement("CloseTime")]
        public string CloseTime { get; set; }

        [XmlElement("RegularPickup")]
        public bool RegularPickup { get; set; }

        [XmlElement("BringConNote")]
        public bool BringConNote { get; set; }

        [XmlElement("SameLocation")]
        public bool SameLocation { get; set; }

        [XmlElement("PickupFromLocation")]
        [StringLength(25)]
        public string PickupFromLocation { get; set; }

        [XmlElement("ReturnJob")]
        public bool ReturnJob { get; set; }
    }


    [Serializable]
    [XmlRoot("Reference")]
    public class PickupDetailReference
    {
        [XmlElement("Reference1")]
        [Required]
        [StringLength(40)]
        public string Reference1 { get; set; }

        [XmlElement("Reference2")]
        [StringLength(40)]
        public string Reference2 { get; set; }
    }


    [Serializable]
    [XmlRoot("Items")]
    public class PickupItem
    {
        [XmlElement("Description")]
        [StringLength(80)]
        public string Description { get; set; }

        [XmlElement(ElementName = "NumberItems")]
        [Required]
        public int NumberItems { get; set; }

        [XmlElement(DataType = "integer", ElementName = "NumberPalletSpaces")]
        public string NumberPalletSpaces { get; set; }

        [XmlElement("Weight")]
        [Required]
        public float Weight { get; set; }

        [XmlElement(DataType = "integer", ElementName = "Length")]
        public string Length { get; set; }

        [XmlElement(DataType = "integer", ElementName = "Width")]
        public string Width { get; set; }

        [XmlElement(DataType = "integer", ElementName = "Height")]
        public string Height { get; set; }

        [XmlElement("Destination")]
        [StringLength(10)]
        public string Destination { get; set; }

        [XmlElement("DangerousGoods")]
        public bool DangerousGoods { get; set; }

        [XmlElement("DangerousGoodsUNCode")]
        [StringLength(10)]
        public string DangerousGoodsUNCode { get; set; }

        [XmlElement("Payer")]
        [StringLength(1)]
        public string Payer { get; set; }

        [XmlElement("PayerAccountCode")]
        [StringLength(10)]
        public string PayerAccountCode { get; set; }

        [XmlElement("ServiceID")]
        [Required]
        [StringLength(15)]
        public string ServiceId { get; set; }

        [XmlElement("ServiceName")]
        [StringLength(30)]
        public string ServiceName { get; set; }

        [XmlElement("ProductID")]
        [StringLength(15)]
        public string ProductId { get; set; }

        [XmlElement("ProductName")]
        [StringLength(30)]
        public string ProductName { get; set; }

        [XmlElement("Temperature")]
        [StringLength(4)]
        public string Temperature { get; set; }

        [XmlElement("Food")]
        public bool Food { get; set; }

        [XmlIgnore]
        public bool FoodSpecified { get; set; }

        [XmlElement(DataType = "integer", ElementName = "EstimatedCartons")]
        public string EstimatedCartons { get; set; }

        [XmlElement(DataType = "integer", ElementName = "EstimatedBags")]
        public string EstimatedBags { get; set; }

        [XmlElement(DataType = "integer", ElementName = "EstimatedOther")]
        public string EstimatedOther { get; set; }

        [XmlElement("LargestItemType")]
        [StringLength(10)]
        public string LargestItemType { get; set; }

        [XmlElement("ReceiverDetail")]
        public ReceiverDetail ReceiverDetail { get; set; }
    }


    [Serializable]
    public class ReceiverDetail
    {
        [XmlElement("CompanyName")]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [XmlElement("AddressLine1")]
        [StringLength(80)]
        public string AddressLine1 { get; set; }

        [XmlElement("AddressLine2")]
        [StringLength(80)]
        public string AddressLine2 { get; set; }

        [XmlElement("Suburb")]
        [StringLength(40)]
        public string Suburb { get; set; }

        [XmlElement("State")]
        [StringLength(5)]
        public string State { get; set; }

        [XmlElement("Postcode")]
        [StringLength(6)]
        public string Postcode { get; set; }

        [XmlElement("Country")]
        [StringLength(3)]
        public string Country { get; set; }

        [XmlElement("ContactName")]
        [StringLength(40)]
        public string ContactName { get; set; }

        [XmlElement("ContactAreaCode")]
        [StringLength(5)]
        public string ContactAreaCode { get; set; }

        [XmlElement("ContactPhoneNumber")]
        [StringLength(15)]
        public string ContactPhoneNumber { get; set; }

        [XmlElement("ContactEmail")]
        [StringLength(50)]
        public string ContactEmail { get; set; }

        [XmlElement("SpecialInstructions")]
        [StringLength(160)]
        public string SpecialInstructions { get; set; }
    }


}
