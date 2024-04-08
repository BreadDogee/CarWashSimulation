
namespace CarWash.Core.Models
{
    public interface ICar
    {
        string Type { get; }
        int WashTime { get; } // минуты
    }
}
