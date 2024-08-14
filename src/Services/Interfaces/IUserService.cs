
using BlogApi.src.DTOs;
using BlogApi.src.Models;

namespace BlogApi.src.Services
{
    public interface IUserService:IService<UserDTO>
    {
        Task<UserDTO> SignUp(RegisterDTO dto);
        Task<LoginReadDTO> Login(LoginDTO dto);
        (string passHash, string salt) CreatePassHash(string password);
        string CreateToken(User dto);
        Task<bool> ActivateAccountAsync(string token, int id);

    }
}