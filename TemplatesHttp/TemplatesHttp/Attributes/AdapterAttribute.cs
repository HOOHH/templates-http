using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatesHttp.Attributes
{
    public class AdapterAttribute : Attribute
    {
        public string AdapterName { get; set; }
        public AdapterAttribute(string adapterName)
        {
            AdapterName = adapterName;
        }
    }
}
