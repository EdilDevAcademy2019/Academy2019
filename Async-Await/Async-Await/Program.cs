using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Xml.Linq;

namespace Async_Await
{
    class Program
    {

        static string filename = "Data2.xml";

        static async Task Main(string[] args)
        {
            var url = "http://www.repubblica.it/rss/speciali/arte/rss2.0.xml";

            var c = new HttpClient();

            var xml = await c.GetStringAsync(url);

            var doc = XDocument.Parse(xml);

            var items = doc.Descendants("item").Take(5);

            Console.WriteLine(items.Count());

            foreach (var item in items)
            {
                Console.WriteLine(" - " + item.Element("title")?.Value);

                Console.ReadLine();
            }


           

           /* if (File.Exists(filename))
            {


                using (var reader = File.OpenText(filename))
                {
                    var fileText = await reader.ReadToEndAsync();

                    Console.WriteLine(fileText);
                }
            }*/
        }
    }
}
