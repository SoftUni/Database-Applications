namespace LinqToJson
{
    using System;
    using System.Linq;
    using Extensions;
    using Newtonsoft.Json.Linq;

    public class Program
    {
        public static void Main()
        {
            var json = @"
            {
              name: 'Sofia',
              places: [{
               'name': 'Pri Ivan',
               'categories': [
                 {
                   'id': 1,
                   'name': 'food'
                 },
                 {
                   'id': 2,
                   'name': 'drinks'
                 }
               ],
               'location': {
                 'latitude': 42.69751,
                 'longitude': 23.32415
               }
             },{
               'name': 'Golyamata Parjola',
               'categories': [
                 {
                   'id': 1,
                   'name': 'food'
                 },
                 {
                   'id': 3,
                   'name': 'big meat'
                 }
               ],
               'location': {
                 'latitude': 43.69751,
                 'longitude': 23.32415
               }
             },{
               'name': 'Dalbokoto dano',
               'categories': [
                 {
                   'id': 4,
                   'name': 'beer'
                 },
                 {
                   'id': 2,
                   'name': 'drinks'
                 }
               ],
               'location': {
                 'latitude': 42.1,
                 'longitude': 23.2
               }
             }]
            }";

            var jsonObj = JObject.Parse(json);

            Console.WriteLine("Places in {0}:", jsonObj["name"]);

            var index = 1;

            jsonObj["places"]
                .Select(pl => 
                    string.Format("{0}) {1} ({2})", index++, pl["name"], string.Join(", ", pl["categories"].Select(cat => cat["name"]))))
                .Print();
        }
    }
}