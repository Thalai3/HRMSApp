using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;

namespace HRMS.DataAccess.Repository
{
    public class SalaryRepo :Repository<PayElementMaster>, ISalaryRepo
    {
        private readonly HrmsAppDbContext _db;
        public SalaryRepo(HrmsAppDbContext db) : base(db)
        {
           _db = db;
        }
        public void Update(PayElementMaster entity)
        {
           _db.tbl_PayElementMaster.Update(entity);
        }
    
    }
}
