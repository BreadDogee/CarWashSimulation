namespace CarWash.Core.Models
{
    public class PassengerCarFactory : ICarFactory
    {
        public ICar CreateCar() => new PassengerCar();
    }
}
