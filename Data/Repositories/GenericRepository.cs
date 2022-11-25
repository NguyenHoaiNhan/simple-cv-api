using SimpleCV.Data.DataContext.EF;
using SimpleCV.Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SimpleCV.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly PgDbContext _pgDbContext;

        public GenericRepository(PgDbContext pgDbContext)
        {
            _pgDbContext = pgDbContext;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _pgDbContext.AddAsync(entity);
            await _pgDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> AddRange(List<TEntity> entities)
        {
            await _pgDbContext.AddRangeAsync(entities);
            await _pgDbContext.SaveChangesAsync();
            return entities;
        }

        public Task<int> Delete(TEntity entity)
        {
            var entryToDelete = _pgDbContext.Remove(entity);
            return _pgDbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _pgDbContext
                 .Set<TEntity>()
                 .FirstOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            var entityQuery = _pgDbContext.Set<TEntity>().AsQueryable();

            if (filter != null)
            {
                entityQuery = entityQuery.Where(filter);
            }

            return await entityQuery.ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _pgDbContext.Update(entity);
            await _pgDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> UpdateRange(List<TEntity> entities)
        {
            _pgDbContext.UpdateRange(entities);
            await _pgDbContext.SaveChangesAsync();
            return entities;
        }
    }
}