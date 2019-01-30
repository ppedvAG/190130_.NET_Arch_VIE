using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var ikeaSchrank = Schrank.BaueSchrank()
                                     .MitTüren(2)
                                     .MitBöden(2)
                                     .HatKleiderstange(true)
                                     .KonstruiereSchrank();

            var xxxLutzSchrank = Schrank.BaueSchrank()
                                        .MitTüren(4)
                                        .MitBöden(1)
                                        .InFarbe("Grün")
                                        .MitOberfläche(Oberflächenart.Lackiert)
                                        .KonstruiereSchrank();

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
