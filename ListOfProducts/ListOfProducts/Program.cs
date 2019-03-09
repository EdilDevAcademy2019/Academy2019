using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Product> products = new List<Product>();

            Console.WriteLine("1) Insert name of product");
            Console.WriteLine("2) View list of items");
            Console.Write("Choice > ");
            ConsoleKeyInfo input = Console.ReadKey();
            Console.Write("\n");

            if (input.KeyChar == '1')
            {


                Console.WriteLine("Name of product:");
                string Name = Console.ReadLine();

                Console.WriteLine("Quantity:");
                int Quantity = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Price:");
                decimal Price = Convert.ToDecimal(Console.ReadLine());

                products.Add(new Product { Name = Name, Quantity = Quantity, Price = Price });


                Console.Write("");
                foreach (Product oProduct in products)
                {
                    Console.WriteLine(oProduct.getData());

                }

            } while (input.KeyChar == '1');




            if (input.KeyChar == '2')
            {

                Console.Write("The list is: ");
                foreach (Product oProduct in products)
                {
                    Console.WriteLine(oProduct.getData());

                }
            }

           

            foreach (Product oProduct in products)
            {
                Console.WriteLine(oProduct.getData());

            }

            Console.ReadLine();



            //Create a list of products
            // List<Product> products = new List<Product>();
            /* products.Add(new Product { Name = "PS4", Quantity = 3, Price = 399.99m });
             products.Add(new Product { Name = "Xbox One", Quantity = 10, Price = 399.99m });
             products.Add(new Product { Name = "Wii U", Quantity = 5, Price = 299.99m });

             //Calculate total (qty * price)
             var total = products.Aggregate(0m, (current, p) => current + p.Quantity * p.Price);


             foreach(Product oProduct in products)
             {
                 Console.WriteLine(oProduct.getData());

             }

            Console.WriteLine("The total of products that you buy is $ " + total);

             Console.WriteLine();

     */



        }
    }
}
