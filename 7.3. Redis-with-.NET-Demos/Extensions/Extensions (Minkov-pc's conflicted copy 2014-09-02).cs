using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
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
    }
}
