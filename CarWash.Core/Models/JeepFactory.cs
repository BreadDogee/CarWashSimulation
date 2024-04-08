namespace CarWash.Core.Models
{
    public class JeepFactory : ICarFactory
    {
        public ICar CreateCar() => new Jeep();
    }
}
