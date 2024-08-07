
using AutoMapper;
using BlogApi.src.DTOs;
using BlogApi.src.Models;

namespace BlogApi.src.Mappers
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Post,PostDTO>().ReverseMap();
            CreateMap<Role,RoleDTO>().ReverseMap();
            CreateMap<Role,ReadRoleDTO>().ReverseMap();

            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<User,UserReadOnlyDTO>().ReverseMap();
            CreateMap<Category,CategoryDTO>().ReverseMap();
            CreateMap<RolePrivilege,RolePrivilegeDTO>().ReverseMap();


            // .ForMember(n=>n.ImageUrl,a=>a.MapFrom(n => string.IsNullOrEmpty(n.ImageUrl) ? "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR63XIy9VsNtzBDN5WqZPXvBpoHdmq8YUlSYEfwNghm0Q&s" : n.ImageUrl));

        }
    }
}