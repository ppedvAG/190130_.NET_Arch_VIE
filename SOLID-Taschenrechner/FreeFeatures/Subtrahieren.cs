using Domain;
using System;

namespace FreeFeatures
{
    public class Subtrahieren : IRechenart
    {
        public string Operator => "-";
        public int Berechne(int operand1, int operand2) => operand1 - operand2;
    }
}
