using System;
using System.Linq;
using System.Threading.Tasks;
using MF.Domain.Entities;

namespace MF.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity:BaseEntity
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task Create(TEntity entity);
        Task Update(Guid id, TEntity entity);
        Task Delete(Guid id);
    }
}