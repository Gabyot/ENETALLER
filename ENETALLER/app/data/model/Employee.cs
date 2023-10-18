using System;
namespace ENETALLER.app.data.model
{
    public class Employee : User
    {
        public string RUT { get; set; }
        public int HourValue { get; set; }
        public int ExtraValue { get; set; }
        public double GrossSalary { get; set; }
        public int NetSalary { get; set; }

        public virtual AFP AFP { get; set; }
        public virtual Health Health { get; set; }

        public Employee(string name, string email, string password, string permissions,
        string address, string phone, string rut, AFP aFP, Health health, int hourValue,
        int extraValue, int grossSalary, int netSalary)
        : base(name, email, password, permissions, address, phone)
        {
            RUT = rut;
            AFP = aFP;
            Health = health;
            HourValue = hourValue;
            ExtraValue = extraValue;
            GrossSalary = grossSalary;
            NetSalary = netSalary;
        }        
    }
}

