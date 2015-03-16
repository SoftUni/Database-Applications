namespace NativelikeMongoDBQueries
{
    using System;
    
    using ExtensionsMethods;
    
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    public class Program
    {
        private const string DatabaseHost = "mongodb://127.0.0.1";
        private const string DatabaseName = "Logger";

        private static MongoDatabase GetDatabase(string name, string fromHost)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }

        private static void Main()
        {
            var db = GetDatabase(DatabaseName, DatabaseHost);

            IMongoQuery findNewLogsQuery = Query.And(
                Query.GT("LogDate", DateTime.Now.AddDays(-1)));

            var logs = db.GetCollection<Log>("Logs").Find(findNewLogsQuery);

            IMongoQuery findOldLogsQuery = Query.And(
                Query.LT("LogDate", DateTime.Now.AddDays(-1)));

            db.GetCollection<Log>("Logs").Remove(findOldLogsQuery);

            logs.Print();
        }
    }
}
