using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ansa
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            bool flag = false;
            int n_pre = 0;
            var news = new List<News>();
            var preferiti = new List<News>();
            n_pre= load_preferiti(preferiti);
            

            var url = ""; ;
            bool flag2 = false;
            bool invio = false;
            int s = 1;
            do
            {

                invio = false;
                Console.Clear();
                Console.WriteLine("Scegli categoria:\n-------------------------");
                if (s == 1) { Console.ForegroundColor = ConsoleColor.Yellow; Console.BackgroundColor = ConsoleColor.Blue; } Console.WriteLine("\t1-Cronaca");  Console.ResetColor();
                if (s == 2) { Console.ForegroundColor = ConsoleColor.Yellow; Console.BackgroundColor = ConsoleColor.Blue; } Console.WriteLine("\t2-Calcio");  Console.ResetColor();
                if (s == 3) { Console.ForegroundColor = ConsoleColor.Yellow; Console.BackgroundColor = ConsoleColor.Blue; } Console.WriteLine("\t3-Cinema");  Console.ResetColor();
                if (s == 4) { Console.ForegroundColor = ConsoleColor.Yellow; Console.BackgroundColor = ConsoleColor.Blue; } Console.WriteLine("\t4-Tecnologia"); Console.ResetColor();
                if (s == 5) {Console.ForegroundColor = ConsoleColor.Yellow; Console.BackgroundColor = ConsoleColor.Blue; }  Console.WriteLine("\t5-Cultura"); Console.ResetColor();
                if (s == 6) { Console.ForegroundColor = ConsoleColor.Yellow; Console.BackgroundColor = ConsoleColor.Blue; } Console.WriteLine("\t6-Ultima ora"); Console.ResetColor();
                if (s == 7) { Console.ForegroundColor = ConsoleColor.Yellow; Console.BackgroundColor = ConsoleColor.Blue; } Console.WriteLine("\t7-Preferiti"); Console.ResetColor();
                if (s == 8) { Console.ForegroundColor = ConsoleColor.Yellow; Console.BackgroundColor = ConsoleColor.Blue; } Console.Write("\t8- Exit"); Console.ResetColor();
                Console.WriteLine(":\n-------------------------\n");

                var tasti = Console.ReadKey().Key;
                if ( tasti == ConsoleKey.DownArrow && s < 9) { s++; }
                else if (tasti == ConsoleKey.UpArrow && s >=1) { s--;  }
                else if (tasti == ConsoleKey.Enter) { invio = true; }
                

                if (invio == true) {

                   
                    switch (s)
                    {
                        case 1:

                            url = "https://www.ansa.it/sito/notizie/cronaca/cronaca_rss.xml"; flag2 = true;
                            break;

                        case 2:

                            url = "https://www.ansa.it/sito/notizie/sport/calcio/calcio_rss.xml"; flag2 = true;
                            break;

                        case 3:

                            url = "https://www.ansa.it/sito/notizie/cultura/cinema/cinema_rss.xml"; flag2 = true;
                            break;

                        case 4:

                            url = "https://www.ansa.it/sito/notizie/tecnologia/tecnologia_rss.xml"; flag2 = true;
                            break;

                        case 5:

                            url = "https://www.ansa.it/sito/notizie/cultura/cultura_rss.xml"; flag2 = true;
                            break;

                        case 6:

                            url = "https://www.ansa.it/sito/notizie/topnews/topnews_rss.xml"; flag2 = true;
                            break;

                        case 7:
                             leggi_preferiti(preferiti, n_pre);  flag2 = false;
                            break;
                        case 8:
                            flag = true;
                            break;




                    };


                    if (flag2 == true)
                    {
                        var News = await asyncMethod.GetTypeAsync<IEnumerable<News>>(url);
                        int i = 1;
                        foreach (var item in News)
                        {
                            i++;
                            news.Add(new News
                            {
                                title = item.title,
                                description = item.description,
                                guid = item.guid,
                                link = item.link,
                                ID = "ID" + i * 10,
                            });

                        };
                        n_pre = stampa(news, preferiti, i);
                    }

                }


                news.Clear();
            } while (flag == false);




        }

        static int stampa(List<News> news, List<News> preferiti, int i)
        {
            int n_pre = 0;
            int j = 0;

            do
            {

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Yellow; Console.BackgroundColor = ConsoleColor.Blue;  Console.WriteLine("Titolo:    " + news[j].title + "\n" ); Console.ResetColor();


                Console.WriteLine("\n\n\tDescrizione :" + news[j].description);

                Console.WriteLine("\n\tLink :" + news[j].link );

                Console.WriteLine("\n-------------------------");

                Console.WriteLine("\n\n Premi S per salvare, altrimenti muoviti avanti e dietro con <- o ->..");

                var tasto = Console.ReadKey().Key;

                if (tasto == ConsoleKey.RightArrow && j != i) { j++; }
                else if (tasto == ConsoleKey.LeftArrow && j != 0) { j--; }
                else if (tasto == ConsoleKey.S)
                {


                    preferiti.Add(new News
                    {
                        title = news[j].title,
                        description = news[j].description,
                        guid = news[j].guid,
                        link = news[j].link,
                        ID = news[j].ID,
                    });



                    var newDoc = new XDocument(
                      new XElement("root",
                          preferiti.Select(x => new XElement("channel",
                              new XElement("title", x.title),
                              new XElement("description", x.description),
                              new XElement("guid", x.guid),
                               new XElement("link", x.link),
                               new XElement("id", x.ID)

                              ))));

                    newDoc.Save("c:/users/devs5_accademy/source/repos/Ansa/Ansa/Salva.xml");



                    Console.Clear(); Console.WriteLine("\n----------------Salvato----------------"); System.Threading.Thread.Sleep(1000);


                    n_pre++;


                }




            } while (j < i - 1);

            return n_pre;

        }

        static void leggi_preferiti(List<News> preferiti, int n_pre)
        {

            for (int i = 0; i < n_pre; i++)
            {
                Console.Clear();
                Console.WriteLine("\n\n-------------------------\nTitolo :" + preferiti[i].title + "\n\n\tDescrizione :" + preferiti[i].description + "\n\tLink :" + preferiti[i].link + "\n------------------------- Premi invio per andare avanti");
                Console.ReadLine();
            }
        }




        static int load_preferiti(List<News> preferiti) {
            int i = 0;
            var doc = XDocument.Load("C:/Users/DEVS5_accademy/source/repos/Ansa/Ansa/Salva.xml");
            var customers = doc
                 .Descendants("root")
                .Select(x => new News
                {
                    title = x.Element("title")?.Value ?? "error title",
                    description = x.Element("description")?.Value ?? "error description",
                    guid = x.Element("guid")?.Value ?? "error guid",
                    link = x.Element("link")?.Value ?? "error link",
                    date = x.Element("pubDate")?.Value ?? "error date",
                });

            foreach (var item in customers)
            {
                i++;
                preferiti.Add(new News
                {
                    title = item.title,
                    description = item.description,
                    guid = item.guid,
                    link = item.link,
                    ID = item.ID,
                });

            };
            Console.WriteLine(i);
            Console.ReadLine();

            return i;

        }









    }
}
