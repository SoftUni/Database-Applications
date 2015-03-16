namespace RedisClients
{
    using System;
    using System.Linq;

    using Demo.Models;

    using Extensions;

    using ServiceStack.Redis;

    public class Program
    {
        public static void Main()
        {
            var client = new RedisClient();

            // UsingIRedisClient(client);
            UsingIRedisTypedClient(client);
        }

        private static void UsingIRedisClient(IRedisClient client)
        {
            var todosKey = "Todos";

            // if list with key "Todos" does not exists, its is dynamically created
            var todos = client.Lists[todosKey];

            long maxId;

            if (todos.Any())
            {
                // finds the current maximun Id
                maxId = todos.Max(td => td.Deserialize<Todo>().Id);
            }
            else
            {
                maxId = 0;
            }

            var todo = new Todo()
            {
                Id = maxId + 1,
                Text = "Todo created at " + DateTime.Now,
                Deadline = DateTime.Now.AddDays(2),
                AssignedTo = new User()
                {
                    Name = "Nakov"
                },
                IsDone = false
            };

            // the object must be serialized into JSON to be added
            todos.Add(todo.Serialize());

            todos.Select(t => t.Deserialize<Todo>())
                 .Select(t => string.Format("\"{0}\" with deadline on {1:ddd, dd-MMM-yyyy} at {1:HH:mm}", t.Text, t.Deadline))
                 .Print();
        }

        private static void UsingIRedisTypedClient(RedisClient client)
        {
            var redisTodos = client.As<Todo>();

            // Mark all Todos, that have passed deadline, as DONE

            redisTodos.GetAll()
                      .Where(t => t.Deadline >= DateTime.Now)
                      // Extension method to execute a lambda expression for each element of a IEnumerable<T> 
                      .ForEach(t => t.IsDone = true);

            var todo = new Todo()
            {
                Id = redisTodos.GetNextSequence(),
                Text = "Todo created at " + DateTime.Now,
                Deadline = DateTime.Now.AddDays(1),
                IsDone = false,
                AssignedTo = new User()
                {
                    Name = "Nakov"
                }
            };

            redisTodos.Store(todo);
            redisTodos.GetAll()
                      .Print();
        }
    }
}