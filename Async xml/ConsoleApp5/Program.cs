using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp5
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://andreagaleazzi.com/feed/";

            var c = new HttpClient();
            var xml = await c.GetStringAsync(url);
            var artc = new List<Article>(); 
            var doc = XDocument.Parse(xml);

            Console.WriteLine("Quanti articoli vuoi visualizzare?");
            int choice = Convert.ToInt32(Console.ReadLine());

            var items = doc.Descendants("item").Take(choice);




            Print(items, artc);






            Console.Clear();
            Console.WriteLine("Articoli terminati.");
        }

        public static void Print (IEnumerable<XElement> items, List<Article> artc)
        {
           
            foreach (var item in items)
            {
                Console.Clear();
    
                Console.WriteLine("Site : " + item.Element("guid")?.Value + "\n");
                Console.WriteLine("-" + item.Element("title")?.Value + "-" + item.Element("author")?.Value);
                Console.WriteLine("\n" + item.Element("description")?.Value);


                Console.Write("\nVuoi salvare l'articolo? y/n -> ");
                string choice_2 = Console.ReadLine();

                if (choice_2 == "y")
                {
                
                    artc.Add(new Article
                    {
                        site = item.Element("guid")?.Value,
                        title = item.Element("title")?.Value,
                        author =item.Element("author")?.Value,
                        description = item.Element("description")?.Value,

                    });
                }
                
                foreach(var c in artc)
                {
                    Console.Clear();
                    Console.WriteLine("Ecco l'articolo salvato!\n");
                    Console.WriteLine("Sito ->  " + c.site + "\nTitolo -> " + c.title + "\nAutore ->  " + c.author + "\nDescrizione :\n" + c.description);

                }
                Console.ReadLine();
            }
        }

        

    }
}
