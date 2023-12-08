using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;

namespace HRMS.DataAccess.Repository
{
    public class RoleRepo : Repository<RoleMaster>, IRoleRepo
    {
        private readonly HrmsAppDbContext _db;
        public RoleRepo(HrmsAppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(RoleMaster entity)
        {
            _db.tbl_RoleMaster.Update(entity);
        }
    }

}
