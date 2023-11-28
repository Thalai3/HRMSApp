using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;

namespace HRMS.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Candidate_Name { get; set; }
        public string Gender { get; set; }
        public DateTime Date_of_Brith { get; set; }
        public string Email_Address { get; set; }
        public string Mobile { get; set; }
        public string Alternate_Mobile { get; set; }
        public string Candidate_Address { get; set; }
        public string Id_Proof { get; set; }
        public string Department { get; set; }
        public string Job_Role { get; set; }
        public string? Candidate_Id { get; set; }
        public DateTime interview_Date { get; set; }
        public string? Result { get; set; }
        public List<CandidateExperience> CandidateExperience { get; set; }
        public List<CandidateEducation> CandidateEducation { get; set; } 
        public Candidate(){}

    }   
    public class CandidateExperience
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public string Year_Of_Experience { get; set; }
        public string Current_CTC { get; set; }
        public string Expected_CTC { get; set; }
        public bool? is_Active { get; set; }

        // Foreign key
        public int? CandidateId { get; set; }
        // Navigation property
        public Candidate? Candidate { get; set; }
    }
    public class CandidateEducation
    {
        public int Id { get; set; }
        public string Education { get; set; }
        public string Year_Of_Passing { get; set; }
        public string _Percentage { get; set; }
        public bool? is_Active { get; set; }

        // Foreign key
        public int? CandidateId { get; set; }
        // Navigation property
        public Candidate? Candidate { get; set; }
    }
    public class Qualifications
    { 
        public int Id { get; set; }
        public string Qualification { get; set; }
        public string year_Of_Passing { get; set; }
        public string Percentage { get; set; }
    }
    public class Experiences
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string Experience  { get; set; }
        public string CTC { get; set; }
    }
    public class Departments
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public bool Is_Active { get; set; }
    }
    public class JobRoles
    {
        public int Id { get; set; }
        public string JobRole { get; set; }
        public bool Is_Active { get; set; }
    }
    public class Login
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class Uploadfiles
    {
        public int Id { get; set; }
        public string CandidateId { get; set; }
        public string? Upload { get; set; }
        public string? Is_Active { get; set; }

    }

}
