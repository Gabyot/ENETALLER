using System;
using ENETALLER.app.data.model;

namespace ENETALLER.app.controller
{
	public static class Calculador
	{
        //Métodos
        public static double CalcularSueldoBruto(Employee empleado, double horasTrabajadas,
            double horasExtra)
        {
            empleado.GrossSalary = (horasTrabajadas * empleado.HourValue +
                (empleado.ExtraValue * horasExtra));

            return empleado.GrossSalary;
        }

        public static int CalcularSueldoLiquido(Employee empleado, AFP afpSeleccionada, Health saludSeleccionada )
        {
            empleado.NetSalary = (int)(empleado.GrossSalary -
                (empleado.GrossSalary * afpSeleccionada.DiscountPercentage + empleado.GrossSalary * saludSeleccionada.DiscountPercentage));
            return empleado.NetSalary;
        }
        
    }
}

