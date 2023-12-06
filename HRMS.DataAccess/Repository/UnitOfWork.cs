using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private HrmsAppDbContext _db;
        public ICandidateRepository candidate { get; private set; }
        public IUserRepository user { get; private set; }
        public UnitOfWork(HrmsAppDbContext db)
        {
                _db = db;

            candidate = new CandidateRepository(_db); 
            user = new UserRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
