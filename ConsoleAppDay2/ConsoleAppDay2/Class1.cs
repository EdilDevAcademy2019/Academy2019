using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDay2
{
    public abstract class Person
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public int PartId { get; set; }
        public override string ToString()
        {
            return "ID: " + PartId + " Nome: " + FirstName + "Cognome: " + LastName;
        }

    }

    public class Client : Person
    {
        public int ClientId { get; set; }
    }
        

    public class Supplier : Person
    {
        public int SupplierId { get; set; }
    }

    public class Products
    {

        public string ProductName { get; set; }
        public string ProductSupplier { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }

        // Override

        public override string ToString()
        {
            return "\tSupplier:\t " + ProductSupplier + "\tNome:\t " + ProductName  + "\tPrezzo: \t " + ProductPrice + "\tID:\t " + ProductId;
        }
    }

}
