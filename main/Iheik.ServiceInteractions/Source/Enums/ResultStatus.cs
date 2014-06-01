using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iheik.ServiceInteractions.Enums
{
    public enum ResultStatus : int
    {
        Error = 0,
        Success = 1,
        EmailRequired = 2,
        OutsideOperationHours = 3,
    }
}
