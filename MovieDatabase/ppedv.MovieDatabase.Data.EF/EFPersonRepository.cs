using ppedv.MovieDatabase.Domain;
using ppedv.MovieDatabase.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.MovieDatabase.Data.EF
{
    public class EFPersonRepository : EFUniversalRepository<Person>, IPersonRepository
    {
        public EFPersonRepository(EFContext context) : base(context){}

        public Person GetPersonWithHighestSalary()
        {
            return Query().OrderByDescending(x => x.Salary).First();
        }

        public Person GetPersonWithMostMovieAppearances()
        {
            return Query().OrderByDescending(x => x.Movies.Count).First();
        }
    }
}
