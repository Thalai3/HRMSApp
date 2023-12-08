using HRMS.Models;
namespace HRMS.DataAccess.Repository.IRepository
{
    public interface IStateRepo: IRepository<StateMaster>
    {
        void Update(StateMaster state);
    }
    

}
