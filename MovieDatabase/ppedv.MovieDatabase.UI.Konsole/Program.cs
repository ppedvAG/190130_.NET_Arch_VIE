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
            Core core = new Core(new EFRepository(new EFContext(@"Server=(localDB)\MSSQLLocalDB;Database=MovieDatabase;Trusted_Connection=true;AttachDbFilename=C:\temp\db.mdf")));

            if (core.Repository.Query<Person>().Count() == 0)
                core.CreateDemoData();

            foreach (Person person in core.Repository.GetAll<Person>())
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}- Age: {person.Age}");
            }


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
