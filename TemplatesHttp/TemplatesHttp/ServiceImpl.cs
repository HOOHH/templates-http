using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatesHttp.Adapters;
using TemplatesHttp.Core;

namespace TemplatesHttp
{
    public class ServiceImpl : IHttpService
    {
        private IAccessor m_accessor;
        private string m_host;
        public ServiceImpl(IAccessor accessor, string host)
        {
            m_accessor = accessor;
            m_host = host;
        }

        public Stream QueryStream(ITemplate template)
        {
            Stream result = m_accessor.QueryFromService(template, m_host);
            return AdapterFactory.Instance.GetAdapters(template.Adapters).Adapt(result);
        }

        public string QueryString(ITemplate template)
        {
            using (StreamReader reader = new StreamReader(QueryStream(template)))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
