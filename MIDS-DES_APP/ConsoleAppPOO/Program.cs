using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Alejandro", "Octavio", "Perez", new DateTime(1990, 02, 22), "900222DF5");
            Console.WriteLine(person.ToString());

            Console.ReadKey();
        }

        
    }
}
