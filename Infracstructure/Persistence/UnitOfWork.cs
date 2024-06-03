using Domain.Interfaces;
using Infracstructure.Persistance;
using Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly datnContext _dbContext;

    public UnitOfWork(datnContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IBaseRepository<T> AsyncRepository<T>() where T : class
    {
        return new RepositoryBase<T>(_dbContext);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}