namespace BuiltInJsonSerializers
{
    using System;
    using System.Web.Script.Serialization;
    using DemoModels;

    public class Program
    {
        public static void Main()
        {
            var serializer = new JavaScriptSerializer();
            
            var place = Place.GetTestPlace();

            var jsonPlace = serializer.Serialize(place);

            Console.WriteLine("JSON place: ");
            Console.WriteLine(jsonPlace);
            Console.WriteLine();

            Console.WriteLine("Original place: ");
            Console.WriteLine(place);
            Console.WriteLine();

            var deserializedPlace = serializer.Deserialize<Place>(jsonPlace);
            Console.WriteLine("Deserialized place: ");
            Console.WriteLine(deserializedPlace);

            // Wrong behavior
            var deserializedCategory = serializer.Deserialize<Category>(jsonPlace);
            Console.WriteLine("Deserialized wrong category: ");
            Console.WriteLine(deserializedCategory);
        }
    }
}