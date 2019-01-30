using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Demo
{
    abstract class Dekorator : IComponent
    {
        public Dekorator(IComponent parent)
        {
            this.parent = parent;
        }
        protected readonly IComponent parent;

        public abstract string Name { get; }
        public abstract decimal Preis { get; }
    }
}
