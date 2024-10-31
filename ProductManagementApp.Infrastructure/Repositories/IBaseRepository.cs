namespace ProductManagementApp.Infrastructure.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task InsertAsync(T entity);
    }
}