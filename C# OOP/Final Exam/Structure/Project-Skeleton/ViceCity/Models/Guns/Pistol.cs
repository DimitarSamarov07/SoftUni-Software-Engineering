using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol:Gun
    {
        private int currentBulletInBarrel;
        //Pistol
        //    Has 10 bullets per barrel and 100 total bullets.

        public Pistol(string name) 
            : base(name, 10, 100)
        {
            currentBulletInBarrel = 0;
        }

        public override int Fire()
        {
            int howMuchToFire = 1;
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
        //The pistol shoots only one bullet.

    }
}
