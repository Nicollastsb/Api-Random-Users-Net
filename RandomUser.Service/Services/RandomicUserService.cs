using AutoMapper;
using RandomUser.Domain.Entities;
using RandomUser.Domain.Interfaces;

namespace RandomUser.Service.Services
{
    public class RandomicUserService : IRandomicUserService
    {
        private readonly IMapper _mapper;
        private IRandomicUserRepository _randomicUserRepository;
        private IUserRepository _userRepository;

        public RandomicUserService(IMapper mapper, IRandomicUserRepository randomicUserRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _randomicUserRepository = randomicUserRepository;
            _userRepository = userRepository;
        }

        public async Task<User> GenerateNewRandomUser()
        {
            var newRandomicUser = await _randomicUserRepository.GetRandomUser();
            var newUser = _mapper.Map<User>(newRandomicUser);
            return await _userRepository.Insert(newUser);
        }
    }
}
