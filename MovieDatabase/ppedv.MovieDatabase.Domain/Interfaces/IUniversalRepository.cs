using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ppedv.MovieDatabase.Domain.Interfaces
{
    public interface IUniversalRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        IQueryable<T> Query() ;
        T GetByID(int ID);
        void Add(T item);
        void Delete(T item);
        void Update(T item);
    }
}
