using CarWash.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Core.Logic
{
    public class CarWashService
    {
        private readonly List<CarWashSlot> _slots;
        private readonly CarQueue _queue = new();
        private int _totalMinutesWorked = 0;
        private int _carsServed = 0;

        public CarWashService(int slotCount)
        {
            _slots = Enumerable.Range(0, slotCount)
                               .Select(_ => new CarWashSlot())
                               .ToList();
        }

        public void AddCar(ICar car) => _queue.Enqueue(car);

        public void Tick()
        {
            foreach (var slot in _slots)
            {
                var time = slot.Tick();
                _totalMinutesWorked += time;

                if (time > 0)
                    _carsServed++;
            }

            foreach (var slot in _slots.Where(s => s.IsFree))
            {
                if (_queue.HasCars)
                {
                    var nextCar = _queue.Dequeue();
                    slot.AssignCar(nextCar!);
                    var time = slot.Tick();
                    _totalMinutesWorked += time;
                }
            }
        }

        public bool IsProcessing => _slots.Any(s => !s.IsFree) || _queue.HasCars;

        public int TotalEarnings => _totalMinutesWorked * 30;
        public int TotalProcessedMinutes => _totalMinutesWorked;
        public int QueueLength => _queue.Count;
        public int TotalCarsServed => _carsServed;
    }

}
