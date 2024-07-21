using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BlogApi.src.Controllers;
using BlogApi.src.DB;
using BlogApi.src.DTOs;
using BlogApi.src.Helpers;
using BlogApi.src.Models;
using BlogApi.src.Repository;
using BlogApi.src.Repository.Generic;
using BlogApi.src.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "admin")]
    [ProducesResponseType(401)]
    public class PostController(IService<PostDTO> service) : ApiController<PostDTO, IService<PostDTO>>(service)
    {
    }
    }