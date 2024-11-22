using System;
using MySql.Data.MySqlClient;
using DotNetEnv;
using System.IO;

namespace ExportarDatosAExcelAPI.Helpers
{
    public class DatabaseConnection
    {
        public string GetConnectionString()
        {
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = BuildConnectionStringFromUserInput();
            }
            return connectionString;
        }

        private string BuildConnectionStringFromUserInput()
        {
            string connectionString = null;
            bool isConnected = false;
            while (!isConnected)
            {
                Console.Write("Ingrese el usuario de la base de datos: ");
                string user = Console.ReadLine();
                Console.Write("Ingrese la contraseña de la base de datos: ");
                string password = ReadPassword();
                Console.Write("Ingrese Nombre del Servidor: ");
                string server = Console.ReadLine();
                Console.Write("Ingrese Nombre de la Base de Datos: ");
                string database = Console.ReadLine();
                Console.Write("Ingrese Número de Puerto: ");
                string port = Console.ReadLine();

                connectionString = $"Server={server};Database={database};Port={port};UserId={user};Password={password};";

                try
                {
                    using var connection = new MySqlConnection(connectionString);
                    connection.Open();
                    isConnected = true;
                }
                catch (MySqlException)
                {
                    Console.WriteLine("Error de conexión. Inténtelo de nuevo.");
                }
            }
            return connectionString;
        }

        private string ReadPassword()
        {
            string password = string.Empty;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return password;
        }
    }
}
