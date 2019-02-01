using Domain;

namespace FreeFeatures
{
    public class Addieren : IRechenart
    {
        public string Operator => "+";
        public int Berechne(int operand1, int operand2) => operand1 + operand2;
    }
}
