using ENETALLER.app.controller;
using ENETALLER.app.data.mock;
using ENETALLER.app.data.model;
using ENETALLER.app.data.repository;

namespace ENETALLER.app.ui;

public partial class CalculadoraSueldo : ContentPage
{
    private Employee selectedEmployee;
    private double sueldoBruto;
    private int sueldoLiquido;
    private AFP afp;
    private Health salud;

    public CalculadoraSueldo(Employee employee)
	{
		InitializeComponent();
        selectedEmployee = employee;
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
                sueldoBruto = Calculador.CalcularSueldoBruto(selectedEmployee, horasTrabajadas, horasExtras);

                // Calcula el sueldo líquido
                afp = MockData.AFPDictionary[afpSeleccionada]; // Obtén el objeto desde diccionario
                salud = MockData.HealthDictionary[saludSeleccionada]; 

                sueldoLiquido = Calculador.CalcularSueldoLiquido(selectedEmployee, afp, salud);

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
        // Actualiza los valores en el objeto empleado seleccionado
        selectedEmployee.GrossSalary = sueldoBruto;
        selectedEmployee.NetSalary = sueldoLiquido;
        selectedEmployee.AFP = afp; // Usar la AFP seleccionada
        selectedEmployee.Health = salud; // Usar el sistema de salud seleccionado

        // Llama al método de EmployeeDAO para actualizar en la base de datos
        EmployeeDAO employeeDAO = new EmployeeDAO();
        employeeDAO.UpdateEmployees(selectedEmployee);

        // Muestra una confirmación al usuario
        DisplayAlert("Éxito", "Los valores se han guardado en la base de datos.", "OK");
    }

    private void OnLimpiarCamposClicked(object sender, EventArgs e)
    {
        Console.WriteLine("Hello, World!");
    }

    private void OnListarClicked(object sender, EventArgs e)
    {
        try
        {
            Console.WriteLine("Hiciste CLick");
            Navigation.PushAsync(new VistaEmpleados());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al navegar a VistaEmpleados: " + ex.ToString());
        }
    }
}
