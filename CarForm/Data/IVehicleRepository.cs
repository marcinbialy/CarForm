using System.Threading.Tasks;
using CarForm.Models;

namespace CarForm.Data
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
        Task<Vehicle> FindVehicle(int id);
    }
}