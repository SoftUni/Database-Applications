namespace LinqToMongoDB
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ExtensionsMethods;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;

    public class EntryPoint
    {
        private const string DatabaseHost = "mongodb://127.0.0.1";
        private const string DatabaseName = "Logger";

        public static MongoDatabase GetDatabase(string name, string fromHost)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }

        public static IEnumerable<Log> CreateSampleLogs(int count)
        {
            var date = DateTime.Now;
            var logs = new List<Log>(count);

            for (var i = 0; i < count; i++)
            {
                var logState = (i % 2 == 0) ? "closed" : "pending";
                var logType = (i % 3 == 0) ? "bug" : (i % 3 == 1) ? "feature-request" : "ticket";
                var text = string.Format("Log  #{0}({1})", i + 1, logType);
                var log = new Log(text, date);
                log.LogType = new LogType()
                {
                    State = logState,
                    Type = logType
                };
                logs.Add(log);
                date = date.AddDays(-1);
            }

            return logs;
        }

        public static void Main()
        {
            var db = GetDatabase(DatabaseName, DatabaseHost);

            var logs = from log in db.GetCollection<Log>("Logs").AsQueryable<Log>()
                       where log.LogType.Type == "ticket" && log.LogType.State == "pending"
                       select log;
            Console.WriteLine(logs.Count());

            logs.Print();
        }
    }
}