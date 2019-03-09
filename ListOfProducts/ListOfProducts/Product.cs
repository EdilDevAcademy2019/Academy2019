using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfProducts
{
    public class Product
    {

        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public string getData()
        {
            return "The list contain the product: " + this.Name + " with quantity of: " + this.Quantity + " costs: " + this.Price;
        }
    }
}
