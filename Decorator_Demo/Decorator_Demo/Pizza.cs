namespace Decorator_Demo
{
    // Root-Element
    class Pizza : IComponent
    {
        public string Name => "Pizza";
        public decimal Preis => 6.99m;
    }
}
