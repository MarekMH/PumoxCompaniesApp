using System.Threading.Tasks;
using PumoxCompaniesApp.API.Domain.Repositories;
using PumoxCompaniesApp.API.Persistence.Contexts;

namespace PumoxCompaniesApp.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;     
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}