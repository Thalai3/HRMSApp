using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DataAccess.Repository
{
    public class CandidateRepository : Repository<Candidate>,ICandidateRepository
    {
        private HrmsAppDbContext _db;
        public CandidateRepository(HrmsAppDbContext db):base(db)
        {
                _db= db;
        }

        public void Save()

        {
            _db.SaveChanges();
        }

        public void Update(Candidate obj)
        {
            _db.Candidates.Update(obj);   
        }
    }
}
