using DapperLesson.Servises;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DapperLesson.Data
{
    public abstract class DbDataAccess<T> : IDisposable 
    {
        protected readonly DbProviderFactory factory;
        protected readonly DbConnection connection;

        public DbDataAccess()
        {
            factory = DbProviderFactories.GetFactory("DapperLessonProvider");
            connection = factory.CreateConnection();
            connection.ConnectionString = ConfigurationService.Configuration["DataAccessConnectionString"];
            connection.Open();
        }
        public abstract void Insert(T entity);
        public abstract void Update(T entity);
        public abstract void Delete(T entity);
        public abstract ICollection<T> Select();
        public void ExecuteTransaction(params SqlCommand[] commands)
        {
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    foreach (var command in commands)
                    {
                        command.Transaction = (SqlTransaction)transaction;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
        public void Dispose()
        {
            connection.Close();
        }
    }
}
