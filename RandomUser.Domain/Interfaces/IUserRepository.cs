using RandomUser.Domain.Entities;

namespace RandomUser.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> Insert(User user);
        Task<User> Update(User updatedUser);
    }
}
