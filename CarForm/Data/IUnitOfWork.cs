using System.Threading.Tasks;

namespace CarForm.Data
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}