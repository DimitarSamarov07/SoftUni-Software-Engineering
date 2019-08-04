using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles.Classes
{
    public class SpeedMotorcycle:Motorcycle
    {
        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, 125)
        {
        }

        public override double MinimumHorsePower { get; set; } = 50;
        public override double MaximumHorsePower { get; set; } = 69;
    }
}
