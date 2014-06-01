using System.ServiceModel;

namespace Iheik.ServiceInteractions.ServiceContracts.PickupTypeOne
{
    [MessageContract(IsWrapped = false)]
    public class PickupTypeOneRequest
    {
        [MessageBodyMember(Name = "BookingRequest", Namespace = "http://pickuprequest.tollfast.com.au", Order = 0)]
        public PickupTypeOne TollFastPickup;
    }

}
