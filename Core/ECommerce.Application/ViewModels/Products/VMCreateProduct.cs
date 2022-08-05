using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.ViewModels.Products
{
    public class VMCreateProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long UnitPrice { get; set; }
    }
}
