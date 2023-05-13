using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineStoreApp.Exceptions;
using OnlineStoreApp.Interfaces;
using OnlineStoreApp.Interfaces.IServices;
using OnlineStoreApp.Models;

namespace OnlineStoreApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _unitOfWork.Users.Get(x => x.Username == username && x.Password == password);
            if(user == null)
                throw new NotFoundException($"Incorrect credentials. Try again.");

            return user;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
