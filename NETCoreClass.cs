using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NetCoreProject
{
    public class News
    {
        public string title { get; set; }
        public string description { get; set; }
        public string guid { get; set; }
        public string link { get; set; }
        public string ID { get; set; }
        public string date { get; set; }
    }

    public class asyncMethod
    {
        public static async Task<IEnumerable<News>> GetTypeAsync<T>(string url)
        {
            var c = new HttpClient();
            var xml = await c.GetStringAsync(url);
            var doc = XDocument.Parse(xml);
            var items = doc.Descendants("item").Take(5).Select(x => new News
            {
                title = x.Element("title")?.Value ?? "error title",
                description = x.Element("description")?.Value ?? "error description",
                guid = x.Element("guid")?.Value ?? "error guid",
                link = x.Element("link")?.Value ?? "error link",
                date = x.Element("pubDate")?.Value ?? "error date",
            });



            return items;
        }
    }
}
