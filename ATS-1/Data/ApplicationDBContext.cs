using ATS_1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS_1.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options){ }
        public ApplicationDBContext () { }
        public DbSet<Applicant> Applicants { set; get; }
        public DbSet<Metadata> Metadata { set; get; }
        public DbSet<Index> Index { set; get; }

    }
}
