namespace Decorator_Demo
{
    class Salami : Dekorator
    {
        public Salami(IComponent parent) : base(parent) { }

        public override string Name => parent.Name + " Salami";
        public override decimal Preis => parent.Preis + 1.99m;
    }
}
