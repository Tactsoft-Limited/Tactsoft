﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tactsoft.Data.DbDependencies;
using Tactsoft.Core.Entities.Base;

namespace Tactsoft.Service.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private DbSet<T> entities;
        public BaseService(AppDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }
        public IQueryable<T> All()
        {
            return entities;
        }
        public IQueryable<T> All(params Expression<Func<T, Object>>[] includeProperties)
        {
            IQueryable<T> queryable = All();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {queryable = queryable.Include<T, object>(includeProperty);}
            return queryable;
        }
        
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public T Find(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public T Find(long id, params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entity.CreatedDateUtc = DateTime.UtcNow;
            entity.UpdatedDateUtc = DateTime.UtcNow;
            entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(long id, T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //Async Methods

        public async Task<List<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }
        public async Task<List<T>> GetAllAsync(params Expression<Func<T, Object>>[] includes)
        {
            return await includes.Aggregate(
                entities.AsQueryable(),
                (current, include) => current.Include(include)).ToListAsync();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includes)
        {
            return await includes.Aggregate(
                entities.AsQueryable(),
                (current, include) => current.Include(include),
                c => c.Where(predicate)
            ).ToListAsync()
            .ConfigureAwait(false);
        }


        public async Task<T> FindAsync(long id) => await entities.FindAsync(id);

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return await includes.Aggregate(entities.AsQueryable(),
                (current, include) => current.Include(include),
                c => c.AsNoTracking().FirstOrDefaultAsync(predicate)
            ).ConfigureAwait(false);
        }
        public async Task<T> UpdateAsync(long id, T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            entities.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateRangeAsync(List<T> entity)
        {
            entities.UpdateRange(entity);
            await Task.CompletedTask;
        }


        public async Task<T> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
           await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteRangeAsync(List<T> entity)
        {
            entities.RemoveRange(entity);
            await Task.CompletedTask;
        }
        public  async Task<T> InsertAsync(T entity)
        {
           await  entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
    }
}
