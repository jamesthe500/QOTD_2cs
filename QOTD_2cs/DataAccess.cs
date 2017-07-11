using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace QOTD_2cs
{
    
	public class AnswersDb : DbContext  
	{
	    public DbSet<Answer> Answers { get; set; }  
	}

    // this repository sits between the code as an abstration.
    public interface IRepository<T> : IDisposable
    {
        // these are the typical methods that will be needed.
        void Add(T newEntity);
        void Delete(T entity);
        T FindById(int id);
        IQueryable<T> FindAll();
        int Commit();
    }

	public class SqlRepository<T> : IRepository<T> where T : class
    {
		// a private field to store the context in
		DbContext _ctx;
		// This is the DBset we want to interact with. 
		DbSet<T> _set;

        // this constructor calls for a DbContext instead of a specific AnswersDb since it can work with any Db
		public SqlRepository(DbContext ctx)
		{
            // we set the outside variable to the incoming context
			_ctx = ctx;
			// This is handy code in that there is a method for getting the right set for the right T
			_set = _ctx.Set<T>();
		}

		public void Add(T newEntity)
		{
			_set.Add(newEntity);
		}

        public int Commit()
        {
            // returns an int- the number of records affected.
            return _ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public IQueryable<T> FindAll()
        {
            // this works because _set is a DbSet<T> that impliments IQuereyable of T
            return _set;
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
