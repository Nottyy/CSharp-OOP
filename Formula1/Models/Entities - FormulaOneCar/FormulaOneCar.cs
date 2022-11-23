using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models.Entities
{
    internal abstract class FormulaOneCar : IFormulaOneCar
    {
        private const int _minModelChars = 3;

        private const int _minHorsepower = 900;
        private const int _maxHorsepower = 1050;

        private const double _minEngineDisplacement = 1.60;
        private const double _maxEngineDisplacement = 2.00;

        private string model;
        private int horsepower;
        private double engineDisplacement;

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            if (String.IsNullOrEmpty(model) || model.Length < _minModelChars)
            {
                throw new ArgumentException(String.Format(Utilities.ExceptionMessages.InvalidF1CarModel, model));
            }

            this.model = model;

            if (horsepower < _minHorsepower || horsepower > _maxHorsepower)
            {
                throw new ArgumentException(String.Format(Utilities.ExceptionMessages.InvalidF1HorsePower, horsepower));
            }

            this.horsepower = horsepower;

            if (engineDisplacement < _minEngineDisplacement || engineDisplacement > _maxEngineDisplacement)
            {
                throw new ArgumentException(String.Format(Utilities.ExceptionMessages.InvalidF1EngineDisplacement, engineDisplacement));
            }

            this.engineDisplacement = engineDisplacement;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
        }

        public int Horsepower
        {
            get
            {
                return this.horsepower;
            }
        }

        public double EngineDisplacement
        {
            get
            {
                return this.engineDisplacement;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            return this.engineDisplacement / this.horsepower * laps;
        }
    }
}
