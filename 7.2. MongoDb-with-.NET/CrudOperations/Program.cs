namespace CrudOperations
{
    using System;

    using ExtensionsMethods;
    
    using MongoDB.Driver;

    public class Program
    {
        private const string DatabaseHost = "mongodb://127.0.0.1";
        private const string DatabaseName = "Logger";

        public static MongoDatabase GetDatabase(string name, string fromHost)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }

        public static void Main()
        {
            var database = GetDatabase(DatabaseName, DatabaseHost);

            var logsCollection = database.GetCollection<Log>("Logs");

            Log[] logsToInsert =
            {
                new Log("Bug Logged", DateTime.Now.AddHours(-1)),
                new Log("Bug Fixed", DateTime.Now)
            };

            logsCollection.InsertBatch(logsToInsert);
            
            var logs = logsCollection.FindAll();

            logs.Print();
        }
    }
}
