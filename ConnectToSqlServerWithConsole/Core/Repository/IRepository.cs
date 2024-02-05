namespace ConnectToSqlServerWithConsole.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> FindAndSort(Func<TEntity, bool> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}
