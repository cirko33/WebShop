using OnlineStoreApp.DTOs;
using OnlineStoreApp.Exceptions;
using OnlineStoreApp.Interfaces;
using OnlineStoreApp.Interfaces.IServices;
using OnlineStoreApp.Models;

namespace OnlineStoreApp.Services
{
    public class AdministrationService : IAdministrationService
    {
        IUnitOfWork _unitOfWork;

        public AdministrationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return (await _unitOfWork.Orders.GetAll()).ToList();
        }

        public async Task<List<User>> GetVerifiedUsers()
        {
            return (await _unitOfWork.Users.GetAll(x => x.VerificationStatus == VerificationStatus.Accepted && x.Type == UserType.Seller)).ToList();
        }

        public async Task<List<User>> GetWaitingUsers()
        {
            return (await _unitOfWork.Users.GetAll(x => x.VerificationStatus == VerificationStatus.Waiting && x.Type == UserType.Seller)).ToList();
        }

        public async Task SetUserStatus(VerifyDTO verifyDTO)
        {
            var user = await _unitOfWork.Users.Get(x => x.Id == verifyDTO.Id);
            if (user == null)
                throw new BadRequestException("User with this ID doesn't exist.");

            user.VerificationStatus = verifyDTO.VerificationStatus;
            _unitOfWork.Users.Update(user);
            await _unitOfWork.Save();
        }
    }
}
