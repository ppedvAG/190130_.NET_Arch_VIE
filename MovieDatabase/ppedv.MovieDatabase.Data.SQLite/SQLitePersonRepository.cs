using ppedv.MovieDatabase.Domain;
using ppedv.MovieDatabase.Domain.Interfaces;
using SQLite;
using System;

namespace ppedv.MovieDatabase.Data.SQLite
{
    public class SQLitePersonRepository : SQLiteUniversalRepository<Person>, IPersonRepository
    {
        public SQLitePersonRepository(SQLiteConnection connection) : base(connection){}

        public Person GetPersonWithHighestSalary()
        {
            return connection.Table<Person>().OrderByDescending(x => x.Salary).First();
        }

        public Person GetPersonWithMostMovieAppearances()
        {
            return connection.Table<Person>().OrderByDescending(x => x.Movies.Count).First();
        }
    }
}
