using ConnectToSqlServerWithConsole.Core.Entity;
using ConnectToSqlServerWithConsole.Data.Context;
using ConnectToSqlServerWithConsole.Data.Repository;

using (var context = new IotContext())
{
    var logRepository = new LogRepository(context);

    // func tanımla
    Func<LOGS, bool> searchFunction =
    (   p =>
        p.Url.Contains("EAKGUL") 
          && 
        p.CreatedDate >= DateTime.Parse("2022/11/15")
    ); 

    // func ı repoya gönder
    var results = logRepository.Find(searchFunction);

    // sonucu görüntüle
    foreach (var log in results)
    {
        Console.WriteLine($"Log Id: {log.ID}, Name: {log.MachineName}, Url: {log.Url} , Date : {log.CreatedDate}");
    }
};

Console.ReadKey();