using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laba1.Models
{
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee> ();
            Works = new HashSet<Work>();
        }

        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "Write name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int HeadID { get; set; }

        [NotMapped]
        public virtual Employee Head { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Work> Works { get; set; }

    }
}