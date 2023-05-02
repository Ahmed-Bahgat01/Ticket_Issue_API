using DAL.Data.Context;
using DAL.Repos.Interfaces;

namespace DAL.Repos;

public class EntityRepo<TEntity> : IEntityRepo<TEntity> where TEntity : class
{
    Context _dbContext;

    public EntityRepo(Context dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(TEntity entity)
    {
        if(entity is not null)
            _dbContext.Set<TEntity>().Add(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>();
    }

    public TEntity? GetById(int id)
    {
        return _dbContext.Set<TEntity>().Find(id);
    }

    public void Update(TEntity entity)
    {
    }
}
