using System;

namespace FactoryMethod_Demo
{
    class Frühstück : IEssen
    {
        public void Beschreibung()
        {
            Console.WriteLine("Eier und Speck");
        }
    }
}
