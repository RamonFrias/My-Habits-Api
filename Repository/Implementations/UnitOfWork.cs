using MyHabitsApi.Context;
using MyHabitsApi.Repository.Interfaces;

namespace MyHabitsApi.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository _userRepository;

        public IHabitRepository _habitRepository;

        private readonly ApiDbContext _context;
        public UnitOfWork(ApiDbContext context) => _context = context;

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new UserRepository(_context);
            }
        }

        public IHabitRepository HabitRepository
        {
            get
            {
                return _habitRepository = _habitRepository ?? new HabitRepository(_context);
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
