using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iheik.Domain.Pocos
{
    public class UserEntityPoco
    {
        public int UserCustomerEntityId { get; set; }
        public int CustomerUsersId { get; set; }
        public int CustomerEntityId { get; set; }
        public string CustomerEntityCode { get; set; }
        public string CustomerEntityName { get; set; }
        public bool ReadOnly { get; set; }
    }
}
