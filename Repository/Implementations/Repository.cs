using Microsoft.EntityFrameworkCore;
using MyHabitsApi.Context;
using MyHabitsApi.Repository.Interfaces;
using System.Linq.Expressions;

namespace MyHabitsApi.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApiDbContext _context;
        public Repository(ApiDbContext context) => _context = context;
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T?> GetByFilter(Expression<Func<T, bool>> predicate)
        {
            var value = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
            if (value is null)
                return null;
            return value;
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
