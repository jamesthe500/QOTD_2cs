using System;
using System.Data.Entity;
using System.Linq;

namespace QOTD_2cs
{
    
	public class AnswersDb : DbContext  
	{
	    public DbSet<Answer> Answers { get; set; }  
	}

    public interface IRepository<T> : IDisposable
    {
        void Add(T newEntity);
        void Delete(T entity);
        T FindById(int id);
        IQueryable<T> FindAll();
        int Commit();
    }

    public class SqlRepository<T> : IRepository<T> where T : class
    {
        DbContext _ctx;
        DbSet<T> _set;

    }
}
