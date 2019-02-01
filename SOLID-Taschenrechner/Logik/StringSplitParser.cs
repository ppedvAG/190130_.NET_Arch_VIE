using Domain;
using System;

namespace Logik
{
    public class StringSplitParser : IParser
    {
        public Formel Parse(string input)
        {
            string[] teile = input.Split(' ');
            return new Formel
            {
                Operand1 = Convert.ToInt32(teile[0]),
                Operand2 = Convert.ToInt32(teile[2]),
                Operator = teile[1]
            };
        }
    }

}
