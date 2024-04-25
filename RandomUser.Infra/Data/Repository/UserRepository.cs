using Microsoft.EntityFrameworkCore;
using RandomUser.Domain.Entities;
using RandomUser.Domain.Interfaces;
using RandomUser.Infra.Data.Context;

namespace RandomUser.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly PostgreSQLContext _postgreSQLContext;

        public UserRepository(PostgreSQLContext postgreSQLContext)
        {
            _postgreSQLContext = postgreSQLContext;
        }

        public async Task<List<User>> GetUsers()
        {
            var listUsers = await _postgreSQLContext.Users.ToListAsync();
            return listUsers;
        }

        public async Task<User> Insert(User user)
        {
            _postgreSQLContext.Database.EnsureCreated();
            await _postgreSQLContext.Users.AddAsync(user);
            await _postgreSQLContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> Update(User updatedUser)
        {
            var baseUser = await _postgreSQLContext.Users.FirstOrDefaultAsync(item => item.Id == updatedUser.Id);
            if (baseUser == null)
                throw new KeyNotFoundException();

            baseUser.Name = updatedUser.Name;
            baseUser.Gender = updatedUser.Gender;
            baseUser.Address = updatedUser.Address;
            baseUser.Email = updatedUser.Email;
            baseUser.Phone = updatedUser.Phone;
            baseUser.Cell = updatedUser.Cell;
            baseUser.PictureMedium = updatedUser.PictureMedium;
            baseUser.PictureLarge = updatedUser.PictureLarge;
            baseUser.PictureThumbnail = updatedUser.PictureThumbnail;
            baseUser.UserName = updatedUser.UserName;
            baseUser.Password = updatedUser.Password;

            await _postgreSQLContext.SaveChangesAsync();
            return baseUser;
        }
    }
}
