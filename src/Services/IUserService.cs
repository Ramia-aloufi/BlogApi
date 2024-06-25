
using BlogApi.src.DTOs;

namespace BlogApi.src.Services
{
    public interface IUserService
    {
        Task<bool> CreateUser(UserDTO dto);
        (string passHash, string salt) CreatePassHash(string password);
        Task<UserReadOnlyDTO> GetUserById(int id);
        Task<List<UserReadOnlyDTO>> GetAllUsers();
        Task<bool> UpdateUserById(UserReadOnlyDTO dto);
        Task<bool> DeleteUserById(int id);
    }
}