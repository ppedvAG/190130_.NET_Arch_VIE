using ppedv.MovieDatabase.Domain;
using ppedv.MovieDatabase.Domain.Interfaces;
using SQLite;
using System;
using System.Linq;
using System.Reflection;

namespace ppedv.MovieDatabase.Data.SQLite
{
    public class SQLiteUnitOfWork : IUnitOfWork
    {
        public SQLiteUnitOfWork(SQLiteConnection connection)
        {
            this.connection = connection;

            #region Automatische Variante für alles, was ein Entity ist:
            //var types = AppDomain.CurrentDomain.GetAssemblies()
            //                                   .SelectMany(x => x.GetTypes())
            //                                   .Where(x => x.IsAbstract == false && typeof(Entity).IsAssignableFrom(x))
            //                                   .ToArray();
            //foreach (Type entityType in types)
            //{
            //    connection.CreateTable(entityType);
            //} 
            #endregion

            connection.CreateTable<StreamProvider>(); // Erstellt die Tabelle nur, wenn sie noch nicht vorhanden ist
            connection.BeginTransaction();
        }
        private readonly SQLiteConnection connection;
        public Type[] SupportedTypes => new Type[] { typeof(StreamProvider) };

        public IPersonRepository PersonRepository => new SQLitePersonRepository(connection);
        public IUniversalRepository<T> GetRepository<T>() where T : Entity, new()
        {
            return new SQLiteUniversalRepository<T>(connection);
        }

        public void Save()
        {
            connection.Commit();
            connection.BeginTransaction();
        }
    }
}
