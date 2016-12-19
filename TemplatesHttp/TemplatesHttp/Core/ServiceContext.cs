using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatesHttp.Core
{
    public class ServiceContext
    {
        public DynamicDictionary HeaderDictionary { get; set; } = new DynamicDictionary();
        public DynamicDictionary BodyDictionary { get; set; } = new DynamicDictionary();
        public DynamicDictionary QueryDictionary { get; set; } = new DynamicDictionary();

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


