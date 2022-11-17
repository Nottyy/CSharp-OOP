using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Entities;
using PlanetWars.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planetRepository;

        public Controller()
        {
            this.planetRepository = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (this.planetRepository.Models.Any(o => o.Name == planetName))
            {
                if (unitTypeName != MilitaryUnitsTypes.AnonymousImpactUnit.ToString() || 
                    unitTypeName != MilitaryUnitsTypes.StormTroopers.ToString() ||
                    unitTypeName != MilitaryUnitsTypes.SpaceForces.ToString())
                {
                    throw new InvalidOperationException(String.Format(Utilities.Messages.ExceptionMessages.ItemNotAvailable, unitTypeName));
                }
                else
                {
                    var planet = this.planetRepository.Models.FirstOrDefault(o => o.Name == planetName);

                    if (planet.Army.Any(o => o.GetType().Name == unitTypeName))
                    {
                        throw new InvalidOperationException(String.Format(Utilities.Messages.ExceptionMessages.UnitAlreadyAdded,
                            unitTypeName, planetName));
                    }else
                    {
                        switch (unitTypeName)
                        {
                            case "SpaceForces":

                            default:
                                break;
                        }
                    }
                }
            }
            else
            {
                throw new InvalidOperationException(String.Format(Utilities.Messages.ExceptionMessages.UnexistingPlanet, planetName));
            }
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            throw new NotImplementedException();
        }

        public string CreatePlanet(string name, double budget)
        {
            if (this.planetRepository.Models.Any(o => o.Name == name))
            {
                return String.Format("Planet {0} is already added!", name);
            }
            else
            {
                this.planetRepository.AddItem(new Planet(name, budget));
                return String.Format("Successfully added Planet: {0}", name);
            }
        }

        public string ForcesReport()
        {
            throw new NotImplementedException();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            throw new NotImplementedException();
        }

        public string SpecializeForces(string planetName)
        {
            throw new NotImplementedException();
        }
    }
}
