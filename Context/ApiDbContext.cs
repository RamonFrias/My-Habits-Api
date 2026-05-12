using Microsoft.EntityFrameworkCore;
using MyHabitsApi.Domains;

namespace MyHabitsApi.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }
    }
}
