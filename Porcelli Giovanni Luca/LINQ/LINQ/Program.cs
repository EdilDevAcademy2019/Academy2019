using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Query for discover all product in this catalog order by name of product.");
            QueryStringArray();

            Console.WriteLine("Query for discover all products in this catalog that have a price < 2500$, order by price.");
            QueryArrayList();

            Console.WriteLine("Query for discover the price > 400$ of famous brand, order by name.");
            QueryCollection();
            Console.ReadLine();
        }

        static void QueryStringArray()
        {

            string[] products = { "PS4", "McBook Air", "Asus 550L", "Modem TPLink", "HP Keyboard" };

            var productSpaces = from product in products
                            where product.Contains(" ")
                            orderby product descending
                            select product;

            /*var productSpaces = product.Contains(x => x.Name).Where(x.Amount)*/
            foreach(var i in productSpaces)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            Console.WriteLine("The number of products that you find is: " + productSpaces.Count());

            Console.WriteLine();
            Console.WriteLine();
        }

        static void QueryArrayList()
        {
            ArrayList famProducts = new ArrayList()
            {
                new Product{Name = "McBook Pro", Price = 2000, Brand = "Apple"},

                 new Product{Name = "Surface Pro", Price = 1500, Brand = "Asus"},

                  new Product{Name = "Dell XPS", Price = 900, Brand = "Dell"}
            };

            var famProductEnum = famProducts.OfType<Product>();

            var smProducts = from product1 in famProductEnum
                            where product1.Price <= 2500
                            orderby product1.Price
                            select product1;

            foreach (var product1 in smProducts)
            {
                Console.WriteLine("{0} product costs {1} $", product1.Name, product1.Price);
            }

            Console.WriteLine();

            Console.WriteLine("The number of products that you find is: " + smProducts.Count());

            Console.WriteLine();
            Console.WriteLine();
        }


        static void QueryCollection()
        {

            var ProductList = new List<Product>()
            {
                 new Product{Name = "Apple", Price = 2000},

                 new Product{Name = "Dell", Price = 800},

                 new Product{Name = "HP", Price = 500}
            };

            var bigBrand = from brand in ProductList
                          where (brand.Price > 400) 
                          orderby brand.Name
                          select brand;

            foreach(var brands in bigBrand)
            {
                Console.WriteLine("A {0} products cost about {1} $", brands.Name, brands.Price);

                
            }

            Console.WriteLine();

            Console.WriteLine("The number of products that you find is: " + bigBrand.Count());

            Console.WriteLine();
            Console.WriteLine();
        }

       
    }
}
