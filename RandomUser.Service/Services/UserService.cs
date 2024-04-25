using RandomUser.Domain.Entities;
using RandomUser.Domain.Interfaces;

namespace RandomUser.Service.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return users;
        }

        public async Task<User> Update(User user) 
        {
            var updatedUser = await _userRepository.Update(user);
            return updatedUser;
        }
    }
}
