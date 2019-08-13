using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle:Gun
    {
        private int currentBulletInBarrel;
        //Rifle
        //    Has 50 bullets per barrel and 500 total bullets.

        public Rifle(string name) 
            : base(name, 50, 500)
        {
        }
        public override int Fire()
        {
            int howMuchToFire = 5;
            if (currentBulletInBarrel == 0)
            {
                currentBulletInBarrel += BulletsPerBarrel;
                TotalBullets -= BulletsPerBarrel;
            }
            else
            {
                currentBulletInBarrel -= howMuchToFire;
            }

            return howMuchToFire;
        }
        //int Fire()
        //The rifle can shoot with 5 bullets.

    }
}
