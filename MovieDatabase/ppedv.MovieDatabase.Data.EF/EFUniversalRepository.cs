using ppedv.MovieDatabase.Domain;
using ppedv.MovieDatabase.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.MovieDatabase.Data.EF
{
    public class EFUniversalRepository<T> : IUniversalRepository<T> where T : Entity
    {
        public EFUniversalRepository(EFContext context) => this.context = context;
        protected readonly EFContext context;

        public void Add(T item)
        {
            context.Set<T>().Add(item);
        }

        public void Delete(T item) 
        {
            context.Set<T>().Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList(); // im speicher
        }

        public IQueryable<T> Query()
        {
            return context.Set<T>(); // query für weitere linq-abfragen
        }

        public T GetByID(int ID)
        {
            // 2 Möglichkeiten
            // return context.Set<T>().Find(ID); // Nimmt, wenn vorhanden, elemente aus dem cache

            return context.Set<T>().FirstOrDefault(x => x.ID == ID); // IMMER aus der DB
        }

        public void Update(T item) 
        {
            var loadedItem = GetByID(item.ID);
            if (loadedItem != null)
                context.Entry(loadedItem).CurrentValues.SetValues(item);
        }
    }
}
