using ppedv.MovieDatabase.Data.EF;
using ppedv.MovieDatabase.Domain;
using ppedv.MovieDatabase.Logic;
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
            Core core = new Core(new EFUnitOfWork(new EFContext(@"Server=(localDB)\MSSQLLocalDB;Database=MovieDatabase;Trusted_Connection=true;AttachDbFilename=C:\temp\db.mdf")));

            if (core.UnitOfWork.PersonRepository.Query().Count() == 0) // Spezifisches Repo
                core.CreateDemoData();

            foreach (Person person in core.UnitOfWork.GetRepository<Person>().GetAll()) // Generisches Repo
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}- Age: {person.Age}");
            }

            Console.WriteLine(core.UnitOfWork.PersonRepository.GetPersonWithHighestSalary().LastName);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
