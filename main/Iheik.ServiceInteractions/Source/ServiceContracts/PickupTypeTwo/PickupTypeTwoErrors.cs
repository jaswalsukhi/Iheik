using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Iheik.ServiceInteractions.ServiceContracts.PickupTypeTwo
{
    [Serializable]
    [XmlRoot("errors")]
    public class PickupTypeTwoErrors
    {
        [XmlElement("error")]
        public List<string> Error { get; set; }
    }
}
