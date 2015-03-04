namespace BlogSystem.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        T GetById(object id);

        //// T GetById<TKey1, TKey2>(TKey1 key1, TKey2 key2);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        //// void Delete(object id);

        void Detach(T entity);
    }
}
