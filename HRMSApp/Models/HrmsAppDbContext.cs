using Microsoft.EntityFrameworkCore;

namespace HRMSApp.Models
{
    public class HrmsAppDbContext:DbContext
    {
        public HrmsAppDbContext(DbContextOptions<HrmsAppDbContext> options):base(options) 
        {
            
        }

        public DbSet<CandidateModel> Candidates{ get; set; }

    }
}
