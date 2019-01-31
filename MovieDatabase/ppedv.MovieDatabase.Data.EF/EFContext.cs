using ppedv.MovieDatabase.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace ppedv.MovieDatabase.Data.EF
{
    // Minimale Basisconfig
    public class EFContext : DbContext
    {
        public EFContext(string connectionString) : base(connectionString){}

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<MovieTheater> MovieTheater { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().HasMany(x => x.Actors)
                                        .WithMany(x => x.Movies);
            // Many-to-Many für Actors zu Movies
        }
    }
}
