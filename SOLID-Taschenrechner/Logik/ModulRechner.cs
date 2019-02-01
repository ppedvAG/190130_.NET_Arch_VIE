using Domain;
using System;
using System.Linq;

namespace Logik
{
    public class ModulRechner : IRechner
    {
        public ModulRechner(params IRechenart[] rechenarten) => this.rechenarten = rechenarten;
        private readonly IRechenart[] rechenarten;

        public int Berechne(Formel input)
        {
            var rechenart = rechenarten.FirstOrDefault(x => x.Operator == input.Operator);
            if (rechenart == null)
                throw new ArgumentException("Die Rechenart wird nicht unterstützt");
            return rechenart.Berechne(input.Operand1, input.Operand2);
        }
    }
}
