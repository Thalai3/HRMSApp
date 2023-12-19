using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DataAccess.Repository.IRepository
{
    public interface ILeavePolicyRepo:IRepository<LeavePolicy>
    {
        void Update(LeavePolicy entity);
    }
}
