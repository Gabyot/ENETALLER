using System;
using ENETALLER.app.data.mock;
using ENETALLER.app.data.model;
using MySql.Data.MySqlClient;

namespace ENETALLER.app.data.repository
{
	public class EmployeeDAO
	{
        public void CreateEmployee(Employee employee)
        {
            try
            {
                using (MySqlConnection connection = DataBaseConnection.ObtenerConexion())
                {
                    connection.Open();
                    string query = "INSERT INTO employee (RUT, name, email, password, permissions, address, phone, hourValue, extraValue, grossSalary, netSalary) " +
                        "VALUES (@RUT, @name, @email, @password, @permissions, @address, @phone, @hourValue, @extraValue, @grossSalary, @netSalary)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue(parameterName: "@RUT", employee.RUT);
                    cmd.Parameters.AddWithValue(parameterName: "@name", employee.Name);
                    cmd.Parameters.AddWithValue(parameterName: "@email", employee.Email);
                    cmd.Parameters.AddWithValue(parameterName: "@password", employee.Password);
                    cmd.Parameters.AddWithValue(parameterName: "@permissions", employee.Permissions);
                    cmd.Parameters.AddWithValue(parameterName: "@address", employee.Address);
                    cmd.Parameters.AddWithValue(parameterName: "@phone", employee.Phone);
                    cmd.Parameters.AddWithValue(parameterName: "@hourValue", employee.HourValue);
                    cmd.Parameters.AddWithValue(parameterName: "@extraValue", employee.ExtraValue);
                    cmd.Parameters.AddWithValue(parameterName: "@grossSalary", employee.GrossSalary);
                    cmd.Parameters.AddWithValue(parameterName: "@netSalary", employee.NetSalary);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        public List<Employee> ReadEmployees()
        {
            List<Employee> employeeList = new List<Employee>();

            using (MySqlConnection connection = DataBaseConnection.ObtenerConexion())
            {
                connection.Open();
                string query = "SELECT RUT, name, address, phone, email, password, permissions, AFP, Health, HourValue, ExtraValue, GrossSalary, NetSalary FROM employee";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader["name"].ToString();
                        string email = reader["email"].ToString();
                        string password = reader["password"].ToString();
                        string permissions = reader["permissions"].ToString();
                        string address = reader["address"].ToString();
                        string phone = reader["phone"].ToString();
                        string rut = reader["RUT"].ToString();
                        string afpName = reader["AFP"].ToString();
                        string healthName = reader["Health"].ToString();
                        int hourValue = Convert.ToInt32(reader["HourValue"]);
                        int extraValue = Convert.ToInt32(reader["ExtraValue"]);
                        int grossSalary = Convert.ToInt32(reader["GrossSalary"]);
                        int netSalary = Convert.ToInt32(reader["NetSalary"]);

                        // Obtén las instancias de AFP y Health
                        AFP afp = MockData.AFPDictionary.ContainsKey(afpName) ? MockData.AFPDictionary[afpName] : null;
                        Health health = MockData.HealthDictionary.ContainsKey(healthName) ? MockData.HealthDictionary[healthName] : null;

                        // Crea una nueva instancia de Employee proporcionando los valores adecuados
                        Employee employee = new Employee(name, email, password, permissions, address, phone, rut, afp, health, hourValue, extraValue, grossSalary, netSalary);

                        // Agrega la instancia de Employee a la lista
                        employeeList.Add(employee);
                    }
                }
                connection.Close();
            }
            return employeeList;
        }


        public void UpdateEmployees(Employee employee)
        {
            using (MySqlConnection connection = DataBaseConnection.ObtenerConexion())
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE employee SET RUT = @RUT, name = @name, password = @password, address = @address," +
                        " phone = @phone, hourValue = @hourValue, extraValue = @extraValue, " +
                        "grossSalary = @grossSalary, netSalary = @netSalary, AFP = @AFP, Health = @Health WHERE RUT = @RUT";
                    MySqlCommand cmd = new MySqlCommand(@query, connection);
                    cmd.Parameters.AddWithValue(parameterName: "@RUT", employee.RUT);
                    cmd.Parameters.AddWithValue(parameterName: "@name", employee.Name);
                    cmd.Parameters.AddWithValue(parameterName: "@password", employee.Password);
                    cmd.Parameters.AddWithValue(parameterName: "@address", employee.Address);
                    cmd.Parameters.AddWithValue(parameterName: "@phone", employee.Phone);
                    cmd.Parameters.AddWithValue(parameterName: "@hourValue", employee.HourValue);
                    cmd.Parameters.AddWithValue(parameterName: "@extraValue", employee.ExtraValue);
                    cmd.Parameters.AddWithValue(parameterName: "@AFP", employee.AFP.Name);
                    cmd.Parameters.AddWithValue(parameterName: "@Health", employee.Health.Name);
                    cmd.Parameters.AddWithValue(parameterName: "@grossSalary", employee.GrossSalary);
                    cmd.Parameters.AddWithValue(parameterName: "@netSalary", employee.NetSalary);

                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error en la actualización de la base de datos: {ex.Message}");
                    // Puedes agregar más información sobre la excepción si es necesario
                    Console.WriteLine($"Error Code: {ex.ErrorCode}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /* public void DeleteEmployees(string RUT)
         {
             using (MySqlConnection connection = DataBaseConnection.ObtenerConexion())
             {
                 connection.Open();
                 string query = "DELETE FROM employee WHERE RUT = @RUT";
                 MySqlCommand cmd = new MySqlCommand(query, connection);
                 cmd.Parameters.AddWithValue(parameterName: "@RUT", RUT);
                 cmd.ExecuteNonQuery();
                 connection.Close();
             }
         }*/
    }

}


