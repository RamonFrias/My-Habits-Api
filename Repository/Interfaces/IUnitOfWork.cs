namespace MyHabitsApi.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IHabitRepository HabitRepository { get; }
        Task CommitAsync();
        void Dispose();
    }
}
