using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;


namespace HRMS.DataAccess.Repository
{
    public class StatusRepo: Repository<StatusMaster>, IStatusRepo
    {
        private readonly HrmsAppDbContext _db;
        public StatusRepo(HrmsAppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(StatusMaster entity)
        {
            _db.tbl_StatusMaster.Update(entity);
        }

    }
}
