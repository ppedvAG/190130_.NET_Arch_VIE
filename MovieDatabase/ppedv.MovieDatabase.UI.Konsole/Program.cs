using ppedv.MovieDatabase.Data.EF;
using ppedv.MovieDatabase.Data.SQLite;
using ppedv.MovieDatabase.Domain;
using ppedv.MovieDatabase.Logic;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.MovieDatabase.UI.Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Core core = new Core(new EFUnitOfWork(new EFContext(@"Server=(localDB)\MSSQLLocalDB;Database=MovieDatabase;Trusted_Connection=true;AttachDbFilename=C:\temp\db.mdf")),
                                 new SQLiteUnitOfWork(new SQLiteConnection("db.sqlite")));

            if (core.GetUnitOfWorkForType<Person>().PersonRepository.Query().Count() == 0) // Spezifisches Repo
                core.CreateDemoData();

            foreach (Person person in core.GetUnitOfWorkForType<Person>().GetRepository<Person>().GetAll()) // Generisches Repo
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}- Age: {person.Age}");
            }

            Console.WriteLine(core.GetUnitOfWorkForType<Person>().PersonRepository.GetPersonWithHighestSalary().LastName);
            Console.WriteLine("--------------------------");

            var movieRepository = core.GetUnitOfWorkForType<Movie>().GetRepository<Movie>();
            foreach (StreamProvider p in core.GetUnitOfWorkForType<StreamProvider>().GetRepository<StreamProvider>().GetAll())
            {
                Console.WriteLine(p.Name);
                Movie[] movies = p.Movies.Split(',').Select(x => movieRepository.GetByID(Convert.ToInt32(x)))
                                                    .ToArray();
                foreach (Movie m in movies)
                {
                    if (m == null) continue;
                    Console.WriteLine(m.Title);
                    Console.WriteLine(m.ReleaseDate);
                }
                Console.WriteLine("---");
            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
