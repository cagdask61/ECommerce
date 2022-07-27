using ECommerce.Application.Repositories.CustomerRepository;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Persistence.Contexts;
using ECommerce.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Repositories.CustomerRepository
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
