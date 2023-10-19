using ENETALLER.app.ui;
using MySql.Data.MySqlClient;
using ENETALLER.app.data;
using ENETALLER.app.data.model;
using ENETALLER.app.data.repository;

namespace ENETALLER;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        PruebaUsuario();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string usuario = UsuarioEntry.Text;
        string contraseña = ContraseñaEntry.Text;

        if (ValidarCredenciales(usuario, contraseña))
        {
            await DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");
            await Navigation.PushAsync(new FormularioAdmin());
        }
        else
        {
            _ = DisplayAlert("Error", "Credenciales incorrectas", "OK");
        }
    }

    private bool ValidarCredenciales(string usuario, string contraseña)
    {
        return usuario == "usuario" && contraseña == "contraseña";
    }
    private void PruebaUsuario()
    {
        EmployeeDAO employeeDAO = new EmployeeDAO();
        List<Employee> listEmployees = employeeDAO.ReadEmployees();
        foreach (Employee employee in listEmployees)
        {
            Console.WriteLine($"{employee.Name}");
        }
    }
}
