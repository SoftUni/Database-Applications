namespace WorkingWithJSON.NET
{
    using System;
    using DemoModels;
    using Newtonsoft.Json;

    public class Program
    {
        public static void Main()
        {

            var place = Place.GetTestPlace();

            var serializedPlace = JsonConvert.SerializeObject(place);
            Console.WriteLine(serializedPlace);

            var serializedPlaceFormatted = JsonConvert.SerializeObject(place, Formatting.Indented);
            Console.WriteLine(serializedPlaceFormatted);

            var deserializedPlace = JsonConvert.DeserializeObject<Place>(serializedPlace);
            Console.WriteLine(deserializedPlace);
        }
    }
}
