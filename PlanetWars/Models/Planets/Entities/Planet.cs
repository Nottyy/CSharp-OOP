using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace PlanetWars.Models.Planets.Entities
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private WeaponRepository weaponRepository;
        private UnitRepository unitRepository;

        public Planet (string name, double budget)
        {
            this.weaponRepository = new WeaponRepository();
            this.unitRepository = new UnitRepository();

            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPlanetName);
            }

            this.name = name;

            if (budget < 0)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidBudgetAmount);
            }

            this.budget = budget;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public double Budget {
            get
            {
                return this.budget;
            }
            private set
            {
                this.budget = value;
            }
        }

        public double MilitaryPower
        {
            get
            {
                return this.CalculateMilitaryPower(this.weaponRepository, this.unitRepository);
            }
        }

        private double CalculateMilitaryPower(WeaponRepository weapons, UnitRepository army)
        {
            double sum = weapons.Models.Sum(o => o.DestructionLevel) +
                                army.Models.Sum(o => o.EnduranceLevel);

            if (army.Models.Any(o => o.GetType().Name == "AnonymousImpactUnit"))
            {
                sum = (sum * 0.3) + sum;
            }

            if (weapons.Models.Any(o => o.GetType().Name == "NuclearWeapon "))
            {
                sum = (sum * 0.45) + sum;
            }

            return Math.Round(sum, 3);
        }

        public IReadOnlyCollection<IMilitaryUnit> Army
        {
            get
            {
                return this.unitRepository.Models;
            }
        }

        public IReadOnlyCollection<IWeapon> Weapons
        {
            get
            {
                return this.weaponRepository.Models;
            }
        }

        public void AddUnit(IMilitaryUnit unit)
        {
            this.unitRepository.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weaponRepository.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine(String.Format("Planet: {0}", this.Name));
            sb.AppendLine(String.Format("--Budget: {0} billion QUID", this.Budget));
            
            sb.AppendLine("--Forces: ");
            if (this.unitRepository.Models.Count() > 0)
            {
                foreach (var item in this.unitRepository.Models)
                {
                    sb.Append(String.Format(", {0}", item.GetType().Name));
                }
            }
            else
            {
                sb.Append(" No units");
            }

            sb.AppendLine("--Combat equipment: ");
            if (this.weaponRepository.Models.Count() > 0)
            {
                foreach (var item in this.weaponRepository.Models)
                {
                    sb.Append(String.Format(", {0}", item.GetType().Name));
                }
            }
            else
            {
                sb.Append(" No weapons");
            }

            sb.AppendLine(String.Format("--Military Power: {0}", this.MilitaryPower));

            return sb.ToString();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > this.Budget)
            {
                throw new InvalidOperationException(Utilities.Messages.ExceptionMessages.UnsufficientBudget);
            }
            else
            {
                this.Budget -= amount;
            }
        }

        public void TrainArmy()
        {
            foreach (var item in this.Army)
            {
                item.IncreaseEndurance();
            }
        }
    }
}
