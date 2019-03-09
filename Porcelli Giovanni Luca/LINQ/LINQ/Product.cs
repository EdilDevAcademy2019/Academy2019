//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LINQ
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }
        public string ProductID { get; set; }


        public Product (string name = "No Name", double price = 0, string brand = "No Brand")

        {
            Name = name;

            Price = price;

            Brand = brand;

        }


    }
}