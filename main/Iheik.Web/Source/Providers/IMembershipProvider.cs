using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iheik.Providers
{
    public interface IMembershipProvider
    {
        Guid ProviderUserKey { get; }
        string UserName { get; }
    }
}