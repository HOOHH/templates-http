using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatesHttp.Core;

namespace TemplatesHttp.Adapters
{
    /// <summary>
    ///Adapter squence as Queue as that could be used in a template context
    /// </summary>
    public sealed class AdapterSquence : Queue<IStreamAdapter>, IStreamAdapter
    {
        public Stream Adapt(Stream stream)
        {
            if (this.Count > 0)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    var adapter = this.Dequeue();
                    stream = adapter.Adapt(stream);
                    this.Enqueue(adapter);
                }
            }
            return stream;
        }
    }
}
