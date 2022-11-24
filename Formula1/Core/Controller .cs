using Formula1.Core.Contracts;
using Formula1.Models.Contracts;
using Formula1.Models.Entities;
using Formula1.Models.Entities___Pilot;
using Formula1.Models.Entities___Race;
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
            var pilot = this.pilotRepository.FindByName(pilotName);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            var car = this.formulaOneCarRepository.FindByName(carModel);

            if (car == null)
            {
                throw new NullReferenceException(String.Format(Utilities.ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            this.formulaOneCarRepository.Remove(car);

            return String.Format(Utilities.ExceptionMessages.CarAddedToPilot, pilotName, car.GetType().Name, carModel);
        }

        //private bool checkIfCarExists(string carModel, IRepository<IFormulaOneCar> carsRepository)
        //{
        //    return carsRepository.Models.Any(o => o.Model == carModel) ? true : false;
        //}

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = this.raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(String.Format(Utilities.ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            var pilot = this.pilotRepository.FindByName(pilotFullName);

            if (pilot == null || !pilot.CanRace || race.Pilots.Any(o => o.FullName == pilotFullName))
            {
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);

            return String.Format(Utilities.ExceptionMessages.PilotAddedToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            var car = this.formulaOneCarRepository.FindByName(model);

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
            var pilot = this.pilotRepository.FindByName(fullName);
            
            if (pilot == null)
            {
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            this.pilotRepository.Add(new Pilot(fullName));

            return String.Format(Utilities.ExceptionMessages.PilotCreated, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var race = this.raceRepository.FindByName(raceName);
            
            if (race != null)
            {
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            this.raceRepository.Add(new Race(raceName, numberOfLaps));

            return String.Format(Utilities.ExceptionMessages.RaceCreated, raceName);
        }

        public string PilotReport()
        {
            var sb = new StringBuilder();

            foreach (var pilot in this.pilotRepository.Models)
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString();
        }

        public string RaceReport()
        {
            var sb = new StringBuilder();

            foreach (var race in this.raceRepository.Models)
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString();
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(String.Format(Utilities.ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(String.Format(Utilities.ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            IPilot[] top3pilots = this.pilotRepository.Models.OrderByDescending(o => o.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).ToArray();

            var sb = new StringBuilder();
            sb.AppendLine(String.Format(Utilities.OutputMessages.PilotFirstPlace, top3pilots[0].FullName, race.RaceName));
            sb.AppendLine(String.Format(Utilities.OutputMessages.PilotSecondPlace, top3pilots[1].FullName, race.RaceName));
            sb.AppendLine(String.Format(Utilities.OutputMessages.PilotThirdPlace, top3pilots[2].FullName, race.RaceName));

            race.TookPlace = true;
            top3pilots[0].WinRace();

            return sb.ToString();
        }
    }
}
