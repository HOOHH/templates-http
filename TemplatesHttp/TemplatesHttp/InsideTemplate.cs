using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplatesHttp.Core;

namespace TemplatesHttp
{
    public class InsideTemplate : ITemplate
    {
        public ServiceContext Context
        {
            get; private set;
        } = new ServiceContext();

        public NameValueCollection GetHeaders()
        {
            throw new NotImplementedException();
        }

        public NameValueCollection GetQuerys()
        {
            throw new NotImplementedException();
        }

        public void WriteBody(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
