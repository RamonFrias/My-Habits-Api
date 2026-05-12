using MyHabitsApi.Domains;
using MyHabitsApi.Pagination;
using MyHabitsApi.Pagination.Filters;
using MyHabitsApi.Pagination.Parameters;

namespace MyHabitsApi.Repository.Interfaces
{
    public interface IHabitRepository : IRepository<Habit>
    {
        Task<PagedList<Habit>> GetAllHabitsAsync(HabitPaginationParameter pagination);
        Task<PagedList<Habit>> GetHabitsIsActiveAsync(HabitIsActiveFilter activeFilter);
        Task<PagedList<Habit>> GetHabitsByFrequencyAsync(HabitFraquencyFilter frequencyFilter);
        Task<PagedList<Habit>> GetHabitsByUserIdAsync(HabitsByUserFilter userFilter);
        Task<Habit?> GetHabitByIdAsync(int id);
    }
}
