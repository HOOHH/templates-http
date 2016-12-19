using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatesHttp.Core
{
    public class ServiceContext
    {
        public DynamicDictionary<string> HeaderDictionary { get; set; } = new DynamicDictionary<string>();
        public DynamicDictionary<object> BodyDictionary { get; set; } = new DynamicDictionary<object>();
        public DynamicDictionary<string> QueryDictionary { get; set; } = new DynamicDictionary<string>();

        public dynamic Header
        {
            get { return HeaderDictionary; }
        }

        public dynamic Query
        {
            get { return QueryDictionary; }
        }

        public dynamic Body
        {
            get { return BodyDictionary; }
        }
    }
}


