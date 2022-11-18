using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.MilitaryUnits.Entities;
using PlanetWars.Models.Planets.Entities;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Models.Weapons.Entities;
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
            var planet = this.planetRepository.Models.FirstOrDefault(o => o.Name == planetName);

            if (planet != null)
            {
                if (unitTypeName != MilitaryUnitsTypes.AnonymousImpactUnit.ToString() || 
                    unitTypeName != MilitaryUnitsTypes.StormTroopers.ToString() ||
                    unitTypeName != MilitaryUnitsTypes.SpaceForces.ToString())
                {
                    throw new InvalidOperationException(String.Format(Utilities.Messages.ExceptionMessages.ItemNotAvailable, unitTypeName));
                }
                else
                {

                    if (planet.Army.Any(o => o.GetType().Name == unitTypeName))
                    {
                        throw new InvalidOperationException(String.Format(Utilities.Messages.ExceptionMessages.UnitAlreadyAdded,
                            unitTypeName, planetName));
                    }else
                    {
                        switch (unitTypeName)
                        {
                            case "AnonymousImpactUnit":
                                planet.AddUnit(new AnonymousImpactUnit());
                                break;
                            case "SpaceForces":
                                planet.AddUnit(new SpaceForces());
                                break;
                            case "StormTroopers":
                                planet.AddUnit(new StormTroopers());
                                break;
                        }

                        return String.Format("{0} added successfully to the Army of {1}!", unitTypeName, planetName);
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
            var planet = this.planetRepository.Models.FirstOrDefault(o => o.Name == planetName);

            if (planet != null)
            {
                if (weaponTypeName != WeaponTypes.NuclearWeapon.ToString() ||
                    weaponTypeName != WeaponTypes.SpaceMissiles.ToString() ||
                    weaponTypeName != WeaponTypes.BioChemicalWeapon.ToString())
                {
                    throw new InvalidOperationException(String.Format(Utilities.Messages.ExceptionMessages.ItemNotAvailable, weaponTypeName));
                }
                else
                {
                    if (planet.Weapons.Any(o => o.GetType().Name == weaponTypeName))
                    {
                        throw new InvalidOperationException(String.Format(Utilities.Messages.ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
                    }
                    else
                    {
                        switch (weaponTypeName)
                        {
                            case "NuclearWeapon":
                                planet.AddWeapon(new NuclearWeapon(destructionLevel));
                                break;
                            case "BioChemicalWeapon":
                                planet.AddWeapon(new BioChemicalWeapon(destructionLevel));
                                break;
                            case "SpaceMissiles":
                                planet.AddWeapon(new SpaceMissiles(destructionLevel));
                                break;
                        }

                        return String.Format(Utilities.Messages.ExceptionMessages.WeaponAdded, planetName, weaponTypeName);
                    }
                }
            }
            else
            {
                throw new InvalidOperationException(String.Format(Utilities.Messages.ExceptionMessages.UnexistingPlanet, planetName));
            }
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
