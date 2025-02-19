namespace Microwave.Domain.SeedWork
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
