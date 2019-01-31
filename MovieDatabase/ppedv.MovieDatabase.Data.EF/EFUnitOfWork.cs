using ppedv.MovieDatabase.Domain;
using ppedv.MovieDatabase.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.MovieDatabase.Data.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public EFUnitOfWork(EFContext context) => this.context = context;
        private readonly EFContext context;

        // Variante "faul" :
        public IPersonRepository PersonRepository => new EFPersonRepository(context);
        public IUniversalRepository<T> GetRepository<T>() where T : Entity, new()
        {
            return new EFUniversalRepository<T>(context);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
