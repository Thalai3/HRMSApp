using HRMS.Models;

namespace HRMS.DataAccess.Repository.IRepository
{
    public interface IStatusRepo:IRepository<StatusMaster>   
    {
        void Update(StatusMaster user);
    }
}
