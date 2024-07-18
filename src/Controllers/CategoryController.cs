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
    [Route("api/[controller]")]
    public class CategoryController(ILogger<CategoryController> logger, IMapper mapper, IRepository<Category> categoryRepository) : Controller
    {
        private readonly ILogger<CategoryController> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IRepository<Category> _categoryRepository = categoryRepository;
        private readonly ApiResponse _apiResponse = new();

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> Create(CategoryDTO dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest();
                Category role = _mapper.Map<Category>(dto);

                var result = await _categoryRepository.Create(role);

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
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            try
            {
                var result = await _categoryRepository.GetAll();
                _apiResponse.Data = _mapper.Map<List<CategoryDTO>>(result);
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
        public async Task<ActionResult<ApiResponse>> GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();
                var role = await _categoryRepository.GetById(n => n.Id == id);
                if (role == null)
                    return NotFound($"role with {id} not found");
                CategoryDTO selectedRole = _mapper.Map<CategoryDTO>(role);
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
        public async Task<ActionResult<ApiResponse>> UpdatById(CategoryDTO dto)
        {
            try
            {
                if (dto == null || dto.Id <= 0)
                    return BadRequest();

                var existRole = await _categoryRepository.GetById(s => s.Id == dto.Id, true);
                if (existRole == null)
                    return NotFound($"role with {dto.Id} not found");

                var newRole = _mapper.Map<Category>(dto);
                await _categoryRepository.Update(newRole);

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
                var role = await _categoryRepository.GetById(n => n.Id == id);
                if (role == null)
                    return NotFound($"role with {id} not found");
                await _categoryRepository.Delete(role);

                _apiResponse.Data = role;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);


            }
            catch (Exception ex)
            {
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.Status = false;
                return _apiResponse;
            }
        }

        
    }
}