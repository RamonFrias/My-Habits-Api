using Microsoft.EntityFrameworkCore;

namespace MyHabitsApi.Pagination
{
    public class PagedList<T> : List<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasNext => CurrentPage < TotalPages;
        public bool HasPreview => CurrentPage > 1;

        public PagedList(List<T> items, int count, int pageSize, int pageNumber)
        {
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(count/(double)pageSize);
            AddRange(items);
        }

        public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> source, int pageSize, int pageNumber)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            return new PagedList<T>(items, count, pageSize, pageNumber);
        }
    }
}
