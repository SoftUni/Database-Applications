namespace ControllingTheParsing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DemoModels;
    using Extensions;
    using Newtonsoft.Json;

    public class Program
    {
        public static void Main(string[] args)
        {
            User[] users =
            {
                new User("Nakov", "123456q"),
                new User("Georgiev", "hah2314h"),
                new User("Karamfilov", "Sl0jn4Par0la")
            };

            var serializedUsers = JsonConvert.SerializeObject(users, Formatting.Indented);
            Console.WriteLine(serializedUsers);

            var jsonUsers = @"
            [
              {
                'username': 'Georgiev',
                'password': '123456q'
              },
            ]";
            var deserializedUsers = JsonConvert.DeserializeObject<IEnumerable<User>>(jsonUsers);           

            deserializedUsers
                .Select(user => string.Format("Id: {0}, Username: {1}, Password: {2}", user.Id, user.Username, user.Password))
                .Print();

            // var userToSend = JsonConvert.SerializeObject(user, Formatting.Indented);
            // Console.WriteLine(userToSend);
        }
    }
}