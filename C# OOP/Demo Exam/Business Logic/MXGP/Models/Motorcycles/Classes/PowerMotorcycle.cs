using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles.Classes
{
    public class PowerMotorcycle:Motorcycle
    {
        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower,450)
        {
        }

        protected override double MinimumHorsePower { get; set; } = 70;
        protected override double MaximumHorsePower { get; set; } = 100;
    }
}
