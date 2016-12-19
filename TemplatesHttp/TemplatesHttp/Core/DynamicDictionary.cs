using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatesHttp.Core
{
    public class DynamicDictionary : DynamicObject
    {
        internal Dictionary<string, string> RefDictionary { get; set; } = new Dictionary<string, string>();

        public DynamicDictionary()
        {

        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (RefDictionary.ContainsKey(binder.Name))
            {
                result = RefDictionary[binder.Name];
                return true;
            }
            return false;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (value is string)
            {
                RefDictionary[binder.Name] = value.ToString();
                return true;
            }
            return false;
        }
    }
}
