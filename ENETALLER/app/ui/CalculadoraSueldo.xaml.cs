using ENETALLER.app.controller;
using ENETALLER.app.data.mock;
using ENETALLER.app.data.model;

namespace ENETALLER.app.ui;

public partial class CalculadoraSueldo : ContentPage
{
	public CalculadoraSueldo()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Obtén las claves del diccionario como opciones para el Picker
        List<string> afpOptions = new List<string>(MockData.AFPDictionary.Keys);
        List<string> saludOptions = new List<string>(MockData.HealthDictionary.Keys);
        // Asigna las opciones al Picker
        AFPPicker.ItemsSource = afpOptions;
        SaludPicker.ItemsSource = saludOptions;
    }

    private void OnCalcularClicked(object sender, EventArgs e)
    {
        // Verifica si los campos de entrada tienen datos válidos
        if (double.TryParse(HorasTrabajadasEntry.Text, out double horasTrabajadas) &&
            double.TryParse(HorasExtrasEntry.Text, out double horasExtras))
        {
            // Obtén las selecciones de AFP y salud
            string afpSeleccionada = AFPPicker.SelectedItem as string;
            string saludSeleccionada = SaludPicker.SelectedItem as string;

            // Verifica si las selecciones son válidas
            if (!string.IsNullOrEmpty(afpSeleccionada) && !string.IsNullOrEmpty(saludSeleccionada))
            {
                // Calcula el sueldo bruto
                double sueldoBruto = Calculador.CalcularSueldoBruto(MockData.gabriela, horasTrabajadas, horasExtras);

                // Calcula el sueldo líquido
                AFP afp = MockData.AFPDictionary[afpSeleccionada]; // Obtén el objeto AFP desde tu diccionario
                Health salud = MockData.HealthDictionary[saludSeleccionada]; // Obtén el objeto de salud desde tu diccionario

                int sueldoLiquido = Calculador.CalcularSueldoLiquido(MockData.gabriela, afp, salud);

                // Muestra los resultados en los Labels
                SueldoBrutoLabel.Text = $"${sueldoBruto:C}";
                SueldoLiquidoLabel.Text = $"${sueldoLiquido:C}";
            }
            else
            {
                DisplayAlert("Error", "Por favor, seleccione una AFP y un sistema de salud.", "OK");
            }
        }
        else
        {
            DisplayAlert("Error", "Por favor, ingrese datos válidos para las horas trabajadas y horas extras.", "OK");
        }
    }


    private void OnGuardarClicked(object sender, EventArgs e)
    {
        Console.WriteLine("Hello, World!");
    }

    private void OnLimpiarCamposClicked(object sender, EventArgs e)
    {
        Console.WriteLine("Hello, World!");
    }

    private void OnListarClicked(object sender, EventArgs e)
    {
        Console.WriteLine("Hello, World!");
    }
}
