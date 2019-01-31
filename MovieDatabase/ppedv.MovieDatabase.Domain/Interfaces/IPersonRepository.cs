namespace ppedv.MovieDatabase.Domain.Interfaces
{
    public interface IPersonRepository : IUniversalRepository<Person>
    {
        Person GetPersonWithHighestSalary();
        Person GetPersonWithMostMovieAppearances();
    }
}
