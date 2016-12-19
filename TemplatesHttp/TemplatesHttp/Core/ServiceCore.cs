using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatesHttp.Core
{
    public class ServiceCore
    {
        public static IHttpService GetService(string svrname)
        {
            throw new NotImplementedException();
        }

        public static void RegistAccessor(IAccessor accessor)
        {

        }

        public static void RegistStreamAdapter(string adapterName, IStreamAdapter adapter)
        {

        }

        public static void RegistTemplate(string templateName, ITemplate template)
        {

        }
    }
}
