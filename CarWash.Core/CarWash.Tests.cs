using NUnit.Framework;
using CarWash.Core.Logic;
using CarWash.Core.Models;
using System.Collections.Generic;

namespace CarWash.Tests
{
    public class CarWashSlotTests
    {
        [Test]
        public void Slot_Assigns_Car_Correctly()
        {
            var slot = new CarWashSlot();
            var car = new PassengerCar();

            slot.AssignCar(car);

            Assert.That(slot.IsFree, Is.False);
        }

        [Test]
        public void Slot_Becomes_Free_After_Washing()
        {
            var slot = new CarWashSlot();
            var car = new PassengerCar(); // 5 мин

            slot.AssignCar(car);

            int total = 0;
            for (int i = 0; i < 5; i++)
            {
                total += slot.Tick();
            }

            Assert.That(slot.IsFree, Is.True);
            Assert.That(total, Is.EqualTo(5));
        }
    }

    public class CarQueueTests
    {
        [Test]
        public void Queue_Enqueue_And_Dequeue()
        {
            var queue = new CarQueue();
            var car = new Jeep();

            queue.Enqueue(car);

            Assert.That(queue.HasCars, Is.True);
            Assert.That(queue.Count, Is.EqualTo(1));

            var dequeued = queue.Dequeue();

            Assert.That(dequeued, Is.EqualTo(car));
            Assert.That(queue.HasCars, Is.False);
        }
    }

    public class CarWashServiceTests
    {
        [Test]
        public void Car_Is_Processed_And_Earnings_Are_Correct()
        {
            var service = new CarWashService(slotCount: 1);
            service.AddCar(new PassengerCar()); // 5 мин

            for (int i = 0; i < 5; i++)
                service.Tick();

            Assert.That(service.TotalEarnings, Is.EqualTo(150)); // 5 * 30
        }

        [Test]
        public void Multiple_Cars_Use_Queue_When_Slot_Is_Busy()
        {
            var service = new CarWashService(slotCount: 1);
            service.AddCar(new PassengerCar()); // в пост
            service.AddCar(new Jeep());         // в очередь

            for (int i = 0; i < 5; i++) service.Tick(); // первый ушёл
            for (int i = 0; i < 8; i++) service.Tick(); // второй ушёл

            Assert.That(service.TotalEarnings, Is.EqualTo(390)); // 5 + 8 = 13 * 30
        }
    }

    public class SimulationEngineTests
    {
        [Test]
        public void Simulation_Processes_All_Cars_And_Calculates_Earnings()
        {
            var carsPerMinute = new Dictionary<int, List<ICar>>
            {
                [0] = new List<ICar> { new PassengerCar() },
                [1] = new List<ICar> { new Jeep() },
                [2] = new List<ICar> { new Minibus() }
            };

            var engine = new SimulationEngine(
                slotCount: 2,
                carGenerator: minute => carsPerMinute.ContainsKey(minute) ? carsPerMinute[minute] : new List<ICar>()
            );

            engine.Run(minutes: 3);

            int expectedTotalMinutes = 5 + 8 + 10;
            int expectedEarnings = expectedTotalMinutes * 30;

            Assert.That(engine.TotalEarnings, Is.EqualTo(expectedEarnings));
        }
    }
}
