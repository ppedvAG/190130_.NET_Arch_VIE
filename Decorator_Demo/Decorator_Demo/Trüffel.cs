namespace Decorator_Demo
{
    class Trüffel : Dekorator
    {
        public Trüffel(IComponent parent) : base(parent) { }

        public override string Name => parent.Name + " Trüffel";
        public override decimal Preis => parent.Preis + 5.99m;
    }
}
