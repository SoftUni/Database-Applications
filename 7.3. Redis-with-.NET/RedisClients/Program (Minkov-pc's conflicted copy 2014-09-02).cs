using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Models;
using ServiceStack.Redis;
using ServiceStack.Text;
using Extensions;

namespace RedisClients
{
    static class ModelsExtensions
    {
        public static string Serialize<T>(this T item)
        {
            return new JsonStringSerializer().SerializeToString(item);
        }

        public static T Deserialize<T>(this string json)
        {
            return new JsonStringSerializer().DeserializeFromString<T>(json);
        }
    }


    class Program
    {

        static void Main()
        {
            var client = new RedisClient();

            UsingIRedisClient(client);
            UsingIRedisTypedClient(client);
        }

        private static void UsingIRedisClient(IRedisClient client)
        {
            var todosKey = "Todos";

            //if list with key "Todos" does not exists, its is dynamically created
            var todos = client.Lists[todosKey];

            long maxId;

            if (todos.Any())
            {
                //finds the current maximun Id
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
                    Name = "Doncho"
                },
                IsDone = false
            };

            //the object must be serialized into JSON to be added
            todos.Add(todo.Serialize());

            todos.Select(t => t.Deserialize<Todo>())
                 .Select(t => string.Format("\"{0}\" with deadline on {1:ddd, dd-MMM-yyyy} at {1:HH:mm}", t.Text, t.Deadline))
                 .Print();
        }

        private static void UsingIRedisTypedClient(RedisClient client)
        {
            var redisTodos = client.As<Todo>();

            //Mark all Todos, that have passed deadline, as DONE

            var passedTodos = redisTodos.GetAll()
                .Where(t => t.Deadline >= DateTime.Now)
                .ForEach(t => t.IsDone = true);

            var todo = new Todo()
            {
                Id = redisTodos.GetNextSequence(),
                Text = "Todo created at " + DateTime.Now,
                Deadline = DateTime.Now.AddDays(1),
                IsDone = false,
                AssignedTo = new User()
                {
                    Name = "Doncho"
                }
            };



        }
    }
}
