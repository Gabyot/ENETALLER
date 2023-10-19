using ENETALLER.app.data.model;
using ENETALLER.app.data.repository;

namespace ENETALLER.app.ui;

public partial class VistaEmpleados : ContentPage
{
	public VistaEmpleados()
	{
        InitializeComponent();
        EmployeeDAO employeeDAO = new EmployeeDAO();
        List<Employee> employeeList = employeeDAO.ReadEmployees(); // Llama a tu método ReadEmployees para obtener la lista de empleados
    
        foreach (var employee in employeeList)
        {
            var dataRow = new ViewCell();
            var dataGrid = new Grid();
            dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var nameCell = new Label { Text = employee.Name };
            var rutCell = new Label { Text = employee.RUT };
            var phoneCell = new Label { Text = employee.Phone };
            var grossSalaryCell = new Label { Text = employee.GrossSalary.ToString() };
            var netSalaryCell = new Label { Text = employee.NetSalary.ToString() };
            var aFPCell = new Label { Text = (employee.AFP != null) ? employee.AFP.Name : "null" };
            var healthCell = new Label { Text = (employee.Health != null) ? employee.Health.Name : "null" };


            Grid.SetColumn(nameCell, 0);
            Grid.SetColumn(rutCell, 1);
            Grid.SetColumn(phoneCell, 2);
            Grid.SetColumn(grossSalaryCell, 3);
            Grid.SetColumn(netSalaryCell, 4);
            Grid.SetColumn(aFPCell, 5);
            Grid.SetColumn(healthCell, 6);

            dataGrid.Children.Add(nameCell);
            dataGrid.Children.Add(rutCell);
            dataGrid.Children.Add(phoneCell);
            dataGrid.Children.Add(grossSalaryCell);
            dataGrid.Children.Add(netSalaryCell);
            dataGrid.Children.Add(aFPCell);
            dataGrid.Children.Add(healthCell);

            dataRow.View = dataGrid;
            employeeTable.Root[0].Add(dataRow);
        }
    }
}
