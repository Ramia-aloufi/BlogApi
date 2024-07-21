using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.src.Services
{
    public interface IService<TDto>
    {
        Task<List<TDto>> GetAllAsync();
        Task<TDto> GetByAsync(int id);
        Task<TDto> CreateAsync(TDto dto);
        Task<bool> UpdateAsync(TDto dto);
        Task<bool> DeleteAsync(int id);

    }
}