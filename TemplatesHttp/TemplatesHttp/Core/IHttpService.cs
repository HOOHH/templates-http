using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatesHttp.Core
{
    /// <summary>
    /// An interface finget that it can access the real or mock up http service
    /// </summary>
    public interface IHttpService
    {
        string QueryString(ITemplate template);

        Stream QueryStream(ITemplate template);
    }
}
