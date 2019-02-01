namespace Domain
{
    public interface IRechenart
    {
        string Operator { get; }
        int Berechne(int operand1, int operand2);
    }
}
