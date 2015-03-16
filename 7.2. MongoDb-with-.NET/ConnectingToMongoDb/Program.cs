namespace ConnectingToMongoDb
{
    using System;
    using System.Linq;
    
    using ExtensionsMethods;
    
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

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
            var db = GetDatabase(DatabaseName, DatabaseHost);

            var logs = db.GetCollection<Log>("Logs");

            logs.Insert(new Log()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                LogDate = DateTime.Now,
                Text = "Something important happened"
            });

            var update = Update.Set("Text", "Changed Text at " + DateTime.Now);

            var query = Query.And(Query.LT("LogDate", DateTime.Now.AddSeconds(-1)));

            logs.Update(query, update);

            logs.FindAll()
                .Select(l => l.Text)
                .Print();
        }
    }
}
