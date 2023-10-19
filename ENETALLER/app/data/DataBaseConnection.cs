using System;
using MySql.Data.MySqlClient;

namespace ENETALLER.app.data
{
    public static class DataBaseConnection
    {
        public static MySqlConnection ObtenerConexion()
        {
            string connectionString = "Server=localhost;Database=enetaller;User=root;Password=gaaabyrf13;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }

    }
}
