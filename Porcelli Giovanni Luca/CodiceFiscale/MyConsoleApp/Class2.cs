using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    class Person
    {
        public enum Gender
        {
            Male, Female
        }

        public readonly Gender gender;

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Lastname { get; set; }

        public DateTime DOB;

        public Person()
        {



        }

    }
}
