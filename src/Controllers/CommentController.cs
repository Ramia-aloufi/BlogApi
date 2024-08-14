using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.src.DTOs;
using BlogApi.src.Models;
using BlogApi.src.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.src.Controllers
{
    [Route("api/[controller]")]
    public class CommentController (IService<CommentDTO> service) : ApiController<CommentDTO, IService<CommentDTO>>(service)
    {
    }
    
}