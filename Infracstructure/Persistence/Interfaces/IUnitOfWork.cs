using Domain.Interfaces;

namespace Infrastructure.Persistence.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    IBaseRepository<T> AsyncRepository<T>() where T : class;
}