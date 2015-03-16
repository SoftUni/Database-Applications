namespace DemoModels
{
    using Newtonsoft.Json;

    public class User
    {
        private static int lastUserId;

        public User()
            : this(string.Empty, string.Empty)
        {
        }

        public User(string username, string password)
        {
            this.Id = ++lastUserId;
            this.Username = username;
            this.Password = password;
        }

        static User()
        {
            lastUserId = 0;
        }


        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonIgnore]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
