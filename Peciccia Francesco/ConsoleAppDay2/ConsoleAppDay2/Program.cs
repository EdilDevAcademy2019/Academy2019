using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDay2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            // Create Program's List

            List<Client> clients = new List<Client>();
            List<Supplier> suppliers = new List<Supplier>();
            List<Products> product = new List<Products>();

            // Create a choise
            bool Flag2 = false;
            Console.WriteLine(" ***************** B E N V E N U T O !!! *****************\n");
            do
            {
                Console.WriteLine("Che tipo di Utente sei?: \n1) Cliente \n2) Fornitore\n");
                int Choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(Choice);
                Console.Clear();
                switch (Choice)

                { // Homepage
                    case 1:

                        Console.WriteLine("Cosa desideri fare?  \n1) Aggiggiungere nuovo Cliente \n2) Vedere lista Clienti\n");
                        Choice = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        // Create a new Client
                        switch (Choice)
                        {
                            case 1:

                                bool Flag = false;

                                do
                                {
                                    Console.WriteLine("Nome: ");
                                    string MemoryFirstName = Console.ReadLine();
                                    Console.WriteLine("Cognome: ");
                                    string MemoryLastName = Console.ReadLine();

                                    clients.Add(new Client() { FirstName = MemoryFirstName, LastName = MemoryLastName, });
                                    Console.WriteLine(" Cosa desideri fare? \n1) Inserisci nuovo Cliente \n2) Uscire dal Programma");
                                    Choice = Convert.ToInt32(Console.ReadLine());

                                    if (Choice == 2)
                                    {
                                        Flag = true;
                                    }

                                } while (Flag == false);
                                break;

                            // See Client's List    
                            case 2:
                                {
                                    Console.WriteLine(" ******************** L I S T A   U T E N T I ******************** ");

                                   
                                  
                                    
                                    foreach (Client item in clients )
                                    {
                                        Console.WriteLine(item.ToString());
                                    }

                                    break;
                                }
                        }

                        break;


                    case 2:

                        Console.WriteLine("Cosa desideri fare?  \n1) Aggiggiungere nuovo Fornitore \n2) Vedere lista Fornitori \n3)Aggiungere prodotti \n4)Vedere lista prodotti");
                        Choice = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        // Create a new Supplier
                        switch (Choice)
                        {
                            case 1:

                                bool Flag3 = false;
                                
                                Console.WriteLine("Nome: ");
                                string MemoryFirstName = Console.ReadLine();
                                Console.WriteLine("Cognome: ");
                                string MemoryLastName = Console.ReadLine();
                                suppliers.Add(new Supplier() { FirstName = MemoryFirstName, LastName = MemoryLastName, });
                                


                                break;

                            // See Supplier's List
                            case 2:
                                {
                                    Console.WriteLine(" ******************** L I S T A   F O R N I T O R I ******************** ");




                                    foreach (Supplier item in suppliers)
                                    {
                                        Console.WriteLine(item.ToString());
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine(" ******************** N U O V O   P R O D O T T O ******************** ");

                                    bool Flag4 = false;

                                    Console.WriteLine("Azienda: ");
                                    string memorySupplier = Console.ReadLine();
                                    Console.WriteLine("Prodotto: ");
                                    string memoryProduct = Console.ReadLine();
                                    Console.WriteLine("Prezzo: ");
                                    decimal memoryPrice = Convert.ToDecimal(Console.ReadLine());
                                    product.Add(new Products() { ProductSupplier = memorySupplier, ProductName = memoryProduct, ProductPrice = memoryPrice });



                                    break;
                                }
                            case 4:
                                {
                                    Console.WriteLine(" ******************** L I S T A   P R O D O T T I ******************** ");




                                    foreach (Products item in product )
                                    {
                                        Console.WriteLine(item.ToString());
                                    }
                                    break;
                                }

                        }
                        break;
                }

                Console.WriteLine(" Vuoi continuare? \n1) Si \n2) No ");
                Choice = Convert.ToInt32(Console.ReadLine());
                if (Choice == 2)
                {
                    Flag2 = true;
                }

            } while (Flag2 == false);
        }






    }
}

