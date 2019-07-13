using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenBudget.Application.Infrastructure.Persistence
{
  public interface IRepository<TEntity>
    where TEntity : class
  {
    Task<List<TEntity>> GetAsync();
    Task<TEntity> GetAsync(Guid id);

    Task<bool> CheckExistsAsync(Guid id);
    Task<long> CountAsync();

    Task<TEntity> InsertAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);

    Task SaveChangesAsync();
  }
}