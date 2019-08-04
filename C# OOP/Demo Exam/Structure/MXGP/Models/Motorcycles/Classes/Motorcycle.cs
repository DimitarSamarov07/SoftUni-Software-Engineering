using System;
using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Models.Motorcycles.Classes
{
    public abstract class Motorcycle : IMotorcycle
    {
        private string model;
        private int horsePower;

        public Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }
        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }

                model = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (value < MinimumHorsePower || value > MaximumHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                horsePower = value;
            }
        }

        public double CubicCentimeters { get; }
        public virtual double MinimumHorsePower { get; set; } = 0;
        public virtual double MaximumHorsePower { get; set; } = 1000;
        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
