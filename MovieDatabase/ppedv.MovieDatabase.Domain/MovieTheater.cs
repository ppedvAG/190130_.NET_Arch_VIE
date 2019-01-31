using System.Collections.Generic;

namespace ppedv.MovieDatabase.Domain
{
    public class MovieTheater : Entity
    {
        public virtual HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
