namespace ProductManagementApp.Application.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task InsertAsync(T entity, string userRole);
    }
}