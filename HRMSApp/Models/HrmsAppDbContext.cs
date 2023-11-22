﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace HRMSApp.Models
{
    public class HrmsAppDbContext:DbContext
    {
        public HrmsAppDbContext(DbContextOptions<HrmsAppDbContext> options):base(options) 
        {
            
        }

        public DbSet<Candidate> Candidates{ get; set; }
        public DbSet<Qualifications> tbl_Qualification { get; set; }
        public DbSet<Experiences> tbl_Experience { get; set; }
        public DbSet<Departments> tbl_Department { get; set; }
        public DbSet<JobRoles> tbl_JobRole { get; set; }


        // Adding Subtable relationship using onModelCreating Class
        public DbSet<CandidateExperience> tbl_CandidateExperience { get; set; }

        public DbSet<CandidateEducation> tbl_CandidateQualification { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the relationship between Blog and Post
            modelBuilder.Entity<Candidate>()
                .HasMany(b => b.CandidateExperience)
                .WithOne(p => p.Candidate)
                .HasForeignKey(p => p.CandidateId);

            modelBuilder.Entity<Candidate>()
               .HasMany(b => b.CandidateEducation)
               .WithOne(p => p.Candidate)
               .HasForeignKey(p => p.CandidateId);
        }
       
       
    }
}
