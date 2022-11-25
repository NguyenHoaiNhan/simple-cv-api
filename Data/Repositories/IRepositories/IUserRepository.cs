using SimpleCV.Data.DTO.User;
using SimpleCV.Data.Entities;

namespace SimpleCV.Data.Repositories.IRepositories 
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> UpdateUserProperties(User user, int Id, List<UserPatchDTO> userPatchDTOs);
    }
}