using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatesHttp.Attributes;
using TemplatesHttp.Core;

namespace TemplatesHttp.Adapters
{

    [Adapter("gzip")]
    public class GzipAdapter : IStreamAdapter
    {
        public Stream Adapt(Stream stream)
        {
            Stream target = new GZipStream(stream, CompressionMode.Decompress);
            return target;
        }
    }
}
