using Formula1.Core.Contracts;
using Formula1.Models.Contracts;
using Formula1.Models.Entities;
using Formula1.Models.Entities___Pilot;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Core
{
    internal class Controller : IController
    {
        private IRepository<IFormulaOneCar> formulaOneCarRepository;
        private IRepository<IPilot> pilotRepository;
        private IRepository<IRace> raceRepository;

        public Controller()
        {
            this.formulaOneCarRepository = new FormulaOneCarRepository();
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            throw new NotImplementedException();
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            throw new NotImplementedException();
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            var car = this.formulaOneCarRepository.Models.FirstOrDefault(o => o.Model == model);

            if (car != null)
            {
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.CarExistErrorMessage, model));
            }

            IFormulaOneCar newCar;

          
            if (type == "Ferrari")
            {
                newCar = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if(type == "Williams")
            {
                newCar = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.InvalidTypeCar, type));
            }

            return String.Format(Utilities.ExceptionMessages.CarCreated, type, model);
        }

        public string CreatePilot(string fullName)
        {
            var pilot = this.pilotRepository.Models.FirstOrDefault(o => o.FullName == fullName);
            
            if (pilot == null)
            {
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            this.pilotRepository.Add(new Pilot(fullName));

            return String.Format(Utilities.ExceptionMessages.PilotCreated, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            throw new NotImplementedException();
        }

        public string PilotReport()
        {
            throw new NotImplementedException();
        }

        public string RaceReport()
        {
            throw new NotImplementedException();
        }

        public string StartRace(string raceName)
        {
            throw new NotImplementedException();
        }
    }
}
