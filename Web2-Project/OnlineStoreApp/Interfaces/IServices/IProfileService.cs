using OnlineStoreApp.DTOs;

namespace OnlineStoreApp.Interfaces.IServices
{
    public interface IProfileService
    {
        public Task<UserDTO> GetProfile(int id);
        public Task EditProfile(int id, EditProfileDTO profile);
        public Task AddImage(int id, IFormFile image);
        public Task<byte[]?> GetImage(int id);
    }
}
