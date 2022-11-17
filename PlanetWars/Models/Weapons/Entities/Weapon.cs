using PlanetWars.Models.Weapons.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons.Entities
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

            DestructionLevel = destructionLevel;
            Price = price;
        }
        public double Price
        {
            get { return price; }
            private set { price = value; }
        }

        public int DestructionLevel
        {
            get { return destructionLevel; }
            private set { this.destructionLevel = value; }
        }

    }
}
