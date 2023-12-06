using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HRMS.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(30,MinimumLength =3)]
        public string? UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [StringLength(25,MinimumLength=3,ErrorMessage ="First Name Not More than 25 Character")]
        public string? FirstName { get;set; }

        [StringLength(25,MinimumLength =3)]
        public string? LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string? Address { get; set; }
        public string? AltAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? Mobile { get; set;}

        [DataType(DataType.PhoneNumber)]    
        public string? AltMobile { get; set;}
        public string? BloodGroup { get; set; }

        [DisplayFormat(NullDisplayText =" Null Status")]
        public string? Status { get; set; }
        public int? UserType { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDateTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ModifiedDateTime { get; set; }

    }
}
