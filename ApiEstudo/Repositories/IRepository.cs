using ApiEstudo.Context;
using System.Linq.Expressions;

namespace ApiEstudo.Repositories
{
    public interface IRepository<T>
    {
    //cuidado para não violar o principio ISP
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    T Create(T entity);
    T Update(T entity);
    T Delete(T entity);
    }
}
