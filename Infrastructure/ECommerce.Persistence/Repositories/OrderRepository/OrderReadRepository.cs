using ECommerce.Application.Repositories.OrderRepository;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Persistence.Contexts;
using ECommerce.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Repositories.OrderRepository
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
