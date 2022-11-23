namespace Formula1.Models.Contracts
{
    using System.Collections.Generic;
    public interface IRace
    {
        string RaceName { get; }

        int NumberOfLaps { get; }

        bool TookPlace { get; set; }

        ICollection<IPilot> Pilots { get; }

        void AddPilot(IPilot pilot);

        string RaceInfo();
    }
}
