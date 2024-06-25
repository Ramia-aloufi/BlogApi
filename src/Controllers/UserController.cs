using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BlogApi.src.DTOs;
using BlogApi.src.Models;
using BlogApi.src.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.src.Controllers
{
    [Route("[controller]")]

    public class UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper) : Controller
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly IUserService _userService = userService;
        private readonly ApiResponse _apiResponse = new();
        private readonly IMapper _mapper = mapper;



        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> CreateUser(UserDTO dto)
        {
            try
            {
                _logger.LogInformation("CreateUser Method started");
                var result = await _userService.CreateUser(dto);
                _apiResponse.Data = result;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
                // return CreatedAtRoute("GetRoleById", new { id = result.Id }, _apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }

        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            try
            {
                _logger.LogInformation("GetAllUser Method started");

                var users = await _userService.GetAllUsers();
                _apiResponse.Data = users;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
                // return CreatedAtRoute("GetRoleById", new { id = result.Id }, _apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;

            }




        }
        [HttpGet("{id:int}",Name ="GetUserById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> GetUserById(int id)
        {
            try
            {
                _logger.LogInformation("GetUserById Method started");

                if (id <= 0)
                    return BadRequest();

                UserReadOnlyDTO user = await _userService.GetUserById(id);


                if (user == null){
                _logger.LogError($"user with {id} not found");

                    return NotFound($"user with {id} not found");
                }

                _apiResponse.Data = user;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;

                return Ok(_apiResponse);

            }
            catch (Exception ex)
            {
                _apiResponse.Data = ex.Message;
                _apiResponse.Status = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                return _apiResponse;
            }
        }
        [HttpPut]
       [ProducesResponseType(200)]
       [ProducesResponseType(500)]
       [ProducesResponseType(404)]
       [ProducesResponseType(400)]
        public async Task<ActionResult<ApiResponse>> UpdateUserById (UserReadOnlyDTO dto)
        {
            try
            {
                if(dto == null || dto.Id <=0){
                return BadRequest();
                }

                var user = await _userService.UpdateUserById(dto) ;
                _apiResponse.Data = user;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
                
            }
            catch (Exception ex)
            {
                _apiResponse.Data = ex.Message;
                _apiResponse.Status = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                return _apiResponse;
            }

        }
         [HttpDelete("{id:int}")]
       [ProducesResponseType(200)]
       [ProducesResponseType(500)]
       [ProducesResponseType(404)]
       [ProducesResponseType(400)]
        public async Task<ActionResult<ApiResponse>> DeleteRolePrivilege(int id)
        {
            try
            {

                var result = await _userService.DeleteUserById(id);

                _apiResponse.Data = result;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
                
            }
            catch (Exception ex)
            {
                _apiResponse.Data = ex.Message;
                _apiResponse.Status = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                return _apiResponse;
            }

        }

    }
}