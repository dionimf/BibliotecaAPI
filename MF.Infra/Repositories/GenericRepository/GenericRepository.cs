using System;
using System.Linq;
using System.Threading.Tasks;
using MF.Domain.Entities;
using MF.Domain.Interfaces;
using MF.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace MF.Infra.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public readonly MainContext _dbContext;

        public GenericRepository(MainContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Guid id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}