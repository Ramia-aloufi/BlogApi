using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BlogApi.src.DTOs;
using BlogApi.src.Models;

namespace BlogApi.src.Services.Interfaces
{
    public interface IPostService:IService<PostDTO>
    {
        Task<List<PostDTO>> GetAllInclude();
 
    }
}