
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
            // CreateMap<Post,PostDTO>().ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));

            CreateMap<Role,RoleDTO>().ReverseMap();
            CreateMap<Role,ReadRoleDTO>().ReverseMap();
            CreateMap<User,UserDTO>().ReverseMap();
            //  CreateMap<Comment,CommentDTO>().ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));


            CreateMap<User,UserReadOnlyDTO>().ReverseMap();
            CreateMap<Comment,CommentDTO>().ReverseMap();
            
             CreateMap<Comment,CommentOnPostDTO>().ReverseMap();

            CreateMap<Category,CategoryDTO>().ReverseMap();


            // .ForMember(n=>n.ImageUrl,a=>a.MapFrom(n => string.IsNullOrEmpty(n.ImageUrl) ? "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR63XIy9VsNtzBDN5WqZPXvBpoHdmq8YUlSYEfwNghm0Q&s" : n.ImageUrl));

        }
    }
}