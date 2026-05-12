using Microsoft.EntityFrameworkCore;
using MyHabitsApi.Context;
using MyHabitsApi.Domains;
using MyHabitsApi.Pagination;
using MyHabitsApi.Pagination.Parameters;
using MyHabitsApi.Repository.Interfaces;

namespace MyHabitsApi.Repository.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApiDbContext context) : base(context) { }

        public async Task<PagedList<User>> GetAllUsers(UserPaginationParameter pagination)
        {
            var users = GetAll().AsQueryable();
            var paginatedUsers = await PagedList<User>.ToPagedList(users, pagination.PageSize, pagination.PageNumber);
            return paginatedUsers;
        }

        public async Task<User?> GetUserById(int id)
        {
            var user = await GetByFilter(u => u.Id == id);
            return user;
        }
    }
}
