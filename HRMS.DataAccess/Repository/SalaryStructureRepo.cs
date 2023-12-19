using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;

namespace HRMS.DataAccess.Repository
{
    public class SalaryStructureRepo : Repository<SalaryStructure>,ISalaryStructureRepo
    {
        private readonly HrmsAppDbContext _db;
        public SalaryStructureRepo(HrmsAppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(SalaryStructure entity)
        {
            _db.tbl_SalaryStructure.Update(entity);
        }
    }
}
