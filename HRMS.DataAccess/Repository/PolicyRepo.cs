using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;

namespace HRMS.DataAccess.Repository
{
    public class PolicyRepo :Repository<LeavePolicyMaster>, IPolicyRepo
    {
        private readonly HrmsAppDbContext _db;
        public PolicyRepo(HrmsAppDbContext db) : base(db)
        {
           _db = db;
        }
        public void Update(LeavePolicyMaster entity)
        {
           _db.tbl_LeavePolicyMaster.Update(entity);
        }
    
    }
}
