using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BlogApi.src.DB;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.src.Repository.Generic
{
    public class Repository<T> : IRepository<T> where T : class
    {
          private readonly DBContext _context;
          private DbSet<T> _dbSet;

        public Repository(DBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> Create(T record)
        {
            _dbSet.Add(record);
            await _context.SaveChangesAsync();
            return record;

        }

        public async Task<bool> Delete(T record)
        {
            _dbSet.Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();

        }

        public async Task<T> GetById(Expression<Func<T,bool>> filter , bool traking = false)
        {
            if(traking)
             return await _dbSet.AsNoTracking().Where(filter).FirstOrDefaultAsync();

            return await _dbSet.Where(filter).FirstOrDefaultAsync();
        }

        public async Task<T> Update(T record)
        {

            _dbSet.Update(record);
            await _context.SaveChangesAsync();
            return record;

        }
    }
    }
