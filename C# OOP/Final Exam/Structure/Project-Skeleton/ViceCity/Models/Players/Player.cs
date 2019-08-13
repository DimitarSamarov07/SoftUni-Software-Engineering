using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            GunRepository = new GunRepository(); 
        }


        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name), "Player's name cannot be null or a whitespace!");
                }

                name = value;
            }
        }

        public bool IsAlive
        {
            get { return LifePoints > 0; }
        }

        public IRepository<IGun> GunRepository { get; private set; }

        public int LifePoints
        {
            get => lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }
                lifePoints = value;
            }
        }
        //•	Name – string 
        //    o	If the username is null or whitespace, throw an ArgumentNullException with message: "Player's name cannot be null or a whitespace!"
        //o	All names are unique
        //•	LifePoints –  int
        //    o	The health of а player 
        //    o	If the health is below 0, throw an ArgumentException with message:
        //"Player life points cannot be below zero!"
        //•	GunRepository - IRepository<Gun>
        //    o	Generic repository of all player's guns
        //•	IsAlive – calculated property, which returns bool

        public void TakeLifePoints(int points)
        {
            lifePoints -= points;
            if (LifePoints < 0)
            {
                lifePoints = 0;
            }
        }
        //void TakeLifePoints(int points)
        //The TakeLifePoints method decreases players' life points. 
        //•	Player's life points should not drop below zero

    }
}
