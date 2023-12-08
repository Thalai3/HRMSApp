using HRMS.Models;
namespace HRMS.DataAccess.Repository.IRepository
{
    public interface IRoleRepo:IRepository<RoleMaster>
    {
        void Update(RoleMaster role);
    }
}
