using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits.Entities
{
    public class AnonymousImpactUnit : MilitaryUnit
    {
        private const double _anonymousImpactUnitCost = 30;
        public AnonymousImpactUnit() : base(_anonymousImpactUnitCost)
        {
        }
    }
}
