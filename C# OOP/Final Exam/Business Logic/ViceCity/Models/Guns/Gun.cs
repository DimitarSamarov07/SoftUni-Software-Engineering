using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or a white space!");
                }

                name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get => bulletsPerBarrel;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below zero!");
                }

                bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get => totalBullets;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total bullets cannot be below zero!");
                }

                totalBullets = value;
            }
        }

        public bool CanFire
        {
            get => TotalBullets > 0;
        }
        //    •	Name – string 
        //    o	If the name of the gun is null or empty, throw an ArgumentException with message:
        //"Name cannot be null or a white space!"
        //o	All names are unique
        //•	BulletsPerBarrel – int
        //    o	If the bullets are below zero, throw an ArgumentException with message:
        //"Bullets cannot be below zero!"
        //o	The initial BulletsPerBarrel count is the actual capacity of the barrel!
        //•	TotalBullets - int 
        //    o	If the total bullets are below zero, throw an ArgumentException with message:
        //"Total bullets cannot be below zero!"
        //•	CanFire – calculated property, which returns bool

        public abstract int Fire();

    }
}
