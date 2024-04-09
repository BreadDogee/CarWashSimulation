using CarWash.Core.Logic;
using CarWash.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarWash.ConsoleApp
{
    internal class Program
    {
        private static readonly Random _random = new();

        static void Main(string[] args)
        {
            Console.WriteLine("=== Модель автомойки самообслуживания ===");

            int slots = GetValidSlotCount();  // Получение корректного числа постов мойки

            var engine = new SimulationEngine(slots, GenerateRandomCars);
            int simulationTime = 100;

            Console.WriteLine($"\nЗапуск симуляции на {simulationTime} минут...\n");

            engine.Run(simulationTime);

            Console.WriteLine("Симуляция завершена.");
            Console.WriteLine($"Обслужено машин: {engine.TotalCarsServed}");
            Console.WriteLine($"Общая выручка: {engine.TotalEarnings} рублей");
        }

        // Метод для ввода и валидации количества постов мойки
        static int GetValidSlotCount()
        {
            int slots;
            while (true)
            {
                Console.Write("Введите количество постов мойки: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out slots) && slots > 0)
                {
                    return slots;
                }
                else
                {
                    Console.WriteLine("Ошибка: введите положительное число для количества постов мойки.");
                }
            }
        }

        // Генератор случайных машин
        static readonly CarFactory _carFactory = new();

        static List<ICar> GenerateRandomCars(int minute)
        {
            int carCount = _random.Next(0, 3); // 0, 1 или 2 машины
            var cars = new List<ICar>();
            var types = _carFactory.GetAvailableTypes().ToList();

            for (int i = 0; i < carCount; i++)
            {
                int index = _random.Next(types.Count);
                var type = types[index];
                cars.Add(_carFactory.Create(type));
            }

            return cars;
        }
    }
}
