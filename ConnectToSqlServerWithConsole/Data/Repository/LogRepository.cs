using ConnectToSqlServerWithConsole.Core.Entity;
using ConnectToSqlServerWithConsole.Core.Repository;
using Microsoft.EntityFrameworkCore;

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
    }
}
