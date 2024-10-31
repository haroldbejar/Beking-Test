using ProductManagementApp.Infrastructure.Repositories;

namespace ProductManagementApp.Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task InsertAsync(T entity, string userRole)
        {
            await _repository.InsertAsync(entity);
        }

    }
}