using Microsoft.AspNetCore.Mvc.Rendering;


namespace HRMS.Models.ViewModels
{
    public class SalaryStructureVM
    {
        public User user { get; set; }
        public List<SalaryStructure> structure { get; set; }
        //public PayElementMaster PayElementId { get; set; }
    }
}
