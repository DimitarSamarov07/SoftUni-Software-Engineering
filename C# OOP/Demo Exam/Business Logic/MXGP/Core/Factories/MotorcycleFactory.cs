using MXGP.Models.Motorcycles.Classes;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders;


namespace MXGP.Core.Factories
{
    public class MotorcycleFactory
    {
        public MotorcycleFactory()
        {
            
        }

        public IMotorcycle CreateMotorcycle(string type, string model, int horsePower)
        {
            if (type=="Power")
            {
                return new PowerMotorcycle(model,horsePower);
            }
            
            if (type=="Speed")
            {
                return new SpeedMotorcycle(model,horsePower);
            }
            return new PowerMotorcycle("PESHObricka",2);
        }
    }
}
