using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    class Program
    {
        /*public static void Main(string[] args)
        {
            var p = new Person();
            p.ID = 1;
            p.FirstName = "Pietro";
            p.LastName = "Chionna";
            Console.WriteLine("Io mi chiamo " + p.FirstName + " " + p.LastName);

            DateTime mybday = new DateTime(1992, 08, 10);
            DateTime today = DateTime.Today;
            int months = 0;
            int days = 0;

            DateTime nextBirthday = mybday.AddYears(today.Year - mybday.Year);
            if (nextBirthday < today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }

            months = 0;
            while (today.AddMonths(months + 1) <= nextBirthday)
            {
                months++;
            }

            days = nextBirthday.Subtract(today.AddMonths(months)).Days;
            Console.WriteLine("Il mio prossimo compleanno sarà tra {0} mesi e {1} giorni.", months, days);
            Console.WriteLine("\n");
            Console.WriteLine("Premi INVIO per continuare");
            Console.ReadLine();

            while (true)
            {
                string name;
                Console.Clear();
                Console.Write("Tu come ti chiami? ");
                name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Ciao, " + name);
                Console.WriteLine("\n");

                Console.Write("Quando sei nato? ");
                
                DateTime birthDate;
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    TimeSpan age = DateTime.Now - birthDate;

                    DateTime nextBday = birthDate.AddYears(today.Year - birthDate.Year);
                    if (nextBday < today)
                    {
                        nextBday = nextBday.AddYears(1);
                    }

                    months = 0;
                    while (today.AddMonths(months + 1) <= nextBday)
                    {
                        months++;
                    }

                    days = nextBday.Subtract(today.AddMonths(months)).Days;

                    Console.Clear();
                    Console.WriteLine("Hai {0} anni e il tuo prossimo compleanno sarà tra {2} mesi e {3} giorni.", (int)(age.Days / 365.25), age.Days % 365.25, months, days);
                    Console.WriteLine("\n");
                    Console.WriteLine("Premere INVIO per tornare indietro");
                    Console.ReadLine();

                }
                else
                    Console.WriteLine("Il formato della data è sbagliato.");
            }
        }*/

        public static void Main(String[] args)
        {

            Console.Write("Che ore sono? ");

            Console.WriteLine("Premere INVIO per saperlo");
            Console.ReadLine();
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt);
           

            Console.WriteLine("E' ora di andarcene a fanculo!");
            Console.ReadLine();
        }

    }

}
