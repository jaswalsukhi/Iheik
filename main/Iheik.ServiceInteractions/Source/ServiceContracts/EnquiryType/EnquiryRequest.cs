using System.ServiceModel;


namespace Iheik.ServiceInteractions.ServiceContracts.EnquiryType
{
    [MessageContract(IsWrapped = false)]
    public class EnquiryRequest
    {
        [MessageBodyMember(Namespace = "urn:tollgroup:162:xsd:unite:enquiry-v1.0", Order = 0)]
        public Enquiry Enquiry;

        public EnquiryRequest()
        {
        }

        public EnquiryRequest(Enquiry enquiry)
        {
            this.Enquiry = enquiry;
        }
    }

}
