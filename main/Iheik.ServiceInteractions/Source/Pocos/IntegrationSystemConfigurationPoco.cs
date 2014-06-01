using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iheik.ServiceInteractions.Pocos
{
    public class IntegrationSystemConfigurationPoco
    {
        public int ConfigId { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public string ConfigGroup { get; set; }
        public string ConfigNotes { get; set; }
        public int Seq { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
