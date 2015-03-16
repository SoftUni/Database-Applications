namespace LinqLikeQueries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ExtensionsMethods;
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

            var logsCollection = db.GetCollection<Log>("Logs");
            
            logsCollection.InsertBatch(CreateSampleLogs(100));

            var findBugsQuery = Query<Log>.Where(log => log.LogType.Type == "bug" && log.LogDate > DateTime.Now.AddDays(-7));

            logsCollection.Find(findBugsQuery)
                          .Select(log => log.Text)
                          .Print();

            var findOldPendingBugsQuery = Query<Log>.Where(log => log.LogDate < DateTime.Now.AddDays(-10) &&
                                                                  log.LogType.Type == "bug" &&
                                                                  log.LogType.State == "pending");

            logsCollection.Find(findOldPendingBugsQuery)
                          .Select(log => log.Text)
                          .Print();
        }
    }
}