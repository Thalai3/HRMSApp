using HRMS.DataAccess.Data;
using HRMS.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private HrmsAppDbContext _db;
        public ICandidateRepository candidate { get; private set; }
        public IUserRepository user { get; private set; }
        public IStatusRepo status { get; private set; }
        public IStateRepo state { get; private set; }
        public IRoleRepo role { get; private set; }
        public ICityRepo city { get; private set; }
        public IPolicyRepo policy { get; private set; }
        public ISalaryRepo salary { get; private set; }
        public ILeavePolicyRepo leavePolicy { get; }
        public ISalaryStructureRepo salarystructure { get; }

        public UnitOfWork(HrmsAppDbContext db)
        {
                _db = db;

            candidate = new CandidateRepository(_db); 
            user = new UserRepository(_db);
            status = new StatusRepo(_db);
            state = new StateRepo(_db);
            role = new RoleRepo(_db);
            city = new CityRepo(_db);
            policy = new PolicyRepo(_db);
            salary = new SalaryRepo(_db);
            leavePolicy = new LeavePoilcyRepo(_db);
            salarystructure = new SalaryStructureRepo(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
