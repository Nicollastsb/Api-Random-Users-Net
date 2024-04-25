using RandomUser.Domain.Entities;

namespace RandomUser.Domain.Interfaces
{
    public interface IRandomicUserRepository
    {
        Task<RandomicUser> GetRandomUser();
    }
}
