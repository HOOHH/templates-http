using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatesHttp.Core
{
    /// <summary>
    /// If you wanted using the NetworkStream Please do not attach any adapter.
    /// </summary>
    public interface IHttpService
    {
        string QueryString(ITemplate template);

        Stream QueryStream(ITemplate template);
    }
}
