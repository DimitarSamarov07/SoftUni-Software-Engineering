using System;
using System.Collections.Generic;
using System.Text;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private string name;

        public Rider(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }
        public int NumberOfWins { get; private set; }
        public bool CanParticipate { get; private set; } = false;
        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            Motorcycle = motorcycle ?? throw new ArgumentNullException("Motorcycle cannot be null.");
            CanParticipate = true;
        }
        public void WinRace()
        {
            NumberOfWins++;
        }

    }
}
