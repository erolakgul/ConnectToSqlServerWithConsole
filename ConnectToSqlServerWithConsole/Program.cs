using ConnectToSqlServerWithConsole.Core.Entity;
using ConnectToSqlServerWithConsole.Data.Context;
using ConnectToSqlServerWithConsole.Data.Repository;
using System.Linq.Expressions;

using (var context = new IotContext())
{
    var logRepository = new LogRepository(context);

    // func tanımla
    //Func<LOGS, bool> searchFunction =
    //(   p =>
    //    p.Url.Contains("EAKGUL") 
    //      && 
    //    p.CreatedDate >= DateTime.Parse("2022/11/15")
    //);

    Expression<Func<LOGS, bool>> searchFunction = p => 
                 p.Url.Contains("EAKGUL") && 
                 p.CreatedDate >= DateTime.Parse("2022/11/15");

    // func ı repoya gönder
    //var results = logRepository.Find(searchFunction);

    Func<IQueryable<LOGS>, IOrderedQueryable<LOGS>> orderByFunction =
        (
            q =>
            q.OrderBy(p => p.CreatedDate)
        );

    //var results = logRepository.FindAndSort(searchFunction, orderByFunction);

    int skipAt = 3;
    int takeAt = 10;

    //var results = logRepository.FindAsPaging(searchFunction, orderByFunction,skipAt,takeAt);

    var results = logRepository.FindWithExpression(searchFunction, orderByFunction, skipAt, takeAt);

    // sonucu görüntüle
    foreach (var log in results)
    {
        Console.WriteLine($"Log Id: {log.ID}, Name: {log.MachineName}, Url: {log.Url} , Date : {log.CreatedDate}");
    }
};

Console.ReadKey();