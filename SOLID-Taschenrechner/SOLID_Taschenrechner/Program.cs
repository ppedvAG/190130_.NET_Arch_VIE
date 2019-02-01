using Domain;
using Logik;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// S - Single Responsibility-Prinzip
// O - Open Closed-Prinzip
// L - Liskovsche Substitutionsprinzip
// I - Interface Segregation Prinzip
// D - Dependency Inversion Prinzip

namespace SOLID_Taschenrechner
{
    class Program
    {
        // Bootstrapping
        static void Main(string[] args)
        {
            // 1) Alle Libs im Ordner "Plugins" laden
            foreach (string file in Directory.GetFiles("./PlugIns"))
            {
                if (Path.GetExtension(file) == ".dll")
                    Assembly.LoadFrom(file);
            }

            // 2) Jeden Datentypen finden, der IRechenart implementiert
           var alleRechenarten = AppDomain.CurrentDomain.GetAssemblies()
                                          .SelectMany(x => x.GetTypes())
                                          .Where(x => x.IsAbstract == false &&
                                                      x.IsInterface == false &&
                                                      typeof(IRechenart).IsAssignableFrom(x))
                                          .Select(x => (IRechenart)Activator.CreateInstance(x))
                                          .ToArray();

            var parser = new RegexParser();
            var rechner = new ModulRechner(alleRechenarten);
            new KonsolenUI(rechner,parser).Start();
        }
    }
}
