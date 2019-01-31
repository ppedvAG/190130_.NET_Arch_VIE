using System;
using System.Collections.Generic;

namespace ppedv.MovieDatabase.Domain
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public virtual Person Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual HashSet<Person> Actors { get; set; } = new HashSet<Person>();
        public virtual HashSet<MovieTheater> MovieTheaters { get; set; } = new HashSet<MovieTheater>();
    }
}
