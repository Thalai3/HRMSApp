using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HRMS.Models
{
    public class SalaryStructure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string? EmployeeId { get; set; }   
        
        // Add Foreign Key
        public int? PayElementId { get; set; }
        [ForeignKey("PayElementId")]
        public PayElementMaster PayElementMaster { get; set; }

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
        public DateTime? ModifiedDateTime { get; set; }
    }

    public class PayElementMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PayElementId { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string? PayElements { get; set; }

        [StringLength(10, MinimumLength = 2)]
        public string? ShortName { get; set; }

        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDateTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDateTime { get; set; }
    }


}
