using System.Collections.ObjectModel;
using ENETALLER.app.data.mock;
using ENETALLER.app.data.model;
using ENETALLER.app.data.repository;

namespace ENETALLER.app.ui;

public partial class FormularioAdmin : ContentPage
{
    ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

    public FormularioAdmin()
    {
        InitializeComponent();
        EmployeePicker.ItemsSource = employees; // Asigna la ObservableCollection al Picker
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadEmployees();
    }

    private void LoadEmployees()
    {
        EmployeeDAO employeeDAO = new EmployeeDAO();
        List<Employee> listEmployees = employeeDAO.ReadEmployees();

        // Actualiza la ObservableCollection con los empleados de la base de datos
        employees.Clear();
        foreach (var employee in listEmployees)
        {
            employees.Add(employee);
        }
    }



    private void OnCrearEmpleadoClicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text;
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;
        string address = AddressEntry.Text;
        string phone = PhoneEntry.Text;
        string rut = RutEntry.Text;
        string hourValueText = HourValueEntry.Text;
        string extraValueText = ExtraValueEntry.Text;

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            DisplayAlert("Error", "Por favor, complete los campos obligatorios.", "OK");
            return;
        }
        else
        {
            // Variables para almacenar los valores enteros
            int hourValue;
            int extraValue;

            // Intentar convertir las cadenas a enteros
            if (int.TryParse(hourValueText, out hourValue) && int.TryParse(extraValueText, out extraValue))
            {
                EmployeeDAO employeeDAO = new EmployeeDAO();
                Employee newEmployee = new Employee(name, email, password, null, address, phone, rut, null, null, hourValue, extraValue, 0, 0);
                employeeDAO.CreateEmployee(newEmployee);

                // Actualiza el Picker con la lista de empleados actualizada
                LoadEmployees();

                // Limpia los campos del formulario
                NameEntry.Text = string.Empty;
                EmailEntry.Text = string.Empty;
                PasswordEntry.Text = string.Empty;
                AddressEntry.Text = string.Empty;
                PhoneEntry.Text = string.Empty;
                RutEntry.Text = string.Empty;
                HourValueEntry.Text = string.Empty;
                ExtraValueEntry.Text = string.Empty;

            }
            else
            {
                // Manejo de valores no válidos o errores de conversión
                DisplayAlert("Error", "Por favor, ingrese valores numéricos válidos para Valor por Hora y Valor por Hora Extra.", "OK");
            }
        }
    }


    private async void OnSeleccionarEmpleadoClicked(object sender, EventArgs e)
    {
        Employee selectedEmployee = EmployeePicker.SelectedItem as Employee;

        if (selectedEmployee != null)
        {
            await Navigation.PushAsync(new CalculadoraSueldo(selectedEmployee));
        }
    }

}
