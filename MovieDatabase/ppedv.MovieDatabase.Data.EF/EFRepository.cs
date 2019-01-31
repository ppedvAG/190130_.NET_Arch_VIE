using ppedv.MovieDatabase.Domain;
using ppedv.MovieDatabase.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.MovieDatabase.Data.EF
{
    public class EFRepository : IRepository
    {
        public EFRepository(EFContext context) => this.context = context;
        private readonly EFContext context;

        public void Add<T>(T item) where T : Entity
        {
            context.Set<T>().Add(item);
        }

        public void Delete<T>(T item) where T : Entity
        {
            context.Set<T>().Remove(item);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToList(); // im speicher
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return context.Set<T>(); // query für weitere linq-abfragen
        }

        public T GetByID<T>(int ID) where T : Entity
        {
            // 2 Möglichkeiten
            // return context.Set<T>().Find(ID); // Nimmt, wenn vorhanden, elemente aus dem cache

            return context.Set<T>().FirstOrDefault(x => x.ID == ID); // IMMER aus der DB
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update<T>(T item) where T : Entity
        {
            var loadedItem = GetByID<T>(item.ID);
            if (loadedItem != null)
                context.Entry(loadedItem).CurrentValues.SetValues(item);
        }
    }
}
