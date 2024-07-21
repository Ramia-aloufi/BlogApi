using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BlogApi.src.DTOs;
using BlogApi.src.Helpers;
using BlogApi.src.Models;
using BlogApi.src.Repository.Generic;
using BlogApi.src.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.src.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController(IService<CategoryDTO> service) : ApiController<CategoryDTO, IService<CategoryDTO>>(service)
    {
    }
}