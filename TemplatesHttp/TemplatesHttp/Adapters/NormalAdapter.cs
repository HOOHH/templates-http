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
            MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[1024];
            int writeCount = 0;
            while ((writeCount = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, writeCount);
            }
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
    }
}
