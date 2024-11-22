using System;
using System.Data;
using ExportarDatosAExcelAPI.Helpers;
using MySql.Data.MySqlClient;

namespace ExportarDatosAExcelAPI.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(DatabaseConnection databaseConnection)
        {
            _connectionString = databaseConnection.GetConnectionString();
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using MySqlConnection connection = new MySqlConnection(_connectionString);
                connection.Open();
                using MySqlCommand command = new MySqlCommand(query, connection);
                using MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dataTable;
        }
    }
}