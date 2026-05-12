using MyHabitsApi.Domains;
using MyHabitsApi.Pagination;
using MyHabitsApi.Pagination.Parameters;

namespace MyHabitsApi.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<PagedList<User>> GetAllUsers(UserPaginationParameter pagination);
        Task<User?> GetUserById(int id);
    }
}
