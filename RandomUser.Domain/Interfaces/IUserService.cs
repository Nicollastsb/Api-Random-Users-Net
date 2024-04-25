using RandomUser.Domain.Entities;

namespace RandomUser.Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> Update(User user);
    }
}
