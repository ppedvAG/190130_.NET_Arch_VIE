namespace Decorator_Demo
{
    class Käse : Dekorator
    {
        public Käse(IComponent parent) : base(parent) {}

        public override string Name => parent.Name + " Käse";
        public override decimal Preis => parent.Preis + 0.99m;
    }
}
