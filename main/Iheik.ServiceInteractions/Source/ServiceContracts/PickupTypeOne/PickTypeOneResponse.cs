using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;


namespace Iheik.ServiceInteractions.ServiceContracts.PickupTypeOne
{
    [MessageContract(IsWrapped = false)]
    public class PickupTypeOneResponseWrapper
    {
        [MessageBodyMember(Name = "BookingResponse", Namespace = "http://pickuprequest.tollfast.com.au", Order = 0)]
        public PickupTypeOneResponse PickupResponse;

        public PickupTypeOneResponseWrapper()
        {
        }

        public PickupTypeOneResponseWrapper(PickupTypeOneResponse pickupResponse)
        {
            this.PickupResponse = pickupResponse;
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = "")]
    public class PickupTypeOneResponse
    {
        [StringLength(25)]
        [DataMember(IsRequired = true, Name = "MessageType", Order = 0)]
        public string MessageType { get; set; }

        [StringLength(20)]
        [DataMember(IsRequired = true, Name = "DocumentId", Order = 1)]
        public string DocumentId { get; set; }

        [StringLength(10)]
        [DataMember(IsRequired = true, Name = "ResultCode", Order = 2)]
        public string ResultCode { get; set; }

        [StringLength(25)]
        [DataMember(IsRequired = true, Name = "BookingId", Order = 3)]
        public string BookingId { get; set; }

        [StringLength(50)]
        [DataMember(IsRequired = true, Name = "SecurityCheckRequired", Order = 4)]
        public string SecurityCheckRequired { get; set; }

        [StringLength(25)]
        [DataMember(IsRequired = false, Name = "ErrorNumber", Order = 5)]
        public string ErrorNumber { get; set; }

        [StringLength(100)]
        [DataMember(IsRequired = false, Name = "ErrorDescription", Order = 6)]
        public string ErrorDescription { get; set; }

        [StringLength(100)]
        [DataMember(IsRequired = false, Name = "Parameter", Order = 7)]
        public string Parameter { get; set; }
    }


}
