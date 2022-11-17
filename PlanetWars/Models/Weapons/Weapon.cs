using PlanetWars.Models.Weapons.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destructionLevel;

        public Weapon(int destructionLevel, double price)
        {
            if (destructionLevel < 1)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.TooLowDestructionLevel);
            }
            else if (destructionLevel > 10)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.TooHighDestructionLevel);
            }

            this.DestructionLevel = destructionLevel;
            this.Price = price;
        }
        public double Price { 
            get { return this.price; }
            private set { this.price = value; }
        }

        public int DestructionLevel {
            get { return this.destructionLevel; }
            private set { this.DestructionLevel = value; }
        }

    }
}
