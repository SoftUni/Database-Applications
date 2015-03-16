namespace Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    using Demo.Models;

    using ServiceStack.Text;

    public static class Extensions
    {
        public static void Print(this IEnumerable collection)
        {
            Console.WriteLine("-".Repeat(50));

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-".Repeat(50));
        }

        public static void Print<T>(this IEnumerable<T> collection)
        {
            ((IEnumerable)collection).Print();
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }

        public static void Print(this string str)
        {
            Console.WriteLine(str);
        }

        public static string Repeat(this string str, int count)
        {
            var builder = new StringBuilder(str.Length * count);
            for (int i = 0; i < count; i++)
            {
                builder.Append(str);
            }
            return builder.ToString();
        }

        public static string Serialize<T>(this T item)
        {
            return new JsonStringSerializer().SerializeToString(item);
        }

        public static T Deserialize<T>(this string json)
        {
            return new JsonStringSerializer().DeserializeFromString<T>(json);
        }

        public static string ToString(this Todo todo)
        {
            return string.Format("\"{0}\" has a deadline at {1}", todo.Text, todo.Deadline);
        }
    }
}
