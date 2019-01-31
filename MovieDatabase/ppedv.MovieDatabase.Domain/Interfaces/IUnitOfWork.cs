using System;

namespace ppedv.MovieDatabase.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        // Spezialvariante fest einbauen
        IPersonRepository PersonRepository { get; }
        Type[] SupportedTypes { get; }

        // Generelle-Variante: Repository generieren
        IUniversalRepository<T> GetRepository<T>() where T : Entity, new();
        void Save();
    }
}
