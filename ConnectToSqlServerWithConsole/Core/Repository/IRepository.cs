namespace ConnectToSqlServerWithConsole.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
    }
}
