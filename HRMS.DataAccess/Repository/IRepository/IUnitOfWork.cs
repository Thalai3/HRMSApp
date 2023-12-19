using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {

        ICandidateRepository candidate{ get; }
        IUserRepository user { get; }
        IStatusRepo status { get; }
        IStateRepo state { get; }
        IRoleRepo role { get; }
        ICityRepo city { get; }
        IPolicyRepo policy { get; }
        ISalaryRepo salary { get; }
        ILeavePolicyRepo leavePolicy { get; }
        ISalaryStructureRepo salarystructure { get; }
        void Save();
    }
}
