using Hostels.Core.Entities;

namespace Hostels.Data.Repositories;

public interface IRepository<TEntity> 
    where TEntity : IEntity
{
    Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken);

    Task<TEntity?> GetById(int id, CancellationToken cancellationToken);

    Task<TEntity?> AddAsync(TEntity entity, CancellationToken cancellationToken);

    TEntity? UpdateAsync(TEntity entity);

    Task<TEntity?> RemoveAsync(int id, CancellationToken cancellationToken);
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}