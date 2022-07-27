using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Repositories.Common
{
    public interface IReadRepository<T> : IRepository<T>
        where T : CommonEntity
    {
        IQueryable<T> GetAll(bool tracking = true);

        IQueryable<T> GetWhereAll(Expression<Func<T, bool>> filter, bool tracking = true);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);

    }
}
