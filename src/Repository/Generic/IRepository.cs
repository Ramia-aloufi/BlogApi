using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BlogApi.src.Models;

namespace BlogApi.src.Repository.Generic
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll(int pageNumber , int pageSize );
        Task<T> GetById(Expression<Func<T,bool>> filter , bool useNoTraking = false);
        Task<T> Create(T record);
        Task<T> Update(T record);
        Task<bool> Delete(T record);
    
    }
}