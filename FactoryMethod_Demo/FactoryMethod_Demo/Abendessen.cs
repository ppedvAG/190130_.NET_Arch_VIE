using System;

namespace FactoryMethod_Demo
{
    class Abendessen : IEssen
    {
        public void Beschreibung()
        {
            Console.WriteLine("Wurstsemmerl");
        }
    }
}
