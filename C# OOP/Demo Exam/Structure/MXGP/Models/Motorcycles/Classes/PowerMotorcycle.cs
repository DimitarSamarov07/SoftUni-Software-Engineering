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

        public override double MinimumHorsePower { get; set; } = 70;
        public override double MaximumHorsePower { get; set; } = 100;
    }
}
