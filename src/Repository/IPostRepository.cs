using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.src.Models;
using BlogApi.src.Repository.Generic;

namespace BlogApi.src.Repository
{
    public interface IPostRepository :IRepository<Post>
    {
        
    }
}