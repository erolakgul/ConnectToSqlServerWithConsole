using ConnectToSqlServerWithConsole.Core.Entity;
using ConnectToSqlServerWithConsole.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ConnectToSqlServerWithConsole.Data.Repository
{
    public class LogRepository : IRepository<LOGS>
    {
        private readonly DbContext _context;
        private readonly DbSet<LOGS> _dbSet;

        public LogRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<LOGS>();
        }

        public IEnumerable<LOGS> Find(Func<LOGS, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<LOGS> FindAndSort(Func<LOGS, bool> predicate, Func<IQueryable<LOGS>, IOrderedQueryable<LOGS>> orderBy = null)
        {
            IQueryable<LOGS> list = _dbSet.AsNoTracking().Where(predicate).AsQueryable();

            if (orderBy is not null)
            {
                list = orderBy(list);
            }

            return list.ToList();
        }

        public IEnumerable<LOGS> FindAsPaging(Func<LOGS, bool> predicate, Func<IQueryable<LOGS>, IOrderedQueryable<LOGS>> orderBy = null, int? skip = 0, int? take = 0)
        {
            IQueryable<LOGS> list = _dbSet.AsNoTracking().Where(predicate).AsQueryable();

            if (orderBy is not null)
            {
                list = orderBy(list);
            }

            if (skip.HasValue)
            {
                list = list.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                list = list.Take(take.Value);
            }

            return list.ToList();
        }

        public IEnumerable<LOGS> FindWithExpression(Expression<Func<LOGS, bool>> predicate, Func<IQueryable<LOGS>, IOrderedQueryable<LOGS>> orderBy = null, int? skip = null, int? take = null)
        {
            IQueryable<LOGS> query = _dbSet.AsNoTracking().Where(predicate);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }
    }
}
