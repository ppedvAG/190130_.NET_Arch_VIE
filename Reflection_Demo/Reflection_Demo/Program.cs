using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            double i = 42;
            Type t = i.GetType();

            Console.WriteLine(t);

            // Instanz erstellen
            var neueZahl = Activator.CreateInstance(t);
            Console.WriteLine(neueZahl);
            Console.WriteLine(neueZahl.GetType());

            // Laden einer Assembly
            var assembly = Assembly.LoadFrom("MeineLib.dll");
            Type taschenrechnerTyp = assembly.GetType("MeineLib.Taschenrechner");
            var tr = Activator.CreateInstance(taschenrechnerTyp);
            Console.WriteLine(tr);

            // Aufrufen von Methoden:
            var methode = taschenrechnerTyp.GetRuntimeMethod("Add", new Type[] { typeof(int), typeof(int) });
            var erg = methode.Invoke(tr, new object[] { 12, 5 });

            Console.WriteLine(erg);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
