using System.Security.Cryptography;
using AutoMapper;
using BlogApi.src.DTOs;
using BlogApi.src.Models;
using BlogApi.src.Repository.Generic;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace BlogApi.src.Services
{
    public class UserService(IRepository<User> UserRepository, IMapper mapper) : IUserService
    {
        private readonly IRepository<User> _UserRepository = UserRepository;

        private readonly IMapper _mapper = mapper;


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
        public async Task<bool> CreateUser(UserDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto, $"the argument {nameof(dto)} is null");

            var existUser = await _UserRepository.GetById(n => n.username.Equals(dto.username));
            if (existUser != null)
                throw new Exception("The User Already exist");

            User newUser = _mapper.Map<User>(dto);
            newUser.createdDte = DateTime.UtcNow;
            newUser.UpdatedDate = DateTime.UtcNow;
            newUser.isDeleted = false;


            if (!string.IsNullOrEmpty(dto.password))
            {
                var passHash = CreatePassHash(newUser.password);
                newUser.password = passHash.passHash;
                newUser.passwordSalt = passHash.salt;
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
                throw new ArgumentException("The user ID must be greater than zero.", nameof(id));

            var user = await _UserRepository.GetById(n => n.Id == id) ?? throw new Exception($"user with id {id} not found");
            return await _UserRepository.Delete(user); ;
        }



    }
}