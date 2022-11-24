using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models.Entities___Pilot
{
    internal class Pilot : IPilot
    {
        private const int _pilotMinCharFullname = 5;

        private string fullName;
        private bool canRace;
        private int numberOfWins;
        private IFormulaOneCar car;

        public Pilot(string fullName)
        {
            if (String.IsNullOrEmpty(fullName) || fullName.Length < _pilotMinCharFullname)
            {
                throw new ArgumentException(String.Format(Utilities.ExceptionMessages.InvalidPilot, fullName));
            }

            this.fullName = fullName;
            this.canRace = false;
            this.numberOfWins = 0;
        }
        public string FullName
        {
            get
            {
                return this.fullName;
            }
        }

        public IFormulaOneCar Car
        {
            get
            {
                //if (this.car == null)
                //{
                //    throw new NullReferenceException(Utilities.ExceptionMessages.InvalidCarForPilot);
                //}

                return this.car;
            }
        }

        public int NumberOfWins
        {
            get
            {
                return this.numberOfWins;
            }
        }

        public bool CanRace
        {
            get
            {
                return this.canRace;
            }
        }

        public void AddCar(IFormulaOneCar car)
        {
            this.car = car;
            this.canRace = true;
        }

        public void WinRace()
        {
            this.numberOfWins += 1;
        }

        public override string ToString()
        {
            return String.Format(Utilities.OutputMessages.PilotWins, this.fullName, this.numberOfWins);
        }
    }
}
