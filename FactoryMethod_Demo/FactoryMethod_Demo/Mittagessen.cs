using System;

namespace FactoryMethod_Demo
{
    class Mittagessen : IEssen
    {
        public void Beschreibung()
        {
            Console.WriteLine("Wiener Schnitzel");
        }
    }
}
