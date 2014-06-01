using System.ServiceModel;
namespace Iheik.ServiceInteractions.ServiceContracts.PickupTypeTwo
{
    [MessageContract(IsWrapped = false)]
    public class TollPriorityPickupRequest
    {
        [MessageBodyMember(Name = "TollPickupRequest", Namespace = "http://online.toll.com.au/XMLSchema", Order = 0)]
        public PickupTypeTwo PickupTypeTwo;
    }

}
