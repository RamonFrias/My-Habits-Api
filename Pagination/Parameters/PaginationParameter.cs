namespace MyHabitsApi.Pagination.Parameters
{
    public class PaginationParameter
    {
        public int maxPageSize = 50;
        public int PageNumber { get; set; }
        public int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

    }
}
