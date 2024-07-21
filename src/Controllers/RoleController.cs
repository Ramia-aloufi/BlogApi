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
using BlogApi.src.Repository;
using BlogApi.src.Repository.Generic;
using BlogApi.src.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.src.Controllers
{
    [Route("api/[controller]")]
    public class RoleController(IService<RoleDTO> roleService) : ApiController<RoleDTO, IService<RoleDTO>>(roleService)
    {
    }



}
