using ENETALLER.app.controller;
using ENETALLER.app.data.mock;
using ENETALLER.app.data.model;
using ENETALLER.app.ui;

namespace ENETALLER;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        PruebaCalculo();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string usuario = UsuarioEntry.Text;
        string contraseña = ContraseñaEntry.Text;

        if (ValidarCredenciales(usuario, contraseña))
        {
            await DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");
            await Navigation.PushAsync(new CalculadoraSueldo());
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
    private void PruebaCalculo()
    {
        double resultado = Calculador.CalcularSueldoBruto(MockData.gabriela, 10.0, 3.0);
        Console.WriteLine($"El sueldo bruto de {MockData.gabriela.Name} es: {resultado}");
    }
}
