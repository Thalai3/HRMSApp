using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class LeavePolicy
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string? EmployeeId { get; set; }
       
        //Add foreign Key
        public int? LeavePolicyId { get; set; }
        [ForeignKey("LeavePolicyId")]
        public LeavePolicyMaster LeavePolicyMaster { get; set; }

        public int? NoOfDays { get; set; }
        public int? UserType { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDateTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDateTime { get; set; }

    }

    public class LeavePolicyMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeavePolicyId { get; set; }

        [StringLength(30, MinimumLength = 3)]
        public string? LeavePolicys { get; set; }

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
