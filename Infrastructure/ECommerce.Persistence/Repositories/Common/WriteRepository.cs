using ECommerce.Application.Repositories.Common;
using ECommerce.Domain.Entities.Common;
using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Repositories.Common
{
    public class WriteRepository<T> : IWriteRepository<T>
        where T : CommonEntity
    {

        private readonly ProjectDbContext _context;
        public WriteRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async void Remove(T entity)
        {
            Table.Remove(entity);
        }

        public async void RemoveAsync(string id)
        {
            var entity = await Table.FirstOrDefaultAsync(e => e.Id == Guid.Parse(id));
            _ = Table.Remove(entity);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync(); 
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }
    }
}
