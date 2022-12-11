namespace CryptoService.Core.Repositories
{
    public interface IRepository<T> : IReadRepository<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task BatchAdd(IEnumerable<T> entities);
        Task BatchUpdate(IEnumerable<T> entities);
        Task BatchRemove(IEnumerable<T> entities);
    }
}
