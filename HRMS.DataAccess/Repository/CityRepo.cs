using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DataAccess.Repository
{
    public class CityRepo: Repository<CityMaster>, ICityRepo
    {
        private readonly HrmsAppDbContext _db;
        public CityRepo(HrmsAppDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(CityMaster entity)
        {
            _db.tbl_CityMaster.Update(entity);
        }
    
    }
}
