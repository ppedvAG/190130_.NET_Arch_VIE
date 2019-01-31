using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.MovieDatabase.Domain
{
    public class StreamProvider : Entity
    {
        public string Name { get; set; }
        public string Movies { get; set; } // "12,2,3,4,5," ....
        public decimal MonthlySubscriptionRate { get; set; }
    }
}
