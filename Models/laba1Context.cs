using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace laba1.Models
{
    public class laba1Context : DbContext
    {
        public laba1Context()
        {
        }

        public laba1Context(DbContextOptions<laba1Context> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:servercyb.database.windows.net,1433;Initial Catalog=laba1;Persist Security Info=False;User ID=someks;Password=17aB21135kSssV1980;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Work> Work { get; set; }
    }
}
