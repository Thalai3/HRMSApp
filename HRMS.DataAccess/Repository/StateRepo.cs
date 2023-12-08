using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;


namespace HRMS.DataAccess.Repository
{
    public class StateRepo : Repository<StateMaster>, IStateRepo
    {
        private readonly HrmsAppDbContext _db;
        public StateRepo(HrmsAppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(StateMaster entity)
        {
            _db.tbl_StateMaster.Update(entity);
        }

    }
    
}
