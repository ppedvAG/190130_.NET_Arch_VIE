using System.Collections.Generic;

namespace ppedv.MovieDatabase.Domain
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public decimal Salary { get; set; }
        public virtual HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
