using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TemplatesHttp
{
    [XmlRoot("Item")]
    public class KeyValueItem
    {
        [XmlAttribute("Key")]
        public string Key { get; set; }

        [XmlAttribute("Value")]
        public string Value { get; set; }
    }
}
