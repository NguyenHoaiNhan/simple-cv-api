using SimpleCV.Data.DTO;

namespace SimpleCV.Services.IServices 
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsers();

        Task<UserDTO> GetUser(int Id);

        Task<UserToAddDTO> AddUser(UserToAddDTO userToAddDTO);

        Task<UserDTO> UpdateUser(UserDTO user);

        Task<UserDTO> UpdateUserProperties(int Id, List<UserPatchDTO> userPatchDTOs);

        Task DeleteUser(int Id);
    }
}