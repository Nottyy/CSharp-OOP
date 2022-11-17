namespace PlanetWars.Models.MilitaryUnits.Entities
{
    public class SpaceForces : MilitaryUnit
    {
        private const double _spaceForcesCost = 11;
        public SpaceForces() : base(_spaceForcesCost)
        {
        }
    }
}