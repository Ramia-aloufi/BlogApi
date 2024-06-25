using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BlogApi.src.DTOs;
using BlogApi.src.Models;
using BlogApi.src.Repository.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.src.Controllers
{
    [Route("[controller]")]
    public class RolePrivilegeController(ILogger<RolePrivilegeController> logger,IMapper mapper,IRepository<RolePrivilege> RolePrivilegeRepository) : Controller
    {
        private readonly ILogger<RolePrivilegeController> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IRepository<RolePrivilege> _RolePrivilegeRepository = RolePrivilegeRepository ;
        private readonly ApiResponse _apiResponse = new();

       [HttpPost]
       [ProducesResponseType(201)]
       [ProducesResponseType(500)]
       [ProducesResponseType(400)]
        public async Task<ActionResult<ApiResponse>> CreateRolePrivilege(RolePrivilegeDTO dto)
        {
            try
            {
                if(dto == null)
                return BadRequest();

                var role =  _mapper.Map<RolePrivilege>(dto);
                var result = await _RolePrivilegeRepository.Create(role);

                _apiResponse.Data = result;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;


                return Ok(_apiResponse);


                
            }
            catch (Exception ex)
            {
                _apiResponse.Status = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Data = ex.Message;
                return _apiResponse;
            }


        }

       [HttpGet("{id:int}")]
       [ProducesResponseType(200)]
       [ProducesResponseType(500)]
       [ProducesResponseType(400)]
       [ProducesResponseType(404)]

        public async Task<ActionResult<ApiResponse>> GetRolePrivilegeById(int id){
            try
            {
                if(id<= 0)
                return BadRequest();

                RolePrivilege role = await _RolePrivilegeRepository.GetById(n=>n.Id==id);
                role.isDeleted = false;
                role.createdDte = DateTime.UtcNow;
                role.UpdatedDate = DateTime.UtcNow;

                 if(role == null)
                return NotFound($"role with {id} not found");

                _apiResponse.Data = role;
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

       [HttpGet]
       [ProducesResponseType(200)]
       [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> GetAllRolePrivilege(){
            try
            {
                var result = await _RolePrivilegeRepository.GetAll();
                _apiResponse.Data = _mapper.Map<List<RolePrivilege>>(result);
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
        public async Task<ActionResult<ApiResponse>> UpdateRolePrivilegeById (RolePrivilegeDTO dto)
        {
            try
            {
                if(dto == null || dto.Id <=0)
                return BadRequest();

                var role = await _RolePrivilegeRepository.GetById(n => n.Id == dto.Id,true);
                if(role == null)
                return NotFound($"role with privilege id {dto.Id} not found");
                role.UpdatedDate = DateTime.UtcNow;
                var rolePrivilege = _mapper.Map<RolePrivilege>(dto);
                 await _RolePrivilegeRepository.Update(rolePrivilege);

                _apiResponse.Data = rolePrivilege;
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
                if(id<=0)
                return BadRequest();

                var rolePrivilege = await _RolePrivilegeRepository.GetById(n=>n.Id==id);
                if(rolePrivilege == null)
                return NotFound($"rolePrivilege with id {id} not found");

                await _RolePrivilegeRepository.Delete(rolePrivilege);

                _apiResponse.Data = rolePrivilege;
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