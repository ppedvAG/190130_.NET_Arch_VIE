using Domain;
using System;

// S - Single Responsibility-Prinzip
// O - Open Closed-Prinzip
// L - Liskovsche Substitutionsprinzip
// I - Interface Segregation Prinzip
// D - Dependency Inversion Prinzip

namespace SOLID_Taschenrechner
{
    class KonsolenUI
    {
        public KonsolenUI(IRechner rechner, IParser parser)
        {
            this.rechner = rechner;
            this.parser = parser;
        }
        private readonly IRechner rechner;
        private readonly IParser parser;

        public void Start()
        {
            Console.WriteLine("Bitte geben Sie Ihre Formel ein:");
            string eingabe = Console.ReadLine();

            Formel formel = parser.Parse(eingabe);
            int ergebnis = rechner.Berechne(formel);

            Console.WriteLine($"Das Ergebnis ist {ergebnis}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }

}
