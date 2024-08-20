using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDBcontext _context;
        public BaseRepository(ApplicationDBcontext context)
        {
            _context = context;
        }
        public async Task<T> Create(T entity)
        {
            try
            {
                var Model= await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return Model.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Delete(T entity)
        {
            try
            {
                var Model=  _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return Model.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                var Model = _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return Model.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
