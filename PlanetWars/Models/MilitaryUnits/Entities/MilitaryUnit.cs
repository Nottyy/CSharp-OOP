using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits.Entities
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private const int _initialValueEnduranceLevel = 1;
        private const int _incrementEnduranceLevelPowerPoints = 1;
        private double cost;
        private int enduranceLevel;

        public MilitaryUnit(double cost)
        {
            this.cost = cost;
            enduranceLevel = _initialValueEnduranceLevel;
        }
        public double Cost
        {
            get { return this.cost; }
            private set { this.cost = value; }
        }

        public int EnduranceLevel
        {
            get { return enduranceLevel; }
            private set { enduranceLevel = value; }
        }

        public void IncreaseEndurance()
        {
            if (EnduranceLevel >= 20)
            {
                EnduranceLevel = 20;
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.EnduranceLevelExceeded);
            }
            else
            {
                EnduranceLevel += _incrementEnduranceLevelPowerPoints;
            }
        }
    }
}
