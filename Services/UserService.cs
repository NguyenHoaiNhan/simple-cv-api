using AutoMapper;
using SimpleCV.Data.DTO;
using SimpleCV.Data.Entities;
using SimpleCV.Data.Repositories.IRepositories;
using SimpleCV.Services.IServices;

namespace SimpleCV.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserToAddDTO> AddUser(UserToAddDTO userToAddDTO)
        {
            var userToAdd = await _userRepository.Add(
                _mapper.Map<User>(userToAddDTO)
            );

            return _mapper.Map<UserToAddDTO>(userToAdd);
        }

        public async Task DeleteUser(int Id)
        {
            var userToDelete = await _userRepository.Get(x => x.Id == Id);
            await _userRepository.Delete(userToDelete);
        }

        public async Task<UserDTO> GetUser(int Id)
        {
            var userToReturn = await _userRepository.Get(x => x.Id == Id);
            return _mapper.Map<UserDTO>(userToReturn);
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            var usersToReturn = await _userRepository.GetList();
            return _mapper.Map<List<UserDTO>>(usersToReturn);
        }

        public async Task<UserDTO> UpdateUser(UserDTO user)
        {
            var userToUpdate = _mapper.Map<User>(user);
            return _mapper.Map<UserDTO>(await _userRepository.Update(userToUpdate));
        }

        public async Task<UserDTO> UpdateUserProperties(int Id, List<UserPatchDTO> userPatchDTOs)
        {
            var userToUpdate = await _userRepository.Get(x => x.Id == Id);
            return _mapper.Map<UserDTO>(await _userRepository.UpdateUserProperties(userToUpdate, Id, userPatchDTOs));
        }
    }
}