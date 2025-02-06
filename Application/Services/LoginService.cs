using Domain;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class LoginService(IMedicoRepository medicoRepository, IUserRepository userRepository, IConfiguration configuration, ILoginRepository loginRepository) : ILoginService
    {
        private readonly IMedicoRepository _medicoRepository = medicoRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ILoginRepository _loginRepository = loginRepository;
        private readonly IConfiguration _configuration = configuration;

        public async Task<string> GetTokenMedico(LoginDto loginDto)
        {
            var userFounded = await _medicoRepository.GetMedicoByUsernameAndPassword(loginDto.Username, loginDto.Password);

            var tokenHandler = new JwtSecurityTokenHandler();

            var keyEncryption = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT"));

            var tokenProperties = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Actor, userFounded.Crm),
                    new Claim(ClaimTypes.Role, TypeAccess.Doctor.ToString()),
                    new Claim(ClaimTypes.Authentication, userFounded.Senha),
                    new Claim(ClaimTypes.NameIdentifier, userFounded.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyEncryption), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenProperties);
            return tokenHandler.WriteToken(token);
        }

        public async Task<string> GetTokenPaciente(LoginDto loginDto)
        {
            var userFounded = await _userRepository.GetUserByUsernameAndPassword(loginDto.Username, loginDto.Password);

            var tokenHandler = new JwtSecurityTokenHandler();

            var keyEncryption = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT"));

            var tokenProperties = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Actor, userFounded.Email),
                    new Claim(ClaimTypes.Role, TypeAccess.User.ToString()),
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
