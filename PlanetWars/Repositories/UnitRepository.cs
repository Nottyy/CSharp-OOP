using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> militaryUnits;
        public UnitRepository()
        {
            this.militaryUnits = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models { 
            get { return this.militaryUnits; } 
        }

        public void AddItem(IMilitaryUnit model)
        {
            this.militaryUnits.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return this.militaryUnits.FirstOrDefault(o => o.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return this.militaryUnits.Remove(this.FindByName(name));
        }
    }
}
