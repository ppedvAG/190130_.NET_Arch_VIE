using ppedv.MovieDatabase.Domain;
using ppedv.MovieDatabase.Domain.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.MovieDatabase.Data.SQLite
{
    public class SQLiteUniversalRepository<T> : IUniversalRepository<T> where T : Entity, new()
    {
        public SQLiteUniversalRepository(SQLiteConnection connection) => this.connection = connection;
        protected readonly SQLiteConnection connection;

        public IEnumerable<T> GetAll()
        {
            return connection.Table<T>().ToList();
        }

        public IQueryable<T> Query()
        {
            return connection.Table<T>().AsQueryable();
        }

        public T GetByID(int ID)
        {
            return connection.Table<T>().First(x => x.ID == ID);
        }

        public void Add(T item)
        {
            connection.Insert(item);
        }

        public void Delete(T item)
        {
            connection.Delete(item);
        }

        public void Update(T item)
        {
            connection.Update(item);
        }
    }
}
