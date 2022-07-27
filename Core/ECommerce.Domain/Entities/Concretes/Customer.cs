using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities.Concretes
{
    public class Customer : CommonEntity
    {
        public int UserId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
