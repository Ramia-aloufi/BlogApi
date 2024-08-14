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
using BlogApi.src.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.src.Controllers
{
    [Route("api/[controller]")]

    public class UserController(IUserService service) : ApiController<UserDTO, IUserService>(service)
    {
        [HttpPost("login")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> Login([FromBody] LoginDTO dto)
        {
            try
            {
                var result = await _service.Login(dto);
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(7),
                    Secure = true, 
                    SameSite = SameSiteMode.Strict
                };
                Response.Cookies.Append("AuthToken", result.Token, cookieOptions);

                var response = ApiResponseHelper.SuccessResponse("Resource Created Successfully!", result, HttpStatusCode.Created);
                return StatusCode((int)response.StatusCode, response);
            }
            catch (Exception ex)
            {
                var statusCode = (HttpStatusCode)(ex.Data["StatusCode"] ?? (int)HttpStatusCode.InternalServerError);
                var response = ApiResponseHelper.ErrorResponse(ex.Message, statusCode);
                return StatusCode((int)response.StatusCode, response);
            }
        }
        [HttpPost("signup")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> Signup([FromBody] RegisterDTO dto)
        {
            try
            {
                var result = await _service.SignUp(dto);
                var response = ApiResponseHelper.SuccessResponse("Signup Successfully!", result, HttpStatusCode.Created);
                return StatusCode((int)response.StatusCode, response);
            }
            catch (Exception ex)
            {
                var statusCode = (HttpStatusCode)(ex.Data["StatusCode"] ?? (int)HttpStatusCode.InternalServerError);
                var response = ApiResponseHelper.ErrorResponse(ex.Message, statusCode);
                return StatusCode((int)response.StatusCode, response);
            }
        }
        
        [HttpPost("activate")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> Activate( [FromBody] ActivateUser user )
        {
            try
            {
                var result = await _service.ActivateAccountAsync(user.Token, user.Id);
                var response = ApiResponseHelper.SuccessResponse("activated Successfully!", result, HttpStatusCode.Created);
                return StatusCode((int)response.StatusCode, response);
            }
            catch (Exception ex)
            {
                var statusCode = (HttpStatusCode)(ex.Data["StatusCode"] ?? (int)HttpStatusCode.InternalServerError);
                var response = ApiResponseHelper.ErrorResponse(ex.Message, statusCode);
                return StatusCode((int)response.StatusCode, response);
            }
        }

    }
}