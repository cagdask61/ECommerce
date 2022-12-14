using ECommerce.Application.Repositories.Common;
using ECommerce.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Repositories.ProductRepository
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
    }
}
