using FreeFeatures;
using Logik;
using System.Collections.Generic;
using System.Linq;
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
            var parser = new RegexParser();
            var rechner = new ModulRechner(new Addieren(),new Subtrahieren());
            new KonsolenUI(rechner,parser).Start();
        }
    }
}
