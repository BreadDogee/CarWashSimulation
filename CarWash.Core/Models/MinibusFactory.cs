namespace CarWash.Core.Models
{
    public class MinibusFactory : ICarFactory
    {
        public ICar CreateCar() => new Minibus();
    }
}
