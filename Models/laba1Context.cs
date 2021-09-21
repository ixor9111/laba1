using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace laba1.Models
{
    public class laba1Context : DbContext
    {
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Task> Task { get; set; }

        public laba1Context(DbContextOptions<laba1Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
