using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities.Concretes
{
    public class Product : CommonEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long UnitPrice { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
