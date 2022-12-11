using System.Linq.Expressions;

namespace CryptoService.Core.Repositories
{
    public interface IReadRepository<T> where T : class
    {
        Task<T> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
    }
}
