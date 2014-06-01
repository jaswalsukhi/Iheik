using System.ServiceModel;

namespace Iheik.ServiceInteractions.ServiceContracts.EnquiryType
{
    [ServiceContract(Namespace = "urn:tollgroup:service:Enquiry_162_BPEL", ConfigurationName = "EnquiryWebService.Enquiry_162_BPEL")]
    public interface IEnquiry
    {
        [OperationContract(Action = "Enquiry", ReplyAction = "*")]
        [XmlSerializerFormat(SupportFaults = true)]
        EnquiryResponseWrapper Enquiry(EnquiryRequest request);
    }

}
