using Domain;
using System;

namespace PaidFeatures
{
    public class Division : IRechenart
    {
        public string Operator => "/";
        public int Berechne(int operand1, int operand2) => Convert.ToInt32(operand1 / operand2);
    }
}
