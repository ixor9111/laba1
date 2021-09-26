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

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Work> Work { get; set; }
    }
}
