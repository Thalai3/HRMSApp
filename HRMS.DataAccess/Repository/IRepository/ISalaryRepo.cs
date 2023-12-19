using HRMS.Models;


namespace HRMS.DataAccess.Repository.IRepository
{
    public interface ISalaryRepo :IRepository<PayElementMaster>
    {
        void Update(PayElementMaster pay);
    }
}
