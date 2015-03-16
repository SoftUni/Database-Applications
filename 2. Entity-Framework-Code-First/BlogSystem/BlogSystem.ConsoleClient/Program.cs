namespace BlogSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using BlogSystem.Data;
    using BlogSystem.Data.Migrations;
    using BlogSystem.Data.Repositories;
    using BlogSystem.Models;

    public class Program
    {
        public static void Main()
        {
            var db = new BlogSystemDbContext();

            var user = new User() {Id = 1};
            db.Users.Attach(user);
            db.SaveChanges();



//            data.Users.Add(new User
//            {
//                Username = "VGeorgiev",
//                Gender = Gender.Male,
//                RegistrationDate = DateTime.Now,
//                FullName = "Vladimir Georgiev",
//                Birthday = new DateTime(1876, 11, 12),
//                ContactInfo = new UserContactInfo
//                {
//                    Tweeter = "@VGeorgiew",
//                    Facebook = "VladiGeorgiev",
//                    PhoneNumber = "0888888888",
//                    Skype = "SkypeProfile"
//                }
//            });
//
//            data.SaveChanges();
//
//            var user = data.Users.All().FirstOrDefault(x => x.FullName == "Vladimir Georgiev");
//            user.FullName = "VG";
//
//            data.SaveChanges();
//
//            data.Users.Delete(user);
//            data.SaveChanges();
        }
    }
}