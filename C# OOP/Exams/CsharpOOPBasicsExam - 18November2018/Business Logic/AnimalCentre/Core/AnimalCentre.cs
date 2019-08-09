using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalCentre.Core.Factories;
using AnimalCentre.Models;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Procedures;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        public AnimalCentre()
        {
            Hotel = new Hotel();
            ChipServices = new Chip();
            DentalServices = new DentalCare();
            NailTrimServices = new NailTrim();
            PlayServices = new Play();
            VaccinateServices = new Vaccinate();
        }
        private Hotel Hotel { get; set; }
        private Procedure ChipServices { get; set; }
        private Procedure DentalServices { get; set; }
        private Procedure FitnessServices { get; set; }
        private Procedure NailTrimServices { get; set; }
        private Procedure PlayServices { get; set; }
        private Procedure VaccinateServices { get; set; }
        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            if (Hotel.Animals.Any(x => x.Key == name))
            {
                throw new ArgumentException($"Animal {name} already exist");
            }
            AnimalFactory fact = new AnimalFactory();
            IAnimal toAdd = fact.MakeAnimal(type, name, energy, happiness, procedureTime);
            Hotel.Accommodate(toAdd);
            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            IAnimal animalToChip = Hotel.Animals.FirstOrDefault(x => x.Key == name).Value;
            if (animalToChip == null)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            ChipServices.DoService(animalToChip,procedureTime);
            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            IAnimal animalToVaccinate = Hotel.Animals.FirstOrDefault(x => x.Key == name).Value;
            if (animalToVaccinate == null)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            VaccinateServices.DoService(animalToVaccinate,procedureTime);
            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            IAnimal animalToGoToFitness = Hotel.Animals.FirstOrDefault(x => x.Key == name).Value;
            if (animalToGoToFitness == null)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            FitnessServices.DoService(animalToGoToFitness,procedureTime);
            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            IAnimal animalToPlay = Hotel.Animals.FirstOrDefault(x => x.Key == name).Value;
            if (animalToPlay == null)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            PlayServices.DoService(animalToPlay,procedureTime);
            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            IAnimal animalToBeDentalCared = Hotel.Animals.FirstOrDefault(x => x.Key == name).Value;
            if (animalToBeDentalCared == null)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            DentalServices.DoService(animalToBeDentalCared,procedureTime);
            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            IAnimal animalToTrim = Hotel.Animals.FirstOrDefault(x => x.Key == name).Value;
            if (animalToTrim == null)
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            NailTrimServices.DoService(animalToTrim,procedureTime);
            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            IAnimal animalToAdopt = Hotel.Animals.FirstOrDefault(x => x.Key == animalName).Value;
            if (animalToAdopt == null)
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            Hotel.Adopt(animalName,owner);
            if (animalToAdopt.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }

            return $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            StringBuilder sb = new StringBuilder();
            if (type=="Chip")
            {
                sb.AppendLine(ChipServices.History());
            }
            if (type=="Vaccinate")
            {
                sb.AppendLine(VaccinateServices.History());
            }
            if (type=="Fitness")
            {
                sb.AppendLine(FitnessServices.History());
            }
            if (type=="Play")
            {
                sb.AppendLine(PlayServices.History());
            }
            if (type=="DentalCare")
            {
                sb.AppendLine(DentalServices.History());
            }
            if (type=="NailTrim")
            {
                sb.AppendLine(NailTrimServices.History());
            }

            return sb.ToString();
        }

    }
}
