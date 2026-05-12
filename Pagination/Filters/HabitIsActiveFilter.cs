using MyHabitsApi.Pagination.Parameters;

namespace MyHabitsApi.Pagination.Filters
{
    public class HabitIsActiveFilter : HabitPaginationParameter
    {
        public bool IsActive { get; set; }
    }
}
