using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using BlogApi.src.DTOs;
using BlogApi.src.Models;
using BlogApi.src.Repository.Generic;
using BlogApi.src.Services.Implementations;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;

namespace BlogApi.src.Services
{
    public class UserService(IRepository<User> userRepository, IMapper mapper, IConfiguration configuration) : Service<User, UserDTO>(userRepository, mapper), IUserService
    {
        private readonly IRepository<User> _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IConfiguration _configuration = configuration;

        public (string passHash, string salt) CreatePassHash(string password)
        {
            var salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8

            ));
            return (hash, Convert.ToBase64String(salt));
        }
        public bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));

            return hash == storedHash;
        }

        public string CreateToken(LoginDTO dto)
        {
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSecret") ?? "");
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity([
                        new(ClaimTypes.Role , "user"),
                        new(ClaimTypes.Name , dto.Email)
                    ]),
                Expires = DateTime.Now.AddHours(4),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenGenerated = tokenHandler.WriteToken(token);
            return tokenGenerated;
        }

        public async Task<LoginReadDTO> Login(LoginDTO dto)
        {
            if (dto == null)
                throw new Exception($"the argument {nameof(dto)} is null") { Data = { ["StatusCode"] = HttpStatusCode.NotFound } };
            var exist = await _userRepository.GetById(n => n.Email == dto.Email) ?? throw new Exception("Login failed: email not found.") { Data = { ["StatusCode"] = HttpStatusCode.BadRequest } };
            if (!VerifyPassword(dto.Password,exist.Password,exist.PasswordSalt))
                throw new Exception("Login failed: incorrect password.") { Data = { ["StatusCode"] = HttpStatusCode.BadRequest } };

            LoginReadDTO loginData = new()
            {
                Token = CreateToken(dto),
                Name = exist.Name
            };
            return loginData;

        }

        public async Task<UserDTO> SignUp(RegisterDTO dto)
        {
            if (dto == null)
                throw new Exception($"the argument {nameof(dto)} is null") { Data = { ["StatusCode"] = HttpStatusCode.NotFound } };
            var exist = await _userRepository.GetById(n => n.Email == dto.Email);
            if (exist != null)
                throw new Exception("The Already exist") { Data = { ["StatusCode"] = HttpStatusCode.BadRequest } };
                if (dto.Password != dto.ConfirmPassword)
                throw new Exception("The password and confirmation password do not match.") { Data = { ["StatusCode"] = HttpStatusCode.BadRequest } };
                UserDTO user = new(){
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = dto.Password

                };
            var newUser = _mapper.Map<User>(user);
            if (!string.IsNullOrEmpty(dto.Password))
            {
                var (passHash,passSalt) = CreatePassHash(newUser.Password);
                newUser.Password = passHash;
                newUser.PasswordSalt = passSalt;
            }
            var entityData = await _userRepository.Create(newUser);
            var dtoData = _mapper.Map<UserDTO>(entityData);
            return dtoData;

        }

    }
}