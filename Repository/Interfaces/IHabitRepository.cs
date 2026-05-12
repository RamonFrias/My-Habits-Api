using MyHabitsApi.Domains;
using MyHabitsApi.Pagination;
using MyHabitsApi.Pagination.Filters;
using MyHabitsApi.Pagination.Parameters;

namespace MyHabitsApi.Repository.Interfaces
{
    public interface IHabitRepository : IRepository<Habit>
    {
        Task<PagedList<Habit>> GetAllHabits(HabitPaginationParameter pagination);
        Task<PagedList<Habit>> GetHabitsIsActive(HabitIsActiveFilter activeFilter);
        Task<PagedList<Habit>> GetHabitsByFrequency(HabitFraquencyFilter frequencyFilter);
        Task<PagedList<Habit>> GetHabitsByUserId(HabitsByUserFilter userFilter);
        Task<Habit?> GetHabitById(int id);
    }
}
