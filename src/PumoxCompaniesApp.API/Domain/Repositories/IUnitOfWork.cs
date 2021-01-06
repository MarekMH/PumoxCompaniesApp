using System.Threading.Tasks;

namespace PumoxCompaniesApp.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}