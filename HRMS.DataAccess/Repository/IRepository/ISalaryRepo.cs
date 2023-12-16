using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DataAccess.Repository.IRepository
{
    public interface ISalaryRepo :IRepository<PayElementMaster>
    {
        void Update(PayElementMaster pay);
    }
}
