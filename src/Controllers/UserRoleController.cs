using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.src.Controllers
{
    [Route("[controller]")]
    public class UserRoleController(ILogger<UserRoleController> logger) : Controller
    {
        private readonly ILogger<UserRoleController> _logger = logger;
    }
}