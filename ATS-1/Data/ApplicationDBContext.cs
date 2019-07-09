using ATS_1.Models;
using Microsoft.EntityFrameworkCore;

namespace ATS_1.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options){ }
        public ApplicationDBContext () { }
        public DbSet<Applicant> Applicants { set; get; }
        public DbSet<ActivityLog> ActivityLog { set; get; }
        public DbSet<ApplicantStatusHistory> ApplicantStatusHistory { set; get; }
        

    }
}
