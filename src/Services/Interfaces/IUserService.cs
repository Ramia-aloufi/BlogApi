
using BlogApi.src.DTOs;

namespace BlogApi.src.Services
{
    public interface IUserService:IService<UserDTO>
    {
        Task<UserDTO> SignUp(RegisterDTO dto);
        Task<LoginReadDTO> Login(LoginDTO dto);

        (string passHash, string salt) CreatePassHash(string password);
         string CreateToken(LoginDTO dto);


    }
}