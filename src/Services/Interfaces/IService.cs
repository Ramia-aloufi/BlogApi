using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BlogApi.src.Models;

namespace BlogApi.src.Services
{
    public interface IService<TDto>
    {
        Task<IPagedResult<TDto>> GetAllAsync(int pageNumber, int pageSize );
        Task<TDto> GetByAsync(int id);
        Task<TDto> CreateAsync(TDto dto);
        Task<bool> UpdateAsync(TDto dto);
        Task<bool> DeleteAsync(int id);

    }
}