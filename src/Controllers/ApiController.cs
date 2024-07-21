using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BlogApi.src.Helpers;
using BlogApi.src.Models;
using BlogApi.src.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlogApi.src.Controllers
{
    [Route("[controller]")]
    public class ApiController<TDto, TService> : Controller
    where TService : IService<TDto>
{
    protected readonly TService _service;

        protected ApiController(TService service)
    {
        _service = service;
    }
     [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<ApiResponse>> Create([FromBody] TDto dto)
    {
        try
        {
            var result = await _service.CreateAsync(dto);
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
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> GetAll()
        {
            try
            {
                var result = await _service.GetAllAsync();
                var response = ApiResponseHelper.SuccessResponse(" Retrieved Successfully!", result,HttpStatusCode.OK);
                return StatusCode((int)response.StatusCode, response);             }
            catch (Exception ex)
            {
               var statusCode = (HttpStatusCode)(ex.Data["StatusCode"] ?? (int)HttpStatusCode.InternalServerError);
                var response = ApiResponseHelper.ErrorResponse(ex.Message, statusCode);
                return StatusCode((int)response.StatusCode, response);              }



        }
         [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> GetById(int id)
        {
            try
            {
                var result = await _service.GetByAsync(id);
                var response = ApiResponseHelper.SuccessResponse("Retrieved Successfully!", result,HttpStatusCode.OK);
                return StatusCode((int)response.StatusCode, response);             }
            catch (Exception ex)
            {
               var statusCode = (HttpStatusCode)(ex.Data["StatusCode"] ?? (int)HttpStatusCode.InternalServerError);
                var response = ApiResponseHelper.ErrorResponse(ex.Message, statusCode);
                return StatusCode((int)response.StatusCode, response);              }

        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> UpdateById([FromBody] TDto dto)
        {
            try
            {
                var result = await _service.UpdateAsync(dto);
                var response = ApiResponseHelper.SuccessResponse(" Updated Successfully!", result,HttpStatusCode.OK);
                return StatusCode((int)response.StatusCode, response);             }
            catch (Exception ex)
            {
               var statusCode = (HttpStatusCode)(ex.Data["StatusCode"] ?? (int)HttpStatusCode.InternalServerError);
                var response = ApiResponseHelper.ErrorResponse(ex.Message, statusCode);
                return StatusCode((int)response.StatusCode, response);              }


        }
                [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                var response = ApiResponseHelper.SuccessResponse("Deleted Successfully!", result,HttpStatusCode.OK);
                return StatusCode((int)response.StatusCode, response);             }
            catch (Exception ex)
            {
               var statusCode = (HttpStatusCode)(ex.Data["StatusCode"] ?? (int)HttpStatusCode.InternalServerError);
                var response = ApiResponseHelper.ErrorResponse(ex.Message, statusCode);
                return StatusCode((int)response.StatusCode, response);              }
        }
    }
}