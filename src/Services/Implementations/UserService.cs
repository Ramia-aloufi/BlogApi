using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using BlogApi.src.DTOs;
using BlogApi.src.Models;
using BlogApi.src.Repository.Generic;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;

namespace BlogApi.src.Services
{
    public class UserService(IRepository<User> UserRepository, IMapper mapper, IConfiguration configuration) : IUserService
    {
        private readonly IRepository<User> _UserRepository = UserRepository;

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
        public async Task<bool> SignUp(UserDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto, $"the argument {nameof(dto)} is null");

            var existUser = await _UserRepository.GetById(n => n.Name == dto.Name);
            if (existUser != null)
                throw new Exception("The User Already exist");

            User newUser = _mapper.Map<User>(dto);
            if (!string.IsNullOrEmpty(dto.Password))
            {
                var passHash = CreatePassHash(newUser.Password);
                newUser.Password = passHash.passHash;
                newUser.PasswordSalt = passHash.salt;
            }

            await _UserRepository.Create(newUser);
            return true;
        }
        public async Task<List<UserReadOnlyDTO>> GetAllUsers()
        {
            var users = await _UserRepository.GetAll();
            return _mapper.Map<List<UserReadOnlyDTO>>(users);
        }
        public async Task<UserReadOnlyDTO> GetUserById(int id)
        {
            var user = await _UserRepository.GetById(n => n.Id == id);
            return _mapper.Map<UserReadOnlyDTO>(user);
        }
        public async Task<bool> UpdateUserById(UserReadOnlyDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto, $"the argument {nameof(dto)} is null");

            var existUser = await _UserRepository.GetById(n => n.Id == dto.Id, true) ?? throw new Exception("The User not found");
            _mapper.Map(dto, existUser);

            existUser.UpdatedDate = DateTime.UtcNow;


            await _UserRepository.Update(existUser);
            return true;
        }
        public async Task<bool> DeleteUserById(int id)
        {

            if (id <= 0)
        throw new Exception("The user ID must be greater than zero."){ Data = { ["StatusCode"] = HttpStatusCode.BadRequest } };

            var user = await _UserRepository.GetById(n => n.Id == id) ?? throw new Exception($"user with id {id} not found"){ Data = { ["StatusCode"] = HttpStatusCode.NotFound } };
            return await _UserRepository.Delete(user);
        }
        public async Task<LoginReadDTO> Login(LoginDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto, $"the argument {nameof(dto)} is null");
            var existUser = await _UserRepository.GetById(n => n.Email == dto.Email, true) ?? throw new Exception("The User not found");

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
            LoginReadDTO loginData = new()
            {
                Token = tokenGenerated,
                Name = existUser.Name
            };


            return loginData;




        }

    }
}