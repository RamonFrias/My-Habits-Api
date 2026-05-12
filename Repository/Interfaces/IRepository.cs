using System.Linq.Expressions;

namespace MyHabitsApi.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
