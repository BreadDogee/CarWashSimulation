using CarWash.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Core.Logic
{
    public class SimulationEngine
    {
        private readonly CarWashService _carWash;
        private readonly Func<int, IEnumerable<ICar>> _carGenerator;

        public SimulationEngine(int slotCount, Func<int, IEnumerable<ICar>> carGenerator)
        {
            _carWash = new CarWashService(slotCount);
            _carGenerator = carGenerator;
        }

        public int TotalEarnings => _carWash.TotalEarnings;
        public int TotalCarsServed => _carWash.TotalCarsServed;

        public void Run(int minutes)
        {
            for (int i = 0; i < minutes; i++)
            {
                foreach (var car in _carGenerator(i))
                {
                    _carWash.AddCar(car);
                }

                _carWash.Tick();
            }

            while (_carWash.IsProcessing)
            {
                _carWash.Tick();
            }
        }
    }

}
