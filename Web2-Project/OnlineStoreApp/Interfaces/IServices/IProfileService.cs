using OnlineStoreApp.DTOs;

namespace OnlineStoreApp.Interfaces.IServices
{
    public interface IProfileService
    {
        public Task<ProfileDTO> GetProfile(int id);
        public Task EditProfile(int id, EditProfileDTO profile);
    }
}
