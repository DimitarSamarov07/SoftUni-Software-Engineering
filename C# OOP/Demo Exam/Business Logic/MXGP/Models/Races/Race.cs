using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;

namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IRider> riders;

        public Race(string name,int laps)
        {
            riders = new List<IRider>();
            this.Name = name;
            this.Laps = laps;
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

        public int Laps
        {
            get => laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");
                }

                laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders
        {
            get => riders;
        }

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException("Rider cannot be null.");
            }

            if (!rider.CanParticipate)
            {
                throw new ArgumentException($"Rider {rider.Name} could not participate in race.");
            }

            if (Riders.Contains(rider))
            {
                throw new ArgumentNullException($"Rider {rider.Name} is already added in {Name} race.");
            }
            riders.Add(rider);
        }
    }
}
