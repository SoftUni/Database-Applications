namespace BlogSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Runtime.Remoting;

    using BlogSystem.Models;

    public interface IBlogSystemDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Tag> Tags { get; set; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
