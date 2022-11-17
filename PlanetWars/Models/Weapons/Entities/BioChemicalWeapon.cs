﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons.Entities
{
    public class BioChemicalWeapon : Weapon
    {
        private const double _bioChemicalWeaponPrice = 3.2;
        public BioChemicalWeapon(int destructionLevel) : base(destructionLevel, _bioChemicalWeaponPrice)
        {
        }
    }
}
