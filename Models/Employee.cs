using System;
using System.ComponentModel.DataAnnotations;

namespace laba1.Models
{
    public class Employee
    {
        public Employee ()
        {

        }

        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "”кажите им€")]
        public string Name { get; set; }
        [Range(typeof(DateTime), "01.01.1960", "01.01.2010", ErrorMessage = "Date should be between {1} and {2} .")]
        public DateTime Birth { get; set; }
        public string Role { get; set; }
        [RegularExpression(@"\\-+", ErrorMessage = "Error in Salary")]
        public string Salary { get; set; }
        public int DepartmentID  { get; set; }
        [Display(Name = "Profile Photo")]
        public string FilePath { get; set; }
        [Required(ErrorMessage ="”кажите адресс")]
        public string Address { get; set; }
        public virtual Department Department { get; set; }
    }
}
