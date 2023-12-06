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
    public class UserRepository : Repository<User>,IUserRepository
    {
        private readonly HrmsAppDbContext _db;
        public UserRepository(HrmsAppDbContext db):base(db)
        {
           _db = db;
        }
        public void Update(User entity)
        {
            _db.tbl_User.Update(entity);
        }

        
    }
}
