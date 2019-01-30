using System;

namespace FactoryMethod_Demo
{
    class KeinEssen : IEssen
    {
        public void Beschreibung()
        {
            Console.WriteLine("Kantine hat zu");
        }
    }
}
