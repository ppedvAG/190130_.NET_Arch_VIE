using Domain;
using System;
using System.Text.RegularExpressions;

namespace Logik
{
    public class RegexParser : IParser
    {
        public Formel Parse(string input)
        {
            Regex r = new Regex(@"(\d+)\s*(\D+)\s*(\d+)");
            var match = r.Match(input);
            if (match.Success)
            {
                return new Formel
                {
                    Operand1 = Convert.ToInt32(match.Groups[1].Value),
                    Operand2 = Convert.ToInt32(match.Groups[3].Value),
                    Operator = match.Groups[2].Value.Trim()
                };
            }

            throw new FormatException("Ihre Formel war leider im falschen Format");
        }
    }

}
