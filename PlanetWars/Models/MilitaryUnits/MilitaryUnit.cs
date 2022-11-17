using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private const int _initialValueEnduranceLevel = 1;
        private const int _incrementEnduranceLevelPowerPoints = 1;
        private double cost;
        private int enduranceLevel;

        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.enduranceLevel = _initialValueEnduranceLevel;
        }
        public double Cost { 
            get { return this.Cost; }
            private set { this.cost = value; }
        }

        public int EnduranceLevel { 
            get { return this.enduranceLevel; }
            private set { this.enduranceLevel = value; }
        }

        public void IncreaseEndurance()
        {
            if (this.EnduranceLevel >= 20)
            {
                this.EnduranceLevel = 20;
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.EnduranceLevelExceeded);
            }
            else
            {
                this.EnduranceLevel += _incrementEnduranceLevelPowerPoints;
            }
        }
    }
}
