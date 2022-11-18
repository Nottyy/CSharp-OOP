using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.MilitaryUnits.Entities;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Planets.Entities;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Models.Weapons.Entities;
using PlanetWars.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            IPlanet planet1 = this.planetRepository.Models.FirstOrDefault(o => o.Name == planetOne);
            IPlanet planet2 = this.planetRepository.Models.FirstOrDefault(o => o.Name == planetTwo);
            IPlanet winner;
            IPlanet loser;

            if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                winner = planet1;
                loser = planet2;
            }
            else if(planet1.MilitaryPower < planet2.MilitaryPower)
            {
                winner = planet2;
                loser = planet1;
            }
            else
            {
                bool planet1HasNuclear = HasNuclearWeapon(planet1);
                bool planet2HasNuclear = HasNuclearWeapon(planet2);

                if ((planet1HasNuclear && planet2HasNuclear) || 
                    (!planet1HasNuclear && !planet2HasNuclear))
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);

                    return Utilities.Messages.ExceptionMessages.NoCombatWinners;
                }
                else if (planet1HasNuclear && !planet2HasNuclear)
                {
                    winner = planet1;
                    loser = planet2;
                }
                else(!planet1HasNuclear && planet2HasNuclear)
                {
                    winner = planet2;
                    loser = planet1;
                }
            }

            return SpaceCombatResult(winner, loser, planetRepository);
        }

        private bool HasNuclearWeapon(IPlanet planet)
        {
            return planet.Weapons.Any(o => o.GetType().Name == "NuclearWeapon") ? true : false;
        }

        private string SpaceCombatResult(IPlanet winner, IPlanet loser, PlanetRepository planets)
        {
            winner.Spend(winner.Budget / 2);
            winner.Profit((loser.Budget / 2) + loser.Army.Sum(o => o.Cost) + loser.Weapons.Sum(o => o.Price));
            planets.RemoveItem(loser.Name);

            return String.Format(Utilities.Messages.ExceptionMessages.CombatResult, winner.Name, loser.Name);
        }

        public string SpecializeForces(string planetName)
        {
            throw new NotImplementedException();
        }
    }
}
