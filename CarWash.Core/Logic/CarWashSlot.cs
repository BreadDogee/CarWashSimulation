using CarWash.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Core.Logic
{
    public class CarWashSlot
    {
        public ICar? CurrentCar { get; private set; }
        public int TimeRemaining { get; private set; } = 0;

        public bool IsFree => TimeRemaining == 0;

        public void AssignCar(ICar car)
        {
            CurrentCar = car;
            TimeRemaining = car.WashTime;
        }

        public int Tick()
        {
            if (TimeRemaining > 0)
            {
                TimeRemaining--;
                if (TimeRemaining == 0)
                {
                    CurrentCar = null;
                }
                return 1;
            }

            return 0;
        }
    }

}
