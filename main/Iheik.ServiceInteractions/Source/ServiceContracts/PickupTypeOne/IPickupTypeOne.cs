using System.ServiceModel;

namespace Iheik.ServiceInteractions.ServiceContracts.PickupTypeOne
{
    [ServiceContract(Namespace = "http://pickuprequest.tollfast.com.au")]
    public interface IPickupTypeOne
    {
        [OperationContract(Name = "BookingRequest", Action = "http://pickuprequest.tollfast.com.au/PickupRequest")]
        [XmlSerializerFormat(SupportFaults = true)]
        PickupTypeOneResponseWrapper BookPickup(PickupTypeOneRequest request);
    }
}
