using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Repositories
{
    internal class PilotRepository : IRepository<IPilot>
    {
        private ICollection<IPilot> pilots;

        public PilotRepository()
        {
            this.pilots = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models
        {
            get
            {
                return (IReadOnlyCollection<IPilot>)this.pilots;
            }
        }

        public void Add(IPilot model)
        {
            this.pilots.Add(model);
        }

        public IPilot FindByName(string name)
        {
            return this.pilots.FirstOrDefault(o => o.FullName == name);
        }

        public bool Remove(IPilot model)
        {
            return this.pilots.Remove(model);
        }
    }
}
