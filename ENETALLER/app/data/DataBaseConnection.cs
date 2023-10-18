using System;
using MySql.Data.MySqlClient;

namespace ENETALLER.app.data
{
    public class DataBaseConnection
    {
        private string connectionString;

        public DataBaseConnection(string connectionStr)
        {
            connectionString = connectionStr;
        }

        public MySqlConnection OpenConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (MySqlException ex)
            {
                // En lugar de imprimir un mensaje, arroja la excepción para que otros componentes puedan manejarla
                throw ex;
            }
        }

        public void CloseConnection(MySqlConnection connection)
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
