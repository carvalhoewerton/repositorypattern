namespace Veiculo_API.Infra.Repositories.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> All();
    Task<T> GetById(int id);
    Task<bool> Add(T entity);
    Task<bool> Update(T entity);
    
}