using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iheik.ServiceInteractions.ServiceContracts.EnquiryType;

namespace Iheik.ServiceInteractions.Proxies
{
    public class EnquiryProxy: ServiceProxyBase<IEnquiry>
    {
        public EnquiryProxy(string serviceEndPointUri, int timeoutInSeconds)
            : base(serviceEndPointUri, timeoutInSeconds)
        {
        }

        public EnquiryResponse Enquiry(EnquiryRequest request)
        {
            EnquiryResponse response = Channel.Enquiry(request).EnquiryResponse;

            return response;
        }

    }
}
