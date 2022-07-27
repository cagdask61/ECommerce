using ECommerce.Application.Repositories.ProductRepository;
using ECommerce.Domain.Entities.Concretes;
using ECommerce.Persistence.Contexts;
using ECommerce.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Repositories.ProductRepository
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
