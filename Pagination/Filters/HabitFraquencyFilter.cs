using MyHabitsApi.Enums;
using MyHabitsApi.Pagination.Parameters;

namespace MyHabitsApi.Pagination.Filters
{
    public class HabitFraquencyFilter : HabitPaginationParameter
    {
        public HabitFrequency Frequency { get; set; }
    }
}
