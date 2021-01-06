using PumoxCompaniesApp.API.Identity.Helpers;
using PumoxCompaniesApp.API.Identity.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumoxCompaniesApp.API.Identity.IntentityServices
{
    public interface IUserService
    {
        Task<AppUser> Authenticate(string username, string password);
        Task<IEnumerable<AppUser>> GetAll();
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<AppUser> _users = new List<AppUser>
        {
            new AppUser { Id = 1, FirstName = "Test", LastName = "User", UserName = "test", Password = "test" }
        };

        public async Task<AppUser> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.UserName == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            return user.WithoutPassword();
        }

        public async Task<IEnumerable<AppUser>> GetAll()
        {
            return await Task.Run(() => _users.WithoutPasswords());
        }
    }
}
