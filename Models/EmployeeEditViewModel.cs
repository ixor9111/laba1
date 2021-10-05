using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba1.Models
{
    public class EmployeeEditViewModel
    {

        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Role { get; set; }
        public string Salary { get; set; }
        public int DepartmentID { get; set; }
        public IFormFile File { get; set; }

        public virtual Department Department { get; set; }
    }
}
