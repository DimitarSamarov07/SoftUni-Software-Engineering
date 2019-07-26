﻿using System;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players.Classes
{
    public abstract class Player:IPlayer
    {
        private string username;
        private int health;
        private ICardRepository cardRepository;

        public Player(ICardRepository cardRepository, string username, int health )
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }
        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string. ");
                }

                username = value;
            }
        }

        public int Health
        {
            get => health;
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero. ");
                }

                health = value;
            }
        }

        public ICardRepository CardRepository
        {
            get => cardRepository;
            set => cardRepository = value;
        }

        public bool IsDead { get; set; }

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }
            if (Health-damagePoints>0)
            {
                Health -= damagePoints;
            }
            else
            {
                Health = 0;
                IsDead = true;
            }
        }
    }
}
