using Domain;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class LoginService(IConfiguration configuration, ILoginRepository loginRepository) : ILoginService
    {
        private readonly ILoginRepository _loginRepository = loginRepository;
        private readonly IConfiguration _configuration = configuration;

        public async Task CreateMedico(LoginDto loginDto)
        {
            var login = new Login
            {
                Password = loginDto.Password,
                TypeAccess = TypeAccess.Doctor,
                Username = loginDto.Username
            };

            await _loginRepository.AddAsync(login);
        }

        public async Task CreatePaciente(LoginDto loginDto)
        {
            var login = new Login
            {
                Password = loginDto.Password,
                TypeAccess = TypeAccess.User,
                Username = loginDto.Username
            };

            await _loginRepository.AddAsync(login);
        }

        public async Task<string> GetTokenMedico(Domain.LoginDto loginDto)
        {
            var userFounded = await _loginRepository.GetUserByUsernameAndPassword(loginDto.Username, loginDto.Password);

            var tokenHandler = new JwtSecurityTokenHandler();

            var keyEncryption = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT"));

            var tokenProperties = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Actor, userFounded.Username),
                    new Claim(ClaimTypes.Role, userFounded.TypeAccess.ToString()),
                    new Claim(ClaimTypes.Authentication, userFounded.Password),
                    new Claim(ClaimTypes.NameIdentifier, userFounded.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyEncryption), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenProperties);
            return tokenHandler.WriteToken(token);
        }
    }
}
