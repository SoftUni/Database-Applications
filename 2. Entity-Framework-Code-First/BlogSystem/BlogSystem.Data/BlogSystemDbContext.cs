namespace BlogSystem.Data
{
    using System.Data.Entity;

    using BlogSystem.Models;

    public class BlogSystemDbContext : DbContext, IBlogSystemDbContext
    {
        public BlogSystemDbContext()
            : base("BlogSystem")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
