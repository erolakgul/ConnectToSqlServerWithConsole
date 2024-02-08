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

    //Expression<Func<LOGS, bool>> searchFunction = p => 
    //             p.Url.Contains("EAKGUL") && 
    //             p.CreatedDate >= DateTime.Parse("2022/11/15");

    // func ı repoya gönder
    //var results = logRepository.Find(searchFunction);

    //Func<IQueryable<LOGS>, IOrderedQueryable<LOGS>> orderByFunction =
    //    (
    //        q =>
    //        q.OrderBy(p => p.CreatedDate)
    //    );

    //var results = logRepository.FindAndSort(searchFunction, orderByFunction);

    //int skipAt = 3;
    //int takeAt = 10;

    //var results = logRepository.FindAsPaging(searchFunction, orderByFunction,skipAt,takeAt);

    //var results = logRepository.FindWithExpression(searchFunction, orderByFunction, skipAt, takeAt);

    var searchParameter = Expression.Parameter(typeof(LOGS), "x");

    #region lambda ile birleştirme 
    /*
    var containsQueryFunc = ExpressionContains<LOGS>("Url", "EAKGUL");

    var dateParam = Expression.Property(searchParameter, "CreatedDate");
    var constantDate = Expression.Constant(new DateTime(2023, 11, 15));
    var dateFunc = Expression.GreaterThan(dateParam, constantDate);
    var expressionQueryFunc = Expression.Lambda<Func<LOGS, bool>>(dateFunc, searchParameter);

    var nameParam = Expression.Property(searchParameter, "Url");
    var constantName = Expression.Constant("/api/admin/user/GetUserDetail/EAKGUL");
    var nameFunc = Expression.Equal(nameParam, constantName);
    var nameQueryFunc = Expression.Lambda<Func<LOGS, bool>>(nameFunc, searchParameter);

    Expression<Func<LOGS, bool>> combinedExpression = Expression.Lambda<Func<LOGS, bool>>(
                                              Expression.AndAlso(
                                                  nameQueryFunc.Body,
                                                  containsQueryFunc.Body),
                                              searchParameter
                                                  );
    */
    #endregion

    Expression<Func<LOGS, bool>> expression =
                                        a => (
                                                a.CreatedDate >= new DateTime(2022, 11, 15)
                                                  && a.CreatedDate <= new DateTime(2022, 11, 21)
                                             )
                                             && a.Url.ToLower().Contains("eakgul");


    Func<IQueryable<LOGS>, IOrderedQueryable<LOGS>> orderByFunction =
     (
         q =>
         q.OrderBy(p => p.CreatedDate)
     );


    int skipAt = 2;
    int takeAt = 5;

    var results = logRepository.FindWithExpressionMultipleFilter(expression, orderByFunction,skipAt,takeAt);

    // sonucu görüntüle
    foreach (var log in results)
    {
        Console.WriteLine($"Log Id: {log.ID}, Name: {log.MachineName}, Url: {log.Url} , Date : {log.CreatedDate}");
    }
};

//static Expression<Func<T, bool>> ExpressionContains<T>(string propertyName, string searchTerm)
//{
//    var parameter = Expression.Parameter(typeof(T), "x");
//    var property = Expression.Property(parameter, propertyName);
//    var searchTermToLower = searchTerm.ToLower();
//    var searchTermExpression = Expression.Constant(searchTermToLower);

//    var toLowerMethod = typeof(string).GetMethod("ToLower", System.Type.EmptyTypes);
//    var propertyToLower = Expression.Call(property, toLowerMethod);

//    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
//    var containsExpression = Expression.Call(propertyToLower, containsMethod, searchTermExpression);

//    return Expression.Lambda<Func<T, bool>>(containsExpression, parameter);
//}


Console.ReadKey();
