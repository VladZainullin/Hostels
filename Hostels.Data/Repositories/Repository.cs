using Hostels.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hostels.Data.Repositories;

public class Repository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class, IEntity
    where TContext : DbContext
{
    private readonly TContext _context;

    public Repository(TContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetById(int id, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<TEntity>()
            .Where(s => s.Id == id)
            .SingleOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<TEntity?> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _context.AddAsync(entity, cancellationToken);

        return entity;
    }

    public TEntity? UpdateAsync(TEntity updateEntity)
    {
        var entity = _context.Set<TEntity>().Attach(updateEntity);
        entity.State = EntityState.Modified;
        return updateEntity;
    }

    public async Task<TEntity?> RemoveAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await GetById(id, cancellationToken);
        if (entity is not null)
        {
            _context.Remove(entity);
        }

        return entity;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}