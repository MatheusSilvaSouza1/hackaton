
using Domain;

namespace Application.Services
{
    public interface IUserService
    {
        Task Create(UserDto loginDto);
    }
}
