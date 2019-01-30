using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Logger().Log("Hallo Welt");
            //new Logger().Log("so macht man es eigentlich nicht !");

            //Logger.Instance.Log("Hallo Welt");
            //Logger.Instance.Log("Schaut schon bisserl besser aus :)");

            Parallel.For(0, 1000, i =>
              {
                  Logger.Instance.Log($"Hallo Welt {i}");
              });


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
