using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Login
{
    class Program
    {

        static List<User> users = new List<User>();



        private static int index = 0;

        static void Main(string[] args)
        {

            LoadUsers();

            List<string> menuItems = new List<string>() {
                "Registrati",
                "Login",
                "Exit"
            };

            Console.CursorVisible = false;

            while (true)
            {
                string selectedMenuItem = drawMenu(menuItems);
                if (selectedMenuItem == "Registrati")
                {


                        string username, password = string.Empty;

                        Console.WriteLine("Inserisci username: ");
                        username = Console.ReadLine();

                        Console.WriteLine("Inserisci la password: ");
                        password = Console.ReadLine();

                   
                    if (password.Length >= 8 )
                    {
                        Console.WriteLine("Password impostata con successo.");
                    }
                    else
                    {
                        Console.WriteLine("Password ERRATA. La password deve contenere almeno 8 caratteri.");
                        Console.WriteLine("Inserisci la password: ");
                        password = Console.ReadLine();
                    }

                
                        users.Add(new User { Name = username, Pass = password });
                        //Console.WriteLine(users.Name);

                        XDocument xmlDocument = new XDocument( new XElement ("users", 
                            users.Select(x => new XElement("user",
                            new XElement("username", x.Name),
                            new XElement("password", x.Pass)
                            ))));

                        xmlDocument.Save("utentiRegistrati.xml");

                        Console.WriteLine("Utente creato con successo!!");

                        Console.ReadLine();
                        Console.Clear();


                }

                else if (selectedMenuItem == "Login")
                {
                    LogIn();
                    Console.Clear();
                }
                else if (selectedMenuItem == "Exit")
                {
                    Environment.Exit(0);
                }
            }
        }
     
        public static void LogIn()
        {

            string username, password = string.Empty;

            Console.WriteLine("Inserisci l'username: ");
            username = Console.ReadLine();

            Console.WriteLine("Inserisci la password: ");
            password = Console.ReadLine();


            bool loggedIn = users.Any(x => x.Name == username && x.Pass == password);

            if (loggedIn)
            {
                Console.WriteLine("Utente loggato");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Riprova");

                LogIn();
            }

            
        }

        public static void LoadUsers()
        {

            var doc = XDocument.Load("utentiRegistrati.xml");

            users.AddRange (doc 
                .Descendants("user")
                .Select(x => new User
                {
                    Name = x.Element("username").Value,
                    Pass = x.Element("password").Value
                }));

        }

        private static string drawMenu(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo ckey = Console.ReadKey();

            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (index == items.Count - 1)
                {
                    //index = 0; 
                }
                else { index++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0)
                {
                    //index = menuItem.Count - 1; 
                }
                else { index--; }
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                return items[index];
            }
            else
            {
                return "";
            }

            Console.Clear();
            return "";
        }

 
    }

}
