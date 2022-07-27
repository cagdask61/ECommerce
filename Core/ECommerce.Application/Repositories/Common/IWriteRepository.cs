using ECommerce.Domain.Entities.Common;

namespace ECommerce.Application.Repositories.Common
{
    public interface IWriteRepository<T> : IRepository<T>
        where T : CommonEntity
    {

        Task AddAsync(T entity);

        void Remove(T entity);
        void RemoveAsync(string id);

        void Update(T entity);

        Task<int> SaveAsync();
    }
}
