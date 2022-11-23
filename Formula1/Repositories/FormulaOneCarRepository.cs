using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Repositories
{
    internal class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private ICollection<IFormulaOneCar> cars;

        public FormulaOneCarRepository()
        {
            this.cars = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models
        {
            get
            {
                return (IReadOnlyCollection<IFormulaOneCar>)this.cars;
            }
        }

        public void Add(IFormulaOneCar model)
        {
            this.cars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return this.cars.FirstOrDefault(o => o.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return this.cars.Remove(model);
        }
    }
}
