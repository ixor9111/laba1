using System;

namespace laba1.Models
{
    public class Employee
    {

        public Employee ()
        {

        }

        public int EmployeeID { get; set; }

        public string Name { get; set; }

        public DateTime Birth { get; set; }

        public string Role { get; set; }

        public string Salary { get; set; }

        public int PhotoID { get; set; }

        public int DepartmentID  { get; set; }



        public virtual File File { get; set; }

        public virtual Department Department { get; set; }



    }
}
