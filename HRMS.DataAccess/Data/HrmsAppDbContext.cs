using HRMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace HRMS.DataAccess.Data
{
    public class HrmsAppDbContext : IdentityDbContext<IdentityUser>
    {
        public HrmsAppDbContext(DbContextOptions<HrmsAppDbContext> options) : base(options)
        {

        }

        public DbSet<HrmsUser> HrmsAppUsers { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Qualifications> tbl_Qualification { get; set; }
        public DbSet<Experiences> tbl_Experience { get; set; }
        public DbSet<Departments> tbl_Department { get; set; }
        public DbSet<JobRoles> tbl_JobRole { get; set; }
        public DbSet<Uploadfiles> tbl_CandidateDocument { get; set; }


        // Adding Subtable relationship using onModelCreating Class
        public DbSet<CandidateExperience> tbl_CandidateExperience { get; set; }

        public DbSet<CandidateEducation> tbl_CandidateQualification { get; set; }

        public DbSet<User> tbl_User { get; set; }

        //Leave policy and salary structure 
        public DbSet<LeavePolicy> tbl_Leavepolicy { get; set; }
        public DbSet<SalaryStructure> tbl_SalaryStructure { get; set; }


        //Master
        public DbSet<StatusMaster> tbl_StatusMaster { get; set; }
        public DbSet<RoleMaster> tbl_RoleMaster { get; set; }
        public DbSet<StateMaster> tbl_StateMaster { get; set; }
        public DbSet<CityMaster> tbl_CityMaster { get; set; }
        public DbSet<LeavePolicyMaster> tbl_LeavePolicyMaster { get; set; }
        public DbSet<PayElementMaster> tbl_PayElementMaster { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder); 

            // Define the relationship between 
            modelBuilder.Entity<Candidate>()
                .HasMany(b => b.CandidateExperience)
                .WithOne(p => p.Candidate)
                .HasForeignKey(p => p.CandidateId);

            modelBuilder.Entity<Candidate>()
               .HasMany(b => b.CandidateEducation)
               .WithOne(p => p.Candidate) 
               .HasForeignKey(p => p.CandidateId);

            modelBuilder.Entity<LeavePolicyMaster>().HasData(
                new LeavePolicyMaster
                {
                    LeavePolicyId = 1,
                    LeavePolicys = "Casual",
                    ShortName = "CL",
                    IsActive = true,
                    CreatedBy = 1,
                    ModifiedBy = 0,
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = null,
                },
                new LeavePolicyMaster
                {
                    LeavePolicyId = 2,
                    LeavePolicys = "Medical",
                    ShortName = "ML",
                    IsActive = true,
                    CreatedBy = 1,
                    ModifiedBy = 0,
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = null,
                },
                new LeavePolicyMaster
                {
                    LeavePolicyId = 3,
                    LeavePolicys = "Special Leave",
                    ShortName = "SL",
                    IsActive = false,
                    CreatedBy = 1,
                    ModifiedBy = 0,
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = null
                }
                );

            modelBuilder.Entity<PayElementMaster>().HasData(
                new PayElementMaster
                {
                    PayElementId = 1,
                    PayElements = "Basic Salary",
                    ShortName = "Basic",
                    IsActive = true,
                    CreatedBy = 1,
                    ModifiedBy = 0,
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = null,
                },
                new PayElementMaster
                {
                    PayElementId = 2,
                    PayElements = "Convaeyance Allownce",
                    ShortName = "CA",
                    IsActive = true,
                    CreatedBy = 1,
                    ModifiedBy = 0,
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = null,
                },
                new PayElementMaster
                {
                    PayElementId = 3,
                    PayElements = "House Rent Allownce",
                    ShortName = "Rent",
                    IsActive = false,
                    CreatedBy = 1,
                    ModifiedBy = 0,
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = null
                },
                new PayElementMaster
                {
                    PayElementId = 4,
                    PayElements = "Special Allownce",
                    ShortName = "Special",
                    IsActive = false,
                    CreatedBy = 1,
                    ModifiedBy = 0,
                    CreatedDateTime = DateTime.Now,
                    ModifiedDateTime = null
                }
                );

            modelBuilder.Entity<SalaryStructure>().HasData(
               new SalaryStructure
               {
                   Id=1,
                   EmployeeId ="Thlai123Dotnet",
                   PayElementId = 1,
                   TotalValue = 10000,
                   Addition = 2000,
                   Deduction = 2000,
                   IsActive = true,
                   CreatedBy = 1,
                   ModifiedBy = 0,
                   CreatedDateTime = DateTime.Now,
                   ModifiedDateTime = null,
               },
               new SalaryStructure
               {
                   Id=2,
                   EmployeeId = "Thlai123Dotnet",
                   PayElementId = 2,
                   TotalValue = 10000,
                   Addition = 2000,
                   Deduction = 2000,
                   IsActive = true,
                   CreatedBy = 1,
                   ModifiedBy = 0,
                   CreatedDateTime = DateTime.Now,
                   ModifiedDateTime = null,
               },
               new SalaryStructure
               {
                   Id =3,
                   EmployeeId = "Thlai123Dotnet",
                   PayElementId = 2,
                   TotalValue = 10000,
                   Addition = 2000,
                   Deduction = 2000,
                   IsActive = true,
                   CreatedBy = 1,
                   ModifiedBy = 0,
                   CreatedDateTime = DateTime.Now,
                   ModifiedDateTime = null,
               }              
               );
            modelBuilder.Entity<LeavePolicy>().HasData(
               new LeavePolicy
               {
                   Id = 1,
                   EmployeeId = "Thlai123Dotnet",
                   LeavePolicyId = 1,                   
                   NoOfDays = 2,
                   IsActive = true,
                   CreatedBy = 1,
                   ModifiedBy = 0,
                   CreatedDateTime = DateTime.Now,
                   ModifiedDateTime = null,
               },
               new LeavePolicy
               {
                   Id = 2,
                   EmployeeId = "Thlai123Dotnet",
                   LeavePolicyId = 2,
                   NoOfDays = 2,
                   IsActive = true,
                   CreatedBy = 1,
                   ModifiedBy = 0,
                   CreatedDateTime = DateTime.Now,
                   ModifiedDateTime = null,
               },
               new LeavePolicy
               {
                   Id = 3,
                   EmployeeId = "Thlai123Dotnet",
                   LeavePolicyId = 3,
                   NoOfDays = 2,
                   IsActive = true,
                   CreatedBy = 1,
                   ModifiedBy = 0,
                   CreatedDateTime = DateTime.Now,
                   ModifiedDateTime = null,
               }
               );
        }


    }
}
