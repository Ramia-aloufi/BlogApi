using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BlogApi.src.DTOs;
using BlogApi.src.Models;
using BlogApi.src.Repository;
using BlogApi.src.Repository.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.src.Controllers
{
    [Route("[controller]")]
    public class RoleController(ILogger<RoleController> logger, IMapper mapper, IRepository<Role> roleRepository) : Controller
    {
        private readonly ILogger<RoleController> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IRepository<Role> _roleRepository = roleRepository;
        private readonly ApiResponse _apiResponse = new();

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> CreateRole(RoleDTO dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest();
                Role role = _mapper.Map<Role>(dto);
                role.isDeleted = false;
                role.createdDte = DateTime.UtcNow;
                role.UpdatedDate = DateTime.UtcNow;

                var result = await _roleRepository.Create(role);

                _apiResponse.Data = result;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;

                return Ok(_apiResponse);
                // return CreatedAtRoute("GetRoleById", new { id = result.Id }, _apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }




        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> GetAllRole()
        {
            try
            {
                var result = await _roleRepository.GetAll();
                _apiResponse.Data = _mapper.Map<List<RoleDTO>>(result);
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }



        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> GetRoleById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();
                var role = await _roleRepository.GetById(n => n.Id == id);
                if (role == null)
                    return NotFound($"role with {id} not found");
                RoleDTO selectedRole = _mapper.Map<RoleDTO>(role);
                _apiResponse.Data = selectedRole;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }

        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> UpdateRoleById(RoleDTO dto)
        {
            try
            {
                if (dto == null || dto.Id <= 0)
                    return BadRequest();

                var existRole = await _roleRepository.GetById(s => s.Id == dto.Id, true);
                if (existRole == null)
                    return NotFound($"role with {dto.Id} not found");

                var newRole = _mapper.Map<Role>(dto);
                await _roleRepository.Update(newRole);

                _apiResponse.Data = newRole;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);


            }
            catch (Exception ex)
            {
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }


        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public async Task<ActionResult<ApiResponse>> DeleteRole(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();
                var role = await _roleRepository.GetById(n => n.Id == id);
                if (role == null)
                    return NotFound($"role with {id} not found");
                await _roleRepository.Delete(role);

                _apiResponse.Data = role;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);


            }
            catch (Exception ex)
            {
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }
        }


    }
}