using Microsoft.AspNetCore.Mvc.Rendering;


namespace HRMS.Models.ViewModels
{
    public class SalaryStructureVM
    {
        public SalaryStructure structure { get; set; }
        public IEnumerable<SelectListItem> salarytype { get; set; }
    }
}
