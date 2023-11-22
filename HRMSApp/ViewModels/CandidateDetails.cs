using HRMSApp.Models;

namespace HRMSApp.ViewModels
{
    public class CandidateDetails
    {
        public Candidate Candidate { get; set; }
        public List<CandidateExperience> CandidateExperience { get; set; }
        public List<CandidateEducation> CandidateEducation { get; set; }
       
    }
}
