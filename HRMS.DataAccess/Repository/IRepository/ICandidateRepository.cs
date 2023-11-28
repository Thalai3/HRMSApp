using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DataAccess.Repository.IRepository
{
    public interface ICandidateRepository:IRepository<Candidate>
    {
        void Update(Candidate obj);
        void Save();      
    }

}
