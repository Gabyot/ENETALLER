using System;
namespace ENETALLER.app.data.model
{
    public class Health
    {
        public string Name { get; set; }
        public double DiscountPercentage { get; set; }

        public Health(string name, double discountPercentage)
        {
            Name = name;
            DiscountPercentage = discountPercentage;
        }

        
    }
}

