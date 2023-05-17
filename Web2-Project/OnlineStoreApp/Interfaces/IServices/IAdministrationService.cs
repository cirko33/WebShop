using OnlineStoreApp.DTOs;
using OnlineStoreApp.Models;

namespace OnlineStoreApp.Interfaces.IServices
{
    public interface IAdministrationService
    {
        public Task<List<OrderDTO>> GetAllOrders();
        public Task<List<UserDTO>> GetWaitingUsers();
        public Task<List<UserDTO>> GetVerifiedUsers();
        public Task SetUserStatus(VerifyDTO verifyDTO);
    }
}
