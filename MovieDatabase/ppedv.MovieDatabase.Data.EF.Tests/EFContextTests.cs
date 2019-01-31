using NUnit.Framework;
using ppedv.MovieDatabase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.MovieDatabase.Data.EF.Tests
{
    public class EFContextTests
    {
        const string connectionString = @"Server=(localDB)\MSSQLLocalDB;Database=MovieDatabaseTests;Trusted_Connection=true;AttachDbFilename=C:\temp\db.mdf";
        [Test]
        public void Can_Create_EFContext()
        {
            EFContext context = new EFContext(connectionString);
        }
        [Test]
        public void EFContext_Can_Create_DB()
        {
            using (EFContext context = new EFContext(connectionString))
            {
                if (context.Database.Exists())
                    context.Database.Delete();

                Assert.IsFalse(context.Database.Exists());
                context.Database.Create();
                Assert.IsTrue(context.Database.Exists());
            }
        }

        [Test]
        public void EFContext_Can_CRUD_Person()
        {
            Person p = new Person { FirstName = "Max", LastName = "Mustermann", Age = 50, Salary = 100_000m };
            string newLastName = "Musterfrau";

            // Create
            using (EFContext context = new EFContext(connectionString))
            {
                context.Person.Add(p); // Insert
                context.SaveChanges();
            }

            using (EFContext context = new EFContext(connectionString))
            {
                // Check Create
                var loadedPerson = context.Person.Find(p.ID);
                Assert.IsNotNull(loadedPerson);
                Assert.AreEqual(p.FirstName, loadedPerson.FirstName);

                // Update
                loadedPerson.LastName = newLastName;
                context.SaveChanges();
            }

            using (EFContext context = new EFContext(connectionString))
            {
                // Check Update
                var loadedPerson = context.Person.Find(p.ID);
                Assert.IsNotNull(loadedPerson);
                Assert.AreEqual(newLastName, loadedPerson.LastName);

                // Delete
                context.Person.Remove(loadedPerson);
                context.SaveChanges();
            }

            using (EFContext context = new EFContext(connectionString))
            {
                // Check Delete
                var loadedPerson = context.Person.Find(p.ID);
                Assert.IsNull(loadedPerson);
            }
        }
    }
}
