using ECommerce.Application.Repositories.CustomerRepository;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Persistence.Contexts;
using ECommerce.Persistence.Repositories.Common;

namespace ECommerce.Persistence.Repositories.CustomerRepository
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
