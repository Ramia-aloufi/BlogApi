using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogApi.src.Repository.Generic
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Expression<Func<T,bool>> filter , bool useNoTraking = false);
        Task<T> Create(T record);
        Task<T> Update(T record);
        Task<bool> Delete(T record);
    }
}