using System.Linq.Expressions;
using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;


namespace HRMS.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HrmsAppDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(HrmsAppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            //_db.Candidate == dbset;
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);  
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> qurey = dbSet;
            qurey  = qurey.Where(filter);
            return qurey.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> qurey = dbSet; 
            return qurey.ToList();
        }

        public void Remove(T entity)
        {
           dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);  

        }
    }
}
