namespace BlogSystem.Data.Repositories
{
    using System.Linq;

    using BlogSystem.Models;

    public interface IUsersRepository : IRepository<User>
    {
        IQueryable<User> AllAuthors();

        IQueryable<User> AllByGender(Gender gender);

        User GetUserByUsername(string username);
    }
}
