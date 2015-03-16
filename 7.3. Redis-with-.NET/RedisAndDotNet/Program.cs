namespace RedisAndDotNet
{
    using System;
    using System.Linq;

    using Extensions;

    using ServiceStack.Redis;

    public class Program
    {
        public static void Main()
        {
            var redis = new RedisClient();
            using (redis)
            {
                var redisTodos = redis.As<Log>();
                redisTodos.Store(new Log()
                {
                    Id = redisTodos.GetNextSequence(),
                    Text = "Log crated on " + DateTime.Now,
                    LogDate = DateTime.Now
                });

                redisTodos.GetAll()
                    .Select(l => string.Format("[{0}] {1}", l.LogDate, l.Text))
                    .Print();
            }
        }
    }
}
