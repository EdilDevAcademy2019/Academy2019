using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreProject
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            bool flag = false;
            var news = new List<News>();
            var search = new List<News>();
            bool flag2 = false;
            bool flagricerca = false;
            bool flagregione = false;
            var url = "";

            do
            {

                flagricerca = false;
                Console.Clear();
                Console.WriteLine("Scegli categoria: ");
                Console.WriteLine("\t1-Cronaca");
                Console.WriteLine("\t2-Calcio");
                Console.WriteLine("\t3-Cinema");
                Console.WriteLine("\t4-Tecnologia");
                Console.WriteLine("\t5-Cultura");
                Console.WriteLine("\t6-Ultima ora");
                Console.WriteLine("\t7- Exit");


                switch (Console.ReadLine())
                {


                    case "1":

                        url = "https://www.ansa.it/sito/notizie/cronaca/cronaca_rss.xml";
                        Console.WriteLine("\t1-Stampa tutte le news");
                        Console.WriteLine("\t2-Ricerca una notizia");
                        if (Console.ReadLine() == "1")
                        {
                            flagricerca = true;

                        }
                        flag2 = true;
                        break;

                    case "2":

                        url = "https://www.ansa.it/sito/notizie/sport/calcio/calcio_rss.xml";
                        Console.WriteLine("\t1-Stampa tutte le news");
                        Console.WriteLine("\t2-Ricerca una notizia");
                        if (Console.ReadLine() == "1")
                        {
                            flagricerca = true;

                        }
                        flag2 = true;
                        break;

                    case "3":

                        url = "https://www.ansa.it/sito/notizie/cultura/cinema/cinema_rss.xml";
                        Console.WriteLine("\t1-Stampa tutte le news");
                        Console.WriteLine("\t2-Ricerca una notizia");
                        if (Console.ReadLine() == "1")
                        {
                            flagricerca = true;

                        }
                        flag2 = true;
                        break;

                    case "4":

                        url = "https://www.ansa.it/sito/notizie/tecnologia/tecnologia_rss.xml";
                        Console.WriteLine("\t1-Stampa tutte le news");
                        Console.WriteLine("\t2-Ricerca una notizia");
                        if (Console.ReadLine() == "1")
                        {
                            flagricerca = true;

                        }
                        flag2 = true;
                        break;

                    case "5":

                        url = "https://www.ansa.it/sito/notizie/cultura/cultura_rss.xml";
                        Console.WriteLine("\t1-Stampa tutte le news");
                        Console.WriteLine("\t2-Ricerca una notizia");
                        if (Console.ReadLine() == "1")
                        {
                            flagricerca = true;

                        }
                        flag2 = true;
                        break;

                    case "6":

                        url = "https://www.ansa.it/sito/notizie/topnews/topnews_rss.xml";
                        Console.WriteLine("\t1-Stampa tutte le news");
                        Console.WriteLine("\t2-Ricerca una notizia");
                        if (Console.ReadLine() == "1")
                        {
                            flagricerca = true;

                        }
                        flag2 = true;
                        break;


                    case "7":
                        flag = true;
                        flag2 = false;
                        break;

                    default:
                        url = "https://www.ansa.it/sito/ansait_rss.xml";
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
                    if (flagricerca == true)
                    {

                        foreach (var s in news)
                        {
                            Console.Clear();
                            Console.WriteLine("\nTitolo :" + s.title + "\n\n\tDescrizione :" + s.description + "\n\tLink :" + s.link);
                            Console.WriteLine("\n\n\nPremi invio per continuare..");

                            Console.ReadLine();
                        };
                    }
                    else
                    {
                        Console.WriteLine("Ricerco");
                        Search(news);
                    }

                }
                news.Clear();
            } while (flag == false);




        }


        static void Search(List<News> news)
        {
            Console.WriteLine("Inserisci parola da ricercare");
            string parola = Console.ReadLine();
            string titolo;

            int i=0;
            foreach (var s in news)
            {

                titolo = s.title;
                
                if (titolo.Contains(parola)== true) 
                {
                    
                    Console.Clear();
                    Console.WriteLine("\nTitolo :" + s.title + "\n\n\tDescrizione :" + s.description + "\n\tLink :" + s.link);
                    Console.WriteLine("\n\n\nPremi invio per continuare..");

                    Console.ReadLine();
                    i++;
                }


            };

            if (i == 0) Console.WriteLine("Ricerca non riuscita!");


        }
    }
}

