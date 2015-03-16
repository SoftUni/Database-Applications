namespace JavaScriptSerializerFeatures
{
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    using Extensions;

    public class App
    {
        public static void Main()
        {
            var digits = new Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 },
            };

            var serializer = new JavaScriptSerializer();
            var digitsInJson = serializer.Serialize(digits);
            Console.WriteLine(digitsInJson);

            var digitsDeserialized = serializer.Deserialize<Dictionary<string, int>>(digitsInJson);
            digitsDeserialized.Print();

            var dict = new Dictionary<int, string>
            {
                { 0, "zero" },
                { 1, "one" },
                { 2, "two" }
            };

            // Exception: On serialization/deserialization of a dictionary, keys must be strings or objects.
            var dictSerialized = serializer.Serialize(dict);
        }
    }
}