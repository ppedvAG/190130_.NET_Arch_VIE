using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Kantine pulkautaler = new Kantine();

            var lecker = pulkautaler.GibEssen();
            lecker.Beschreibung();

            var zukunft = pulkautaler.GibEssen(new DateTime(2100, 8, 22, 20, 45, 13));
            zukunft.Beschreibung();

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
