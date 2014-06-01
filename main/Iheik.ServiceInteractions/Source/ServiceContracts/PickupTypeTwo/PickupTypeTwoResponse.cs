using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Xml.Serialization;


namespace Iheik.ServiceInteractions.ServiceContracts.PickupTypeTwo
{
    [MessageContract(IsWrapped = false)]
    public class TollPriorityResponseWrapper
    {
        [MessageBodyMember(Name = "TollPickupResponse", Namespace = "http://online.toll.com.au/XMLSchema/TollPickup", Order = 0)]
        public TollPriorityPickupResponse PickupResponse;

        public TollPriorityResponseWrapper()
        {
        }

        public TollPriorityResponseWrapper(TollPriorityPickupResponse pickupResponse)
        {
            this.PickupResponse = pickupResponse;
        }
    }


    [XmlRoot("TollPickupResponse")]
    public class TollPriorityPickupResponse : PickupTypeTwoBase
    {
        // Header from base

        [XmlElement(ElementName = "PickupConfirmation", Order = 2)]
        public ResponsePickupConfirmation PickupConfirmation { get; set; }

        [XmlElement(ElementName = "Error", IsNullable = true, Order = 3)]
        public ErrorDetail Error { get; set; }
    }


    [Serializable]
    [XmlRoot("PickupConfirmation")]
    public class ResponsePickupConfirmation
    {
        [XmlElement(ElementName = "ConfirmationNumber", Order = 1)]
        public string ConfirmationNumber { get; set; }

        [XmlElement(ElementName = "ChargeAmount", Order = 2)]
        public float ChargeAmount { get; set; }

        [XmlElement(ElementName = "SecurityCheckRequired", Order = 3)]
        public bool SecurityCheckRequired { get; set; }

        [XmlElement(ElementName = "AdditionalSurchargeRequired", Order = 4)]
        public bool AdditionalSurchargeRequired { get; set; }

        [XmlElement(ElementName = "ConfirmationMessage", Order = 5)]
        public List<string> ConfirmationMessage { get; set; }
    }


    [Serializable]
    [XmlRoot("Error")]
    public class ErrorDetail
    {
        [XmlElement(ElementName = "Message", Order = 1)]
        public string Message { get; set; }
    }
}
