﻿using ppedv.MovieDatabase.Domain;
using ppedv.MovieDatabase.Domain.Interfaces;
using System;
using System.Linq;

namespace ppedv.MovieDatabase.Logic
{
    public class Core
    {
        public Core(params IUnitOfWork[] unitsOfWork) => UnitsOfWork = unitsOfWork;
        private IUnitOfWork[] UnitsOfWork { get; set; }

        public IUnitOfWork GetUnitOfWorkForType<T>()
        {
            return UnitsOfWork.First(x => x.SupportedTypes.Contains(typeof(T)));
        }

        public void CreateDemoData()
        {
            Person p1 = new Person { FirstName = "Tom", LastName = "Ate", Age = 10, Salary = 100m };
            Person p2 = new Person { FirstName = "Anna", LastName = "Nass", Age = 20, Salary = 2000m };
            Person p3 = new Person { FirstName = "Peter", LastName = "Silie", Age = 30, Salary = 333.99m };
            Person p4 = new Person { FirstName = "Franz", LastName = "Ose", Age = 40, Salary = 0 };
            Person p5 = new Person { FirstName = "Martha", LastName = "Pfahl", Age = 50, Salary = 12345m };
            Person p6 = new Person { FirstName = "Klara", LastName = "Fall", Age = 60, Salary = 98765m };
            Person p7 = new Person { FirstName = "Rainer", LastName = "Zufall", Age = 70, Salary = 77m };
            Person p8 = new Person { FirstName = "Frank N", LastName = "Stein", Age = 80, Salary = 100_000m };
            Person p9 = new Person { FirstName = "Axel", LastName = "Schweiß", Age = 90, Salary = 6493m };
            Person p10 = new Person { FirstName = "Anna", LastName = "Bolika", Age = 100, Salary = 1_000_000m };
            Person p11 = new Person { FirstName = "Ann", LastName = "Geber", Age = 110, Salary=  987650m };

            Movie m1 = new Movie
            {
                Title = "Robin Hood",
                Director = p8,
                ReleaseDate = DateTime.Now
            };
            m1.Actors.Add(p1);
            m1.Actors.Add(p2);
            m1.Actors.Add(p3);

            Movie m2 = new Movie
            {
                Title = "Terminator",
                Director = p10,
                ReleaseDate = new DateTime(1984, 10, 10)
            };
            m2.Actors.Add(p3);
            m2.Actors.Add(p4);
            m2.Actors.Add(p5);

            Movie m3 = new Movie
            {
                Title = "Titanic",
                Director = p2,
                ReleaseDate = new DateTime(1997, 1, 1)
            };
            m3.Actors.Add(p5);
            m3.Actors.Add(p6);
            m3.Actors.Add(p7);
            m3.Actors.Add(p9);

            MovieTheater mt1 = new MovieTheater();
            mt1.Movies.Add(m1);
            mt1.Movies.Add(m2);

            MovieTheater mt2 = new MovieTheater();
            mt1.Movies.Add(m2);
            mt1.Movies.Add(m3);

            // UnitOfWork für die oberen Datentypen finden:
            var efUnitOfWork = GetUnitOfWorkForType<MovieTheater>();

            var movieTheaterRepo = efUnitOfWork.GetRepository<MovieTheater>(); // Generisches Repo
            movieTheaterRepo.Add(mt1);
            movieTheaterRepo.Add(mt2);
            efUnitOfWork.PersonRepository.Add(p11); // Spezifisches Repo

            efUnitOfWork.Save();

            var sqliteUnitOfWork = GetUnitOfWorkForType<StreamProvider>();

            if (sqliteUnitOfWork == null)
                return;

            StreamProvider sp1 = new StreamProvider
            {
                Name = "Netflix",
                MonthlySubscriptionRate = 12.99m,
                Movies = "0,1"
            };
            StreamProvider sp2 = new StreamProvider
            {
                Name = "Amazon Prime",
                MonthlySubscriptionRate = 7.99m,
                Movies = "1,2"
            };

            var streamProviderRepo = sqliteUnitOfWork.GetRepository<StreamProvider>();
            streamProviderRepo.Add(sp1);
            streamProviderRepo.Add(sp2);
            sqliteUnitOfWork.Save();
        }
    }
}
