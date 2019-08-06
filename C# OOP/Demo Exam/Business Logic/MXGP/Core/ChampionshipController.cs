using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using MXGP.Core.Contracts;
using MXGP.Core.Factories;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        public ChampionshipController()
        {
            RiderRepo = new RiderRepository();
            MotoRepo = new MotorcycleRepository();
            RaceRepo = new RaceRepository();
        }
        private RiderRepository RiderRepo;
        private MotorcycleRepository MotoRepo;
        private RaceRepository RaceRepo;
        public string CreateRider(string riderName)
        {
            if (RiderRepo.GetAll().All(x => x.Name != riderName))
            {
                IRider rider = new Rider(riderName);
                RiderRepo.Add(rider);
                return $"Rider {riderName} is created.";
            }

            throw new ArgumentException($"Rider {riderName} is already created.");
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            MotorcycleFactory fact = new MotorcycleFactory();
            IMotorcycle moto = fact.CreateMotorcycle(type, model, horsePower);
            if (MotoRepo.GetAll().All(x => x.Model != moto.Model))
            {
                MotoRepo.Add(moto);
                return $"{moto.GetType().Name} {model} is created.";
            }
            throw new ArgumentException($"Motorcycle {model} is already created.");
        }

        public string CreateRace(string name, int laps)
        {
            if (RaceRepo.GetAll().All(x => x.Name != name))
            {
                IRace race = new Race(name,laps);
                RaceRepo.Add(race);
                return $"Race {name} is created.";
            }
            throw new InvalidOperationException($"Race {name} is already created.");
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            if (RaceRepo.GetAll().All(x => x.Name != raceName))
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (RiderRepo.GetAll().All(x => x.Name != riderName))
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            IRace race = RaceRepo.GetByName(raceName);
            IRider rider = RiderRepo.GetByName(riderName);
            race.AddRider(rider);
            return $"Rider {riderName} added in {raceName} race.";
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            if (RiderRepo.GetAll().All(x => x.Name != riderName))
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            if (MotoRepo.GetAll().All(x => x.Model != motorcycleModel))
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            IRider rider = RiderRepo.GetByName(riderName);
            IMotorcycle moto = MotoRepo.GetByName(motorcycleModel);
            rider.AddMotorcycle(moto);
            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string StartRace(string raceName)
        {
            StringBuilder sb = new StringBuilder();
            if (RaceRepo.GetAll().All(x => x.Name != raceName))
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            IRace race = RaceRepo.GetByName(raceName);
            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            Dictionary<string, double> dictOfResults = new Dictionary<string, double>();
            foreach (var rider in race.Riders)
            {
                dictOfResults.Add(rider.Name, rider.Motorcycle.CalculateRacePoints(race.Laps));
            }

            int counter = 0;
            foreach (var result in dictOfResults.OrderByDescending(x => x.Value))
            {
                if (counter == 0)
                {
                    sb.AppendLine($"Rider {result.Key} wins {raceName} race.");
                    counter++;
                }
                else if (counter == 1)
                {
                    sb.AppendLine($"Rider {result.Key} is second in {raceName} race.");
                    counter++;
                }
                else if (counter == 2)
                {
                    sb.AppendLine($"Rider {result.Key} is third in {raceName} race.");
                    break;
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
