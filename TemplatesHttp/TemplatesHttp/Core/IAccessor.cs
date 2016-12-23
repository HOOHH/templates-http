using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatesHttp.Core
{
    /// <summary>
    /// Accessor is using for query remote service, also something other stream.
    /// </summary>
    public interface IAccessor
    {
        Stream QueryFromService(ITemplate tempate, string host);
    }
}
