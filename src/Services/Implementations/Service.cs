
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Net;
using AutoMapper;
using BlogApi.src.DTOs;
using BlogApi.src.Models;
using BlogApi.src.Repository.Generic;

namespace BlogApi.src.Services.Implementations
{
    public class Service<TEntity, TDto>(IRepository<TEntity> repository, IMapper mapper) : IService<TDto> where TEntity : class, IEntity where TDto : ITDto
    {
        private readonly IRepository<TEntity> _Repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<TDto> CreateAsync(TDto dto)
        {
             if (dto == null)
                throw new Exception( $"the argument {typeof(TEntity).Name} is null"){ Data = { ["StatusCode"] = HttpStatusCode.NotFound }};
            var exist = await _Repository.GetById(n => n.Name == dto.Name);
            if (exist != null)
                throw new Exception($"The {typeof(TEntity).Name} Name is Already exist"){ Data = { ["StatusCode"] = HttpStatusCode.BadRequest }};
            var newData = _mapper.Map<TEntity>(dto);
            var entityData = await _Repository.Create(newData);
            var dtoData = _mapper.Map<TDto>(entityData);
            return dtoData;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new Exception("The ID must be greater than zero.") { Data = { ["StatusCode"] = HttpStatusCode.BadRequest } };
            var data = await _Repository.GetById(n => n.Id == id) ?? throw new Exception($"{typeof(TEntity).Name} with ID {id} not found") { Data = { ["StatusCode"] = HttpStatusCode.NotFound } };
            var isDeleted = await _Repository.Delete(data);
            return isDeleted;
        }
        public async Task<IPagedResult<TDto>> GetAllAsync(int pageNumber = 1, int pageSize = 0)
        {
            var data = await _Repository.GetAll(pageNumber,pageSize);
            var allData = await _Repository.GetAll(1,0);

            var result = _mapper.Map<List<TDto>>(data);

            return new IPagedResult<TDto>
            {
            Data = result,
            TotalRecords = allData.Count,
            PageNumber = pageNumber,
            PageSize = result.Count
        };
        }
        public async Task<TDto> GetByAsync(int id)
        {
            if (id <= 0)
            throw new Exception("The ID must be greater than zero.") { Data = { ["StatusCode"] = HttpStatusCode.BadRequest } };
            var data = await _Repository.GetById(n => n.Id == id) ?? throw new Exception($"{typeof(TEntity).Name} with ID {id} not found") { Data = { ["StatusCode"] = HttpStatusCode.NotFound } };
            var dto = _mapper.Map<TDto>(data);
            return dto;
        }
        public async Task<bool> UpdateAsync(TDto dto)
        {
            if (dto.Id <= 0)
                throw new Exception("The ID must be greater than zero.") { Data = { ["StatusCode"] = HttpStatusCode.BadRequest } };
            var data = await _Repository.GetById(n => n.Id == dto.Id,true) ?? throw new Exception($"{typeof(TEntity).Name} with ID {dto.Id} not found") { Data = { ["StatusCode"] = HttpStatusCode.NotFound } };
            _mapper.Map(dto, data);
            await _Repository.Update(data);
            return true;
        }
    
    }
}