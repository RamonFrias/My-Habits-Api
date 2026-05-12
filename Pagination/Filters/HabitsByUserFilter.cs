using MyHabitsApi.Pagination.Parameters;

namespace MyHabitsApi.Pagination.Filters
{
    public class HabitsByUserFilter : HabitPaginationParameter
    {
        public int UserId { get; set; }
    }
}
