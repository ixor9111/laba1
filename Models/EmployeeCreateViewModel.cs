using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace laba1.Models
{
    public class EmployeeCreateViewModel
    {
        [Required(ErrorMessage = "Write name")]
        public string Name { get; set; }
        [Range(typeof(DateTime), "01.01.1960", "01.01.2010", ErrorMessage = "Date should be between {1} and {2} .")]
        public DateTime Birth { get; set; }
        public string Role { get; set; }
        [RegularExpression(@"^\d+", ErrorMessage = "Error in Salary")]
        public string Salary { get; set; }
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Write Address")]
        public string Address { get; set; }
        public IFormFile File { get; set; }
        [Required(ErrorMessage = "Write DepartmentName")]
        public string DepartmentName { get; set; }

        public virtual Department Department { get; set; }
    }
}
