
using ConnectToSqlServerWithConsole.Data.Context;

using (var context = new IotContext())
{
	try
	{
		var list = context.Logs.Where(x => !x.IsDeleted).ToList();

		foreach (var item in list)
		{
			Console.WriteLine(item.Url);
		}
	}
	catch (Exception ex) 
	{
		Console.WriteLine(ex.Message.ToString());
	}
}


Console.ReadKey();