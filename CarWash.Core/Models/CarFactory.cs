using System;
using System.Collections.Generic;

namespace CarWash.Core.Models
{
    public class CarFactory
    {
        private readonly Dictionary<string, ICarFactory> _factories;

        public CarFactory()
        {
            _factories = new Dictionary<string, ICarFactory>
            {
                { "PassengerCar", new PassengerCarFactory() },
                { "Jeep", new JeepFactory() },
                { "Minibus", new MinibusFactory() }
            };
        }

        public ICar Create(string type)
        {
            if (_factories.TryGetValue(type, out var factory))
            {
                return factory.CreateCar();
            }

            throw new ArgumentException($"Неизвестный тип машины: {type}");
        }

        public IEnumerable<string> GetAvailableTypes() => _factories.Keys;
    }
}
