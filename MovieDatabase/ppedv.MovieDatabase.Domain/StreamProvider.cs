using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.MovieDatabase.Domain
{
    public class StreamProvider : Entity
    {
        public string Name { get; set; }
        public int[] Movies { get; set; }
        public decimal MonthlySubscriptionRate { get; set; }
    }
}
