namespace Decorator_Demo
{
    class Schinken : Dekorator
    {
        public Schinken(IComponent parent) : base(parent) { }

        public override string Name => parent.Name + " Schinken";
        public override decimal Preis => parent.Preis + 0.50m;
    }
}
