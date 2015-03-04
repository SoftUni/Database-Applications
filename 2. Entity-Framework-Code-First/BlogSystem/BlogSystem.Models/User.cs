namespace BlogSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        private ICollection<Post> posts;
        private ICollection<Comment> comments;

        public User()
        {
            this.posts = new HashSet<Post>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        public UserContactInfo ContactInfo { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        } 
    }
}
