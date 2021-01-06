using PumoxCompaniesApp.API.Persistence.Contexts;

namespace PumoxCompaniesApp.API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}