using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models.Entities___Race
{
    internal class Race : IRace
    {
        private const int _minCharRaceName = 5;

        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;

        private ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            if (String.IsNullOrEmpty(raceName) || raceName.Length < _minCharRaceName)
            {
                throw new ArgumentException(String.Format(Utilities.ExceptionMessages.InvalidRaceName, raceName));
            }

            this.raceName = raceName;

            if (numberOfLaps < 1)
            {
                throw new ArgumentException(String.Format(Utilities.ExceptionMessages.InvalidLapNumbers, numberOfLaps));
            }

            this.numberOfLaps = numberOfLaps;
            this.tookPlace = false;
            this.pilots = new List<IPilot>();
        }
        public string RaceName
        {
            get
            {
                return this.raceName;
            }
        }

        public int NumberOfLaps
        {
            get
            {
                return this.numberOfLaps;
            }
        }

        public bool TookPlace
        {
            get
            {
                return this.tookPlace;
            }
            set
            {
                this.tookPlace = value;
            }
        }

        public ICollection<IPilot> Pilots
        {
            get
            {
                return this.pilots;
            }
        }

        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine(String.Format("The {0} race has:", this.raceName));
            sb.AppendLine(String.Format("Participants: {0}", this.pilots.Count));
            sb.AppendLine(String.Format("Number of laps: {0}", this.numberOfLaps));
            sb.AppendLine(String.Format("Took place: {0}", this.tookPlace ? "Yes" : "No"));

            return sb.ToString();
        }
    }
}
