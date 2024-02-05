namespace ConnectToSqlServerWithConsole.Core.Repository
{
    public interface ILogRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
    }
}
