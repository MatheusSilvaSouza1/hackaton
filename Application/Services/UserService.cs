using Domain;
using Domain.Repositories;

namespace Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public readonly IUserRepository _userRepository = userRepository;
        public async Task Create(UserDto loginDto)
        {
            await _userRepository.AddAsync(new Usuario
            {
                Email = loginDto.Email,
                Password = loginDto.Password
            });
        }
    }
}
