using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace laba1.Models
{
    public class Department
    {

        public Department()
        {
            Employees = new HashSet<Employee> ();
            Tasks = new HashSet<Task>();
        }


        public int DepartmentID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int HeadID { get; set; }


        public virtual Employee Head { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

    }
}