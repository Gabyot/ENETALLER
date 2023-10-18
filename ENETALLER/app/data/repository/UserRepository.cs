using System.Data;

using Dapper;
using ENETALLER.app.data.model;
using MySql.Data.MySqlClient;

namespace ENETALLER.app.data
{
    public class UsuarRepository
    {
        private IDbConnection dbConnection;

        public UsuarRepository(string connectionString)
        {
            dbConnection = new MySqlConnection(connectionString);
        }

        public bool InsertUsuario(User usuario)
        {
            string query = "INSERT INTO usuarios (nombre, correo) VALUES (@Nombre, @Correo)";

            try
            {
                dbConnection.Open();
                dbConnection.Execute(query, usuario);
                return true; // Éxito al insertar el usuario
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar el usuario: " + ex.Message);
                return false; // Error al insertar el usuario
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}
