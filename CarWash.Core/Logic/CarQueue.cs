using CarWash.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Core.Logic
{
    public class CarQueue
    {
        private readonly Queue<ICar> _queue = new();

        public void Enqueue(ICar car) => _queue.Enqueue(car);
        public ICar? Dequeue() => _queue.Count > 0 ? _queue.Dequeue() : null;
        public bool HasCars => _queue.Count > 0;
        public int Count => _queue.Count;
    }

}
