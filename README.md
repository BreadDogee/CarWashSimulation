# 🚗 Car Wash Simulator

**Car Wash Simulator** — это учебный C#-проект, моделирующий работу автомойки с несколькими постами. Проект построен по принципам хорошей архитектуры: использует интерфейсы, паттерн "Фабрика", разделение на модули, а также поддержку симуляции через консольное приложение.

---

## 🔧 Возможности

- Поддержка различных типов машин:
  - Passenger Car
  - Jeep
  - Minibus
- Моделирование очереди и параллельной мойки на нескольких постах
- Гибкая настройка количества постов
- Учёт времени и доходов
- Валидируемый ввод от пользователя

---

## 📂 Структура проекта

CarWash/
├── CarWash.Core/
│   ├── Models/
│   │   ├── ICar.cs
│   │   ├── PassengerCar.cs
│   │   ├── Jeep.cs
│   │   ├── Minibus.cs
│	│	├── ICarFactory.cs
│	│	├── CarFactory.cs
│	│	├── PassengerCarFactory.cs
│   │   ├── JeepFactory.cs
│   │   └── MinibusFactory.cs
│   │   
│   ├── Logic/
│   │   ├── CarQueue.cs
│   │   ├── CarWashSlot.cs
│   │   ├── CarWashService.cs
│	│	└── SimulationEngine.cs
│   │
│   └── CarWash.Tests.cs
│
├── CarWash.ConsoleApp/
│   ├── CarWash.ConsoleApp.cs
└── README.md

---

## Автор

**Пономарев Роман**
email: roma.ponomarev.05@mail.ru


