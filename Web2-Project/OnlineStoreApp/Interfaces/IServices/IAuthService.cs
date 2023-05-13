using OnlineStoreApp.Models;

namespace OnlineStoreApp.Interfaces.IServices
{
    public interface IAuthService
    {
        public Task<User> Login(string username, string password);
        public void Logout();
    }
}
