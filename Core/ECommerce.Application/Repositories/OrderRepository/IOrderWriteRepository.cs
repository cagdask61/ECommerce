using ECommerce.Application.Repositories.Common;
using ECommerce.Domain.Entities.Concretes;

namespace ECommerce.Application.Repositories.OrderRepository
{
    public interface IOrderWriteRepository : IWriteRepository<Order>
    {
    }
}
