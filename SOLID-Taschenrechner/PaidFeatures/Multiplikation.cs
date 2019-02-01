using Domain;

namespace PaidFeatures
{
    public class Multiplikation : IRechenart
    {
        public string Operator => "*";
        public int Berechne(int operand1, int operand2) => operand1 * operand2;
    }
}
