namespace DAL.Repos.Interfaces;

public interface IEntityRepo<T> where T : class
{
    T? GetById(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
}
