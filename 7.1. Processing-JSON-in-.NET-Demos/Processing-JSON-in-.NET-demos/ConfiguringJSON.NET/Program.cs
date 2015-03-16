namespace ConfiguringJSON.NET
{
    using System;
    using DemoModels;
    using Newtonsoft.Json;

    public class Program
    {
        public static void Main(string[] args)
        {
            var place = Place.GetTestPlace();

            var jsonPlace = JsonConvert.SerializeObject(place, Formatting.Indented);
            Console.WriteLine(jsonPlace);

            var json =
                @"{
                  'firstName': 'Vladimir',
                  'lastName': 'Georgiev',
                  'jobTitle': 'Technical Trainer'
                }";

            var template = new
            {
                FirstName = string.Empty,
                Lastname = string.Empty,
                JobTitle = string.Empty
            };

            var person = JsonConvert.DeserializeAnonymousType(json, template);
            Console.WriteLine(person);
        }
    }
}
