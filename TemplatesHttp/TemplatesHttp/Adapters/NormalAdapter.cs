using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatesHttp.Attributes;
using TemplatesHttp.Core;

namespace TemplatesHttp.Adapters
{
    [Adapter("normal")]
    public class NormalAdapter : IStreamAdapter
    {
        public Stream Adapt(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
