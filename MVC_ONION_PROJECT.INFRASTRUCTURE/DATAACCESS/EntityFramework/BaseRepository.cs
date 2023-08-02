using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MVC_ONION_PROJECT.DOMAIN.CORE.BASE;
using MVC_ONION_PROJECT.DOMAIN.CORE.Interfaces;
using MVC_ONION_PROJECT.INFRASTRUCTURE.DATAACCESS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MVC_ONION_PROJECT.INFRASTRUCTURE.DATAACCESS.EntityFramework
{
    public abstract class BaseRepository<TEntity> : IRepository, IAsyncRepository, IAsyncFindableRepository<TEntity>, IAsyncInsertableRepository<TEntity>, IAsyncQueryableRepository<TEntity>, IAsyncOrderableRepository<TEntity>, IAsyncDeletableRepository<TEntity>, IAsyncUpdateableRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _context;

        private readonly DbSet<TEntity> _table;

        public BaseRepository(DbContext context, DbSet<TEntity> table)
        {
            _context = context;
            _table = table;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var entry = await _table.AddAsync(entity);
            return entry.Entity;
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return _table.AddRangeAsync(entities);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            return expression is null ? GetAllActives().AnyAsync() : GetAllActives().AnyAsync(expression);
        }

        public Task DeletableAsync(TEntity entity)
        {
            return Task.FromResult(_table.Remove(entity)); //silmenin async işlemi yok
        }

        public Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities); //yine async yok derleyici görünüyor ama yok
            return _context.SaveChangesAsync(); //bu da aslında diğer yöntemi
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = true)
        {
            return await GetAllActives(tracking).ToListAsync(); //dönüşün async ise buraya await yazmak zorundasın yukarı da async gelir
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true)
        {
            return await GetAllActives(tracking).Where(expression).ToListAsync(); //sadece where(expression) ekledik
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> orderby, bool orderDesc = false, bool tracking = true)
        {
            var values = GetAllActives(tracking);
            return orderDesc ? await values.OrderByDescending(orderby).ToListAsync() : await values.OrderBy(orderby).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, bool>> orderby, bool orderDesc = false, bool tracking = true)
        {
            var values = GetAllActives(tracking).Where(expression);
            return orderDesc ? await values.OrderByDescending(orderby).ToListAsync() : await values.OrderBy(orderby).ToListAsync();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true)
        {
            return await GetAllActives(tracking).FirstOrDefaultAsync(expression);
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, bool tracking = true)
        {
            return await GetAllActives(tracking).FirstOrDefaultAsync(x=>x.Id == id);
        }

        public int SaveChange()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entry = await Task.FromResult(_table.Update(entity));
            return entry.Entity;
        }

        protected IQueryable<TEntity> GetAllActives(bool tracking = true)
        {
            var values = _table.Where(x => x.Status != DOMAIN.ENUMS.Status.Deleted);
            return tracking ? values : values.AsNoTracking();
        }
    }
}
