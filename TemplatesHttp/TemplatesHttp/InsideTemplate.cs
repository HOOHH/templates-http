using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TemplatesHttp.Core;

namespace TemplatesHttp
{
    public class InsideTemplate : ITemplate
    {
        public ServiceContext Context { get; private set; } = new ServiceContext();

        public NameValueCollection GetHeaders()
        {
            NameValueCollection collection = new NameValueCollection();
            foreach (var item in Context.HeaderDictionary.RefDictionary)
            {
                collection.Set(item.Key, item.Value);
            }
            if (StaticHeader != null)
            {
                foreach (var item in this.StaticHeader)
                {
                    collection.Set(item.Key, item.Value);
                }
            }
            return collection;
        }

        public NameValueCollection GetQuerys()
        {
            NameValueCollection collection = new NameValueCollection();
            foreach (var item in Context.Query.RefDictionary)
            {
                collection.Set(item.Key, item.Value);
            }
            if (StaticQuery != null)
            {
                foreach (var item in this.StaticQuery)
                {
                    collection.Set(item.Key, item.Value);
                }
            }
            return collection;
        }

        public void WriteBody(Stream stream)
        {
            Regex regexSquence = new Regex(@"\[\$\.([\w]+)\]->\[(.*)]");

            string replacedResult = Body;
            replacedResult = regexSquence.Replace(replacedResult, (match) =>
             {
                 var groups = match.Groups;
                 var squenceKey = groups[1].Value;
                 var squenceBody = groups[2].Value;
                 StringBuilder result = new StringBuilder();
                 if (Context.BodyDictionary.RefDictionary.ContainsKey(squenceKey)
                     && Context.BodyDictionary.RefDictionary[squenceKey] is IEnumerable<string>
                 )
                 {
                     foreach (var item in Context.BodyDictionary.RefDictionary[squenceKey] as IEnumerable<string>)
                     {
                         result.Append(squenceBody.Replace("[$]", item));
                     }
                 }
                 return result.ToString();
             });
            Regex regexSingle = new Regex(@"\[\#\.(\w+)\]");
            replacedResult = regexSingle.Replace(replacedResult, (match) =>
            {
                var groups = match.Groups;
                var singleKey = groups[1].Value;
                if (Context.BodyDictionary.RefDictionary.ContainsKey(singleKey))
                {
                    return Context.BodyDictionary.RefDictionary[singleKey].ToString();
                }
                return "";
            });
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(replacedResult);
        }
        public KeyValueItem[] StaticHeader { get; set; }

        public KeyValueItem[] StaticQuery { get; set; }

        public string Body { get; set; }

        /// <summary>
        /// shallow copy 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            InsideTemplate template = new InsideTemplate();
            template.Body = Body.Clone() as string;
            if (StaticHeader != null)
                template.StaticHeader = StaticHeader.Clone() as KeyValueItem[];
            if (StaticQuery != null)
                template.StaticQuery = StaticQuery.Clone() as KeyValueItem[];
            return template;
        }

        public string[] Adapters { get; set; }
    }
}
