using System;
using System.Collections.Generic;
using System.Text;

namespace Speed_Racing
{
    class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKm { get; set; }

        public double TravelledDistance { get; set; }

        private string model;

        private double fuelAmount;

        private double fuelConsumptionPerKm;

        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionPerKm = fuelConsumptionPerKm;
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }
        /// <summary>
        /// Moves the car 
        /// </summary>
        /// <param name="model">Model of the car</param>
        /// <param name="amountOfKm">The amount of km traveled</param>
        
    }
}
