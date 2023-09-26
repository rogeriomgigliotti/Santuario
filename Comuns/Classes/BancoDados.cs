using DbUp;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;

namespace Comuns.Classes
{
    public static class BancoDados
    {
        public static void Inicializar()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            if (!string.IsNullOrEmpty(sqlConnectionStringBuilder.AttachDBFilename))
            {
                var mdfFilePath = sqlConnectionStringBuilder.AttachDBFilename;
                mdfFilePath = mdfFilePath.Replace("|DataDirectory|", Environment.CurrentDirectory);

                var masterConnectionString = $"Data Source={sqlConnectionStringBuilder.DataSource};Initial Catalog=master;Integrated Security=True";

                if (!File.Exists(mdfFilePath))
                    CriarBanco(masterConnectionString, mdfFilePath);
            }

            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
                throw result.Error;
        }

        private static void CriarBanco(string masterConnectionString, string mdfFilePath)
        {
            using (var connection = new SqlConnection(masterConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    var databaseName = mdfFilePath.ToUpper();

                    try
                    {
                        var dropSql = new StringBuilder();
                        dropSql.AppendLine($" IF EXISTS (SELECT 1 FROM sys.databases WHERE name = '{databaseName}') ");
                        dropSql.AppendLine($"    DROP DATABASE [{databaseName}]; ");

                        command.CommandText = dropSql.ToString();
                        command.ExecuteNonQuery();
                    }
                    catch { }

                    var createSql = new StringBuilder();
                    createSql.AppendLine($" CREATE DATABASE [{databaseName}] ON PRIMARY ");
                    createSql.AppendLine($" (NAME = [{databaseName}_Data], FILENAME = '{mdfFilePath}'); ");

                    command.CommandText = createSql.ToString();
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
