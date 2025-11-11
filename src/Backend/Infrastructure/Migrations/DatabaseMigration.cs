using Dapper;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Infrastructure.Migrations
{
    public class DatabaseMigration
    {
        public static void Migrate(string connectionString, IServiceProvider serviceProvider)
        {
            EnsureDatabaseCreated(connectionString);
            MigrationDatabase(serviceProvider);

        }

        private static void EnsureDatabaseCreated(string connectionString)
        {
            var connectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);

            var databaseName = connectionStringBuilder.Database;

            connectionStringBuilder.Remove("Database");

            using var dbConnection = new NpgsqlConnection(connectionStringBuilder.ConnectionString);

            var parameters = new DynamicParameters();

            parameters.Add("name", databaseName!.ToLower());

            var records = dbConnection.Query("SELECT datname from pg_database WHERE datname = @name", parameters);

            if (records.Any() == false)
                dbConnection.Execute($"CREATE DATABASE {databaseName}");
        }
        private static void MigrationDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.ListMigrations();
            runner.MigrateUp();
        }


    }
}