using System;
using System.Web.Security;

namespace Iheik.Providers
{
    public class MembershipProvider : IMembershipProvider
    {
        public Guid ProviderUserKey
        {
            get
            {
                return (Guid)Membership.GetUser().ProviderUserKey;
            }
        }

        public string UserName
        {
            get
            {
                return Membership.GetUser().UserName;
            }
        }

    }
}