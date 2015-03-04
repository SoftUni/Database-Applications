using System;

namespace UsingEntityFrameworkModel
{
    public class Logger
    {
        static Logger()
        {
            SeparatorLine = new string('-', 50);
        }

        public static string SeparatorLine { get; private set; }
    
        public static void PrintQueries(object query)
        {
            Console.WriteLine(SeparatorLine);
            Console.WriteLine(query.ToString());
            Console.WriteLine(SeparatorLine);
        }
    }
}
