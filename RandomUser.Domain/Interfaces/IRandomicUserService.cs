using RandomUser.Domain.Entities;

namespace RandomUser.Domain.Interfaces
{
    public interface IRandomicUserService
    {
        Task<User> GenerateNewRandomUser();
    }
}
