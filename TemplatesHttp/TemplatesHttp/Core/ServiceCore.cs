using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace TemplatesHttp.Core
{
    public class ServiceCore
    {
        internal static ILog ModuleLogger { get; private set; }

        internal static Dictionary<string, IStreamAdapter> AdapterStore { get; set; }
            = new Dictionary<string, IStreamAdapter>();

        internal static Dictionary<string, ITemplate> TemplateStore { get; set; }
            = new Dictionary<string, ITemplate>();

        internal static IAccessor ImplAccessor { get; set; }

        public static IHttpService GetService(string svrname)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// If you call this function the Accessor will be replace.
        /// </summary>
        /// <param name="accessor"></param>
        public static void RegistAccessor(IAccessor accessor)
        {
            ImplAccessor = accessor;
        }


        public static void RegistStreamAdapter(string adapterName, IStreamAdapter adapter)
        {
            ModuleLogger.Debug("Adapter Registed :" + adapterName);
            if (string.IsNullOrEmpty(adapterName))
                throw new ArgumentNullException("adapterName", "arg could be null");
            AdapterStore[adapterName] = adapter;
        }

        public static void RegistTemplate(string templateName, ITemplate template)
        {
            ModuleLogger.Debug("Templte Registed :" + templateName);
            if (string.IsNullOrEmpty(templateName))
                throw new ArgumentNullException("templateName", "arg could be null");
            TemplateStore[templateName] = template;
        }

        static ServiceCore()
        {
            XmlConfigurator.Configure();
            ModuleLogger = LogManager.GetLogger(typeof(ServiceCore));
            ModuleLogger.Info("Logger On Line");
        }

    }
}
