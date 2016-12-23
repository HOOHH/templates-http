using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatesHttp.Core;

namespace TemplatesHttp.Adapters
{
    public sealed class AdapterFactory
    {

        private static AdapterFactory _instance;
        public static AdapterFactory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AdapterFactory();
                return _instance;
            }
        }

        public IStreamAdapter GetAdapter(string name)
        {
            if (ServiceCore.AdapterStore.ContainsKey(name))
            {
                return ServiceCore.AdapterStore[name];
            }
            ServiceCore.ModuleLogger.Warn("Can not find the adapter:" + name);
            return new AdapterSquence();
        }

        public IStreamAdapter GetAdapters(string[] names)
        {
            AdapterSquence squence = new AdapterSquence();
            for (int i = 0; names == null || i < names.Length; i++)
            {
                squence.Enqueue(GetAdapter(names[i]));
            }
            return squence;
        }

        private AdapterFactory()
        {
            ServiceCore.RegistStreamAdapter("normal", new NormalAdapter());
            ServiceCore.RegistStreamAdapter("gzip", new GzipAdapter());
            ServiceCore.RegistStreamAdapter("deflate", new DeflateAdapter());
        }
    }
}
