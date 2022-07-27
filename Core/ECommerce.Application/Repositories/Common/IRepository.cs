using ECommerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Repositories.Common
{
    public interface IRepository<T>
        where T : CommonEntity
    {
        DbSet<T> Table { get; }
    }
}
