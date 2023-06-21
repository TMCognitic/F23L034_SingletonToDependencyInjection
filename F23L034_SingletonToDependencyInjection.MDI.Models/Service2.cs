using System.Data;

namespace F23L034_SingletonToDependencyInjection.Models
{
    public class Service2 : IService2
    {
        private readonly IDbConnection _dbConnection;

        public Service2(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public void DoSomething()
        {
            Console.WriteLine($"I do something (by Service2) : {_dbConnection.ConnectionString}");
        }
    }
}