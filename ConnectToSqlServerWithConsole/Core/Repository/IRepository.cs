using ConnectToSqlServerWithConsole.Core.Entity;
using System.Linq.Expressions;

namespace ConnectToSqlServerWithConsole.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> FindAndSort(Func<TEntity, bool> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        IEnumerable<TEntity> FindAsPaging(Func<TEntity, bool> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,int? skip = 0,int? take = 0);
        public IEnumerable<TEntity> FindWithExpression(Expression<Func<TEntity, bool>> predicate,
                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,int? skip = null,int? take = null);

        public IEnumerable<TEntity> FindWithExpressionMultipleFilter(Expression<Func<LOGS, bool>> searchFunction, Func<IQueryable<LOGS>, IOrderedQueryable<LOGS>> orderBy = null, int? skip = 0, int? take = 0);  
    }
}
