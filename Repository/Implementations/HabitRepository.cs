using MyHabitsApi.Context;
using MyHabitsApi.Domains;
using MyHabitsApi.Pagination;
using MyHabitsApi.Pagination.Filters;
using MyHabitsApi.Pagination.Parameters;
using MyHabitsApi.Repository.Interfaces;

namespace MyHabitsApi.Repository.Implementations
{
    public class HabitRepository : Repository<Habit>, IHabitRepository
    {
        public HabitRepository(ApiDbContext context) : base(context) { }

        public async Task<PagedList<Habit>> GetAllHabitsAsync(HabitPaginationParameter pagination)
        {
            var habits = GetAll().AsQueryable();
            var paginatedHabits = await PagedList<Habit>.ToPagedListAsync(habits, pagination.PageSize, pagination.PageNumber);
            return paginatedHabits;
        }

        public async Task<Habit?> GetHabitByIdAsync(int id)
        {
            var habit = await GetByFilterAsync(h => h.Id == id);
            return habit;
        }

        public async Task<PagedList<Habit>> GetHabitsByFrequencyAsync(HabitFraquencyFilter frequencyFilter)
        {
            var habits = GetAll().Where(h => h.Frequency == frequencyFilter.Frequency).AsQueryable();
            var paginatedHabits = await PagedList<Habit>.ToPagedListAsync(habits, frequencyFilter.PageSize, frequencyFilter.PageNumber);
            return paginatedHabits;
        }

        public async Task<PagedList<Habit>> GetHabitsByUserIdAsync(HabitsByUserFilter userFilter)
        {
            var habits = GetAll().Where(h => h.UserId == userFilter.UserId).AsQueryable();
            var paginatedHabits = await PagedList<Habit>.ToPagedListAsync(habits, userFilter.PageSize, userFilter.PageNumber);
            return paginatedHabits;
        }

        public async Task<PagedList<Habit>> GetHabitsIsActiveAsync(HabitIsActiveFilter activeFilter)
        {
            var habits = GetAll().Where(h => h.IsActive == activeFilter.IsActive).AsQueryable();
            var paginatedHabits = await PagedList<Habit>.ToPagedListAsync(habits, activeFilter.PageSize, activeFilter.PageNumber);
            return paginatedHabits;
        }
    }
}
