using System;
namespace ENETALLER.app.data.model
{
    public class AFP
    {
        public string Name { get; set; }
        public double DiscountPercentage { get; set; }

        public AFP(string name, double discountPercentage)
        {
            Name = name;
            DiscountPercentage = discountPercentage;
        }

        // Declarar una propiedad estática para AFPArray
        /**/
    }
}
