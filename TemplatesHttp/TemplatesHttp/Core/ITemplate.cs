using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatesHttp.Core
{
    public interface ITemplate : ICloneable
    {
        NameValueCollection GetHeaders();
        NameValueCollection GetQuerys();
        void WriteBody(Stream stream);
        ServiceContext Context { get; }
        string[] Adapters { get; }
    }
}
