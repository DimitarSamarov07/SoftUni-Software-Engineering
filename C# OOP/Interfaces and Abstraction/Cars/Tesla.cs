using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla:ICar,IElectricCar
    {
        private int battery;
        private string color;
        private string model;

        public Tesla(string model,string color,int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public string Model
        {
            get => model;
            set => model = value;
        }

        public string Color
        {
            get => color;
            set => color = value;
        }

        public int Battery
        {
            get => battery;
            set => battery = value;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Battery} Batteries";
        }
    }
}
