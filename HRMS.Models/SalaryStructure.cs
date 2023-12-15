using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Models
{
    public class SalaryStructure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string? EmployeeId { get; set; }   
        
        public string? PayElementId { get; set; }
        public int? TotalValue { get; set; }
        public int? Addition { get; set; }
        public int? Deduction { get; set; }
        public int? UserType { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDateTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ModifiedDateTime { get; set; }
    }



}
