using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Xml;
using MySql.Data.MySqlClient;
using Warehouse.Database.Configuration;

namespace Warehouse.Database.Initializer
{
    internal abstract class BaseIDatabaseInitializer<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
    {
        public void InitializeDatabase(TContext context)
        {
            Console.WriteLine("Database " + context.Database.Connection.Database);

            if (!context.Database.Exists())
            {
                if (DbConfigManager.IsTrowIfDatabaseNotFound)
                    throw new ApplicationException("Database is not found");
                CreateDatabase(context);
            }
            else
            {
                if (DbConfigManager.IsDeleteExistDatabase)
                {
                    var databaseName = context.Database.Connection.Database;

                    context.Database.Delete();
                    Console.WriteLine("Current database {0} is deleted.", databaseName);
                    CreateDatabase(context);
                }
            }

            if (DbConfigManager.IsAddTestData)
            {
                AddTestData(context);
                context.SaveChanges();
                Console.WriteLine("Test data is added.");
            }
        }

        private void CreateDatabase(TContext context)
        {
            CreateMySqlDatabase(context);
            AddSystemData(context);
            context.SaveChanges();

            Console.WriteLine("New database is created.");
        }

        protected void CreateMySqlDatabase(TContext context)
        {
            try
            {
                context.Database.Create();

                return;
            }
            catch (MySqlException ex)
            {
                if (ex.Number != 1064)
                {
                    throw;
                }
            }

            using (MySqlConnection connection = (MySqlConnection)((MySqlConnection)context
                    .Database.Connection).Clone())
            using (var command = connection.CreateCommand())
            {
                const string createMigrationHistoryTable = @"CREATE TABLE __MigrationHistory (MigrationId mediumtext NOT NULL, Model mediumblob NOT NULL, ProductVersion mediumtext NOT NULL);
																			ALTER TABLE __MigrationHistory ADD PRIMARY KEY (MigrationId(255));
																			INSERT INTO __MigrationHistory (MigrationId, Model, ProductVersion) VALUES ('InitialCreate', @Model, @ProductVersion);";

                command.CommandText = createMigrationHistoryTable;

                command.Parameters.AddWithValue(
                        "@Model",
                        GetModel(context));
                command.Parameters.AddWithValue(
                        "@ProductVersion",
                        GetProductVersion());

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private byte[] GetModel(TContext context)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(
                        memoryStream,
                        CompressionMode.Compress))
                using (var xmlWriter = XmlWriter.Create(
                        gzipStream,
                        new XmlWriterSettings { Indent = true }))
                {
                    EdmxWriter.WriteEdmx(context, xmlWriter);
                }

                return memoryStream.ToArray();
            }
        }

        private string GetProductVersion()
        {
            return typeof(DbContext).Assembly
                    .GetCustomAttributes(false)
                    .OfType<AssemblyInformationalVersionAttribute>()
                    .Single()
                    .InformationalVersion;
        }

        protected abstract void AddSystemData(TContext context);
        protected abstract void AddTestData(TContext context);
    }
}