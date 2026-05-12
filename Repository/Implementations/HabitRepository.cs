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

        public async Task<PagedList<Habit>> GetAllHabits(HabitPaginationParameter pagination)
        {
            var habits = GetAll().AsQueryable();
            var paginatedHabits = await PagedList<Habit>.ToPagedList(habits, pagination.PageSize, pagination.PageNumber);
            return paginatedHabits;
        }

        public async Task<Habit?> GetHabitById(int id)
        {
            var habit = await GetByFilter(h => h.Id == id);
            return habit;
        }

        public async Task<PagedList<Habit>> GetHabitsByFrequency(HabitFraquencyFilter frequencyFilter)
        {
            var habits = GetAll().Where(h => h.Frequency == frequencyFilter.Frequency).AsQueryable();
            var paginatedHabits = await PagedList<Habit>.ToPagedList(habits, frequencyFilter.PageSize, frequencyFilter.PageNumber);
            return paginatedHabits;
        }

        public async Task<PagedList<Habit>> GetHabitsByUserId(HabitsByUserFilter userFilter)
        {
            var habits = GetAll().Where(h => h.UserId == userFilter.UserId).AsQueryable();
            var paginatedHabits = await PagedList<Habit>.ToPagedList(habits, userFilter.PageSize, userFilter.PageNumber);
            return paginatedHabits;
        }

        public async Task<PagedList<Habit>> GetHabitsIsActive(HabitIsActiveFilter activeFilter)
        {
            var habits = GetAll().Where(h => h.IsActive == activeFilter.IsActive).AsQueryable();
            var paginatedHabits = await PagedList<Habit>.ToPagedList(habits, activeFilter.PageSize, activeFilter.PageNumber);
            return paginatedHabits;
        }
    }
}
