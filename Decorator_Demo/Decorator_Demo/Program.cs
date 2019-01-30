using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            var gutePizza = new Trüffel(new Salami (new Käse(new Pizza())));

            Console.WriteLine(gutePizza.Name);
            Console.WriteLine(gutePizza.Preis);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
