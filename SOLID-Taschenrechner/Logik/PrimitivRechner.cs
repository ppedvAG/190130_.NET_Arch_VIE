using Domain;
using System;

namespace Logik
{
    public class PrimitivRechner : IRechner
    {
        public int Berechne(Formel input)
        {
            if (input.Operator == "+")
                return input.Operand1 + input.Operand2;
            else if (input.Operator == "-")
                return input.Operand1 - input.Operand2;
            throw new ArgumentException("Der Operator ist leider unbekannt");
        }
    }

}
