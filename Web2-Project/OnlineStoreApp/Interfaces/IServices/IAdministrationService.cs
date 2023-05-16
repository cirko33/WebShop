using OnlineStoreApp.DTOs;
using OnlineStoreApp.Models;

namespace OnlineStoreApp.Interfaces.IServices
{
    public interface IAdministrationService
    {
        public Task<List<Order>> GetAllOrders();
        public Task<List<User>> GetWaitingUsers();
        public Task<List<User>> GetVerifiedUsers();
        public Task SetUserStatus(VerifyDTO verifyDTO);
    }
}
