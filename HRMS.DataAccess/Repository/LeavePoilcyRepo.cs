using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;

namespace HRMS.DataAccess.Repository
{
    public class LeavePoilcyRepo:Repository<LeavePolicy>,ILeavePolicyRepo
    {
        private readonly HrmsAppDbContext _db;
        public LeavePoilcyRepo(HrmsAppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(LeavePolicy entity)
        {
            _db.tbl_Leavepolicy.Update(entity);
        }
    }
}
